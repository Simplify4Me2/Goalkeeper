INSERT INTO Stats.Seasons
([StartUtc], [EndUtc], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  ('2020-08-08 00:00:00.0000000', '2021-05-23 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ('2021-07-23 00:00:00.0000000', '2022-04-09 00:00:00.0000000', GETDATE(), 'Seed', GETDATE(), 'Seed')

INSERT INTO Stats.SeasonTeams
([SeasonId], [TeamId], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Royal Antwerp FC%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Club Brugge%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KAA Gent%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Cercle Brugge%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Beerschot VA%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Standard Luik%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Oud-Heverlee Leuven%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KV Kortrijk%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Royal Charleroi Sporting Club%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KV Mechelen%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KV Oostende%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%RSC Anderlecht%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Royal Excel Moeskroen%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KRC Genk%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Sint-Truidense VV%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KVRS Waasland - SK Beveren%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KAS Eupen%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2020 AND YEAR([EndUtc]) = 2021), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%SV Zulte Waregem%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),

  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Royal Antwerp FC%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Club Brugge%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KAA Gent%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Cercle Brugge%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Beerschot VA%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Standard Luik%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Oud-Heverlee Leuven%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KV Kortrijk%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Royal Charleroi Sporting Club%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KV Mechelen%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KV Oostende%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%RSC Anderlecht%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KRC Genk%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Sint-Truidense VV%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%KAS Eupen%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%SV Zulte Waregem%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%Union%'), GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ((SELECT Id FROM [Stats].Seasons WHERE YEAR([StartUtc]) = 2021 AND YEAR([EndUtc]) = 2022), (SELECT Id FROM [Stats].Teams WHERE [Name] like '%RFC Seraing%'), GETDATE(), 'Seed', GETDATE(), 'Seed')
