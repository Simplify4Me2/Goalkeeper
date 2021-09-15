DECLARE 
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
([Minute], [Extra], [PlayerId], [MatchId], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  ('69', NULL,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Laifis%'), (SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @StandardLuik AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ('90', '2',	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Bongonda%'), (SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [AwayTeamId] = @Genk AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ('24', NULL,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Vossen%'), (SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [AwayTeamId] = @ZulteWaregem AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ('42', NULL,	(SELECT Id FROM Stats.Players WHERE [LastName] like '%Henry%'), (SELECT match.Id FROM Stats.Matches match JOIN Stats.Seasons season ON season.Id =@CurrentSeason WHERE [Matchday] = 1 AND [HomeTeamId] = @OHL AND match.DateUtc BETWEEN season.StartUtc AND season.EndUtc), GETDATE(), 'Seed', GETDATE(), 'Seed')
  