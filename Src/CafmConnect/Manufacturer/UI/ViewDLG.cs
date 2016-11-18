using CafmConnect.Manufacturer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafmConnect.Manufacturer.UI
{
    public partial class ViewDLG : Form, IView
    {
        private IPresenter m_presenter;

        public ViewDLG()
        {
            InitializeComponent();
        }

        public void SetCode(string code)
        {
            _textBoxCode.Text = code;
        }

        public void SetData(List<CcManufacturerProduct> data)
        {
            _dataGridViewManufacturers.DataSource = data;
        }

        public void SetPresenter(IPresenter pres)
        {
            m_presenter = pres;
        }

        public DialogResult ShowSelectionDLG()
        {
            return this.ShowDialog();
        }

        CcManufacturerProduct m_selprd = null;
        private void _dataGridViewManufacturers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dataGridViewManufacturers.SelectedRows != null)
                {
                    m_selprd = _dataGridViewManufacturers.SelectedRows[0].DataBoundItem as CcManufacturerProduct;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public CcManufacturerProduct GetSelectedProduct()
        {
            return m_selprd;
        }
    }
}
