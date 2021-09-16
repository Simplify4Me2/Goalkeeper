﻿DECLARE 
	@Anderlecht BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%RSC Anderlecht%'),
	@Antwerp BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'),
	@Beerschot BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Beerschot VA%'),
	@CercleBrugge BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Cercle Brugge%'),
	@ClubBrugge BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'),
	@Charleroi BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Charleroi Sporting Club%'),
	@Eupen BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%KAS Eupen%'),
	@Genk BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%KRC Genk%'),
	@Gent BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'),
	@Mechelen BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Mechelen%'),
	@Kortrijk BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Kortrijk%'),
	@OHL BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Oud-Heverlee Leuven%'),
	@Oostende BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Oostende%'),
	@Seraing BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%RFC Seraing%'),
	@StandardLuik BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Standard Luik%'),
	@STVV BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Sint-Truidense VV%'),
	@ZulteWaregem BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Zulte Waregem%'),
	@Union BIGINT = (SELECT Id FROM Stats.Teams WHERE [Name] like '%Union%')

INSERT INTO [Stats].[Matches]
([HomeTeamId], [HomeTeamScore], [AwayTeamId], [AwayTeamScore], [Matchday], [DateUtc], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  (@StandardLuik	, 1, @Genk			  , 1, 1, '2021-07-23 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL				, 1, @ZulteWaregem	  , 1, 1, '2021-07-24 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk		, 2, @Seraing		  , 0, 1, '2021-07-24 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende		, 0, @Charleroi		  , 3, 1, '2021-07-24 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen		, 3, @Antwerp		  , 2, 1, '2021-07-25 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge		, 2, @Eupen			  , 2, 1, '2021-07-25 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht		, 1, @Union			  , 3, 1, '2021-07-25 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV			, 2, @Gent			  , 1, 1, '2021-07-25 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot		, 0, @CercleBrugge	  , 1, 1, '2021-07-27 20:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@Genk          , 3, @Oostende        , 4, 2, '2021-07-30 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , 0, @STVV            , 0, 2, '2021-07-31 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , 1, @Mechelen        , 0, 2, '2021-07-31 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , 1, @OHL             , 1, 2, '2021-07-31 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , 1, @Anderlecht      , 1, 2, '2021-07-31 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , 0, @ClubBrugge      , 1, 2, '2021-08-01 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , 1, @StandardLuik    , 2, 2, '2021-08-01 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , 2, @Beerschot       , 2, 2, '2021-08-01 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , 0, @Kortrijk        , 1, 2, '2021-08-01 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed')  ,

  (@ClubBrugge    , 1, @CercleBrugge    , 1, 3, '2021-08-06 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , 0, @Union           , 3, 3, '2021-08-07 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , 1, @Eupen           , 3, 3, '2021-08-07 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , 1, @ZulteWaregem    , 3, 3, '2021-08-07 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , 1, @Genk            , 2, 3, '2021-08-07 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , 2, @Antwerp         , 5, 3, '2021-08-08 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , 1, @Charleroi       , 1, 3, '2021-08-08 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , 3, @Seraing         , 0, 3, '2021-08-08 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , 1, @Gent            , 0, 3, '2021-08-08 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Charleroi     , 1, @Antwerp         , 1, 4, '2021-08-13 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , 2, @Kortrijk        , 0, 4, '2021-08-14 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , 2, @STVV            , 1, 4, '2021-08-14 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , 2, @Oostende        , 3, 4, '2021-08-14 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , 4, @OHL             , 0, 4, '2021-08-14 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , 0, @StandardLuik    , 1, 4, '2021-08-15 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , 2, @Mechelen        , 0, 4, '2021-08-15 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , 1, @Anderlecht      , 2, 4, '2021-08-15 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , 0, @ClubBrugge      , 4, 4, '2021-08-15 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@StandardLuik  , 1, @Oostende        , 0, 5, '2021-08-20 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , 2, @CercleBrugge    , 1, 5, '2021-08-21 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , 1, @Eupen           , 4, 5, '2021-08-21 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , 0, @Kortrijk        , 2, 5, '2021-08-21 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , 2, @Charleroi       , 2, 5, '2021-08-22 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , 3, @Beerschot       , 2, 5, '2021-08-22 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , 3, @Union           , 1, 5, '2021-08-22 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Genk         , NULL, 5, '2021-09-22 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @Gent         , NULL, 5, '2021-09-23 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Kortrijk      , 2, @Mechelen        , 2, 6, '2021-08-27 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , 5, @Beerschot       , 2, 6, '2021-08-28 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , 1, @Seraing         , 2, 6, '2021-08-28 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , 0, @STVV            , 1, 6, '2021-08-28 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , 4, @StandardLuik    , 0, 6, '2021-08-28 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , 6, @ClubBrugge      , 1, 6, '2021-08-29 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , 2, @OHL             , 2, 6, '2021-08-29 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , 1, @Anderlecht      , 0, 6, '2021-08-29 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , 0, @ZulteWaregem    , 2, 6, '2021-08-29 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@ClubBrugge    , 3, @Oostende        , 0, 7, '2021-09-10 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , 0, @Antwerp         , 1, 7, '2021-09-11 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , 2, @CercleBrugge    , 4, 7, '2021-09-11 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , 0, @StandardLuik    , 1, 7, '2021-09-11 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , 7, @Mechelen        , 2, 7, '2021-09-12 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , 2, @Charleroi       , 3, 7, '2021-09-12 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , 1, @Union           , 1, 7, '2021-09-12 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , 2, @Kortrijk        , 1, 7, '2021-09-12 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , 0, @STVV            , 1, 7, '2021-09-13 20:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@CercleBrugge  , NULL, @Eupen        , NULL, 8, '2021-09-17 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Beerschot    , NULL, 8, '2021-09-18 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @OHL          , NULL, 8, '2021-09-18 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @ZulteWaregem , NULL, 8, '2021-09-18 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @ClubBrugge   , NULL, 8, '2021-09-18 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Genk         , NULL, 8, '2021-09-19 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Seraing      , NULL, 8, '2021-09-19 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @Anderlecht   , NULL, 8, '2021-09-19 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @Gent         , NULL, 8, '2021-09-19 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@ClubBrugge    , NULL, @OHL          , NULL, 9, '2021-09-24 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @Eupen        , NULL, 9, '2021-09-25 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Kortrijk     , NULL, 9, '2021-09-25 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @STVV         , NULL, 9, '2021-09-25 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Antwerp      , NULL, 9, '2021-09-26 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @CercleBrugge , NULL, 9, '2021-09-26 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Anderlecht   , NULL, 9, '2021-09-26 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @Seraing      , NULL, 9, '2021-09-26 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @Mechelen     , NULL, 9, '2021-09-26 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Mechelen      , NULL, @StandardLuik , NULL, 10, '2021-10-01 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @Charleroi    , NULL, 10, '2021-10-02 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Oostende     , NULL, 10, '2021-10-02 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Union        , NULL, 10, '2021-10-02 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @Beerschot    , NULL, 10, '2021-10-02 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @ClubBrugge   , NULL, 10, '2021-10-03 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @ZulteWaregem , NULL, 10, '2021-10-03 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Gent         , NULL, 10, '2021-10-03 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @Genk         , NULL, 10, '2021-10-03 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@ClubBrugge    , NULL, @Kortrijk     , NULL, 11, '2021-10-15 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Seraing      , NULL, 11, '2021-10-16 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Antwerp      , NULL, 11, '2021-10-16 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @CercleBrugge , NULL, 11, '2021-10-16 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @OHL          , NULL, 11, '2021-10-16 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Anderlecht   , NULL, 11, '2021-10-17 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @Mechelen     , NULL, 11, '2021-10-17 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @Genk         , NULL, 11, '2021-10-17 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @Eupen        , NULL, 11, '2021-10-17 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Seraing       , NULL, @Charleroi    , NULL, 12, '2021-10-22 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @StandardLuik , NULL, 12, '2021-10-23 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @Oostende     , NULL, 12, '2021-10-23 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @ZulteWaregem , NULL, 12, '2021-10-23 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @Union        , NULL, 12, '2021-10-23 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @ClubBrugge   , NULL, 12, '2021-10-24 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @Beerschot    , NULL, 12, '2021-10-24 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @Gent         , NULL, 12, '2021-10-24 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @STVV         , NULL, 12, '2021-10-24 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Charleroi     , NULL, @Eupen        , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @Kortrijk     , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @Seraing      , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @ClubBrugge   , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Genk         , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Mechelen     , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @Union        , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @OHL          , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Antwerp      , NULL, 13, '2021-10-30 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Eupen         , NULL, @ZulteWaregem , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @STVV         , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Charleroi    , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @StandardLuik , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @CercleBrugge , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Anderlecht   , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @Oostende     , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @Beerschot    , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @Gent         , NULL, 14, '2021-11-06 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@StandardLuik  , NULL, @Eupen        , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @Seraing      , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Union        , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Charleroi    , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @Kortrijk     , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Gent         , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @ClubBrugge   , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Antwerp      , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @Genk         , NULL, 15, '2021-11-20 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@Antwerp       , NULL, @Oostende     , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @STVV         , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Mechelen     , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @OHL          , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Beerschot    , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @Anderlecht   , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @Kortrijk     , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @StandardLuik , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @ClubBrugge   , NULL, 16, '2021-11-27 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Beerschot     , NULL, @Antwerp      , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Union        , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @Genk         , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @Seraing      , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @CercleBrugge , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Eupen        , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @Gent         , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @Charleroi    , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @ZulteWaregem , NULL, 17, '2021-12-04 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Kortrijk      , NULL, @OHL          , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @Anderlecht   , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Mechelen     , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @CercleBrugge , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @Oostende     , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @Beerschot    , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @Genk         , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @ZulteWaregem , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @StandardLuik , NULL, 18, '2021-12-11 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@StandardLuik  , NULL, @Beerschot    , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @STVV         , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Eupen        , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Kortrijk     , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @Gent         , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Union        , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Seraing      , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @Charleroi    , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @ClubBrugge   , NULL, 19, '2021-12-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Seraing       , NULL, @Kortrijk     , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @Antwerp      , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @Charleroi    , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @StandardLuik , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @CercleBrugge , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Mechelen     , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @Anderlecht   , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @Oostende     , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @STVV         , NULL, 20, '2021-12-18 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Kortrijk      , NULL, @Antwerp      , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Gent         , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @Seraing      , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Genk         , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Eupen        , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @ZulteWaregem , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @Anderlecht   , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @OHL          , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @ClubBrugge   , NULL, 21, '2021-12-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@Anderlecht    , NULL, @StandardLuik , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @Beerschot    , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @STVV         , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @Kortrijk     , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Charleroi    , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @Mechelen     , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Oostende     , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @CercleBrugge , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @Union        , NULL, 22, '2022-01-15 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  (@Kortrijk      , NULL, @Eupen        , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @ClubBrugge   , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @Gent         , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Genk         , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @Anderlecht   , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Seraing      , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @OHL          , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @ZulteWaregem , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Antwerp      , NULL, 23, '2022-01-22 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Gent          , NULL, @Oostende     , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @OHL          , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @Beerschot    , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @StandardLuik , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @CercleBrugge , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @Mechelen     , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @Kortrijk     , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @STVV         , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @Union        , NULL, 24, '2022-01-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Union         , NULL, @Anderlecht   , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @Mechelen     , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @Antwerp      , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @Genk         , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @ClubBrugge   , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @Eupen        , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @ZulteWaregem , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Oostende     , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Charleroi    , NULL, 25, '2022-01-29 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Anderlecht    , NULL, @Eupen        , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @STVV         , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @Gent         , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @ZulteWaregem , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @OHL          , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @CercleBrugge , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @Seraing      , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Union        , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @Beerschot    , NULL, 26, '2022-02-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@ClubBrugge    , NULL, @Charleroi    , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @StandardLuik , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @CercleBrugge , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @Antwerp      , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @STVV         , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Anderlecht   , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @Oostende     , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @Kortrijk     , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @Gent         , NULL, 27, '2022-02-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Kortrijk      , NULL, @ZulteWaregem , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Mechelen     , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @Seraing      , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @ClubBrugge   , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @StandardLuik , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @Genk         , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Beerschot    , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @Union        , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @OHL          , NULL, 28, '2022-02-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@Beerschot     , NULL, @Charleroi    , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @CercleBrugge , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @Kortrijk     , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Eupen        , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@OHL           , NULL, @Anderlecht   , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @Gent         , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Seraing      , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @Antwerp      , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @STVV         , NULL, 29, '2022-02-26 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@CercleBrugge  , NULL, @Genk         , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @Oostende     , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Mechelen     , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @OHL          , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @StandardLuik , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @ZulteWaregem , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @Union        , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @Beerschot    , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @ClubBrugge   , NULL, 30, '2022-03-05 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@OHL           , NULL, @Union        , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @Gent         , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @Charleroi    , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @Antwerp      , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @Eupen        , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @ClubBrugge   , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Kortrijk     , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @STVV         , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @Seraing      , NULL, 31, '2022-03-12 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@ClubBrugge    , NULL, @Genk         , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @Anderlecht   , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @StandardLuik , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @Mechelen     , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @CercleBrugge , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@STVV          , NULL, @Beerschot    , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Oostende     , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @OHL          , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @ZulteWaregem , NULL, 32, '2022-03-19 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@OHL           , NULL, @Antwerp      , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@CercleBrugge  , NULL, @Gent         , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ZulteWaregem  , NULL, @STVV         , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Oostende      , NULL, @Seraing      , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Mechelen      , NULL, @Kortrijk     , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Genk          , NULL, @Eupen        , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Beerschot     , NULL, @ClubBrugge   , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@StandardLuik  , NULL, @Union        , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Anderlecht    , NULL, @Charleroi    , NULL, 33, '2022-04-02 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  
  (@STVV          , NULL, @StandardLuik , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@ClubBrugge    , NULL, @Mechelen     , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Antwerp       , NULL, @CercleBrugge , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Kortrijk      , NULL, @Anderlecht   , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Seraing       , NULL, @Genk         , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Union         , NULL, @Beerschot    , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Gent          , NULL, @OHL          , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Charleroi     , NULL, @ZulteWaregem , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (@Eupen         , NULL, @Oostende     , NULL, 34, '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed')
