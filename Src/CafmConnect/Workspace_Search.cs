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
        public List<Ifc4.CcFacility> SearchObjects(string classificatioCode)
        {
            List<Ifc4.CcFacility> facs = new List<Ifc4.CcFacility>();

            return facs;
        }
    }
}
