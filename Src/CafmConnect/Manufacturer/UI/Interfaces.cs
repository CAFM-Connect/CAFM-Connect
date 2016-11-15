using CafmConnect.Manufacturer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafmConnect.Manufacturer.UI
{
    public interface IView
    {
        void SetCode(string code);
        void SetPresenter(IPresenter pres);
        void SetData(List<CcManufacturerProduct> data);
        DialogResult ShowSelectionDLG();
        CcManufacturerProduct GetSelectedProduct();
    }

    public interface IPresenter
    {
        void StartSelection(string code);
        CcManufacturerProduct GetSelectedProduct();
    }
}
