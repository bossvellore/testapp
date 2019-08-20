#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace WallInfo
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        UIApplication uiApp;
        UIDocument uiDoc;
        Application app;
        Document doc;
        public List<WallData> walls = new List<WallData>();

        public UIDocument UiDoc { get => uiDoc; set => uiDoc = value; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uiApp = commandData.Application;
            uiDoc = uiApp.ActiveUIDocument;
            app = uiApp.Application;
            doc = uiDoc.Document;

            CalculateWallArea();
            WallsForm wf = new WallsForm(this);
            wf.ShowDialog();
            // Modify document within a transaction

            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("Transaction Name");
                tx.Commit();
            }

            return Result.Succeeded;
        }

        public void CalculateWallArea()
        {
            int totalWalls = 0;
            double totalArea = 0;
            foreach(Element e in GetAllWalls())
            {
                totalWalls++;
                
                var _wall = (from wall in walls
                             where wall.Type.Equals(e.Name)
                             select wall).FirstOrDefault<WallData>();

                //var result = _walls.ToList<WallData>();
                var _p=e.GetParameters("Area");
                var p = _p[0];
                totalArea = Math.Round(totalArea+p.AsDouble(),2);
                if (_wall == null )
                {
                    var temp = new WallData(e.Name, 1,  Math.Round(p.AsDouble(), 2));
                    temp.ids.Add(e.Id);
                    walls.Add(temp);
                }
                else
                {
                    walls.Remove(_wall);
                    _wall.Count++;
                    _wall.Area = Math.Round( _wall.Area+p.AsDouble(), 2);
                    _wall.ids.Add(e.Id);
                    walls.Add(_wall);
                    Debug.Print("Sdf");
                    
                }
                
            }
            walls.Add(new WallData("Total", totalWalls, Math.Round(totalArea, 2)));
            Debug.Print("walls");

        }

        public FilteredElementCollector GetAllWalls()
        {
            // Retrieve elements from database
            FilteredElementCollector col
              = new FilteredElementCollector(doc, uiDoc.ActiveView.Id)
                //.WhereElementIsNotElementType()
                //.OfCategory(BuiltInCategory.INVALID)
                .OfClass(typeof(Wall));

            // Filtered element collector is iterable
            
            //foreach (Element e in col)
            //{
            //    Debug.Print(e.Name);
            //}
            return col;
        }
    }

    public class WallData
    {
        private string type;
        private int count;
        private double area;
        public List<ElementId> ids=new List<ElementId>();

        public string Type { get => type; set => type = value; }
        public int Count { get => count; set => count = value; }
        public double Area { get => area; set => area = value; }

        public WallData(String type, int count, double area)
        {
            this.type = type;
            this.count = count;
            this.area = area;
        }
    }
}
