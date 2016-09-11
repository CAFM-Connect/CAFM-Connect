using System;
using System.IO;
using System.Reflection;

namespace CafmConnect
{
    public class Workspace
    {
        public Ifc.NET.Document Ifc4Document;

        /// <summary>
        /// Opens an IFC file and instanciates the CAFM-Connect classes
        /// </summary>
        /// <param name="filename">Path to the file to open</param>
        public void OpenFile(string filename) 

        {

        }

        /// <summary>
        /// Create a new object based on the CAFM-Connect specification
        /// </summary>
        /// <param name="filename">Path to the file to open, without the extension. if an filename with extensions will be passed, the extension will be removed and the extension .ifcxml will be automatically applied</param>
        /// <param name="author">Name of the author of the file</param>
        /// <param name="organization">Name of the organisation, that created the file</param>
        /// <param name="originatingSystem">name of the software spplication, that creates the file</param>
        /// <param name="authorization">name of the person, that has authorized the content of the file</param>
        public void CreateFile(string author, string organization, string originatingSystem, string authorization)
        { 
            // ------------------------------------------------------
            // Please work every time with the catalogue template file
            // Check the Original Source: http://katalog.cafm-connect.org/CC-Katalog/CAFM-ConnectFacilitiesViewTemplate.ifcxml
            //-------------------------------------------------------

            string tempPath = Path.GetTempPath();
            string tempName = Guid.NewGuid().ToString();
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("CafmConnect.Catalogue.CAFM-ConnectFacilitiesViewTemplate.ifcxml"))
            {
                using (var file = new FileStream(Path.Combine(tempPath, tempName), FileMode.Create, FileAccess.Write))
                {
                    resource?.CopyTo(file);
                }
            }

            Ifc4Document = Ifc.NET.Workspace.CurrentWorkspace.OpenDocument(Path.Combine(tempPath, tempName));
            Ifc4Document.PopulateIndividualUosHeader(author,organization,originatingSystem,authorization);
        }

        /// <summary>
        /// Saves the the Ifc File based on the CAFM-Connect specification
        /// </summary>
        /// <param name="filename">Path to the file to open, without the extension. if an filename with extensions will be passed, the extension will be removed and the extension .ifcxml will be automatically applied</param>
        public void SaveFile(string filename)
        {
           Ifc4Document.Workspace.SaveDocument(Path.GetFileNameWithoutExtension(filename) + "ifcxml");
        }



    }
}
