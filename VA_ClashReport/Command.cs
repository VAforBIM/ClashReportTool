#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using VA_Helpers.Methods;
using VA_ClashReport; 


#endregion

namespace VA_ClashReport
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            ClashFromInfo info = new ClashFromInfo();
            using (ClashesForm cl = new ClashesForm())
            {
                cl.ShowDialog();
                info = cl.createclashinfo();
            }
            info.Create3DView(doc);
            return Result.Succeeded;
        }
    }
}
namespace VA_Helpers.Methods
{
    #region Creating a 3D view and collecting inforamtion from a form
    /// <summary>
    /// This is a clashfrom model which takes information from the form and populates the class. 
    /// </summary>
    public class ClashFromInfo
    {
        public int Itemnumber { get; set; }
        public string FilePath { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
    }

    public static class  Myutilis
    {
        /// <summary>
        /// Reads a .txt or .csv files and more, and return the content of the file in a list of strings
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>List of strings</returns>
        public static List<string> LoadFile(this string filepath)
        {
            if (!File.Exists(filepath))
            {
                return new List<string>();
            }
            return File.ReadAllLines(filepath).ToList();
        }
        /// <summary>
        /// Based on the file path, and either 1 or 2, can retrive the item 1 or item 2 elementid from<br/>
        /// the .txt clash report from Navisworks eg.<para/>
        /// ------------------<br/>
        /// Name:	Clash10<br/>
        /// Distance:	-0.268m<br/>
        /// Image Location:	<br/>
        /// Hard<br/>
        /// Item 1<br/>
        /// Element ID:	44734646<br/>
        /// Item 2<br/>
        /// Element ID:	871944<br/>
        /// ------------------<para/>
        /// The method will check where is the lines with Item 1 or item 2<br/>
        /// and collects the id from the next line.<br/>
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="itemnumber"></param>
        /// <returns>A list of int </returns>
        private static List<int> ItemElementId( string filepath, int itemnumber)
        {
            List<int> ItemIds = new List<int>();
            List<string> lines = filepath.LoadFile();
            int i = 0;
            foreach (string line in lines)
            {
                if (line.Contains("Item "+ itemnumber.ToString()))
                {
                    string [] col = lines[i+1].Split('\t');
                    string s = col[1];
                    ItemIds.Add(int.Parse(s));
                }
                i++;
            }
            return ItemIds;
        }
        /// <summary>
        /// Based on the file path, can retrive the the clash name<br/>
        /// the .txt clash report from Navisworks eg.<para/>
        /// ------------------<br/>
        /// Name:	Clash10<br/>
        /// Distance:	-0.268m<br/>
        /// Image Location:	<br/>
        /// Hard<br/>
        /// Item 1<br/>
        /// Element ID:	44734646<br/>
        /// Item 2<br/>
        /// Element ID:	871944<br/>
        /// ------------------<para/>
        /// The method will return a list of all clashes names in the document<br/>
        /// and collects the id from the next line.<br/>
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>A list of strings </returns>
        private static List<string> ClashName(string filepath)
        {
            List<string> ClashNames = new List<string>();
            List<string> lines = filepath.LoadFile();
            int i = 0;
            foreach (string line in lines)
            {
                if (line.Contains("Name"))
                {
                    string[] col = line.Split('\t');
                    ClashNames.Add(col[1]);
                }
                i++;
            }
            return ClashNames;
        }
        /// <summary>
        /// Used to check if you have multiple list that all should work together<br/>
        /// check if they all have the same count<para/>
        /// The method will return true if all list have the same count
        /// and false otherwise<br/>
        /// </summary>
        /// <param name="listcounts"></param>
        /// <returns>True or false</returns>
        public static bool ValidateMultipleListCount (params int[] listcounts)
        {
            int i = listcounts[0];
            foreach(int x in listcounts)
            {
                if (x != i)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Creates a new 3d isometric view
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="viewname"></param>
        /// <param name="viewFamilyType"></param>
        /// <returns> View 3D</returns>
        private static View3D CreatenewView(Document doc, string viewname, ViewFamilyType viewFamilyType)
        {
            View3D newview = View3D.CreateIsometric(doc, viewFamilyType.Id);
            newview.get_Parameter(BuiltInParameter.VIEW_NAME).Set(viewname);
            return newview;
        }
        /// <summary>
        /// Taking a 3D view, and an element and crop the 3d view to the element
        /// </summary>
        /// <param name="view3D"></param>
        /// <param name="e"></param>
        private static void CropToElement (View3D view3D, Element e)
        {
            BoundingBoxXYZ ElementBoundingbox = e.get_BoundingBox(null);
            BoundingBoxXYZ ViewBoundingbox = view3D.GetSectionBox();
            ViewBoundingbox.Enabled = true;
            view3D.SetSectionBox(ElementBoundingbox);
        }
        /// <summary>
        /// Create multiple 3D views,for each clash and renames the<br/>
        /// using clashinfo class, and a Revit document.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="doc"></param>
        /// <param name="viewFamilyType"></param>
        public static void Create3DView(this ClashFromInfo info, Document doc)
        {
            ViewFamilyType viewFamilyType = (from v in new FilteredElementCollector(doc).
                    OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>()
                                             where v.ViewFamily == ViewFamily.ThreeDimensional
                                             select v).First();

            List<int> ElementID = new List<int>();
            if (info.Itemnumber == 1)
            {
                ElementID = ItemElementId(info.FilePath, 1);
            }
            if (info.Itemnumber == 2)
            {
                ElementID = ItemElementId(info.FilePath, 2);
            }
            List<string> clashnames = ClashName(info.FilePath);
            ///
            int rangefrom = info.RangeFrom;
            int rangeto = info.RangeTo;
            if (rangeto == 0)
                rangeto = ElementID.Count();
            for (int i = rangefrom; i < rangeto; i++)
            {
                ElementId ClashelElementid = new ElementId(ElementID[i]);
                Element ClashElement = doc.GetElement(ClashelElementid);
                string clashname = clashnames[i];
                ICollection<ElementId> listofelementsids = new List<ElementId>();
                listofelementsids.Add(ClashelElementid);
                
                using (Transaction tr = new Transaction(doc, clashname))
                {
                    tr.Start();
                    View3D newview = CreatenewView(doc, clashname, viewFamilyType);
                    CropToElement(newview, ClashElement);
                    tr.Commit();
                }
            }
        }

    }
}
#endregion



