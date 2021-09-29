INSERT INTO dbo.Countries
(TwoLetterISOCode, [Name], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  ('BE', 'Belgium',		GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ('PT', 'Portugal',	GETDATE(), 'Seed', GETDATE(), 'Seed'),
  ('SN', 'Senegal',		GETDATE(), 'Seed', GETDATE(), 'Seed')