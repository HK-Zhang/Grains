CREATE TABLE [dbo].[EmployeeGenreateOnUpdates] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (MAX) NULL,
    [EmploymentStarted] DATETIME2 (7)  NOT NULL,
    [Salary]            INT            NOT NULL,
    [LastPayRaise]      DATETIME2 (7)  NULL,
    CONSTRAINT [PK_EmployeeGenreateOnUpdates] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE TRIGGER [dbo].[EmployeeGenreateOnUpdates_UPDATE]
	ON [dbo].[EmployeeGenreateOnUpdates]
    AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
                  
    IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;
                  
    IF UPDATE(Salary) AND NOT Update(LastPayRaise)
    BEGIN
        DECLARE @Id INT
        DECLARE @OldSalary INT
        DECLARE @NewSalary INT
          
        SELECT @Id = INSERTED.Id, @NewSalary = Salary        
        FROM INSERTED
          
        SELECT @OldSalary = Salary        
        FROM deleted
          
        IF @NewSalary > @OldSalary
        BEGIN
            UPDATE dbo.EmployeeGenreateOnUpdates
            SET LastPayRaise = CONVERT(date, GETDATE())
            WHERE @Id = @Id
        END
    END
END