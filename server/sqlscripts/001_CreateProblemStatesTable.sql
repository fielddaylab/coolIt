/**
*  To be run against CoolIt database
*  New table added in version 2.15 of the CoolIt Web Service
*/
/****** Object:  Table [dbo].[ProblemStates]    Script Date: 02/24/2010 14:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProblemStates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[timestamp] [datetime] NULL,
	[powerFactor] [float] NULL,
	[cost] [float] NULL,
	[stressLimit] [float] NULL,
	[temperature] [float] NULL,
	[isValidSolution] [bit] NULL,
	[episodeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProblemStates]  WITH CHECK ADD  CONSTRAINT [FK6EAE3E03A7A20398] FOREIGN KEY([episodeId])
REFERENCES [dbo].[Episodes] ([id])
GO
ALTER TABLE [dbo].[ProblemStates] CHECK CONSTRAINT [FK6EAE3E03A7A20398]