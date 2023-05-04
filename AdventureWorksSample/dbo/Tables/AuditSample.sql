CREATE TABLE [dbo].[AuditSample] (
    [ID]               INT      IDENTITY (1, 1) NOT NULL,
    [TitleNumberInput] INT      NOT NULL,
    [OutputRowCount]   INT      NOT NULL,
    [EntryDate]        DATETIME CONSTRAINT [DF_AuditSample_EntryDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_AuditSample] PRIMARY KEY CLUSTERED ([ID] ASC)
);

