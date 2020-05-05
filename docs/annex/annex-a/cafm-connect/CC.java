	public enum IfcSimplePropertyTemplateTypeEnum
	{
		P_SINGLEVALUE,
		P_ENUMERATEDVALUE,
		P_BOUNDEDVALUE,
		P_LISTVALUE,
		P_TABLEVALUE,
		P_REFERENCEVALUE,
		Q_LENGTH,
		Q_AREA,
		Q_VOLUME,
		Q_COUNT,
		Q_WEIGHT,
		Q_TIME,
	}
	

	public interface IfcDefinitionSelect
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
	

	public class IfcProject extends IfcContext
	{
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
	

	public class IfcRelAssociates extends IfcRelationship
	{
		private IfcDefinitionSelect[] RelatedObjects;
	}
	

	public class IfcRelAssociatesClassification extends IfcRelAssociates
	{
		private IfcClassificationSelect RelatingClassification;
	}
	

	public class IfcRelationship extends IfcRoot
	{
	}
	

	public class IfcRelDefines extends IfcRelationship
	{
	}
	

	public class IfcRelDefinesByProperties extends IfcRelDefines
	{
		private IfcObjectDefinition[] RelatedObjects;
		private IfcPropertySetDefinitionSelect RelatingPropertyDefinition;
	}
	

	public class IfcRoot extends IfcBase
	{
		private string GlobalId;
		private IfcOwnerHistory OwnerHistory;
		private string Name;
		private string Description;
	}
	

	public class IfcSimplePropertyTemplate extends IfcPropertyTemplate
	{
		private IfcSimplePropertyTemplateTypeEnum TemplateType;
		private string PrimaryMeasureType;
		private string SecondaryMeasureType;
		private IfcPropertyEnumeration Enumerators;
		private IfcUnit PrimaryUnit;
		private IfcUnit SecondaryUnit;
		private string Expression;
		private IfcStateEnum AccessState;
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
	

	/* IfcDate : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcTimeStamp : INTEGER (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcURIReference : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	public interface IfcClassificationReferenceSelect
	{
	}
	

	public interface IfcClassificationSelect
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
	

	/* IfcIdentifier : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcLabel : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	/* IfcText : STRING (Java does not support structures, so usage of defined types are inline for efficiency.) */
	

	public interface IfcSimpleValue
	{
	}
	

	public interface IfcValue
	{
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
	

