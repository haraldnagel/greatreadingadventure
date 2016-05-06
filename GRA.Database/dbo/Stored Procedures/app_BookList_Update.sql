﻿
/****** Object:  StoredProcedure [dbo].[app_BookList_Update]    Script Date: 01/05/2015 14:43:20 ******/
--Create the Update Proc
CREATE PROCEDURE [dbo].[app_BookList_Update] (
	@BLID INT,
	@AdminName VARCHAR(255),
	@ListName VARCHAR(255),
	@AdminDescription TEXT,
	@Description TEXT,
	@LiteracyLevel1 INT,
	@LiteracyLevel2 INT,
	@ProgID INT,
	@LibraryID INT,
	@AwardBadgeID INT,
	@AwardPoints INT,
	@LastModDate DATETIME,
	@LastModUser VARCHAR(50),
	@AddedDate DATETIME,
	@AddedUser VARCHAR(50),
	@TenID INT = 0,
	@FldInt1 INT = 0,
	@FldInt2 INT = 0,
	@FldInt3 INT = 0,
	@FldBit1 BIT = 0,
	@FldBit2 BIT = 0,
	@FldBit3 BIT = 0,
	@FldText1 TEXT = '',
	@FldText2 TEXT = '',
	@FldText3 TEXT = '',
	@NumBooksToComplete INT = 0
	)
AS
UPDATE BookList
SET AdminName = @AdminName,
	ListName = @ListName,
	AdminDescription = @AdminDescription,
	Description = @Description,
	LiteracyLevel1 = @LiteracyLevel1,
	LiteracyLevel2 = @LiteracyLevel2,
	ProgID = @ProgID,
	LibraryID = @LibraryID,
	AwardBadgeID = @AwardBadgeID,
	AwardPoints = @AwardPoints,
	LastModDate = @LastModDate,
	LastModUser = @LastModUser,
	AddedDate = @AddedDate,
	AddedUser = @AddedUser,
	TenID = @TenID,
	FldInt1 = @FldInt1,
	FldInt2 = @FldInt2,
	FldInt3 = @FldInt3,
	FldBit1 = @FldBit1,
	FldBit2 = @FldBit2,
	FldBit3 = @FldBit3,
	FldText1 = @FldText1,
	FldText2 = @FldText2,
	FldText3 = @FldText3,
	NumBooksToComplete = @NumBooksToComplete
WHERE BLID = @BLID
	AND TenID = @TenID
