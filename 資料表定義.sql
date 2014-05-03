CREATE TABLE [dbo].[CodeNote](
	[CodeNoteID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](64) NULL,
	[Language] [nvarchar](32) NULL,
	[Description] [ntext] NULL,
	[Context] [ntext] NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_CodeNote] PRIMARY KEY CLUSTERED 
(
	[CodeNoteID] ASC
)ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
