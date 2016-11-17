using CafmConnect.Manufacturer.Model;
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

            Manufacturer.ManufacturerCreatorUtils.InitializeManufacturerFile(key, "SampleManufacturer", "SampleManufacturer description");

            // We want to add a rediator product definition to our new file
            // At first we have to get the CcManufaturerProduct, which is automatically filled with the required attibutes
            CcManufacturerProduct product = Manufacturer.ManufacturerCreatorUtils.LoadProductDataTemplate(key, "423.17");

            product.Name = "Name of my product";
            // Set the description for this product
            product.Description = "Description of the radiator";

            foreach (CcManufacturerProductDetail detail in product.Attributes)
            {
                // Get here the manufacturer data from the own product catalogue
                detail.AttributeValue = "My Value";
            }

            Manufacturer.ManufacturerCreatorUtils.AddManufacturerProductToFile(key, product);

            string filename = @"c:\\tmp\\MyFirstEmptyCafmConnectManufacturerFile.ifcxml";
            if (File.Exists(filename))
                File.Delete(filename);

            Workspace.Current.SaveCcFileAs(key, filename);
        }

        private void _buttonViewer_Click(object sender, EventArgs e)
        {
            SimpleIfcViewer.MainForm dlg = new SimpleIfcViewer.MainForm();
            dlg.Show();
        }

        private void _buttonTester_Click(object sender, EventArgs e)
        {
            CafmConnect.Manufacturer.UI.ViewDLG dlg = new Manufacturer.UI.ViewDLG();
            Manufacturer.UI.Presenter pr = new Manufacturer.UI.Presenter(dlg);
            pr.StartSelection("423.17");
        }
    }
}
