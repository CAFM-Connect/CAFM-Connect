using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafmConnect.Samples
{
    public partial class MainDLG : Form
    {
        public MainDLG()
        {
            InitializeComponent();
        }

        private void _buttonCreateManufacturerData_Click(object sender, EventArgs e)
        {
            string key = Workspace.Current.CreateCcFile("MyName", "MyCompany", "MySoftware", "MyAuthorization");

            Manufacturer.ManufacturerUtils.InitializeManufacturerFile(key, "SampleManufacturer", "SampleManufacturer description");

            // We want to add a rediator product definition to our new file
            // At first we have to get the CcManufaturerProduct, which is automatically filled with the required attibutes
            Manufacturer.CcManufacturerProduct product = Manufacturer.ManufacturerUtils.LoadProductDataTemplate(key, "423.17");

            product.Name = "Name of my product";
            // Set the description for this product
            product.Description = "Description of the radiator";

            foreach (Manufacturer.CcManufacturerProductDetail detail in product.Attributes)
            {
                // Get here the manufacturer data from the own product catalogue
                detail.AttributeValue = "My Value";
            }

            Manufacturer.ManufacturerUtils.AddManufacturerProductToFile(key, product);

            string filename = @"c:\\tmp\\MyFirstEmptyCafmConnectManufacturerFile.ifcxml";
            if (File.Exists(filename))
                File.Delete(filename);

            Workspace.Current.SaveCcFileAs(key, filename);
        }
    }
}
