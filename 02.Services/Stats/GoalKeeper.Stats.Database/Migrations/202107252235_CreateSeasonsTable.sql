
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Stats].[Seasons](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StartUtc] [datetime2](7) NOT NULL,
	[EndUtc] [datetime2](7) NOT NULL,
	[CreatedUtc] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Seasons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [Stats].[SeasonTeams](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SeasonId] [bigint] NOT NULL,
	[TeamId] [bigint] NOT NULL,
	[CreatedUtc] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_SeasonTeams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Stats].[SeasonTeams] 
ADD CONSTRAINT [FK_SeasonTeams_SeasonId_Seasons] FOREIGN KEY ([SeasonId]) REFERENCES [Stats].[Seasons] ([Id])

GO 

ALTER TABLE [Stats].[SeasonTeams] 
ADD CONSTRAINT [FK_SeasonTeams_TeamId_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Stats].[Teams] ([Id])

GO 

