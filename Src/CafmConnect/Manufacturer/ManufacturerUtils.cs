using Ifc.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafmConnect.Manufacturer
{
    public static class ManufacturerUtils
    {
        public static void InitializeManufacturerFile(string key, string manufacurerName, string manufacturerDescription)
        {
            IfcProject ifcProject = Workspace.Current.Documents[key].Project;
            ifcProject.Name = manufacurerName;
            ifcProject.LongName = manufacturerDescription;

            IfcSite site = ifcProject.Sites.AddNewSite();
            site.Name = manufacurerName;
            site.LongName = manufacturerDescription;
        }

        public static CcManufacturerProduct LoadProductDataTemplate(string key, string classificationCode)
        {
            CcManufacturerProduct ccProductDataTemplate = new CcManufacturerProduct(classificationCode);

            return ccProductDataTemplate;
        }

        public static void AddManufacturerProductToFile(string key, CcManufacturerProduct ccProduct)
        {

            //check if site exists, if not add the first which IFC requires


        }
    }
}
