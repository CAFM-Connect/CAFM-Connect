using CafmConnect.Manufacturer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafmConnect.Manufacturer.UI
{
    public class Presenter : IPresenter
    {
        IView m_view = null;
        IModel m_model = null;

        public Presenter()
        {
            m_view = new ViewDLG();
            m_view.SetPresenter(this);

            m_model = new Model.Model();
            m_model.LoadData();
        }

        CcManufacturerProduct m_prd = null;

        public void StartSelection(string code)
        {
            m_view.SetCode(code);
            m_view.SetData(m_model.GetProductSelectionForCode(code));

            if(m_view.ShowSelectionDLG() == System.Windows.Forms.DialogResult.OK)
            {
                m_prd = m_view.GetSelectedProduct();
            }
        }

        public CcManufacturerProduct GetSelectedProduct()
        {
            return m_prd;
        }
    }
}
