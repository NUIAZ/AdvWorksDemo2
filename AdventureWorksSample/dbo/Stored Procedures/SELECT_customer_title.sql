CREATE PROCEDURE [dbo].[SELECT_customer_title]
	@title int 
AS

-- lets say that a 1 = 'Mr.' and everything else is a 'Ms.'
DECLARE @titleWeWant char(3)

--lets use a random number so the results wont always be the same.
DECLARE @count int
SET @count = (Select floor(rand()*251))

-- IF Statement https://learn.microsoft.com/en-us/sql/t-sql/language-elements/if-else-transact-sql?view=sql-server-ver16 
IF @title = 1 
	SET @titleWeWant = 'Mr.'
ELSE
	SET @titleWeWant = 'Ms.'

SELECT top (@count)
      [Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
  FROM [AdventureWorksLT2017].[SalesLT].[Customer]
  where [Title] = @titleWeWant
  AND MiddleName IS NOT NULL
  AND Title IS NOT NULL
