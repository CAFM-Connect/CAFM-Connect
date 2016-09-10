using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CafmConnect
{
    public class Workspace
    {

        public Workspace()
        {

        }

        public void CreateFile(string filename)
        { 
            // ------------------------------------------------------
            // Please work every time withe the catalogue template file
            // Check the Original Source: http://katalog.cafm-connect.org/CC-Katalog/CAFM-ConnectFacilitiesViewTemplate.ifcxml
            //-------------------------------------------------------

            string tempPath = Path.GetTempPath();
            string tempName = Guid.NewGuid().ToString();
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("CafmConnect.Catalogue.CAFM-ConnectFacilitiesViewTemplate.ifcxml"))
            {
                using (var file = new FileStream(Path.Combine(tempPath, tempName), FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }

            Ifc.NET.Document ifc4Document = null;
            ifc4Document = Ifc.NET.Workspace.CurrentWorkspace.OpenDocument(Path.Combine(tempPath, tempName));
            ifc4Document.PopulateDefaultUosHeader();
            ifc4Document.PopulateIndividualUosHeader("MyName","MyCompany","MySoftware","MyAuthorization");
            ifc4Document.Workspace.SaveDocument(filename);
        }

    }
}
