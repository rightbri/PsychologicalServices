///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;

namespace PsychologicalServices.Data
{

	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Address.
	/// </summary>
	public enum AddressFieldIndex:int
	{
		///<summary>AddressId. </summary>
		AddressId,
		///<summary>Street. </summary>
		Street,
		///<summary>Suite. </summary>
		Suite,
		///<summary>City. </summary>
		City,
		///<summary>Province. </summary>
		Province,
		///<summary>PostalCode. </summary>
		PostalCode,
		///<summary>Country. </summary>
		Country,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>AddressTypeId. </summary>
		AddressTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AddressType.
	/// </summary>
	public enum AddressTypeFieldIndex:int
	{
		///<summary>AddressTypeId. </summary>
		AddressTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Appointment.
	/// </summary>
	public enum AppointmentFieldIndex:int
	{
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>LocationId. </summary>
		LocationId,
		///<summary>AppointmentTime. </summary>
		AppointmentTime,
		///<summary>PsychometristId. </summary>
		PsychometristId,
		///<summary>PsychologistId. </summary>
		PsychologistId,
		///<summary>AppointmentStatusId. </summary>
		AppointmentStatusId,
		///<summary>Deleted. </summary>
		Deleted,
		///<summary>AssessmentId. </summary>
		AssessmentId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AppointmentStatus.
	/// </summary>
	public enum AppointmentStatusFieldIndex:int
	{
		///<summary>AppointmentStatusId. </summary>
		AppointmentStatusId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>NotifyReferralSource. </summary>
		NotifyReferralSource,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AppointmentTask.
	/// </summary>
	public enum AppointmentTaskFieldIndex:int
	{
		///<summary>AppointmentId. </summary>
		AppointmentId,
		///<summary>TaskId. </summary>
		TaskId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Assessment.
	/// </summary>
	public enum AssessmentFieldIndex:int
	{
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>ReferralTypeId. </summary>
		ReferralTypeId,
		///<summary>ReferralSourceId. </summary>
		ReferralSourceId,
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>Deleted. </summary>
		Deleted,
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>ReportStatusId. </summary>
		ReportStatusId,
		///<summary>FileSize. </summary>
		FileSize,
		///<summary>ReferralSourceContactEmail. </summary>
		ReferralSourceContactEmail,
		///<summary>DocListWriterId. </summary>
		DocListWriterId,
		///<summary>NotesWriterId. </summary>
		NotesWriterId,
		///<summary>MedicalFileReceivedDate. </summary>
		MedicalFileReceivedDate,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentClaim.
	/// </summary>
	public enum AssessmentClaimFieldIndex:int
	{
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>ClaimId. </summary>
		ClaimId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentIssueInDispute.
	/// </summary>
	public enum AssessmentIssueInDisputeFieldIndex:int
	{
		///<summary>AssessmentId. </summary>
		AssessmentId,
		///<summary>IssueIsDisputeId. </summary>
		IssueIsDisputeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentType.
	/// </summary>
	public enum AssessmentTypeFieldIndex:int
	{
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>Duration. </summary>
		Duration,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: AssessmentTypeReportType.
	/// </summary>
	public enum AssessmentTypeReportTypeFieldIndex:int
	{
		///<summary>AssessmentTypeId. </summary>
		AssessmentTypeId,
		///<summary>ReportTypeId. </summary>
		ReportTypeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Claim.
	/// </summary>
	public enum ClaimFieldIndex:int
	{
		///<summary>ClaimId. </summary>
		ClaimId,
		///<summary>ClaimantId. </summary>
		ClaimantId,
		///<summary>DateOfLoss. </summary>
		DateOfLoss,
		///<summary>ClaimNumber. </summary>
		ClaimNumber,
		///<summary>Deleted. </summary>
		Deleted,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Claimant.
	/// </summary>
	public enum ClaimantFieldIndex:int
	{
		///<summary>ClaimantId. </summary>
		ClaimantId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Age. </summary>
		Age,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Gender. </summary>
		Gender,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Company.
	/// </summary>
	public enum CompanyFieldIndex:int
	{
		///<summary>CompanyId. </summary>
		CompanyId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: InvoiceAmount.
	/// </summary>
	public enum InvoiceAmountFieldIndex:int
	{
		///<summary>ReferralSourceId. </summary>
		ReferralSourceId,
		///<summary>ReportTypeId. </summary>
		ReportTypeId,
		///<summary>InvoiceAmount. </summary>
		InvoiceAmount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: IssueInDispute.
	/// </summary>
	public enum IssueInDisputeFieldIndex:int
	{
		///<summary>IssueInDisputeId. </summary>
		IssueInDisputeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>Instructions. </summary>
		Instructions,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralSource.
	/// </summary>
	public enum ReferralSourceFieldIndex:int
	{
		///<summary>ReferralSourceId. </summary>
		ReferralSourceId,
		///<summary>Name. </summary>
		Name,
		///<summary>ReferralSourceTypeId. </summary>
		ReferralSourceTypeId,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>LargeFileSize. </summary>
		LargeFileSize,
		///<summary>LargeFileFeeAmount. </summary>
		LargeFileFeeAmount,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralSourceType.
	/// </summary>
	public enum ReferralSourceTypeFieldIndex:int
	{
		///<summary>ReferralSourceTypeId. </summary>
		ReferralSourceTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralType.
	/// </summary>
	public enum ReferralTypeFieldIndex:int
	{
		///<summary>ReferralTypeId. </summary>
		ReferralTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReferralTypeIssueInDispute.
	/// </summary>
	public enum ReferralTypeIssueInDisputeFieldIndex:int
	{
		///<summary>ReferralTypeId. </summary>
		ReferralTypeId,
		///<summary>IssueInDisputeId. </summary>
		IssueInDisputeId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReportStatus.
	/// </summary>
	public enum ReportStatusFieldIndex:int
	{
		///<summary>ReportStatusId. </summary>
		ReportStatusId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: ReportType.
	/// </summary>
	public enum ReportTypeFieldIndex:int
	{
		///<summary>ReportTypeId. </summary>
		ReportTypeId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>NumberOfReports. </summary>
		NumberOfReports,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Right.
	/// </summary>
	public enum RightFieldIndex:int
	{
		///<summary>RightId. </summary>
		RightId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Role.
	/// </summary>
	public enum RoleFieldIndex:int
	{
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>Name. </summary>
		Name,
		///<summary>Description. </summary>
		Description,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: RoleRight.
	/// </summary>
	public enum RoleRightFieldIndex:int
	{
		///<summary>RoleId. </summary>
		RoleId,
		///<summary>RightId. </summary>
		RightId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Task.
	/// </summary>
	public enum TaskFieldIndex:int
	{
		///<summary>TaskId. </summary>
		TaskId,
		///<summary>TaskTemplateId. </summary>
		TaskTemplateId,
		///<summary>TaskStatusId. </summary>
		TaskStatusId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TaskStatus.
	/// </summary>
	public enum TaskStatusFieldIndex:int
	{
		///<summary>TaskStatusId. </summary>
		TaskStatusId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: TaskTemplate.
	/// </summary>
	public enum TaskTemplateFieldIndex:int
	{
		///<summary>TaskTemplateId. </summary>
		TaskTemplateId,
		///<summary>Name. </summary>
		Name,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CompanyId. </summary>
		CompanyId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: User.
	/// </summary>
	public enum UserFieldIndex:int
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>LastName. </summary>
		LastName,
		///<summary>Email. </summary>
		Email,
		///<summary>IsActive. </summary>
		IsActive,
		///<summary>CompanyId. </summary>
		CompanyId,
		/// <summary></summary>
		AmountOfFields
	}


	/// <summary>
	/// Index enum to fast-access EntityFields in the IEntityFields collection for the entity: UserRole.
	/// </summary>
	public enum UserRoleFieldIndex:int
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>RoleId. </summary>
		RoleId,
		/// <summary></summary>
		AmountOfFields
	}





	/// <summary>
	/// Enum definition for all the entity types defined in this namespace. Used by the entityfields factory.
	/// </summary>
	public enum EntityType:int
	{
		///<summary>Address</summary>
		AddressEntity,
		///<summary>AddressType</summary>
		AddressTypeEntity,
		///<summary>Appointment</summary>
		AppointmentEntity,
		///<summary>AppointmentStatus</summary>
		AppointmentStatusEntity,
		///<summary>AppointmentTask</summary>
		AppointmentTaskEntity,
		///<summary>Assessment</summary>
		AssessmentEntity,
		///<summary>AssessmentClaim</summary>
		AssessmentClaimEntity,
		///<summary>AssessmentIssueInDispute</summary>
		AssessmentIssueInDisputeEntity,
		///<summary>AssessmentType</summary>
		AssessmentTypeEntity,
		///<summary>AssessmentTypeReportType</summary>
		AssessmentTypeReportTypeEntity,
		///<summary>Claim</summary>
		ClaimEntity,
		///<summary>Claimant</summary>
		ClaimantEntity,
		///<summary>Company</summary>
		CompanyEntity,
		///<summary>InvoiceAmount</summary>
		InvoiceAmountEntity,
		///<summary>IssueInDispute</summary>
		IssueInDisputeEntity,
		///<summary>ReferralSource</summary>
		ReferralSourceEntity,
		///<summary>ReferralSourceType</summary>
		ReferralSourceTypeEntity,
		///<summary>ReferralType</summary>
		ReferralTypeEntity,
		///<summary>ReferralTypeIssueInDispute</summary>
		ReferralTypeIssueInDisputeEntity,
		///<summary>ReportStatus</summary>
		ReportStatusEntity,
		///<summary>ReportType</summary>
		ReportTypeEntity,
		///<summary>Right</summary>
		RightEntity,
		///<summary>Role</summary>
		RoleEntity,
		///<summary>RoleRight</summary>
		RoleRightEntity,
		///<summary>Task</summary>
		TaskEntity,
		///<summary>TaskStatus</summary>
		TaskStatusEntity,
		///<summary>TaskTemplate</summary>
		TaskTemplateEntity,
		///<summary>User</summary>
		UserEntity,
		///<summary>UserRole</summary>
		UserRoleEntity
	}




	#region Custom ConstantsEnums Code
	
	// __LLBLGENPRO_USER_CODE_REGION_START CustomUserConstants
	// __LLBLGENPRO_USER_CODE_REGION_END
	#endregion

	#region Included code

	#endregion
}


