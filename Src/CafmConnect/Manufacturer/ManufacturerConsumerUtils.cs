using Ifc4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafmConnect.Manufacturer
{
    public static class ManufacturerConsumerUtils
    {
        public static List<CcManufacturerProduct>GetManufacturerProductsForCode(string code)
        {
            List<CcManufacturerProduct> _products = new List<CcManufacturerProduct>();

            foreach (Document doc in Workspace.Current.Documents.Values)
            {
                //get classificationreference for this code
                IfcClassificationReference classref = GetClassificationReferencesForCode(doc, code);
                if(classref != null)
                {
                    //get relation to propertysettemplate
                    IfcRelAssociatesClassification relassocclass = GetRelAssocClassification(doc, classref);
                    if(relassocclass != null)
                    {
                        List<IfcPropertySet> psets = new List<IfcPropertySet>();
                        foreach (var psettempl in relassocclass.RelatedObjects.Items)
                        {
                            //get propertysets which use the referenced psettemplate
                            if(psettempl is IfcPropertySetTemplate)
                            {
                                List<IfcPropertySet> tempset = GetPropertySetsForTemplateReference(doc, psettempl.Ref);
                                if(tempset != null)
                                    psets.AddRange(tempset);
                            }
                        }

                        _products.AddRange(GetListOfManufacturerProducts(doc, psets, code));
                    }
                }
            }

            return _products;
        }

        private static List<CcManufacturerProduct> GetListOfManufacturerProducts(Document doc, List<IfcPropertySet> psets, string code)
        {
            List<CcManufacturerProduct> lstproducts = new List<CcManufacturerProduct>();
            foreach (IfcPropertySet pset in psets)
            {
                CcManufacturerProduct prd = GetProductFromPset(doc, pset);
                if (prd != null)
                {
                    prd.Code = code;
                    prd.Attributes.AddRange(GetAttributesForProduct(doc, pset));
                    lstproducts.Add(prd);
                }
            }
            return lstproducts;
        }

        private static List<CcManufacturerProductDetail> GetAttributesForProduct(Document document, IfcPropertySet pset)
        {
            List<CcManufacturerProductDetail> details = new List<CcManufacturerProductDetail>();

            foreach (IfcProperty prop in pset.HasProperties.Items)
            {
                CcManufacturerProductDetail det = GetDetailsFromProperty(prop);
                if(det != null)
                    details.Add(det);
            }
            return details;
        }

        private static CcManufacturerProductDetail GetDetailsFromProperty(IfcProperty prop)
        {
            CcManufacturerProductDetail result = null;
            if (prop is IfcPropertySingleValue)
            {
                IfcPropertySingleValue single = prop as IfcPropertySingleValue;
                result = new CcManufacturerProductDetail() { AttributeName = single.Name };
                result.AttributeValue = GetNominalValue(single.NominalValue);
            }
            else if(prop is IfcPropertyEnumeratedValue)
            {
                IfcPropertyEnumeratedValue enumval = prop as IfcPropertyEnumeratedValue;
                result = new CcManufacturerProductDetail() { AttributeName = enumval.Name, AttributeDescription = enumval.Description };
                result.AttributeValue = GetEnumeratedValue(enumval.EnumerationValues);
            }
            else
            {
                throw new NotImplementedException();
            }

            return result;
        }

        private static string GetEnumeratedValue(IfcPropertyEnumeratedValueEnumerationValues enumerationValues)
        {
            string result = null;   
            foreach (var item in enumerationValues.Items)
            {
                if (item is IfcLabelwrapper)
                {
                    IfcLabelwrapper lb = item as IfcLabelwrapper;
                    if (lb != null)
                    {
                        result = lb.Value;
                    }
                }
            }

            return result;
        }

        private static string GetNominalValue(IfcPropertySingleValueNominalValue nominalValue)
        {
            string result = null;
            if(nominalValue.Item is IfcLabelwrapper)
            {
                IfcLabelwrapper lb = nominalValue.Item as IfcLabelwrapper;
                if(lb != null)
                {
                    result = lb.Value;
                }
            }

            return result;
        }

        private static CcManufacturerProduct GetProductFromPset(Document document, IfcPropertySet pset)
        {
            CcManufacturerProduct prd = null;

            var reldefprop = document.IfcXmlDocument.Items.OfType<IfcRelDefinesByProperties>();
            //.Where(ele => ele.RelatingPropertyDefinition.Item..RelatingTemplate.Ref == pset.Id);

            foreach (IfcRelDefinesByProperties reldef in reldefprop)
            {
                IfcPropertySet settemp = reldef.RelatingPropertyDefinition.Item as IfcPropertySet;
                if (settemp != null && settemp.Ref == pset.Id)
                {
                    var relobj = document.IfcXmlDocument.Items.OfType<IfcElement>()
                        .Where(ele => ele.Id == reldef.RelatedObjects.Ref);

                    List<IfcElement> eles = relobj.ToList();
                    if(eles != null && eles.Count > 0)
                    {
                        prd = new CcManufacturerProduct();
                        prd.Name = eles[0].Name;
                        prd.Description = eles[0].Description;
                        break;
                    }
                }
            }

            return prd;
        }

        private static List<IfcPropertySet> GetPropertySetsForTemplateReference(Document document, string refToPsetTemplate)
        {
            List<IfcPropertySet> _psets = new List<IfcPropertySet>();

            var teldeftempl = document.IfcXmlDocument.Items.OfType<IfcRelDefinesByTemplate>()
                .Where(ele => ele.RelatingTemplate.Ref == refToPsetTemplate);

            foreach (IfcRelDefinesByTemplate relDefYbTemp in teldeftempl)
            {
                foreach (IfcPropertySet pset in relDefYbTemp.RelatedPropertySets.Items)
                {
                    IfcPropertySet tempset = GetPropertySet(document, pset.Ref);
                    if(tempset != null)
                        _psets.Add(tempset);
                }
            }
            return _psets;
        }

        private static IfcPropertySet GetPropertySet(Document document, string reference)
        {
            IfcPropertySet psettemp = null;
            var pset = document.IfcXmlDocument.Items.OfType<IfcPropertySet>()
                .Where(ele => ele.Id == reference);

            List<IfcPropertySet> setlist = pset.ToList();
            if (setlist != null && setlist.Count > 0)
            {
                psettemp = setlist[0];
            }
            return psettemp;
        }

        private static IfcClassificationReference GetClassificationReferencesForCode(Document document, string classification)
        {
            IfcClassificationReference _ref = null;

            var classrefs = document.IfcXmlDocument.Items.OfType<IfcClassificationReference>()
                            .Where(ele => ele.Identification == classification);

            List<IfcClassificationReference> grp = classrefs.ToList();
            if (grp != null && grp.Count > 0)
            {
                _ref = grp[0];
            }

            return _ref;
        }

        private static IfcRelAssociatesClassification GetRelAssocClassification(Document document, IfcClassificationReference classref)
        {
            IfcRelAssociatesClassification _rel = null;
            var relassoc = document.IfcXmlDocument.Items.OfType<IfcRelAssociatesClassification>()
                .Where(ele => ele.RelatingClassification.Item.Ref == classref.Id);

            List<IfcRelAssociatesClassification> grp = relassoc.ToList();
            if (grp != null && grp.Count > 0)
            {
                _rel = grp[0];
            }
            return _rel;
        }

        /// <summary>
        /// Search for facilities based on a classification string
        /// </summary>
        /// <param name="classificationCode"></param>
        /// <returns></returns>
        private static List<Ifc4.IfcElement> SearchForProducts(string classificationCode)
        {
            List<Ifc4.IfcElement> facs = new List<Ifc4.IfcElement>();

            return facs;
        }

    }
}
