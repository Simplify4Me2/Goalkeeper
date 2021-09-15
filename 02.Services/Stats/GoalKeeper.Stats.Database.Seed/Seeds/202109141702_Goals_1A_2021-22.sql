﻿DECLARE 
	@CurrentSeason BIGINT = (SELECT MAX(Id) FROM Stats.Seasons),
	@Anderlecht BIGINT =	(SELECT Id FROM Stats.Teams WHERE [Name] like '%RSC Anderlecht%'),
	@Antwerp BIGINT =		(SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'),
	@Beerschot BIGINT =		(SELECT Id FROM Stats.Teams WHERE [Name] like '%Beerschot VA%'),
	@CercleBrugge BIGINT =	(SELECT Id FROM Stats.Teams WHERE [Name] like '%Cercle Brugge%'),
	@ClubBrugge BIGINT =	(SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'),
	@Charleroi BIGINT =		(SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Charleroi Sporting Club%'),
	@Eupen BIGINT =			(SELECT Id FROM Stats.Teams WHERE [Name] like '%KAS Eupen%'),
	@Genk BIGINT =			(SELECT Id FROM Stats.Teams WHERE [Name] like '%KRC Genk%'),
	@Gent BIGINT =			(SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'),
	@Mechelen BIGINT =		(SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Mechelen%'),
	@Kortrijk BIGINT =		(SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Kortrijk%'),
	@OHL BIGINT =			(SELECT Id FROM Stats.Teams WHERE [Name] like '%Oud-Heverlee Leuven%'),
	@Oostende BIGINT =		(SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Oostende%'),
	@Seraing BIGINT =		(SELECT Id FROM Stats.Teams WHERE [Name] like '%RFC Seraing%'),
	@StandardLuik BIGINT =	(SELECT Id FROM Stats.Teams WHERE [Name] like '%Standard Luik%'),
	@STVV BIGINT =			(SELECT Id FROM Stats.Teams WHERE [Name] like '%Sint-Truidense VV%'),
	@ZulteWaregem BIGINT =	(SELECT Id FROM Stats.Teams WHERE [Name] like '%Zulte Waregem%'),
	@Union BIGINT =			(SELECT Id FROM Stats.Teams WHERE [Name] like '%Union%')

INSERT INTO [Stats].[Goals]
([Minute], [Extra], [Penalty] [PlayerId], [TeamId], [MatchId], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  (69, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Laifis%' AND [FirstName] like '%Konstantinos%'),		@StandardLuik, 	(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @StandardLuik 	AND [AwayTeamId] = @Genk 			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (90, 2, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Bongonda%' AND [FirstName] like '%Théo%'), 			@Genk, 			(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @StandardLuik 	AND [AwayTeamId] = @Genk 			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (24, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Vossen%' AND [FirstName] like '%Jelle%'), 			@ZulteWaregem, 	(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @OHL			AND [AwayTeamId] = @ZulteWaregem 	AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  (42, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Henry%' AND [FirstName] like '%Thomas%'), 			@OHL, 			(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @OHL 			AND [AwayTeamId] = @ZulteWaregem 	AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (31, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Chevalier%' AND [FirstName] like '%Teddy%'),			@Kortrijk, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Kortrijk 		AND [AwayTeamId] = @Seraing			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (88, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Selemani%' AND [FirstName] like '%Faïz%'),			@Kortrijk, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Kortrijk 		AND [AwayTeamId] = @Seraing			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (7, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Bedia%' AND [FirstName] like '%Chris%'),				@Charleroi, 	(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Oostende		AND [AwayTeamId] = @Charleroi 		AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (50, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Zaroury%' AND [FirstName] like '%Anass%'),			@Charleroi, 	(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Oostende		AND [AwayTeamId] = @Charleroi 		AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (85, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Kayembe%' AND [FirstName] like '%Joris%'), 			@Charleroi, 	(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Oostende		AND [AwayTeamId] = @Charleroi 		AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (18, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Frey%' AND [FirstName] like '%Michael%'),				@Antwerp, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Mechelen		AND [AwayTeamId] = @Antwerp 		AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (56, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Benson%' AND [FirstName] like '%Manuel%'),			@Antwerp, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Mechelen		AND [AwayTeamId] = @Antwerp 		AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (60, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%De Laet%' AND [FirstName] like '%Ritchie%'),			@Mechelen, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Mechelen 		AND [AwayTeamId] = @Antwerp			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (73, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Druijf%' AND [FirstName] like '%Ferdy%'),				@Mechelen, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Mechelen 		AND [AwayTeamId] = @Antwerp			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (74, NULL, 0,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Druijf%' AND [FirstName] like '%Ferdy%'),				@Mechelen, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @Mechelen 		AND [AwayTeamId] = @Antwerp			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (56, NULL, 1,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Dost%' AND [FirstName] like '%Bas%'),					@ClubBrugge, 	(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @ClubBrugge	AND [AwayTeamId] = @Eupen			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (60, NULL, 1,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Kayembe%' AND [FirstName] like '%Edo%'),				@Eupen, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @ClubBrugge	AND [AwayTeamId] = @Eupen			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (77, NULL, 1,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Ngoy%' AND [FirstName] like '%Julien%'),				@Eupen, 		(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @ClubBrugge	AND [AwayTeamId] = @Eupen			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  (90, 13, 1,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%De Ketelaere%' AND [FirstName] like '%Charles%'),		@ClubBrugge, 	(SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @ClubBrugge	AND [AwayTeamId] = @Eupen			AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  