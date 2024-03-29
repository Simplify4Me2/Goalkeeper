﻿INSERT INTO Stats.Teams
([Name], [StadiumId], CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy)
VALUES
  ('Royal Antwerp FC', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Bosuilstadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed')
, ('Club Brugge', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Jan Breydelstadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('KAA Gent', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Ghelamco Arena%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('Cercle Brugge', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Jan Breydelstadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('Beerschot VA', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Olympisch Stadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('Standard Luik', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Maurice Dufrasnestadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('Oud-Heverlee Leuven', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%King Power at Den Dreef%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('KV Kortrijk', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Guldensporenstadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('Royal Charleroi Sporting Club', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Stade du Pays de Charleroi%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('KV Mechelen', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%AFAS Stadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('KV Oostende', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Diaz Arena%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('RSC Anderlecht', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Lotto Park%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('Royal Excel Moeskroen', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Le Canonnier%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('KRC Genk', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Luminus Arena%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('Sint-Truidense VV', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Stayen%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('KVRS Waasland - SK Beveren', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Freethielstadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('KAS Eupen', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Kehrweg-Stadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('SV Zulte Waregem', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Regenboogstadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
, ('Union', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Joseph Marien Stadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed')
, ('RFC Seraing', (SELECT Id FROM [Stats].Stadiums WHERE [Name] like '%Pairaystadion%'), GETDATE(), 'Seed', GETDATE(), 'Seed') 
