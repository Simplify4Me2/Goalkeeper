INSERT INTO Stats.Teams
([Name], [StadiumId], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  ('Union', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Bosuilstadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed')
, ('RFC Seraing', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Pairaystadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
