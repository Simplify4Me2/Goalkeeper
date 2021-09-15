SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Stats].[Goals](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
    [MatchId] [bigint] NOT NULL,
    [PlayerId] [bigint] NOT NULL,
	[Minute] [int] NOT NULL,
	[Extra] [int] NULL,
	[CreatedUtc] [datetime2](7) NOT NULL DEFAULT GETDATE(),
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Goals] PRIMARY KEY CLUSTERED ([Id] ASC) 
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [FK_Goals_Players] FOREIGN KEY ([PlayerId]) REFERENCES [Stats].[Players] ([Id])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO