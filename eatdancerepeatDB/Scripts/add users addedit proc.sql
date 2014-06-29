IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_Users_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_Users_Update]
GO

CREATE PROC dbo.usp_Users_Update
/*
	AUTHOR:		Tad Graves, 06/29/2014

	PURPOSE:		Update/Insert Users record

	APPLICATION:		eatdancerepeat

	CONTACT:		Tad Graves
*/
(
	@UserID			int	= -999999999 OUTPUT,
	@FirstName			nvarchar(50)	= '',
	@LastName			nvarchar(50)	= '',
	@FacebookLink			nvarchar(200)	= '',
	@UrlName			varchar(200)	= ''
)
AS
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SET NOCOUNT ON

	IF NOT EXISTS(SELECT * FROM Users WHERE UserID = @UserID)
	BEGIN
		INSERT INTO	Users
				([FirstName],
				[LastName],
				[FacebookLink],
				[UrlName])
		SELECT	CASE WHEN @FirstName = '' THEN NULL ELSE @FirstName END,
				CASE WHEN @LastName = '' THEN NULL ELSE @LastName END,
				CASE WHEN @FacebookLink = '' THEN NULL ELSE @FacebookLink END,
				CASE WHEN @UrlName = '' THEN NULL ELSE @UrlName END

		SELECT	@UserID = SCOPE_IDENTITY()
	END

	UPDATE	Users
	SET		[FirstName]	= CASE WHEN @FirstName = '' THEN [FirstName] ELSE @FirstName END,
			[LastName]	= CASE WHEN @LastName = '' THEN [LastName] ELSE @LastName END,
			[FacebookLink]	= CASE WHEN @FacebookLink = '' THEN [FacebookLink] ELSE @FacebookLink END,
			[UrlName]	= CASE WHEN @UrlName = '' THEN [UrlName] ELSE @UrlName END
	WHERE	UserID = @UserID
	
	IF ISNULL(@UrlName, '') = ''
	BEGIN
			SELECT	@UrlName = FirstName + LastName + CAST(UserID AS varchar)
			FROM	Users
			WHERE	UserID = @UserID
	END
	
	IF EXISTS(SELECT * FROM Users WHERE UrlName = @UrlName)
	BEGIN
			UPDATE		Users
			SET			UrlName = FirstName + LastName + CAST(UserID AS varchar)
			WHERE		UserID = @UserID
	END