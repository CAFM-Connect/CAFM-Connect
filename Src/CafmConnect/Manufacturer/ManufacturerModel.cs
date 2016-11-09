using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafmConnect.Manufacturer
{
    public partial class CcManufacturerProduct
    {
        List<CcManufacturerProductDetail> m_attributes;
        string m_Code;
        string m_Description;
        string m_name = "temp";

        public CcManufacturerProduct(string classificationCode) : this()
        {            
            m_Code = classificationCode;
        }

        public CcManufacturerProduct()
        {
            m_attributes = new List<CcManufacturerProductDetail>();
        }

        public List<CcManufacturerProductDetail> Attributes
        {
            get
            {
                return m_attributes;
            }

            set
            {
                m_attributes = value;
            }
        }

        public string Code
        {
            get
            {
                return m_Code;
            }
            set
            {
                m_Code = value;
            }
        }

        public string Description
        {
            get
            {
                return m_Description;
            }

            set
            {
                m_Description = value;
            }
        }
        public string Name { get { return m_name; } set { m_name = value; } }
    }


    public partial class CcManufacturerProductDetail
    {
        string attributeDescription;
        string attributeName;
        string attributeUnit;
        string attributeValue;

        public CcManufacturerProductDetail()
        { }

        public string AttributeDescription
        {
            get
            {
                return attributeDescription;
            }

            set
            {
                attributeDescription = value;
            }
        }

        public string AttributeName
        {
            get
            {
                return attributeName;
            }

            set
            {
                attributeName = value;
            }
        }
        public string AttributeUnit
        {
            get
            {
                return attributeUnit;
            }

            set
            {
                attributeUnit = value;
            }
        }

        public string AttributeValue
        {
            get
            {
                return attributeValue;
            }

            set
            {
                attributeValue = value;
            }
        }
    }



}
