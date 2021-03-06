/**
*  To be run against CoolIt database
*  New table added in version 2.15 of the CoolIt Web Service
*/
/****** Object:  Table [dbo].[CoolerStates]    Script Date: 02/24/2010 14:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoolerStates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[inputPower] [float] NULL,
	[coolerId] [int] NOT NULL,
	[problemStateId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CoolerStates]  WITH CHECK ADD  CONSTRAINT [FK42B78FE860C0475F] FOREIGN KEY([problemStateId])
REFERENCES [dbo].[ProblemStates] ([id])
GO
ALTER TABLE [dbo].[CoolerStates] CHECK CONSTRAINT [FK42B78FE860C0475F]
GO
ALTER TABLE [dbo].[CoolerStates]  WITH CHECK ADD  CONSTRAINT [FK42B78FE8B2701F5E] FOREIGN KEY([coolerId])
REFERENCES [dbo].[Coolers] ([id])
GO
ALTER TABLE [dbo].[CoolerStates] CHECK CONSTRAINT [FK42B78FE8B2701F5E]