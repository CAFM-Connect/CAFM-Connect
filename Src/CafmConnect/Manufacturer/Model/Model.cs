using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafmConnect.Manufacturer.Model
{
    public class Model : IModel
    {
        public void DownloadNewData()
        {
            throw new NotImplementedException();
        }

        public List<CcManufacturerProduct> GetProductSelectionForCode(string code)
        {
            return ManufacturerConsumerUtils.GetManufacturerProductsForCode(code);
        }

        public void LoadData()
        {
            Workspace.Current.LoadFromPool();
        }
    }
}
