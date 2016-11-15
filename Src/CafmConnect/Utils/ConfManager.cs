using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CafmConnect.ConfigManager
{
    public class ConfManager
    {
        private System.Configuration.Configuration _config = null;
        private string _myLocation;
        private string _sConfigFile;
        private Assembly assembly;

        public ConfManager(Assembly _myAssembl)
        {
            OpenAssemblyConfiguration(_myAssembl);
        }

        public ConfManager(Assembly _myAssembl, bool open)
        {
            try
            {
                GetConfigLocationForAssembly(_myAssembl, out _myLocation, out _sConfigFile);
                if (open)
                {
                    string sTemp = GetConfigurationFilePath(_myLocation);
                    if (File.Exists(sTemp))
                    {
                        this._myLocation = sTemp;
                        this._sConfigFile = sTemp;
                        OpenMyConfig();
                    }
                    else
                    {
                        OpenAssemblyConfiguration(_myAssembl);
                    }
                }
                else
                {
                    OpenAssemblyConfiguration(_myAssembl);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public ConfManager(string DirectConfigPath, Assembly assembly)
        {
            // TODO: Complete member initialization
            this._sConfigFile = DirectConfigPath;
            this.assembly = assembly;
            OpenMyConfig();
        }

        public System.Configuration.Configuration MyConfiguration
        {
            get { return _config; }
            set { _config = value; }
        }

        public string GetValueForAppsetting(string appsetting)
        {
            string val = null;
            if(MyConfiguration != null)
            {
                val = MyConfiguration.AppSettings.Settings[appsetting].Value;
            }

            return val;
        }

        private static void GetConfigLocationForAssembly(Assembly _myAssembl, out string _myLocation, out string _sConfigFile)
        {
            _myLocation = _myAssembl.Location;
            //string _myName = _myAssembl.FullName;
            _sConfigFile = GetConfigurationFilePath(_myLocation);
        }

        private static string GetConfigurationFilePath(string _myLocation)
        {
            string _sConfigFile;
            _sConfigFile = _myLocation + ".config";
            return _sConfigFile;
        }

        private static void ShowSectionGroupCollectionInfo(ConfigurationSectionGroupCollection sectionGroups)
        {
            foreach (String groupName in sectionGroups.Keys)
            {
                ConfigurationSectionGroup sectionGroup = (ConfigurationSectionGroup)sectionGroups[groupName];
                //ShowSectionGroupInfo(sectionGroup);
                if (sectionGroup.Name == "system.web")
                {
                    //ForceDeclaration(sectionGroup, true);
                }
            }
        }

        private void OpenAssemblyConfiguration(Assembly _myAssembl)
        {
            try
            {
                GetConfigLocationForAssembly(_myAssembl, out _myLocation, out _sConfigFile);
                if (File.Exists(_sConfigFile))
                {
                    OpenMyConfig();
                }
                else
                {
                    MessageBox.Show(("File for configuration " + _sConfigFile + " not found!"));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void OpenMyConfig()
        {
            try
            {
                ExeConfigurationFileMap configFileMAP = new ExeConfigurationFileMap();
                configFileMAP.ExeConfigFilename = this._sConfigFile;

                this._config = ConfigurationManager.OpenMappedExeConfiguration(
                    configFileMAP,
                    ConfigurationUserLevel.None);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            //this._config = ConfigurationManager.OpenExeConfiguration(_myLocation);
        }
        /*
        static void ShowSectionGroupInfo(ConfigurationSectionGroup sectionGroup)
        {
            // Get the group name including the
            // parent group names.
            Console.WriteLine(getSpacer() +
                "Section Group Name: " +
                sectionGroup.Name);

            // Get the group name without including
            // the parent group names.
            Console.WriteLine(getSpacer() +
                "Section Group Name: " +
                sectionGroup.SectionGroupName);

            indentLevel++;

            Console.WriteLine(getSpacer() +
                "Type: " + sectionGroup.Type);

            Console.WriteLine(getSpacer() +
                "Is Group Required?: " +
                sectionGroup.IsDeclarationRequired);

            Console.WriteLine(getSpacer() +
                "Is Group Declared?: " +
                sectionGroup.IsDeclared);

            Console.WriteLine(getSpacer() +
                "Contained Sections:");

            indentLevel++;

            ConfigurationSectionCollection sectionCollection =
                sectionGroup.Sections;
            foreach (String sectionName in sectionCollection.Keys)
            {
                ConfigurationSection section =
                    (ConfigurationSection)sectionCollection[sectionName];
                Console.WriteLine(getSpacer() + "Section Name:"
                    + section.SectionInformation.Name);
            }

            indentLevel--;

            Console.WriteLine(getSpacer() +
                "Contained Section Groups:");

            indentLevel++;

            ConfigurationSectionGroupCollection sectionGroups =
                sectionGroup.SectionGroups;
            ShowSectionGroupCollectionInfo(sectionGroups);

            indentLevel--;
        }
         * */
    }
}