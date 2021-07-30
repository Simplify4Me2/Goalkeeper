
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Stats].[Stadiums](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PictureUrl] [nvarchar](max) NULL,
	[CreatedUtc] [datetime2](7) NOT NULL DEFAULT GETDATE(),
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Stadiums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Stats].[Teams] ADD [StadiumId] BIGINT NOT NULL

GO

ALTER TABLE [Stats].[Teams]
ADD CONSTRAINT [FK_Teams_Stadiums] FOREIGN KEY ([StadiumId]) REFERENCES [Stats].[Stadiums] ([Id])

GO