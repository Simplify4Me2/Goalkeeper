IF NOT EXISTS(
    SELECT schema_name
    FROM information_schema.schemata
    WHERE   schema_name = 'EventStore')
BEGIN
    EXEC sp_executesql N'CREATE SCHEMA EventStore'
END

GO

IF NOT EXISTS(
    SELECT schema_name
    FROM information_schema.schemata
    WHERE   schema_name = 'Stats')
BEGIN
    EXEC sp_executesql N'CREATE SCHEMA Stats'
END
