using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafmConnect
{
    public class CcManufacturerProduct
    {
        string m_Code;
        string m_Description;
        List<CcManufacturerProductDetail> m_attributes;

        public string Code
        {
            get
            {
                return m_Code;
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

        public CcManufacturerProduct(string classificationCode)

        {
            m_Code = classificationCode;
        }
    }


    public class CcManufacturerProductDetail
    {
        string attributeName;
        string attributeDescription;
        string attributeUnit;
        string attributeValue;

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
