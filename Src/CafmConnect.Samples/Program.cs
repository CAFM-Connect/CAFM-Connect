using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ifc.NET;
using Workspace = CafmConnect.Workspace;

namespace CafmConnect.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Workspace cc = new Workspace();        
            cc.CreateCcFile( "MyName", "MyCompany", "MySoftware", "MyAuthorization");

            IfcProject ifcProject = new IfcProject {Name = "MyProject",LongName = "MyProject Description"};
            IfcSite site = new IfcSite {Name = "MySite",LongName = "MySite Description"};

            ifcProject.Sites.AddNewSite();

            string checksum = cc.Ifc4Document.Checksum.ToString();

            CcManufacturerProduct product = cc.LoadProductDataTemplate("423.17");
            product.Description = "Description of the manufacturer";

            foreach (CcManufacturerProductDetail detail in product.Attributes)
            {
                // Get here the manufacturer data from the own product catalogue
                detail.AttributeValue = "My Value";
            }

            cc.AddManufacturerProductToFile("MyManufacturerName",product);

            string filename = @"c:\\tmp\\MyFirstEmptyCafmConnectFile.xy";
            cc.SaveCcFile(filename);
        }
    }
}
