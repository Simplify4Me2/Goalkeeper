SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persons](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max)NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Nationality] [bigint] NULL,
	[CreatedUtc] [datetime2](7) NOT NULL DEFAULT GETDATE(),
	[CreatedBy] [nvarchar](max) NOT NULL,
	[ModifiedUtc] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([Id] ASC) 
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [FK_Persons_Countries] FOREIGN KEY ([Nationality]) REFERENCES [dbo].[Countries] ([Id])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO