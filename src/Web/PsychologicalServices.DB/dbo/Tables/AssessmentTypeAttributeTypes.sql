CREATE TABLE [dbo].[AssessmentTypeAttributeTypes] (
    [AssessmentTypeId] INT NOT NULL,
    [AttributeTypeId]  INT NOT NULL,
    CONSTRAINT [PK_AssessmentTypeAttributeTypes] PRIMARY KEY CLUSTERED ([AssessmentTypeId] ASC, [AttributeTypeId] ASC),
    CONSTRAINT [FK_AssessmentTypeAttributeTypes_AssessmentTypes] FOREIGN KEY ([AssessmentTypeId]) REFERENCES [dbo].[AssessmentTypes] ([AssessmentTypeId]),
    CONSTRAINT [FK_AssessmentTypeAttributeTypes_AttributeTypes] FOREIGN KEY ([AttributeTypeId]) REFERENCES [dbo].[AttributeTypes] ([AttributeTypeId])
);

