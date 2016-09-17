using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CafmConnect
{
    public class Workspace
    {
        public Ifc.NET.Document Ifc4Document;


        #region CREATING FILES

        /////////////////////////////////////////////////////////////////////////////////////////////
        ////////               CREATING FILES BASIC
        /////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Create a new object based on the CAFM-Connect specification
        /// </summary>
        /// <param name="filename">Path to the file to open, without the extension. if an filename with extensions will be passed, the extension will be removed and the extension .ifcxml will be automatically applied</param>
        /// <param name="author">Name of the author of the file</param>
        /// <param name="organization">Name of the organisation, that created the file</param>
        /// <param name="originatingSystem">name of the software spplication, that creates the file</param>
        /// <param name="authorization">name of the person, that has authorized the content of the file</param>
        public void CreateCcFile(string author, string organization, string originatingSystem, string authorization)
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
        public void SaveCcFile(string filename)
        {
            Ifc4Document.Workspace.SaveDocument(Path.GetFileNameWithoutExtension(filename) + "ifcxml");
        }

        #endregion

        #region CREATING FILES FOR MANUFACTURERS

        public CcManufacturerProduct LoadProductDataTemplate(string classificationCode)
        {
            CcManufacturerProduct ccProductDataTemplate = new CcManufacturerProduct(classificationCode);

            return ccProductDataTemplate;
        }

        public void AddManufacturerProductToFile(string manufacturerName, CcManufacturerProduct ccProduct)
        {

            //check if site exists, if not add the first which IFC requires


        }

        #endregion

        #region CREATING FILES FOR FACILITYMANAGERS

        public void AddSite()
        { }
        public void AddBuilding()
        { }

        public void AddObject()
        { }

        #endregion

        #region CONSUMING FILES

        /////////////////////////////////////////////////////////////////////////////////////////////
        ////////               CONSUMING FILES
        /////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Opens an IFC file and instanciates the CAFM-Connect classes
        /// </summary>
        /// <param name="filename">Path to the file to open</param>
        public void OpenFile(string filename)

        {
            Ifc.NET.Document doc = null;

            Ifc4Document = doc;
        }


        /// <summary>
        /// Creates a workspace from many source files
        /// </summary>
        /// <param name="sourceFilenames"></param>
        /// <returns></returns>
        public void OpenFiles(List<string> sourceFilenames)
        {
            Ifc.NET.Document doc = null;

            Ifc4Document = doc;
        }


        /// <summary>
        /// Search for facilities base on a classifications string
        /// </summary>
        /// <param name="classificationCode"></param>
        /// <returns></returns>
        public List<Ifc.NET.CcFacility> SearchObjects(string classificatioCode)
        {
            List<Ifc.NET.CcFacility> facs = new List<Ifc.NET.CcFacility>();

            return facs;

        }

        #endregion

    }
}
