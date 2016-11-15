using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafmConnect.Manufacturer.Model
{
    public interface IModel
    {
        void LoadData();
        List<CcManufacturerProduct> GetProductSelectionForCode(string code);
        void DownloadNewData();
    }
}
