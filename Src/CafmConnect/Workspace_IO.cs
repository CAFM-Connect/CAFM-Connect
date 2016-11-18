using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Ifc4;
using System.Threading.Tasks;

namespace CafmConnect
{
    public partial class Workspace
    {
        Dictionary<string, Ifc4.Document> m_ifc4Documents;
        static Workspace m_current = null;
        const string m_extension = ".ifcxml";

        public Workspace()
        {
            m_current = this;
            m_ifc4Documents = new Dictionary<string, Ifc4.Document>();
        }

        public Dictionary<string, Document> Documents
        {
            get
            {
                return Current.m_ifc4Documents;
            }
        }

        public static Workspace Current
        {
            get
            {
                if (m_current == null)
                    m_current = new Workspace();

                return m_current;
            }
        }

        #region Create files

        /// <summary>
        /// Create a new object based on the CAFM-Connect specification.
        /// The file will be stored to your temp dir! Make sure you call SaveCcFileAs to save it to your desired directory!
        /// </summary>
        /// <param name="author">Name of the author of the file</param>
        /// <param name="organization">Name of the organisation, that created the file</param>
        /// <param name="originatingSystem">name of the software spplication, that creates the file</param>
        /// <param name="authorization">name of the person, that has authorized the content of the file</param>
        public string CreateCcFile(string author, string organization, string originatingSystem, string authorization)
        {
            // ------------------------------------------------------
            // Please work every time with the catalogue template file
            // Check the Original Source: http://katalog.cafm-connect.org/CC-Katalog/CAFM-ConnectFacilitiesViewTemplate.ifcxml
            //-------------------------------------------------------

            string tempPath = Path.GetTempPath();
            string tempName = Guid.NewGuid().ToString();

            string tempModelFilename = Path.Combine(tempPath, tempName);
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("CafmConnect.Catalogue.CAFM-ConnectFacilitiesViewTemplate.ifcxml"))
            {
                using (var file = new FileStream(tempModelFilename, FileMode.Create, FileAccess.Write))
                {
                    resource?.CopyTo(file);
                }
            }

            if(!Current.Documents.ContainsKey(tempModelFilename))
            {
                Document doc = Ifc4.Workspace.CurrentWorkspace.OpenDocument(tempModelFilename, Ifc4.Document.IfcFileType.IfcXml);
                doc.PopulateIndividualUosHeader(author,organization,originatingSystem,authorization);
                Current.Documents.Add(tempModelFilename, doc);
            }

            return tempModelFilename;
        }
        #endregion

        #region Load files
        /// <summary>
        /// Loads the specified ifcxml file into the current workspace
        /// </summary>
        /// <param name="filename">path to existing ifcxml file without extension</param>
        public void LoadCcFile(string filename)
        {
            if (File.Exists(filename))
            {
                if (!Current.Documents.ContainsKey(filename))
                {
                    Document doc = Ifc4.Workspace.CurrentWorkspace.OpenDocument(filename, Ifc4.Document.IfcFileType.IfcXml);
                    Current.Documents.Add(filename, doc);
                }
            }
        }

        /// <summary>
        /// Loads a collection of files into the current workspace
        /// </summary>
        /// <param name="filenames">List of ifcxml files to load, without extensions</param>
        public void LoadCcFiles(List<string> filenames)
        {
            foreach (string file in filenames)
            {
                LoadCcFile(file);
            }
        }

        const string m_ManufacturerPoolLocation = "ProductsPool";
        public void LoadFromPool()
        {
            //Read pool position from configuration
            CafmConnect.ConfigManager.ConfManager man = new ConfigManager.ConfManager(System.Reflection.Assembly.GetAssembly(this.GetType()));
            string pathPool = man.GetValueForAppsetting(m_ManufacturerPoolLocation);
            if (String.IsNullOrEmpty(pathPool))
                return;

            DirectoryInfo dirpool = new DirectoryInfo(pathPool);
            if(dirpool.Exists)
            {
                FileInfo[] files = dirpool.GetFiles("*.ifcxml");

                Parallel.ForEach(files, f =>
                {
                    LoadCcFile(f.FullName);
                });
            }
        }
        #endregion

        #region Save files
        /// <summary>
        /// Saves the IfcXml file from current workspace based on the CAFM-Connect specification
        /// </summary>
        /// <param name="filename">Path to the file to open, without the extension. if an filename with extensions will be passed, the extension will be removed and the extension .ifcxml will be automatically applied</param>
        public void SaveCcFile(string filename)
        {
            if (Current.Documents.ContainsKey(filename))
            {
                Current.Documents[filename].Workspace.SaveDocument(Path.GetFileNameWithoutExtension(filename) + "ifcxml");
            }
        }

        /// <summary>
        /// Saves the IfcXml file from current workspace based on the CAFM-Connect specification to a new filename
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void SaveCcFileAs(string currentFilename, string newFilename, bool overrideFile = true)
        {
            string finalFilename = Path.Combine(Path.GetDirectoryName(newFilename), Path.GetFileNameWithoutExtension(newFilename) + m_extension);
            if (Current.Documents.ContainsKey(currentFilename))
            {
                if (File.Exists(finalFilename))
                {
                    if (overrideFile)
                        File.Delete(finalFilename);
                }
                Current.Documents[currentFilename].Workspace.SaveDocument(finalFilename);
            }
        }

        #endregion
    }
}
