/**
*  To be run against CoolIt database
*  New table added in version 2.15 of the CoolIt Web Service
*/
/****** Object:  Table [dbo].[StrutStates]    Script Date: 02/24/2010 14:32:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StrutStates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[length] [float] NULL,
	[crossSection] [float] NULL,
	[materialId] [int] NOT NULL,
	[problemStateId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[StrutStates]  WITH CHECK ADD  CONSTRAINT [FK14CF574E60C0475F] FOREIGN KEY([problemStateId])
REFERENCES [dbo].[ProblemStates] ([id])
GO
ALTER TABLE [dbo].[StrutStates] CHECK CONSTRAINT [FK14CF574E60C0475F]
GO
ALTER TABLE [dbo].[StrutStates]  WITH CHECK ADD  CONSTRAINT [FK14CF574E922DF342] FOREIGN KEY([materialId])
REFERENCES [dbo].[Materials] ([id])
GO
ALTER TABLE [dbo].[StrutStates] CHECK CONSTRAINT [FK14CF574E922DF342]