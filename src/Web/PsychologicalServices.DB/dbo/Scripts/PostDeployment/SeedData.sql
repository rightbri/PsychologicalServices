GO

SET IDENTITY_INSERT [dbo].[Companies] ON;

INSERT INTO [dbo].[Companies] ([CompanyId],[Name],[IsActive]) VALUES
	(1,'Watson Psychological Services',1)

SET IDENTITY_INSERT [dbo].[Companies] OFF;


SET IDENTITY_INSERT [dbo].[AddressTypes] ON;

INSERT INTO [dbo].[AddressTypes] ([AddressTypeId],[Name],[IsActive]) VALUES
	 (1,'Company Address',1)
	,(2,'Referral Source Address',1)
	,(3,'Appointment Address',1)

SET IDENTITY_INSERT [dbo].[AddressTypes] OFF;


SET IDENTITY_INSERT [dbo].[AppointmentStatuses] ON;

INSERT INTO [dbo].[AppointmentStatuses] ([AppointmentStatusId],[Name],[Description],[IsActive],[NotifyReferralSource]) VALUES 
	 (1,'On Hold','Appointment requested',1,0)
	,(2,'Confirmed','Appointment meets criteria to proceed',1,1)
	,(3,'Canceled',NULL,1,0)
	,(4,'Showed','Claimant arrived for appointment',1,1)
	,(5,'No Show','Claimant did not arrive within 30 minutes of scheduled appointment time',1,1)
	,(6,'Incomplete','Claimant needs to return for another appointment to finish testing',1,1)
	,(7,'Complete','A report will be generated',1,1)
	,(8,'Rescheduled','Referral Source has requested another appointment day/time',1,0)

SET IDENTITY_INSERT [dbo].[AppointmentStatuses] OFF;


SET IDENTITY_INSERT [dbo].[AssessmentTypes] ON;

INSERT INTO [dbo].[AssessmentTypes] ([Name],[Description],[Duration],[IsActive]) VALUES
	 (1,'NP','Neuropsychological',0,1)
	,(2,'NC','Neurocognitive',0,1)
	,(3,'P','Psychological',0,1)
	,(4,'PVOC','Psychovocational',0,1)
;
SET IDENTITY_INSERT [dbo].[AssessmentTypes] OFF;


SET IDENTITY_INSERT [dbo].[ReportTypes] ON;

INSERT INTO [dbo].[ReportTypes] ([ReportTypeId],[Name],[NumberOfReports],[IsActive]) VALUES 
	 (1,'NP',1,1)
	,(2,'NC/P',2,1)
	,(3,'NP/test',2,1)
	,(4,'NC',1,1)
	,(5,'NC/test',2,1)
	,(6,'P',1,1)
	,(7,'PVOC',1,1)
;
SET IDENTITY_INSERT [dbo].[ReportTypes] OFF;


INSERT INTO [dbo].[AssessmentTypeReportTypes] ([AssessmentTypeId],[ReportTypeId]) VALUES
	 (1,1)
	,(1,2)
	,(1,3)
	,(2,4)
	,(2,5)
	,(3,6)
	,(4,7)


SET IDENTITY_INSERT [dbo].[IssuesInDispute] ON;

INSERT INTO [dbo].[IssuesInDispute] ([IssueInDisputeId],[Name],[IsActive],[Instructions]) VALUES 
	 (1,'IRB - Pre 104',1,NULL)
	,(2,'IRB - Post 104',1,NULL)
	,(3,'Non Earner Benefits',1,NULL)
	,(4,'Attendant Care',1,NULL)
	,(5,'Housekeeping',1,NULL)
	,(6,'Catastrophic',1,NULL)
	,(7,'Med Rehab',1,NULL)

SET IDENTITY_INSERT [dbo].[IssuesInDispute] OFF;


SET IDENTITY_INSERT [dbo].[ReferralSourceTypes] ON;

INSERT INTO [dbo].[ReferralSourceTypes] ([ReferralSourceTypeId],[Name],[IsActive]) VALUES 
	 (1,'IME Company',1)
	,(2,'Insurance Company',1)
	,(3,'Lawyer',1)
	,(4,'Self',1)

SET IDENTITY_INSERT [dbo].[ReferralSourceTypes] OFF;


SET IDENTITY_INSERT [dbo].[ReferralTypes] ON;

INSERT INTO [dbo].[ReferralTypes] ([ReferralTypeId],[Name],[IsActive]) VALUES
	 (1,'AB',1)
	,(2,'LTD',1)
	,(3,'Employed',1)
	,(4,'Legal',1)

SET IDENTITY_INSERT [dbo].[ReferralTypes] OFF;


INSERT INTO [dbo].[ReferralTypeIssuesInDispute] ([ReferralTypeId],[IssueInDisputeId]) VALUES
	 (1,1)
	,(1,2)
	,(1,3)
	,(1,4)
	,(1,5)
	,(1,6)
	,(1,7)


SET IDENTITY_INSERT [dbo].[ReportStatuses] ON;

INSERT INTO [dbo].[ReportStatuses] ([ReportStatusId],[Name],[IsActive]) VALUES
	 (1,'Medical file received',1)
	,(2,'Medical file reviewed',1)
	,(3,'DocList back',1)
	,(4,'Notes back',1)
	,(5,'To be edited',1)
	,(6,'Returned to psychologist',1)
	,(7,'Sent to referral source',1)
	
SET IDENTITY_INSERT [dbo].[ReportStatuses] OFF;


SET IDENTITY_INSERT [dbo].[ReferralSources] ON;

INSERT INTO [dbo].[ReferralSources] ([ReferralSourceId],[Name],[ReferralSourceTypeId],[IsActive],[LargeFileSize],[LargeFileFeeAmount]) VALUES 
	 (1,'Seiden',1,1,1500,250.00)
	
SET IDENTITY_INSERT [dbo].[ReferralSources] OFF;




SET IDENTITY_INSERT [dbo].[AttributeTypes] ON;

INSERT INTO [dbo].[AttributeTypes] ([AttributeTypeId],[Name],[IsActive]) VALUES
	 (1,'Appointment',1)
	,(2,'Assessment',1)

SET IDENTITY_INSERT [dbo].[AttributeTypes] OFF;



SET IDENTITY_INSERT [dbo].[Attributes] ON;

INSERT INTO [dbo].[Attributes] ([AttributeId],[Name],[AttributeTypeId],[IsActive]) VALUES
--	 ('Room Rental Arranged',1,1)
--	,('Consent Form Printed',1,1)
	 (1,'Reader Booked',1,1)
	,(2,'Translator Booked',1,1)
	,(3,'Psychiatrist',2,1)
	,(4,'Typical Day',2,1)
	,(5,'Work History',2,1)

SET IDENTITY_INSERT [dbo].[Attributes] OFF;


INSERT INTO [dbo].[CompanyAttributes] ([CompanyId],[AttributeId]) VALUES
	 (1,1)
	,(1,2)
	,(1,3)
	,(1,4)
	,(1,5)
	

SET IDENTITY_INSERT [dbo].[Users] ON;

INSERT INTO [dbo].[Users] ([UserId],[FirstName],[LastName],[Email],[IsActive],[CompanyId]) VALUES
	 (1,'Mark','Watson','doctormarkwatson@gmail.com',1,1)
	,(2,'Michelle','Avent','michelle.avent@gmail.com',1,1)
	,(3,'Brian','Avent','brian.avent@gmail.com',1,1)

SET IDENTITY_INSERT [dbo].[Users] OFF;


SET IDENTITY_INSERT [dbo].[Rights] ON;

INSERT INTO [dbo].[Rights] ([RightId],[Name],[Description],[IsActive]) VALUES 
	 (1,'Psychologist','',1)
	,(2,'Psychometrist','',1)
	,(3,'WriteDocList','',1)
	,(4,'WriteNotes','',1)

SET IDENTITY_INSERT [dbo].[Rights] OFF;

SET IDENTITY_INSERT [dbo].[Roles] ON;

INSERT INTO [dbo].[Roles] ([RoleId],[Name],[Description],[IsActive]) VALUES 
	 (1,'Psychologist','',1)
	,(2,'Psychometrist','',1)
	,(3,'DocList Writer','',1)
	,(4,'Notes Writer','',1)

SET IDENTITY_INSERT [dbo].[Roles] OFF;

INSERT INTO [dbo].[RoleRights] ([RoleId],[RightId]) VALUES 
	 (1,1)
	,(2,2)
	,(3,3)
	,(4,4)

INSERT INTO [dbo].[UserRoles] ([UserId],[RoleId]) VALUES 
	 (1,1)
	,(2,3)
	,(2,4)
	,(3,2)

