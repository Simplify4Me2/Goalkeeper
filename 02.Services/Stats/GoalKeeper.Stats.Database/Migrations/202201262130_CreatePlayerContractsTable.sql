SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Stats].[PlayerContracts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
    [PlayerId] [bigint] NOT NULL,
    [TeamId] [bigint] NOT NULL,
	[ShirtNumber] [int] NOT NULL,
	[StartDateUtc] [datetime2](7) NOT NULL,
	[EndDateUtc] [datetime2](7) NULL,
	[CreatedUtc] [datetime2](7) NOT NULL DEFAULT GETDATE(),
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PlayerContracts] PRIMARY KEY CLUSTERED ([Id] ASC) 
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [FK_PlayerContracts_Players] FOREIGN KEY ([PlayerId]) REFERENCES [Stats].[Players] ([Id]),
 CONSTRAINT [FK_PlayerContracts_Teams] FOREIGN KEY ([PlayerId]) REFERENCES [Stats].[Teams] ([Id])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
