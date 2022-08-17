USE [MovieDB]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 8/16/2022 9:53:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Movies]') AND type in (N'U'))
DROP TABLE [dbo].[Movies]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 8/16/2022 9:53:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[release_year] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [MovieDB]
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (51, N'Forrest Gump', N'The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.', 1994)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (75, N'The Terminal', N'An Eastern European tourist unexpectedly finds himself stranded in JFK airport, and must take up temporary residence there.', 2004)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (76, N'Cast Away', N'A FedEx executive undergoes a physical and emotional transformation after crash landing on a deserted island.', 2000)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (77, N'Captain Phillips', N'The true story of Captain Richard Phillips and the 2009 hijacking by Somali pirates of the U.S.-flagged MV Maersk Alabama, the first American cargo ship to be hijacked in two hundred years.', 2013)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (78, N'Sully', N'When pilot Chesley "Sully" Sullenberger lands his damaged plane on the Hudson River in order to save the flight''s passengers and crew, some consider him a hero while others think he was reckless.', 2016)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (79, N'Bridge of Spies', N'During the Cold War, an American lawyer is recruited to defend an arrested Soviet spy in court, and then help the CIA facilitate an exchange of the spy for the Soviet captured American U2 spy plane pilot, Francis Gary Powers.', 2015)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (80, N'The Post', N'A cover-up spanning four U.S. Presidents pushes the country''s first female newspaper publisher and her editor to join an unprecedented battle between press and government.', 2017)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (81, N'Saving Mr. Banks', N'Author P.L. Travers reflects on her childhood after reluctantly meeting with Walt Disney, who seeks to adapt her Mary Poppins books for the big screen.', 2013)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (82, N'A Beautiful Day in the Neighborhood', N'Based on the true story of a real-life friendship between Fred Rogers and journalist Lloyd Vogel.', 2019)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (83, N'Big', N'After wishing to be made big, a teenage boy wakes the next morning to find himself mysteriously in the body of an adult.', 1988)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (84, N'Apollo 13', N'NASA must devise a strategy to return Apollo 13 to Earth safely after the spacecraft undergoes massive internal damage putting the lives of the three astronauts on board in jeopardy.', 1995)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (85, N'The Da Vinci Code', N'A murder inside the Louvre, and clues in Da Vinci paintings, lead to the discovery of a religious mystery protected by a secret society for two thousand years, which could shake the foundations of Christianity.', 2006)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (86, N'Angels & Demons', N'Harvard symbologist Robert Langdon works with a nuclear physicist to solve a murder and prevent a terrorist act against the Vatican during one of the significant events within the church.', 2009)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (87, N'Inferno', N'When Robert Langdon wakes up in an Italian hospital with amnesia, he teams up with Dr. Sienna Brooks and they race across Europe together against the clock to foil a deadly global plot.', 2016)
GO
INSERT [dbo].[Movies] ([id], [name], [description], [release_year]) VALUES (88, N'Cloud Atlas', N'An exploration of how the actions of individual lives impact one another in the past, present and future, as one soul is shaped from a killer into a hero, and an act of kindness ripples across centuries to inspire a revolution.', 2012)
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO


