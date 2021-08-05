INSERT INTO [Stats].[Matches]
([HomeTeamId], [HomeTeamScore], [AwayTeamId], [AwayTeamScore], [Matchday], [DateUtc], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Standard Luik%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KRC Genk%'), 1, 1, '2021-07-23 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Oud-Heverlee Leuven%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Zulte Waregem%'), 1, 1, '2021-07-24 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Kortrijk%'), 2, (SELECT Id FROM Stats.Teams WHERE [Name] like '%RFC Seraing%'), 0, 1, '2021-07-24 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Oostende%'), 0, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Charleroi Sporting Club%'), 3, 1, '2021-07-24 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Mechelen%'), 3, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 2, 1, '2021-07-25 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 2, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KAS Eupen%'), 2, 1, '2021-07-25 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%RSC Anderlecht%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Union%'), 3, 1, '2021-07-25 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Sint-Truidense VV%'), 2, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 1, 1, '2021-07-25 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Beerschot VA%'), 0, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Cercle Brugge%'), 1, 1, '2021-07-27 20:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),

  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KRC Genk%'), 3, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Oostende%'), 4, 2, '2021-07-30 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Charleroi Sporting Club%'), 0, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Sint-Truidense VV%'), 0, 2, '2021-07-31 16:15:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%RFC Seraing%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Mechelen%'), 0, 2, '2021-07-31 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Cercle Brugge%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Oud-Heverlee Leuven%'), 1, 2, '2021-07-31 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAS Eupen%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%RSC Anderlecht%'), 1, 2, '2021-07-31 20:45:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Union%'), 0, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 1, 2, '2021-08-01 13:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Zulte Waregem%'), 1, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Standard Luik%'), 2, 2, '2021-08-01 16:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 2, (SELECT Id FROM Stats.Teams WHERE [Name] like '%Beerschot VA%'), 2, 2, '2021-08-01 18:30:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 0, (SELECT Id FROM Stats.Teams WHERE [Name] like '%KV Kortrijk%'), 1, 2, '2021-08-01 21:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed')
