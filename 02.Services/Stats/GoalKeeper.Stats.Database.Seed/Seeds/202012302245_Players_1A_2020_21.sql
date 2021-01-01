INSERT INTO Stats.Players
(TeamId, FirstName, LastName, ShirtNumber, Position, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Jean', 'Butez', 46, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Davor', 'Matijaš', 71, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Alireza', 'Beiranvand', 1, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Bruny', 'Nsimba', 22, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Guy', 'Mbenza Kamboleke', 9, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Didier', 'Lamkel Ze', 7, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Ivo', 'Rodrigues', 8, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Dieumerci', 'Mbokani', 70, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Christian', 'Benavente Bristol', 24, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Birger', 'Verstraete', 5, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Nana', 'Ampomah', 23, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Nill', 'De Pauw', 14, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Manuel', 'Benson', 28, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Koji', 'Miyoshi', 19, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Pieter', 'Gerkens', 16, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Louis', 'Verstraete', 33, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Sander', 'Cooman', 20, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Alexis', 'De Sart', 25, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Lior', 'Refaelov', 11, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Faris', 'Haroun', 38, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Dragan', 'Lausberg', 64, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Luete Ava', 'Dongo', 12, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Jordan', 'Lukaku', 94, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Jérémy', 'Gelin', 26, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Frank', 'Boya', 15, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Ritchie', 'De Laet', 2, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Júnior', 'Pius', 40, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Abdoulaye', 'Seck', 4, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Aurélio', 'Buta', 30, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Dylan', 'Batubinsika', 21, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Royal Antwerp FC%'), 'Simen', 'Juklerød', 6, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')

  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Ethan', 'Horvath', 22, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Nick', 'Shinton', 33, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Simon', 'Mignolet', 88, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Senne', 'Lammens', 91, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Eduard', 'Sobol', 2, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Odilon', 'Kossounou', 5, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Matej', 'Mitrovic', 15, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Simon', 'Deli', 17, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Federico', 'Ricca', 18, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Ignace', 'Van Der Brempt', 28, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Brandon', 'Mechele', 44, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Clinton', 'Mata', 77, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Éder', 'Balanta', 3, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Krépin', 'Diatta', 11, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Hans', 'Vanaken', 20, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Ruud', 'Vormer', 25, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Mats', 'Rits', 26, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Maxim', 'De Cuyper', 55, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Charles', 'De Ketelaere', 90, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Thomas', 'Van Den Keybus', 97, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Amadou', 'Sagna', 7, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Michael', 'krmenčík', 9, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Noa', 'Lang', 10, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Siebe', 'Schrijvers', 16, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'David', 'Okereke', 21, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Youssouph', 'Badji', 27, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Club Brugge%'), 'Emmanuel B.', 'Dennis', 42, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Sinan', 'Bolat', 1, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Colin', 'Coosemans', 26, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Davy', 'Roef', 33, 'GK', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Andreas', 'Hanche-Olsen', 0, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Michael', 'Ngadeu', 5, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Alessio', 'Castro-Montes', 14, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Milad', 'Mohammadi', 15, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Jordan', 'Botaka', 17, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Nurio', 'Fortuna', 25, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Ibrahima', 'Cissé', 28, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Bruno', 'Godeau', 31, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Igor', 'Plastun', 32, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Dino', 'Arslanagic', 36, 'DEF', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Elisha', 'Owusu', 6, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Vadis', 'Odjidja-Ofoe', 8, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Roman', 'Bezus', 9, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Giorgi', 'Chakvetadze', 10, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Wouter', 'George', 11, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Alexandre', 'De Bruyn', 12, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Matisse', 'Samoise', 19, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Sulayman', 'Marreh', 22, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Sven', 'Kums', 24, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Mathéo', 'Parmentier', 27, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Niklas', 'Dorsch', 30, 'MID', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Roman', 'Yaremchuk', 7, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Anderson', 'Niangbo', 11, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Dylan', 'Mbayo', 18, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Osman', 'Bukari', 20, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Laurent', 'Depoitre', 29, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%KAA Gent%'), 'Tim', 'Kleindienst', 34, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')

  ((SELECT Id FROM Stats.Teams WHERE [Name] like '%Cercle Brugge%'), 'Tim', 'Kleindienst', 34, 'ATT', GETDATE(), 'Seed', GETDATE(), 'Seed')
