
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Stats].[Matches](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HomeTeamId] [bigint] NOT NULL,
	[HomeTeamScore] [int] NULL,
	[AwayTeamId] [bigint] NOT NULL,
	[AwayTeamScore] [int] NULL,
	[Matchday] [int] NOT NULL,
	[DateUtc] [datetime2](7) NOT NULL,
	[CreatedUtc] [datetime2](7) NOT NULL DEFAULT GETDATE(),
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Stats].[Matches] 
ADD CONSTRAINT [FK_Matches_HomeTeam_Teams] FOREIGN KEY ([HomeTeamId]) REFERENCES [Stats].[Teams] ([Id])

GO 

ALTER TABLE [Stats].[Matches] 
ADD CONSTRAINT [FK_Matches_AwayTeam_Teams] FOREIGN KEY ([AwayTeamId]) REFERENCES [Stats].[Teams] ([Id])

GO
