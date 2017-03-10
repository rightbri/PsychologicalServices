﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using PsychologicalServices.Data;
using PsychologicalServices.Data.HelperClasses;
using PsychologicalServices.Data.FactoryClasses;
using PsychologicalServices.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PsychologicalServices.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'Assessment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AssessmentEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AppointmentEntity> _appointments;
		private EntityCollection<AssessmentClaimEntity> _assessmentClaims;
		private EntityCollection<AssessmentColorEntity> _assessmentColors;
		private EntityCollection<AssessmentIssueInDisputeEntity> _assessmentIssuesInDispute;
		private EntityCollection<AssessmentMedRehabEntity> _assessmentMedRehabs;
		private EntityCollection<AssessmentNoteEntity> _assessmentNotes;








		private AssessmentTypeEntity _assessmentType;
		private CompanyEntity _company;
		private ReferralSourceEntity _referralSource;
		private ReferralTypeEntity _referralType;
		private ReportStatusEntity _reportStatus;
		private UserEntity _notesWriter;
		private UserEntity _docListWriter;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AssessmentType</summary>
			public static readonly string AssessmentType = "AssessmentType";
			/// <summary>Member name Company</summary>
			public static readonly string Company = "Company";
			/// <summary>Member name ReferralSource</summary>
			public static readonly string ReferralSource = "ReferralSource";
			/// <summary>Member name ReferralType</summary>
			public static readonly string ReferralType = "ReferralType";
			/// <summary>Member name ReportStatus</summary>
			public static readonly string ReportStatus = "ReportStatus";
			/// <summary>Member name NotesWriter</summary>
			public static readonly string NotesWriter = "NotesWriter";
			/// <summary>Member name DocListWriter</summary>
			public static readonly string DocListWriter = "DocListWriter";
			/// <summary>Member name Appointments</summary>
			public static readonly string Appointments = "Appointments";
			/// <summary>Member name AssessmentClaims</summary>
			public static readonly string AssessmentClaims = "AssessmentClaims";
			/// <summary>Member name AssessmentColors</summary>
			public static readonly string AssessmentColors = "AssessmentColors";
			/// <summary>Member name AssessmentIssuesInDispute</summary>
			public static readonly string AssessmentIssuesInDispute = "AssessmentIssuesInDispute";
			/// <summary>Member name AssessmentMedRehabs</summary>
			public static readonly string AssessmentMedRehabs = "AssessmentMedRehabs";
			/// <summary>Member name AssessmentNotes</summary>
			public static readonly string AssessmentNotes = "AssessmentNotes";









		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AssessmentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AssessmentEntity():base("AssessmentEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AssessmentEntity(IEntityFields2 fields):base("AssessmentEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AssessmentEntity</param>
		public AssessmentEntity(IValidator validator):base("AssessmentEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="assessmentId">PK value for Assessment which data should be fetched into this Assessment object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AssessmentEntity(System.Int32 assessmentId):base("AssessmentEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AssessmentId = assessmentId;
		}

		/// <summary> CTor</summary>
		/// <param name="assessmentId">PK value for Assessment which data should be fetched into this Assessment object</param>
		/// <param name="validator">The custom validator object for this AssessmentEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AssessmentEntity(System.Int32 assessmentId, IValidator validator):base("AssessmentEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AssessmentId = assessmentId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AssessmentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_appointments = (EntityCollection<AppointmentEntity>)info.GetValue("_appointments", typeof(EntityCollection<AppointmentEntity>));
				_assessmentClaims = (EntityCollection<AssessmentClaimEntity>)info.GetValue("_assessmentClaims", typeof(EntityCollection<AssessmentClaimEntity>));
				_assessmentColors = (EntityCollection<AssessmentColorEntity>)info.GetValue("_assessmentColors", typeof(EntityCollection<AssessmentColorEntity>));
				_assessmentIssuesInDispute = (EntityCollection<AssessmentIssueInDisputeEntity>)info.GetValue("_assessmentIssuesInDispute", typeof(EntityCollection<AssessmentIssueInDisputeEntity>));
				_assessmentMedRehabs = (EntityCollection<AssessmentMedRehabEntity>)info.GetValue("_assessmentMedRehabs", typeof(EntityCollection<AssessmentMedRehabEntity>));
				_assessmentNotes = (EntityCollection<AssessmentNoteEntity>)info.GetValue("_assessmentNotes", typeof(EntityCollection<AssessmentNoteEntity>));








				_assessmentType = (AssessmentTypeEntity)info.GetValue("_assessmentType", typeof(AssessmentTypeEntity));
				if(_assessmentType!=null)
				{
					_assessmentType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_company = (CompanyEntity)info.GetValue("_company", typeof(CompanyEntity));
				if(_company!=null)
				{
					_company.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_referralSource = (ReferralSourceEntity)info.GetValue("_referralSource", typeof(ReferralSourceEntity));
				if(_referralSource!=null)
				{
					_referralSource.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_referralType = (ReferralTypeEntity)info.GetValue("_referralType", typeof(ReferralTypeEntity));
				if(_referralType!=null)
				{
					_referralType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_reportStatus = (ReportStatusEntity)info.GetValue("_reportStatus", typeof(ReportStatusEntity));
				if(_reportStatus!=null)
				{
					_reportStatus.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_notesWriter = (UserEntity)info.GetValue("_notesWriter", typeof(UserEntity));
				if(_notesWriter!=null)
				{
					_notesWriter.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_docListWriter = (UserEntity)info.GetValue("_docListWriter", typeof(UserEntity));
				if(_docListWriter!=null)
				{
					_docListWriter.AfterSave+=new EventHandler(OnEntityAfterSave);
				}

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((AssessmentFieldIndex)fieldIndex)
			{
				case AssessmentFieldIndex.ReferralTypeId:
					DesetupSyncReferralType(true, false);
					break;
				case AssessmentFieldIndex.ReferralSourceId:
					DesetupSyncReferralSource(true, false);
					break;
				case AssessmentFieldIndex.AssessmentTypeId:
					DesetupSyncAssessmentType(true, false);
					break;
				case AssessmentFieldIndex.CompanyId:
					DesetupSyncCompany(true, false);
					break;
				case AssessmentFieldIndex.ReportStatusId:
					DesetupSyncReportStatus(true, false);
					break;
				case AssessmentFieldIndex.DocListWriterId:
					DesetupSyncDocListWriter(true, false);
					break;
				case AssessmentFieldIndex.NotesWriterId:
					DesetupSyncNotesWriter(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
				
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{
				case "AssessmentType":
					this.AssessmentType = (AssessmentTypeEntity)entity;
					break;
				case "Company":
					this.Company = (CompanyEntity)entity;
					break;
				case "ReferralSource":
					this.ReferralSource = (ReferralSourceEntity)entity;
					break;
				case "ReferralType":
					this.ReferralType = (ReferralTypeEntity)entity;
					break;
				case "ReportStatus":
					this.ReportStatus = (ReportStatusEntity)entity;
					break;
				case "NotesWriter":
					this.NotesWriter = (UserEntity)entity;
					break;
				case "DocListWriter":
					this.DocListWriter = (UserEntity)entity;
					break;
				case "Appointments":
					this.Appointments.Add((AppointmentEntity)entity);
					break;
				case "AssessmentClaims":
					this.AssessmentClaims.Add((AssessmentClaimEntity)entity);
					break;
				case "AssessmentColors":
					this.AssessmentColors.Add((AssessmentColorEntity)entity);
					break;
				case "AssessmentIssuesInDispute":
					this.AssessmentIssuesInDispute.Add((AssessmentIssueInDisputeEntity)entity);
					break;
				case "AssessmentMedRehabs":
					this.AssessmentMedRehabs.Add((AssessmentMedRehabEntity)entity);
					break;
				case "AssessmentNotes":
					this.AssessmentNotes.Add((AssessmentNoteEntity)entity);
					break;









				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return AssessmentEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "AssessmentType":
					toReturn.Add(AssessmentEntity.Relations.AssessmentTypeEntityUsingAssessmentTypeId);
					break;
				case "Company":
					toReturn.Add(AssessmentEntity.Relations.CompanyEntityUsingCompanyId);
					break;
				case "ReferralSource":
					toReturn.Add(AssessmentEntity.Relations.ReferralSourceEntityUsingReferralSourceId);
					break;
				case "ReferralType":
					toReturn.Add(AssessmentEntity.Relations.ReferralTypeEntityUsingReferralTypeId);
					break;
				case "ReportStatus":
					toReturn.Add(AssessmentEntity.Relations.ReportStatusEntityUsingReportStatusId);
					break;
				case "NotesWriter":
					toReturn.Add(AssessmentEntity.Relations.UserEntityUsingNotesWriterId);
					break;
				case "DocListWriter":
					toReturn.Add(AssessmentEntity.Relations.UserEntityUsingDocListWriterId);
					break;
				case "Appointments":
					toReturn.Add(AssessmentEntity.Relations.AppointmentEntityUsingAssessmentId);
					break;
				case "AssessmentClaims":
					toReturn.Add(AssessmentEntity.Relations.AssessmentClaimEntityUsingAssessmentId);
					break;
				case "AssessmentColors":
					toReturn.Add(AssessmentEntity.Relations.AssessmentColorEntityUsingAssessmentId);
					break;
				case "AssessmentIssuesInDispute":
					toReturn.Add(AssessmentEntity.Relations.AssessmentIssueInDisputeEntityUsingAssessmentId);
					break;
				case "AssessmentMedRehabs":
					toReturn.Add(AssessmentEntity.Relations.AssessmentMedRehabEntityUsingAssessmentId);
					break;
				case "AssessmentNotes":
					toReturn.Add(AssessmentEntity.Relations.AssessmentNoteEntityUsingAssessmentId);
					break;









				default:

					break;				
			}
			return toReturn;
		}
#if !CF
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0+1+1+1+1+1+1+1;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));
				case "AssessmentType":
					return true;
				case "Company":
					return true;
				case "ReferralSource":
					return true;
				case "ReferralType":
					return true;
				case "ReportStatus":
					return true;
				case "NotesWriter":
					return true;
				case "DocListWriter":
					return true;

				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "AssessmentType":
					SetupSyncAssessmentType(relatedEntity);
					break;
				case "Company":
					SetupSyncCompany(relatedEntity);
					break;
				case "ReferralSource":
					SetupSyncReferralSource(relatedEntity);
					break;
				case "ReferralType":
					SetupSyncReferralType(relatedEntity);
					break;
				case "ReportStatus":
					SetupSyncReportStatus(relatedEntity);
					break;
				case "NotesWriter":
					SetupSyncNotesWriter(relatedEntity);
					break;
				case "DocListWriter":
					SetupSyncDocListWriter(relatedEntity);
					break;
				case "Appointments":
					this.Appointments.Add((AppointmentEntity)relatedEntity);
					break;
				case "AssessmentClaims":
					this.AssessmentClaims.Add((AssessmentClaimEntity)relatedEntity);
					break;
				case "AssessmentColors":
					this.AssessmentColors.Add((AssessmentColorEntity)relatedEntity);
					break;
				case "AssessmentIssuesInDispute":
					this.AssessmentIssuesInDispute.Add((AssessmentIssueInDisputeEntity)relatedEntity);
					break;
				case "AssessmentMedRehabs":
					this.AssessmentMedRehabs.Add((AssessmentMedRehabEntity)relatedEntity);
					break;
				case "AssessmentNotes":
					this.AssessmentNotes.Add((AssessmentNoteEntity)relatedEntity);
					break;

				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "AssessmentType":
					DesetupSyncAssessmentType(false, true);
					break;
				case "Company":
					DesetupSyncCompany(false, true);
					break;
				case "ReferralSource":
					DesetupSyncReferralSource(false, true);
					break;
				case "ReferralType":
					DesetupSyncReferralType(false, true);
					break;
				case "ReportStatus":
					DesetupSyncReportStatus(false, true);
					break;
				case "NotesWriter":
					DesetupSyncNotesWriter(false, true);
					break;
				case "DocListWriter":
					DesetupSyncDocListWriter(false, true);
					break;
				case "Appointments":
					base.PerformRelatedEntityRemoval(this.Appointments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AssessmentClaims":
					base.PerformRelatedEntityRemoval(this.AssessmentClaims, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AssessmentColors":
					base.PerformRelatedEntityRemoval(this.AssessmentColors, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AssessmentIssuesInDispute":
					base.PerformRelatedEntityRemoval(this.AssessmentIssuesInDispute, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AssessmentMedRehabs":
					base.PerformRelatedEntityRemoval(this.AssessmentMedRehabs, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AssessmentNotes":
					base.PerformRelatedEntityRemoval(this.AssessmentNotes, relatedEntity, signalRelatedEntityManyToOne);
					break;

				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_assessmentType!=null)
			{
				toReturn.Add(_assessmentType);
			}
			if(_company!=null)
			{
				toReturn.Add(_company);
			}
			if(_referralSource!=null)
			{
				toReturn.Add(_referralSource);
			}
			if(_referralType!=null)
			{
				toReturn.Add(_referralType);
			}
			if(_reportStatus!=null)
			{
				toReturn.Add(_reportStatus);
			}
			if(_notesWriter!=null)
			{
				toReturn.Add(_notesWriter);
			}
			if(_docListWriter!=null)
			{
				toReturn.Add(_docListWriter);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Appointments);
			toReturn.Add(this.AssessmentClaims);
			toReturn.Add(this.AssessmentColors);
			toReturn.Add(this.AssessmentIssuesInDispute);
			toReturn.Add(this.AssessmentMedRehabs);
			toReturn.Add(this.AssessmentNotes);

			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_appointments", ((_appointments!=null) && (_appointments.Count>0) && !this.MarkedForDeletion)?_appointments:null);
				info.AddValue("_assessmentClaims", ((_assessmentClaims!=null) && (_assessmentClaims.Count>0) && !this.MarkedForDeletion)?_assessmentClaims:null);
				info.AddValue("_assessmentColors", ((_assessmentColors!=null) && (_assessmentColors.Count>0) && !this.MarkedForDeletion)?_assessmentColors:null);
				info.AddValue("_assessmentIssuesInDispute", ((_assessmentIssuesInDispute!=null) && (_assessmentIssuesInDispute.Count>0) && !this.MarkedForDeletion)?_assessmentIssuesInDispute:null);
				info.AddValue("_assessmentMedRehabs", ((_assessmentMedRehabs!=null) && (_assessmentMedRehabs.Count>0) && !this.MarkedForDeletion)?_assessmentMedRehabs:null);
				info.AddValue("_assessmentNotes", ((_assessmentNotes!=null) && (_assessmentNotes.Count>0) && !this.MarkedForDeletion)?_assessmentNotes:null);








				info.AddValue("_assessmentType", (!this.MarkedForDeletion?_assessmentType:null));
				info.AddValue("_company", (!this.MarkedForDeletion?_company:null));
				info.AddValue("_referralSource", (!this.MarkedForDeletion?_referralSource:null));
				info.AddValue("_referralType", (!this.MarkedForDeletion?_referralType:null));
				info.AddValue("_reportStatus", (!this.MarkedForDeletion?_reportStatus:null));
				info.AddValue("_notesWriter", (!this.MarkedForDeletion?_notesWriter:null));
				info.AddValue("_docListWriter", (!this.MarkedForDeletion?_docListWriter:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AssessmentFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AssessmentFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AssessmentRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Appointment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAppointments()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AppointmentFields.AssessmentId, null, ComparisonOperator.Equal, this.AssessmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentClaim' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentClaims()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentClaimFields.AssessmentId, null, ComparisonOperator.Equal, this.AssessmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentColor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentColors()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentColorFields.AssessmentId, null, ComparisonOperator.Equal, this.AssessmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentIssueInDispute' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentIssuesInDispute()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentIssueInDisputeFields.AssessmentId, null, ComparisonOperator.Equal, this.AssessmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentMedRehab' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentMedRehabs()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentMedRehabFields.AssessmentId, null, ComparisonOperator.Equal, this.AssessmentId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AssessmentNote' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentNoteFields.AssessmentId, null, ComparisonOperator.Equal, this.AssessmentId));
			return bucket;
		}









		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'AssessmentType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAssessmentType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AssessmentTypeFields.AssessmentTypeId, null, ComparisonOperator.Equal, this.AssessmentTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Company' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCompany()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CompanyFields.CompanyId, null, ComparisonOperator.Equal, this.CompanyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ReferralSource' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralSource()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralSourceFields.ReferralSourceId, null, ComparisonOperator.Equal, this.ReferralSourceId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ReferralType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReferralType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReferralTypeFields.ReferralTypeId, null, ComparisonOperator.Equal, this.ReferralTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ReportStatus' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReportStatus()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ReportStatusFields.ReportStatusId, null, ComparisonOperator.Equal, this.ReportStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesWriter()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.NotesWriterId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'User' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDocListWriter()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserId, null, ComparisonOperator.Equal, this.DocListWriterId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(PsychologicalServices.Data.EntityType.AssessmentEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(AssessmentEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._appointments);
			collectionsQueue.Enqueue(this._assessmentClaims);
			collectionsQueue.Enqueue(this._assessmentColors);
			collectionsQueue.Enqueue(this._assessmentIssuesInDispute);
			collectionsQueue.Enqueue(this._assessmentMedRehabs);
			collectionsQueue.Enqueue(this._assessmentNotes);








		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._appointments = (EntityCollection<AppointmentEntity>) collectionsQueue.Dequeue();
			this._assessmentClaims = (EntityCollection<AssessmentClaimEntity>) collectionsQueue.Dequeue();
			this._assessmentColors = (EntityCollection<AssessmentColorEntity>) collectionsQueue.Dequeue();
			this._assessmentIssuesInDispute = (EntityCollection<AssessmentIssueInDisputeEntity>) collectionsQueue.Dequeue();
			this._assessmentMedRehabs = (EntityCollection<AssessmentMedRehabEntity>) collectionsQueue.Dequeue();
			this._assessmentNotes = (EntityCollection<AssessmentNoteEntity>) collectionsQueue.Dequeue();








		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._appointments != null)
			{
				return true;
			}
			if (this._assessmentClaims != null)
			{
				return true;
			}
			if (this._assessmentColors != null)
			{
				return true;
			}
			if (this._assessmentIssuesInDispute != null)
			{
				return true;
			}
			if (this._assessmentMedRehabs != null)
			{
				return true;
			}
			if (this._assessmentNotes != null)
			{
				return true;
			}








			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentClaimEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentClaimEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentColorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentColorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentIssueInDisputeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentIssueInDisputeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentMedRehabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentMedRehabEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AssessmentNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentNoteEntityFactory))) : null);








		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AssessmentType", _assessmentType);
			toReturn.Add("Company", _company);
			toReturn.Add("ReferralSource", _referralSource);
			toReturn.Add("ReferralType", _referralType);
			toReturn.Add("ReportStatus", _reportStatus);
			toReturn.Add("NotesWriter", _notesWriter);
			toReturn.Add("DocListWriter", _docListWriter);
			toReturn.Add("Appointments", _appointments);
			toReturn.Add("AssessmentClaims", _assessmentClaims);
			toReturn.Add("AssessmentColors", _assessmentColors);
			toReturn.Add("AssessmentIssuesInDispute", _assessmentIssuesInDispute);
			toReturn.Add("AssessmentMedRehabs", _assessmentMedRehabs);
			toReturn.Add("AssessmentNotes", _assessmentNotes);









			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_appointments!=null)
			{
				_appointments.ActiveContext = base.ActiveContext;
			}
			if(_assessmentClaims!=null)
			{
				_assessmentClaims.ActiveContext = base.ActiveContext;
			}
			if(_assessmentColors!=null)
			{
				_assessmentColors.ActiveContext = base.ActiveContext;
			}
			if(_assessmentIssuesInDispute!=null)
			{
				_assessmentIssuesInDispute.ActiveContext = base.ActiveContext;
			}
			if(_assessmentMedRehabs!=null)
			{
				_assessmentMedRehabs.ActiveContext = base.ActiveContext;
			}
			if(_assessmentNotes!=null)
			{
				_assessmentNotes.ActiveContext = base.ActiveContext;
			}








			if(_assessmentType!=null)
			{
				_assessmentType.ActiveContext = base.ActiveContext;
			}
			if(_company!=null)
			{
				_company.ActiveContext = base.ActiveContext;
			}
			if(_referralSource!=null)
			{
				_referralSource.ActiveContext = base.ActiveContext;
			}
			if(_referralType!=null)
			{
				_referralType.ActiveContext = base.ActiveContext;
			}
			if(_reportStatus!=null)
			{
				_reportStatus.ActiveContext = base.ActiveContext;
			}
			if(_notesWriter!=null)
			{
				_notesWriter.ActiveContext = base.ActiveContext;
			}
			if(_docListWriter!=null)
			{
				_docListWriter.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_appointments = null;
			_assessmentClaims = null;
			_assessmentColors = null;
			_assessmentIssuesInDispute = null;
			_assessmentMedRehabs = null;
			_assessmentNotes = null;








			_assessmentType = null;
			_company = null;
			_referralSource = null;
			_referralType = null;
			_reportStatus = null;
			_notesWriter = null;
			_docListWriter = null;

			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AssessmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReferralTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReferralSourceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AssessmentTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Deleted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CompanyId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReportStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FileSize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReferralSourceContactEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DocListWriterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotesWriterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MedicalFileReceivedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Psychiatrist", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypicalDay", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WorkHistory", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _assessmentType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAssessmentType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _assessmentType, new PropertyChangedEventHandler( OnAssessmentTypePropertyChanged ), "AssessmentType", AssessmentEntity.Relations.AssessmentTypeEntityUsingAssessmentTypeId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AssessmentFieldIndex.AssessmentTypeId } );		
			_assessmentType = null;
		}

		/// <summary> setups the sync logic for member _assessmentType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAssessmentType(IEntity2 relatedEntity)
		{
			if(_assessmentType!=relatedEntity)
			{
				DesetupSyncAssessmentType(true, true);
				_assessmentType = (AssessmentTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _assessmentType, new PropertyChangedEventHandler( OnAssessmentTypePropertyChanged ), "AssessmentType", AssessmentEntity.Relations.AssessmentTypeEntityUsingAssessmentTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAssessmentTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _company</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCompany(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _company, new PropertyChangedEventHandler( OnCompanyPropertyChanged ), "Company", AssessmentEntity.Relations.CompanyEntityUsingCompanyId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AssessmentFieldIndex.CompanyId } );		
			_company = null;
		}

		/// <summary> setups the sync logic for member _company</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCompany(IEntity2 relatedEntity)
		{
			if(_company!=relatedEntity)
			{
				DesetupSyncCompany(true, true);
				_company = (CompanyEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _company, new PropertyChangedEventHandler( OnCompanyPropertyChanged ), "Company", AssessmentEntity.Relations.CompanyEntityUsingCompanyId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCompanyPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _referralSource</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncReferralSource(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _referralSource, new PropertyChangedEventHandler( OnReferralSourcePropertyChanged ), "ReferralSource", AssessmentEntity.Relations.ReferralSourceEntityUsingReferralSourceId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AssessmentFieldIndex.ReferralSourceId } );		
			_referralSource = null;
		}

		/// <summary> setups the sync logic for member _referralSource</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReferralSource(IEntity2 relatedEntity)
		{
			if(_referralSource!=relatedEntity)
			{
				DesetupSyncReferralSource(true, true);
				_referralSource = (ReferralSourceEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _referralSource, new PropertyChangedEventHandler( OnReferralSourcePropertyChanged ), "ReferralSource", AssessmentEntity.Relations.ReferralSourceEntityUsingReferralSourceId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReferralSourcePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _referralType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncReferralType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _referralType, new PropertyChangedEventHandler( OnReferralTypePropertyChanged ), "ReferralType", AssessmentEntity.Relations.ReferralTypeEntityUsingReferralTypeId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AssessmentFieldIndex.ReferralTypeId } );		
			_referralType = null;
		}

		/// <summary> setups the sync logic for member _referralType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReferralType(IEntity2 relatedEntity)
		{
			if(_referralType!=relatedEntity)
			{
				DesetupSyncReferralType(true, true);
				_referralType = (ReferralTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _referralType, new PropertyChangedEventHandler( OnReferralTypePropertyChanged ), "ReferralType", AssessmentEntity.Relations.ReferralTypeEntityUsingReferralTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReferralTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _reportStatus</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncReportStatus(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _reportStatus, new PropertyChangedEventHandler( OnReportStatusPropertyChanged ), "ReportStatus", AssessmentEntity.Relations.ReportStatusEntityUsingReportStatusId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AssessmentFieldIndex.ReportStatusId } );		
			_reportStatus = null;
		}

		/// <summary> setups the sync logic for member _reportStatus</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncReportStatus(IEntity2 relatedEntity)
		{
			if(_reportStatus!=relatedEntity)
			{
				DesetupSyncReportStatus(true, true);
				_reportStatus = (ReportStatusEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _reportStatus, new PropertyChangedEventHandler( OnReportStatusPropertyChanged ), "ReportStatus", AssessmentEntity.Relations.ReportStatusEntityUsingReportStatusId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnReportStatusPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _notesWriter</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNotesWriter(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _notesWriter, new PropertyChangedEventHandler( OnNotesWriterPropertyChanged ), "NotesWriter", AssessmentEntity.Relations.UserEntityUsingNotesWriterId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AssessmentFieldIndex.NotesWriterId } );		
			_notesWriter = null;
		}

		/// <summary> setups the sync logic for member _notesWriter</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNotesWriter(IEntity2 relatedEntity)
		{
			if(_notesWriter!=relatedEntity)
			{
				DesetupSyncNotesWriter(true, true);
				_notesWriter = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _notesWriter, new PropertyChangedEventHandler( OnNotesWriterPropertyChanged ), "NotesWriter", AssessmentEntity.Relations.UserEntityUsingNotesWriterId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotesWriterPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _docListWriter</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDocListWriter(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _docListWriter, new PropertyChangedEventHandler( OnDocListWriterPropertyChanged ), "DocListWriter", AssessmentEntity.Relations.UserEntityUsingDocListWriterId, true, signalRelatedEntity, "", resetFKFields, new int[] { (int)AssessmentFieldIndex.DocListWriterId } );		
			_docListWriter = null;
		}

		/// <summary> setups the sync logic for member _docListWriter</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDocListWriter(IEntity2 relatedEntity)
		{
			if(_docListWriter!=relatedEntity)
			{
				DesetupSyncDocListWriter(true, true);
				_docListWriter = (UserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _docListWriter, new PropertyChangedEventHandler( OnDocListWriterPropertyChanged ), "DocListWriter", AssessmentEntity.Relations.UserEntityUsingDocListWriterId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDocListWriterPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AssessmentEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AssessmentRelations Relations
		{
			get	{ return new AssessmentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Appointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAppointments
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("Appointments")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.AppointmentEntity, 0, null, null, null, null, "Appointments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentClaim' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentClaims
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentClaimEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentClaimEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentClaims")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.AssessmentClaimEntity, 0, null, null, null, null, "AssessmentClaims", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentColor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentColors
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentColorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentColorEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentColors")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.AssessmentColorEntity, 0, null, null, null, null, "AssessmentColors", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentIssueInDispute' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentIssuesInDispute
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentIssueInDisputeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentIssueInDisputeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentIssuesInDispute")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.AssessmentIssueInDisputeEntity, 0, null, null, null, null, "AssessmentIssuesInDispute", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentMedRehab' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentMedRehabs
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentMedRehabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentMedRehabEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentMedRehabs")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.AssessmentMedRehabEntity, 0, null, null, null, null, "AssessmentMedRehabs", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentNote' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentNotes
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AssessmentNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentNoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentNotes")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.AssessmentNoteEntity, 0, null, null, null, null, "AssessmentNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}









		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AssessmentType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAssessmentType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AssessmentType")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.AssessmentTypeEntity, 0, null, null, null, null, "AssessmentType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Company' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCompany
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CompanyEntityFactory))),
					(IEntityRelation)GetRelationsForField("Company")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.CompanyEntity, 0, null, null, null, null, "Company", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralSource' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralSource
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReferralSourceEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReferralSource")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.ReferralSourceEntity, 0, null, null, null, null, "ReferralSource", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReferralType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReferralType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReferralTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReferralType")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.ReferralTypeEntity, 0, null, null, null, null, "ReferralType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReportStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReportStatus
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ReportStatusEntityFactory))),
					(IEntityRelation)GetRelationsForField("ReportStatus")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.ReportStatusEntity, 0, null, null, null, null, "ReportStatus", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesWriter
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotesWriter")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "NotesWriter", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDocListWriter
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("DocListWriter")[0], (int)PsychologicalServices.Data.EntityType.AssessmentEntity, (int)PsychologicalServices.Data.EntityType.UserEntity, 0, null, null, null, null, "DocListWriter", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AssessmentEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return AssessmentEntity.FieldsCustomProperties;}
		}

		/// <summary> The AssessmentId property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."AssessmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AssessmentId
		{
			get { return (System.Int32)GetValue((int)AssessmentFieldIndex.AssessmentId, true); }
			set	{ SetValue((int)AssessmentFieldIndex.AssessmentId, value); }
		}

		/// <summary> The ReferralTypeId property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."ReferralTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ReferralTypeId
		{
			get { return (System.Int32)GetValue((int)AssessmentFieldIndex.ReferralTypeId, true); }
			set	{ SetValue((int)AssessmentFieldIndex.ReferralTypeId, value); }
		}

		/// <summary> The ReferralSourceId property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."ReferralSourceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ReferralSourceId
		{
			get { return (System.Int32)GetValue((int)AssessmentFieldIndex.ReferralSourceId, true); }
			set	{ SetValue((int)AssessmentFieldIndex.ReferralSourceId, value); }
		}

		/// <summary> The AssessmentTypeId property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."AssessmentTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AssessmentTypeId
		{
			get { return (System.Int32)GetValue((int)AssessmentFieldIndex.AssessmentTypeId, true); }
			set	{ SetValue((int)AssessmentFieldIndex.AssessmentTypeId, value); }
		}

		/// <summary> The Deleted property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."Deleted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Deleted
		{
			get { return (System.Boolean)GetValue((int)AssessmentFieldIndex.Deleted, true); }
			set	{ SetValue((int)AssessmentFieldIndex.Deleted, value); }
		}

		/// <summary> The CompanyId property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."CompanyId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 CompanyId
		{
			get { return (System.Int32)GetValue((int)AssessmentFieldIndex.CompanyId, true); }
			set	{ SetValue((int)AssessmentFieldIndex.CompanyId, value); }
		}

		/// <summary> The ReportStatusId property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."ReportStatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ReportStatusId
		{
			get { return (System.Int32)GetValue((int)AssessmentFieldIndex.ReportStatusId, true); }
			set	{ SetValue((int)AssessmentFieldIndex.ReportStatusId, value); }
		}

		/// <summary> The FileSize property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."FileSize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> FileSize
		{
			get { return (Nullable<System.Int32>)GetValue((int)AssessmentFieldIndex.FileSize, false); }
			set	{ SetValue((int)AssessmentFieldIndex.FileSize, value); }
		}

		/// <summary> The ReferralSourceContactEmail property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."ReferralSourceContactEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ReferralSourceContactEmail
		{
			get { return (System.String)GetValue((int)AssessmentFieldIndex.ReferralSourceContactEmail, true); }
			set	{ SetValue((int)AssessmentFieldIndex.ReferralSourceContactEmail, value); }
		}

		/// <summary> The DocListWriterId property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."DocListWriterId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DocListWriterId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AssessmentFieldIndex.DocListWriterId, false); }
			set	{ SetValue((int)AssessmentFieldIndex.DocListWriterId, value); }
		}

		/// <summary> The NotesWriterId property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."NotesWriterId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NotesWriterId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AssessmentFieldIndex.NotesWriterId, false); }
			set	{ SetValue((int)AssessmentFieldIndex.NotesWriterId, value); }
		}

		/// <summary> The MedicalFileReceivedDate property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."MedicalFileReceivedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> MedicalFileReceivedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AssessmentFieldIndex.MedicalFileReceivedDate, false); }
			set	{ SetValue((int)AssessmentFieldIndex.MedicalFileReceivedDate, value); }
		}

		/// <summary> The Psychiatrist property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."Psychiatrist"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Psychiatrist
		{
			get { return (System.Boolean)GetValue((int)AssessmentFieldIndex.Psychiatrist, true); }
			set	{ SetValue((int)AssessmentFieldIndex.Psychiatrist, value); }
		}

		/// <summary> The TypicalDay property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."TypicalDay"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean TypicalDay
		{
			get { return (System.Boolean)GetValue((int)AssessmentFieldIndex.TypicalDay, true); }
			set	{ SetValue((int)AssessmentFieldIndex.TypicalDay, value); }
		}

		/// <summary> The WorkHistory property of the Entity Assessment<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Assessments"."WorkHistory"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean WorkHistory
		{
			get { return (System.Boolean)GetValue((int)AssessmentFieldIndex.WorkHistory, true); }
			set	{ SetValue((int)AssessmentFieldIndex.WorkHistory, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AppointmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AppointmentEntity))]
		public virtual EntityCollection<AppointmentEntity> Appointments
		{
			get
			{
				if(_appointments==null)
				{
					_appointments = new EntityCollection<AppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AppointmentEntityFactory)));
					_appointments.SetContainingEntityInfo(this, "Assessment");
				}
				return _appointments;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentClaimEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentClaimEntity))]
		public virtual EntityCollection<AssessmentClaimEntity> AssessmentClaims
		{
			get
			{
				if(_assessmentClaims==null)
				{
					_assessmentClaims = new EntityCollection<AssessmentClaimEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentClaimEntityFactory)));
					_assessmentClaims.SetContainingEntityInfo(this, "Assessment");
				}
				return _assessmentClaims;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentColorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentColorEntity))]
		public virtual EntityCollection<AssessmentColorEntity> AssessmentColors
		{
			get
			{
				if(_assessmentColors==null)
				{
					_assessmentColors = new EntityCollection<AssessmentColorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentColorEntityFactory)));
					_assessmentColors.SetContainingEntityInfo(this, "Assessment");
				}
				return _assessmentColors;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentIssueInDisputeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentIssueInDisputeEntity))]
		public virtual EntityCollection<AssessmentIssueInDisputeEntity> AssessmentIssuesInDispute
		{
			get
			{
				if(_assessmentIssuesInDispute==null)
				{
					_assessmentIssuesInDispute = new EntityCollection<AssessmentIssueInDisputeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentIssueInDisputeEntityFactory)));
					_assessmentIssuesInDispute.SetContainingEntityInfo(this, "Assessment");
				}
				return _assessmentIssuesInDispute;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentMedRehabEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentMedRehabEntity))]
		public virtual EntityCollection<AssessmentMedRehabEntity> AssessmentMedRehabs
		{
			get
			{
				if(_assessmentMedRehabs==null)
				{
					_assessmentMedRehabs = new EntityCollection<AssessmentMedRehabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentMedRehabEntityFactory)));
					_assessmentMedRehabs.SetContainingEntityInfo(this, "Assessment");
				}
				return _assessmentMedRehabs;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AssessmentNoteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AssessmentNoteEntity))]
		public virtual EntityCollection<AssessmentNoteEntity> AssessmentNotes
		{
			get
			{
				if(_assessmentNotes==null)
				{
					_assessmentNotes = new EntityCollection<AssessmentNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AssessmentNoteEntityFactory)));
					_assessmentNotes.SetContainingEntityInfo(this, "Assessment");
				}
				return _assessmentNotes;
			}
		}









		/// <summary> Gets / sets related entity of type 'AssessmentTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AssessmentTypeEntity AssessmentType
		{
			get
			{
				return _assessmentType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAssessmentType(value);
				}
				else
				{
					if(value==null)
					{
						if(_assessmentType != null)
						{
							UnsetRelatedEntity(_assessmentType, "AssessmentType");
						}
					}
					else
					{
						if(_assessmentType!=value)
						{
							SetRelatedEntity((IEntity2)value, "AssessmentType");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CompanyEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CompanyEntity Company
		{
			get
			{
				return _company;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCompany(value);
				}
				else
				{
					if(value==null)
					{
						if(_company != null)
						{
							UnsetRelatedEntity(_company, "Company");
						}
					}
					else
					{
						if(_company!=value)
						{
							SetRelatedEntity((IEntity2)value, "Company");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReferralSourceEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ReferralSourceEntity ReferralSource
		{
			get
			{
				return _referralSource;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncReferralSource(value);
				}
				else
				{
					if(value==null)
					{
						if(_referralSource != null)
						{
							UnsetRelatedEntity(_referralSource, "ReferralSource");
						}
					}
					else
					{
						if(_referralSource!=value)
						{
							SetRelatedEntity((IEntity2)value, "ReferralSource");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReferralTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ReferralTypeEntity ReferralType
		{
			get
			{
				return _referralType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncReferralType(value);
				}
				else
				{
					if(value==null)
					{
						if(_referralType != null)
						{
							UnsetRelatedEntity(_referralType, "ReferralType");
						}
					}
					else
					{
						if(_referralType!=value)
						{
							SetRelatedEntity((IEntity2)value, "ReferralType");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ReportStatusEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ReportStatusEntity ReportStatus
		{
			get
			{
				return _reportStatus;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncReportStatus(value);
				}
				else
				{
					if(value==null)
					{
						if(_reportStatus != null)
						{
							UnsetRelatedEntity(_reportStatus, "ReportStatus");
						}
					}
					else
					{
						if(_reportStatus!=value)
						{
							SetRelatedEntity((IEntity2)value, "ReportStatus");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity NotesWriter
		{
			get
			{
				return _notesWriter;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNotesWriter(value);
				}
				else
				{
					if(value==null)
					{
						if(_notesWriter != null)
						{
							UnsetRelatedEntity(_notesWriter, "NotesWriter");
						}
					}
					else
					{
						if(_notesWriter!=value)
						{
							SetRelatedEntity((IEntity2)value, "NotesWriter");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual UserEntity DocListWriter
		{
			get
			{
				return _docListWriter;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDocListWriter(value);
				}
				else
				{
					if(value==null)
					{
						if(_docListWriter != null)
						{
							UnsetRelatedEntity(_docListWriter, "DocListWriter");
						}
					}
					else
					{
						if(_docListWriter!=value)
						{
							SetRelatedEntity((IEntity2)value, "DocListWriter");
						}
					}
				}
			}
		}

	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the PsychologicalServices.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)PsychologicalServices.Data.EntityType.AssessmentEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
