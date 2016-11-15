using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using etask.Ifc4;


namespace SimpleIfcViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tv.AfterSelect += tv_AfterSelect;
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CustomTreeNode customTreeNode = e.Node as CustomTreeNode;
            if(customTreeNode != null && customTreeNode.CcObject != null)
                pg.SelectedObjects = new object[] { customTreeNode.CcObject };
            else
                pg.SelectedObjects = new object[] { };
        }

        private void PopulateDocument(string fullName)
        {
            if (String.IsNullOrWhiteSpace(fullName))
                throw new ArgumentNullException(nameof(fullName));

            var document = Workspace.CurrentWorkspace.OpenDocument(fullName);


            tv.Nodes.Clear();

            PopulateSpatialStructure(document);

            PopulateCatalogues(document);
        }

        public class CustomTreeNode : TreeNode
        {
            public CustomTreeNode(string text, BaseObject ccObject) : base(text)
            {
                CcObject = ccObject;
            }
            public BaseObject CcObject { get; set; }
            public BaseObject CcUISubObject { get; set; }
        }

        private void PopulateSpatialStructure(Document document)
        {
            CustomTreeNode sitesNode = new CustomTreeNode("Liegenschaften", document.Project.Sites);
            tv.Nodes.Add(sitesNode);

            string name = "";
            string longName = "";

            foreach (IfcSite site in document.Project.Sites)
            {
                CustomTreeNode siteNode = new CustomTreeNode("Liegenschaft", site);
                name = String.IsNullOrEmpty(site.Name) ? "<Name>" : site.Name;
                longName = String.IsNullOrEmpty(site.LongName) ? "" : site.LongName;
                siteNode.Text = String.Format("{0} {1}", name, longName);
                sitesNode.Nodes.Add(siteNode);
                siteNode.Expand();

                foreach (IfcBuilding building in site.Buildings)
                {
                    CustomTreeNode buildingNode = new CustomTreeNode("Gebäude", building);
                    name = String.IsNullOrEmpty(building.Name) ? "<Name>" : building.Name;
                    longName = String.IsNullOrEmpty(building.LongName) ? "" : building.LongName;
                    buildingNode.Text = String.Format("{0} {1}", name, longName);
                    siteNode.Nodes.Add(buildingNode);
                    buildingNode.Expand();

                    foreach (IfcBuildingStorey buildingStorey in building.BuildingStoreys)
                    {
                        CustomTreeNode buildingStoreyNode = new CustomTreeNode("Etage", buildingStorey);
                        name = String.IsNullOrEmpty(buildingStorey.Name) ? "<Name>" : buildingStorey.Name;
                        longName = String.IsNullOrEmpty(buildingStorey.LongName) ? "" : buildingStorey.LongName;
                        buildingStoreyNode.Text = String.Format("{0} {1}", name, longName);
                        buildingNode.Nodes.Add(buildingStoreyNode);

                        foreach (IfcSpace space in buildingStorey.Spaces)
                        {
                            CustomTreeNode spaceNode = new CustomTreeNode("Raum", space);
                            name = String.IsNullOrEmpty(space.Name) ? "<Name>" : space.Name;
                            longName = String.IsNullOrEmpty(space.LongName) ? "" : space.LongName;
                            spaceNode.Text = String.Format("{0} {1}", name, longName);
                            buildingStoreyNode.Nodes.Add(spaceNode);
                        }
                    }
                }
            }
        }

        private List<IfcClassificationReference> m_IfcClassificationReferenceCollection = null;
        private Dictionary<string, IEnumerable<IfcPropertySetTemplate>> m_RelatingClassificationIdCollection = null;

        private void PopulateCatalogues(Document document)
        {
            CustomTreeNode cataloguesNode = new CustomTreeNode("Kataloge" /*RESX.DW_STRUCTURE_NODERESOURCES*/ , null);
            cataloguesNode.Expand();
            tv.Nodes.Add(cataloguesNode);

            var relatingClassificationRefs = document.IfcXmlDocument.Items.OfType<IfcRelAssociatesClassification>()
                                                        .Where(root => root.RelatedObjects.Items.Exists(item => item.Ref == document.Project.Id))
                                                        .Select(item => item.RelatingClassification.Item.Ref);

            var classifications = document.Classifications.Where(item => relatingClassificationRefs.Contains(item.Id));

            foreach (IfcClassification classification in classifications)
            {
                CustomTreeNode classificationNode = new CustomTreeNode(classification.Name, classification);
                // TODO: set node images, colors, ...
                cataloguesNode.Nodes.Add(classificationNode);

                string sid = classification.Id;
                PopulateCatalogue(classificationNode, document, sid);
            }
        }

        private void PopulateCatalogue(CustomTreeNode treeNode, Document document, string sid)
        {
            if (m_IfcClassificationReferenceCollection == null)
                m_IfcClassificationReferenceCollection = document.IfcXmlDocument.Items.OfType<IfcClassificationReference>().ToList();

            var classificationReferences = m_IfcClassificationReferenceCollection.Where(item => item.ReferencedSource != null && item.ReferencedSource.Item.Ref == sid).Select(item => item);

            foreach (var classificationReference in classificationReferences)
            {
                string nodeText = String.Format("{0} - {1}", classificationReference.Identification, classificationReference.Name);
                CustomTreeNode classificationReferenceNode = new CustomTreeNode(nodeText, classificationReference);
                // TODO: set node images, colors, ...
                treeNode.Nodes.Add(classificationReferenceNode);
                PopulateCatalogue(classificationReferenceNode, document, classificationReference.Id);
            }

            // gibt es ein propertySetTemplate zu RelatingClassification
            IEnumerable<IfcPropertySetTemplate> newPropertySetTemplates = GetIfcPropertySetTemplateCollectionRelatingClassificationId(document, sid);
            var baseObjects = new BaseObjects<IfcPropertySetTemplate>(null);
            baseObjects.AddRange(newPropertySetTemplates);
            treeNode.CcUISubObject = baseObjects;
            PopulatePropertyTemplates(treeNode, newPropertySetTemplates);
        }

        private IEnumerable<IfcPropertySetTemplate> GetIfcPropertySetTemplateCollectionRelatingClassificationId(Document document, string sid)
        {
            if (m_RelatingClassificationIdCollection == null)
            {
                m_RelatingClassificationIdCollection = new Dictionary<string, IEnumerable<IfcPropertySetTemplate>>();
                var ifcPropertySetTemplateCollection = document.IfcXmlDocument.Items.OfType<IfcPropertySetTemplate>().ToList();

                foreach (var ifcRelAssociatesClassification in document.IfcXmlDocument.Items.OfType<IfcRelAssociatesClassification>())
                {
                    if (ifcRelAssociatesClassification.RelatingClassification != null && ifcRelAssociatesClassification.RelatingClassification.Item != null)
                    {

                        string key = ifcRelAssociatesClassification.RelatingClassification.Item.Ref;
                        if (m_RelatingClassificationIdCollection.ContainsKey(key))
                        {
                            // TODO
                            // hier stimmt etwas nicht!!!
                        }
                        else
                        {
                            m_RelatingClassificationIdCollection.Add(
                                    key,
                                    ifcPropertySetTemplateCollection.Where(item => ifcRelAssociatesClassification.RelatedObjects.Items.Exists(item2 => item2.Ref == item.Id))
                                );
                        }
                    }
                }
            }

            IEnumerable<IfcPropertySetTemplate> l;
            if (m_RelatingClassificationIdCollection.TryGetValue(sid, out l))
                return l;

            return new List<IfcPropertySetTemplate>();
        }

        private void PopulatePropertyTemplates(CustomTreeNode treeNode, IEnumerable<IfcPropertySetTemplate> propertySetTemplates)
        {
            if (propertySetTemplates == null)
                return;

            foreach (var propertySetTemplate in propertySetTemplates)
            {
                if (propertySetTemplate.HasPropertyTemplates == null)
                    continue;

                foreach (var propertyTemplate in propertySetTemplate.HasPropertyTemplates.Items)
                {
                    IfcSimplePropertyTemplate simplePropertyTemplate = propertyTemplate as IfcSimplePropertyTemplate;
                    if (simplePropertyTemplate == null)
                        continue;

                    string nodeText = String.Format("{0}", simplePropertyTemplate.Name);
                    if (!String.IsNullOrEmpty(simplePropertyTemplate.PrimaryMeasureType))
                    {
                        nodeText = String.Concat(nodeText, String.Format(" [{0}]", simplePropertyTemplate.PrimaryMeasureType));
                    }

                    CustomTreeNode simplePropertyTemplateNode = new CustomTreeNode(nodeText, simplePropertyTemplate);
                    treeNode.Nodes.Add(simplePropertyTemplateNode);

                    if (simplePropertyTemplate.TemplateType == IfcSimplePropertyTemplateTypeEnum.PSinglevalue)
                    {
                        // TODO: set node images, colors, ...
                    }
                    else if (simplePropertyTemplate.TemplateType == IfcSimplePropertyTemplateTypeEnum.PEnumeratedvalue)
                    {
                        foreach (var enumItem in simplePropertyTemplate.Enumerators.EnumerationValues.Items)
                        {
                            if (enumItem is IfcLabelwrapper)
                            {
                                IfcLabelwrapper labelWrapper = enumItem as IfcLabelwrapper;

                                string enumNodeText = String.Format("{0}", labelWrapper.Value);
                                CustomTreeNode enumNode = new CustomTreeNode(enumNodeText, (IfcLabelwrapper)enumItem);
                                // TODO: set node images, colors, ...
                                simplePropertyTemplateNode.Nodes.Add(enumNode);
                            }
                        }
                        // TODO: set node images, colors, ...
                    }
                }
            }
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            var title = "Open";
            var initialDirectory = "";
            string filter = String.Format("{0} (*.ifcxml)|*.ifcxml", "CAFM Connect Datei");
            string[] allowedExtensions = new string[] { ".ifcxml" };

            string fullName;
            bool result = OpenFileDialog(
                                            title,
                                            filter,
                                            initialDirectory,
                                            allowedExtensions,
                                            out fullName
                                        );
            if (result)
            {
                PopulateDocument(fullName);
            }
        }
        public static bool OpenFileDialog(string title, string filter, string initialDirectory, string[] allowedExtensions, out string fullName)
        {
            fullName = String.Empty;
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            try
            {
                dialog.Title = title;
                dialog.Filter = filter;
                if (!String.IsNullOrEmpty(initialDirectory))
                {
                    dialog.InitialDirectory = initialDirectory;
                }
                dialog.FilterIndex = 1; //The index value of the first filter entry is 1.
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fullName = dialog.FileName;
                    if (String.IsNullOrEmpty(fullName))
                    {
                        fullName = String.Empty;
                    }
                    else
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(fullName);

                        if (!allowedExtensions.Contains(fi.Extension.ToLowerInvariant()))
                            fullName = String.Empty;

                    }
                }

                if (String.IsNullOrEmpty(fullName))
                    return false;

                return true;
            }
            catch
            {
                fullName = String.Empty;
                return false;
            }
            finally
            {
                dialog.Dispose();
            }
        }
    }
}
