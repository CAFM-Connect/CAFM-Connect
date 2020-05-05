	public interface IfcDefinitionSelect
	{
	}
	

	public interface IfcProductSelect
	{
	}
	

	public interface IfcPropertySetDefinitionSelect
	{
	}
	

	public class IfcContext extends IfcObjectDefinition
	{
		private string ObjectType;
		private string LongName;
		private string Phase;
		private IfcRepresentationContext[] RepresentationContexts;
		private IfcUnitAssignment UnitsInContext;
		private IfcRelDefinesByProperties[] IsDefinedBy;
		private IfcRelDeclares[] Declares;
	}
	

	public class IfcGroup extends IfcObject
	{
		private IfcRelAssignsToGroup[] IsGroupedBy;
	}
	

	public class IfcObject extends IfcObjectDefinition
	{
		private string ObjectType;
		private IfcRelDefinesByObject[] IsDeclaredBy;
		private IfcRelDefinesByObject[] Declares;
		private IfcRelDefinesByType[] IsTypedBy;
		private IfcRelDefinesByProperties[] IsDefinedBy;
	}
	

	public class IfcObjectDefinition extends IfcRoot
	{
		private IfcRelAssigns[] HasAssignments;
		private IfcRelNests[] Nests;
		private IfcRelNests[] IsNestedBy;
		private IfcRelDeclares[] HasContext;
		private IfcRelAggregates[] IsDecomposedBy;
		private IfcRelAggregates[] Decomposes;
		private IfcRelAssociates[] HasAssociations;
	}
	

	public class IfcProduct extends IfcObject
	{
		private IfcObjectPlacement ObjectPlacement;
		private IfcProductRepresentation Representation;
		private IfcRelAssignsToProduct[] ReferencedBy;
	}
	

	public class IfcProjectLibrary extends IfcContext
	{
	}
	

	public class IfcPropertyDefinition extends IfcRoot
	{
		private IfcRelDeclares[] HasContext;
		private IfcRelAssociates[] HasAssociations;
	}
	

	public class IfcPropertySetDefinition extends IfcPropertyDefinition
	{
		private IfcTypeObject[] DefinesType;
		private IfcRelDefinesByTemplate[] IsDefinedBy;
		private IfcRelDefinesByProperties[] DefinesOccurrence;
	}
	

	public class IfcPropertySetTemplate extends IfcPropertyTemplateDefinition
	{
		private IfcPropertySetTemplateTypeEnum TemplateType;
		private string ApplicableEntity;
		private IfcPropertyTemplate[] HasPropertyTemplates;
		private IfcRelDefinesByTemplate[] Defines;
	}
	

	public class IfcPropertyTemplate extends IfcPropertyTemplateDefinition
	{
		private IfcComplexPropertyTemplate[] PartOfComplexTemplate;
		private IfcPropertySetTemplate[] PartOfPsetTemplate;
	}
	

	public class IfcPropertyTemplateDefinition extends IfcPropertyDefinition
	{
	}
	

	public class IfcRelAssigns extends IfcRelationship
	{
		private IfcObjectDefinition[] RelatedObjects;
		private IfcObjectTypeEnum RelatedObjectsType;
	}
	

	public class IfcRelAssignsToGroup extends IfcRelAssigns
	{
		private IfcGroup RelatingGroup;
	}
	

	public class IfcRelAssignsToProduct extends IfcRelAssigns
	{
		private IfcProductSelect RelatingProduct;
	}
	

	public class IfcRelAssociates extends IfcRelationship
	{
		private IfcDefinitionSelect[] RelatedObjects;
	}
	

	public class IfcRelAssociatesClassification extends IfcRelAssociates
	{
		private IfcClassificationSelect RelatingClassification;
	}
	

	public class IfcRelAssociatesLibrary extends IfcRelAssociates
	{
		private IfcLibrarySelect RelatingLibrary;
	}
	

	public class IfcRelationship extends IfcRoot
	{
	}
	

	public class IfcRelDeclares extends IfcRelationship
	{
		private IfcContext RelatingContext;
		private IfcDefinitionSelect[] RelatedDefinitions;
	}
	

	public class IfcRelDefines extends IfcRelationship
	{
	}
	

	public class IfcRelDefinesByProperties extends IfcRelDefines
	{
		private IfcObjectDefinition[] RelatedObjects;
		private IfcPropertySetDefinitionSelect RelatingPropertyDefinition;
	}
	

	public class IfcRelDefinesByType extends IfcRelDefines
	{
		private IfcObject[] RelatedObjects;
		private IfcTypeObject RelatingType;
	}
	

	public class IfcRoot extends IfcBase
	{
		private string GlobalId;
		private IfcOwnerHistory OwnerHistory;
		private string Name;
		private string Description;
	}
	

	public class IfcTypeObject extends IfcObjectDefinition
	{
		private string ApplicableOccurrence;
		private IfcPropertySetDefinition[] HasPropertySets;
		private IfcRelDefinesByType[] Types;
	}
	

	public class IfcTypeProduct extends IfcTypeObject
	{
		private IfcRepresentationMap[] RepresentationMaps;
		private string Tag;
		private IfcRelAssignsToProduct[] ReferencedBy;
	}
	

	public class IfcRelAssociatesMaterial extends IfcRelAssociates
	{
		private IfcMaterialSelect RelatingMaterial;
	}
	

	public class IfcSystem extends IfcGroup
	{
		private IfcRelServicesBuildings[] ServicesBuildings;
	}
	

	public interface IfcActorSelect
	{
	}
	

	public class IfcOrganization extends IfcBase
	{
		private string Identification;
		private string Name;
		private string Description;
		private IfcActorRole[] Roles;
		private IfcAddress[] Addresses;
		private IfcOrganizationRelationship[] IsRelatedBy;
		private IfcOrganizationRelationship[] Relates;
		private IfcPersonAndOrganization[] Engages;
	}
	

	public class IfcPerson extends IfcBase
	{
		private string Identification;
		private string FamilyName;
		private string GivenName;
		private string[] MiddleNames;
		private string[] PrefixTitles;
		private string[] SuffixTitles;
		private IfcActorRole[] Roles;
		private IfcAddress[] Addresses;
		private IfcPersonAndOrganization[] EngagedIn;
	}
	

	public class IfcPersonAndOrganization extends IfcBase
	{
		private IfcPerson ThePerson;
		private IfcOrganization TheOrganization;
		private IfcActorRole[] Roles;
	}
	

	/* IfcTimeStamp : INTEGER (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcURIReference : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	public interface IfcClassificationSelect
	{
	}
	

	public interface IfcLibrarySelect
	{
	}
	

	public class IfcClassification extends IfcExternalInformation
	{
		private string Source;
		private string Edition;
		private string EditionDate;
		private string Name;
		private string Description;
		private string Location;
		private string[] ReferenceTokens;
		private IfcRelAssociatesClassification[] ClassificationForObjects;
		private IfcClassificationReference[] HasReferences;
	}
	

	public class IfcClassificationReference extends IfcExternalReference
	{
		private IfcClassificationReferenceSelect ReferencedSource;
		private string Description;
		private string Sort;
		private IfcRelAssociatesClassification[] ClassificationRefForObjects;
		private IfcClassificationReference[] HasReferences;
	}
	

	public class IfcExternalInformation extends IfcBase
	{
	}
	

	public class IfcExternalReference extends IfcBase
	{
		private string Location;
		private string Identification;
		private string Name;
		private IfcExternalReferenceRelationship[] ExternalReferenceForResources;
	}
	

	public class IfcLibraryInformation extends IfcExternalInformation
	{
		private string Name;
		private string Version;
		private IfcActorSelect Publisher;
		private string VersionDate;
		private string Location;
		private string Description;
		private IfcRelAssociatesLibrary[] LibraryInfoForObjects;
		private IfcLibraryReference[] HasLibraryReferences;
	}
	

	public class IfcLibraryReference extends IfcExternalReference
	{
		private string Description;
		private IfcIdentifier Language;
		private IfcLibraryInformation ReferencedLibrary;
		private IfcRelAssociatesLibrary[] LibraryRefForObjects;
	}
	

	public class IfcObjectPlacement extends IfcBase
	{
		private IfcProduct[] PlacesObject;
		private IfcLocalPlacement[] ReferencedByPlacements;
	}
	

	public interface IfcMaterialSelect
	{
	}
	

	public class IfcMaterial extends IfcMaterialDefinition
	{
		private string Name;
		private string Description;
		private string Category;
		private IfcMaterialDefinitionRepresentation[] HasRepresentation;
		private IfcMaterialRelationship[] IsRelatedWith;
		private IfcMaterialRelationship[] RelatesTo;
	}
	

	public class IfcMaterialConstituent extends IfcMaterialDefinition
	{
		private string Name;
		private string Description;
		private IfcMaterial Material;
		private IfcRatioMeasure Fraction;
		private string Category;
		private IfcMaterialConstituentSet ToMaterialConstituentSet;
	}
	

	public class IfcMaterialConstituentSet extends IfcMaterialDefinition
	{
		private string Name;
		private string Description;
		private IfcMaterialConstituent[] MaterialConstituents;
	}
	

	public class IfcMaterialDefinition extends IfcBase
	{
		private IfcRelAssociatesMaterial[] AssociatedTo;
		private IfcExternalReferenceRelationship[] HasExternalReferences;
		private IfcMaterialProperties[] HasProperties;
	}
	

	public class IfcMaterialLayer extends IfcMaterialDefinition
	{
		private IfcMaterial Material;
		private IfcLengthMeasure LayerThickness;
		private int IsVentilated;
		private string Name;
		private string Description;
		private string Category;
		private int Priority;
		private IfcMaterialLayerSet ToMaterialLayerSet;
	}
	

	public class IfcMaterialLayerSet extends IfcMaterialDefinition
	{
		private IfcMaterialLayer[] MaterialLayers;
		private string LayerSetName;
		private string Description;
		private double TotalThickness;
	}
	

	public class IfcMaterialList extends IfcBase
	{
		private IfcMaterial[] Materials;
	}
	

	public class IfcMaterialProfile extends IfcMaterialDefinition
	{
		private string Name;
		private string Description;
		private IfcMaterial Material;
		private IfcProfileDef Profile;
		private int Priority;
		private string Category;
		private IfcMaterialProfileSet ToMaterialProfileSet;
	}
	

	public class IfcMaterialProfileSet extends IfcMaterialDefinition
	{
		private string Name;
		private string Description;
		private IfcMaterialProfile[] MaterialProfiles;
		private IfcCompositeProfileDef CompositeProfile;
	}
	

	public class IfcMaterialProperties extends IfcExtendedProperties
	{
		private IfcMaterialDefinition Material;
	}
	

	public class IfcMaterialUsageDefinition extends IfcBase
	{
		private IfcRelAssociatesMaterial[] AssociatedTo;
	}
	

	/* IfcIdentifier : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcLabel : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcLengthMeasure : REAL (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcNonNegativeLengthMeasure : IfcLengthMeasure (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcText : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	public interface IfcSimpleValue
	{
	}
	

	public interface IfcValue
	{
	}
	

	public enum IfcProfileTypeEnum
	{
		CURVE,
		AREA,
	}
	

	public class IfcProfileDef extends IfcBase
	{
		private IfcProfileTypeEnum ProfileType;
		private string ProfileName;
		private IfcExternalReferenceRelationship[] HasExternalReference;
		private IfcProfileProperties[] HasProperties;
	}
	

	public class IfcExtendedProperties extends IfcPropertyAbstraction
	{
		private string Name;
		private string Description;
		private IfcProperty[] Properties;
	}
	

	public class IfcProperty extends IfcPropertyAbstraction
	{
		private string Name;
		private string Description;
		private IfcPropertySet[] PartOfPset;
		private IfcPropertyDependencyRelationship[] PropertyForDependance;
		private IfcPropertyDependencyRelationship[] PropertyDependsOn;
		private IfcComplexProperty[] PartOfComplex;
		private IfcResourceConstraintRelationship[] HasConstraints;
		private IfcResourceApprovalRelationship[] HasApprovals;
	}
	

	public class IfcPropertyAbstraction extends IfcBase
	{
		private IfcExternalReferenceRelationship[] HasExternalReferences;
	}
	

	/* IfcGloballyUniqueId : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	public class IfcApplication extends IfcBase
	{
		private IfcOrganization ApplicationDeveloper;
		private string Version;
		private string ApplicationFullName;
		private string ApplicationIdentifier;
	}
	

	public class IfcOwnerHistory extends IfcBase
	{
		private IfcPersonAndOrganization OwningUser;
		private IfcApplication OwningApplication;
		private IfcStateEnum State;
		private IfcChangeActionEnum ChangeAction;
		private int LastModifiedDate;
		private IfcPersonAndOrganization LastModifyingUser;
		private IfcApplication LastModifyingApplication;
		private int CreationDate;
	}
	

