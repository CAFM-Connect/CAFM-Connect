using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafmConnect
{
    public partial class Workspace
    {
        /// <summary>
        /// Search for facilities based on a classification string
        /// </summary>
        /// <param name="classificationCode"></param>
        /// <returns></returns>
        public List<Ifc.NET.CcFacility> SearchObjects(string classificatioCode)
        {
            List<Ifc.NET.CcFacility> facs = new List<Ifc.NET.CcFacility>();

            return facs;
        }
    }
}
