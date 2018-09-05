CREATE TABLE [dbo].[Employees] (
    [EmployeeId]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (MAX) NULL,
    [EmploymentStarted] DATETIME2 (7)  DEFAULT (CONVERT([date],getdate())) NOT NULL,
    [Salary]            INT            NOT NULL,
    [LastPayRaise]      DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

