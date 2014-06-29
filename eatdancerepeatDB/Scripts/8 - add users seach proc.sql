IF EXISTS (SELECT * FROM dbo.sysobjects WHERE name = 'usp_Users_Search')
DROP PROCEDURE usp_Users_Search
GO
CREATE PROC dbo.usp_Users_Search
/*
	AUTHOR:		Tad Graves, 06/29/2014

	PURPOSE:		Search for a Users record

	APPLICATION:		eatdancerepeat

	CONTACT:		Tad Graves
*/
(
	@UserID			int= NULL,
	@FacebookLink			nvarchar(200)= NULL,
	@UrlName			varchar(200)= NULL
)
AS
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SET NOCOUNT ON

	SELECT 	
			u.[UserID],
			u.[FirstName],
			u.[LastName],
			u.[JoinDate],
			u.[FacebookLink],
			u.[UrlName]

	FROM		Users u
	WHERE		COALESCE(u.[UserID],0)=COALESCE(@UserID,u.[UserID],0)
	AND			COALESCE(u.[FacebookLink],'') = COALESCE(@FacebookLink,u.[FacebookLink],'')
	AND			COALESCE(u.[UrlName],'') = COALESCE(@UrlName,u.[UrlName],'')
GO