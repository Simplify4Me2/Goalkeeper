INSERT INTO [Stats].[Matches]
([HomeTeamId], [HomeTeamScore], [AwayTeamId], [AwayTeamScore], [Matchday], [DateUtc], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 0, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Charleroi Sporting Club%'), 1, 1, '2020-08-08 16:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Excel Moeskroen%'), 1, 1, '2020-08-08 19:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Standard Luik%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Cercle Brugge%'), 0, 1, '2020-08-08 19:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Sint-Truidense VV%'), 2, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 1, 1, '2020-08-09 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%SV Zulte Waregem%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KRC Genk%'), 2, 1, '2020-08-09 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Mechelen%'), 2, (SELECT Id FROM Stats.Teams WHERE [Name] like '%RSC Anderlecht%'), 2, 1, '2020-08-09 18:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Kortrijk%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KVRS Waasland - SK Beveren%'), 3, 1, '2020-08-09 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Oostende%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Beerschot VA%'), 2, 1, '2020-08-10 19:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Oud-Heverlee Leuven%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KAS Eupen%'), 1, 1, '2020-08-10 19:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed')

  