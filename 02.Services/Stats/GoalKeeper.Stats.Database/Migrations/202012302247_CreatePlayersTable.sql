SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Stats].[Players](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
    [TeamId] [bigint] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
    [ShirtNumber] [int] NULL,
	[Position] [nvarchar](5) NULL,
	[CreatedUtc] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED ([Id] ASC) 
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [FK_Players_Teams] FOREIGN KEY ([TeamId]) REFERENCES [Stats].[Teams] ([Id])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
