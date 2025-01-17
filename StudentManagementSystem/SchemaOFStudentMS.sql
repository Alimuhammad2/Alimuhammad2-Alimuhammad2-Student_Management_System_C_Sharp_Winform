create database StudentMS 
USE [StudentMS]
GO
/****** Object:  Table [dbo].[AdminTbl]    Script Date: 5/17/2024 10:05:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseDetails]    Script Date: 5/17/2024 10:05:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseDetails](
	[CourseDetailId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[RegistrationId] [int] NULL,
	[EnrollmentDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 5/17/2024 10:05:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 5/17/2024 10:05:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Age] [nvarchar](50) NOT NULL,
	[Enrollment] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[DateOfBirth] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminTbl] ON 

INSERT [dbo].[AdminTbl] ([Id], [Name], [Password]) VALUES (1, N'Admin', N'12345')
SET IDENTITY_INSERT [dbo].[AdminTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseDetails] ON 

INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (6, 10, 5, CAST(N'2024-05-17T00:14:13.720' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (7, 12, 5, CAST(N'2024-05-17T00:14:24.440' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (8, 13, 4, CAST(N'2024-05-17T00:15:00.803' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (9, 9, 4, CAST(N'2024-05-17T00:15:06.347' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (10, 11, 4, CAST(N'2024-05-17T00:39:24.817' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (11, 7, 4, CAST(N'2024-05-17T00:39:31.987' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (12, 6, 4, CAST(N'2024-05-17T00:39:33.420' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (13, 10, 8, CAST(N'2024-05-17T01:20:55.627' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (14, 7, 8, CAST(N'2024-05-17T01:20:58.317' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (15, 6, 8, CAST(N'2024-05-17T01:20:59.660' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (16, 13, 8, CAST(N'2024-05-17T01:21:02.327' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (17, 11, 8, CAST(N'2024-05-17T01:21:18.753' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (18, 11, 9, CAST(N'2024-05-17T01:38:25.863' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (19, 10, 10, CAST(N'2024-05-17T01:50:20.943' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (20, 9, 11, CAST(N'2024-05-17T21:22:16.777' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (21, 11, 11, CAST(N'2024-05-17T21:22:19.340' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (22, 12, 11, CAST(N'2024-05-17T21:22:21.217' AS DateTime))
INSERT [dbo].[CourseDetails] ([CourseDetailId], [CourseId], [RegistrationId], [EnrollmentDate]) VALUES (23, 9, 12, CAST(N'2024-05-17T21:42:42.893' AS DateTime))
SET IDENTITY_INSERT [dbo].[CourseDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseId], [CourseName]) VALUES (6, N'Mathematics')
INSERT [dbo].[Courses] ([CourseId], [CourseName]) VALUES (7, N'Physics')
INSERT [dbo].[Courses] ([CourseId], [CourseName]) VALUES (8, N'Chemistry')
INSERT [dbo].[Courses] ([CourseId], [CourseName]) VALUES (9, N'Biology')
INSERT [dbo].[Courses] ([CourseId], [CourseName]) VALUES (10, N'Computer Science')
INSERT [dbo].[Courses] ([CourseId], [CourseName]) VALUES (11, N'English Literature')
INSERT [dbo].[Courses] ([CourseId], [CourseName]) VALUES (12, N'History')
INSERT [dbo].[Courses] ([CourseId], [CourseName]) VALUES (13, N'Geography')
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Registrations] ON 

INSERT [dbo].[Registrations] ([RegistrationId], [Name], [Password], [Age], [Enrollment], [CreatedAt], [UpdatedAt], [DateOfBirth]) VALUES (4, N'Shuja', N'123', N'26', N'36E1E5A0CF', CAST(N'2024-05-17T00:11:53.780' AS DateTime), CAST(N'2024-05-17T00:11:53.780' AS DateTime), CAST(N'1998-08-16' AS Date))
INSERT [dbo].[Registrations] ([RegistrationId], [Name], [Password], [Age], [Enrollment], [CreatedAt], [UpdatedAt], [DateOfBirth]) VALUES (5, N'Ali', N'123', N'27', N'7B089660E1', CAST(N'2024-05-17T00:12:05.483' AS DateTime), CAST(N'2024-05-17T00:12:05.483' AS DateTime), CAST(N'1998-07-16' AS Date))
INSERT [dbo].[Registrations] ([RegistrationId], [Name], [Password], [Age], [Enrollment], [CreatedAt], [UpdatedAt], [DateOfBirth]) VALUES (7, N'Admin', N'admin123', N'0', N'F2763BB7F0', CAST(N'2024-05-17T00:49:51.303' AS DateTime), CAST(N'2024-05-17T00:49:51.303' AS DateTime), CAST(N'2024-05-17' AS Date))
INSERT [dbo].[Registrations] ([RegistrationId], [Name], [Password], [Age], [Enrollment], [CreatedAt], [UpdatedAt], [DateOfBirth]) VALUES (8, N'Hasnain', N'12345', N'23', N'4734EA7F35', CAST(N'2024-05-17T01:19:58.767' AS DateTime), CAST(N'2024-05-17T01:19:58.767' AS DateTime), CAST(N'2004-08-12' AS Date))
INSERT [dbo].[Registrations] ([RegistrationId], [Name], [Password], [Age], [Enrollment], [CreatedAt], [UpdatedAt], [DateOfBirth]) VALUES (9, N'Faizan', N'123', N'13', N'33033CE416', CAST(N'2024-05-17T01:38:12.430' AS DateTime), CAST(N'2024-05-17T01:38:12.430' AS DateTime), CAST(N'2024-05-17' AS Date))
INSERT [dbo].[Registrations] ([RegistrationId], [Name], [Password], [Age], [Enrollment], [CreatedAt], [UpdatedAt], [DateOfBirth]) VALUES (10, N'Ali muhammad', N'123456789', N'23', N'F46D49FEB9', CAST(N'2024-05-17T01:48:56.007' AS DateTime), CAST(N'2024-05-17T01:48:56.007' AS DateTime), CAST(N'2024-05-17' AS Date))
INSERT [dbo].[Registrations] ([RegistrationId], [Name], [Password], [Age], [Enrollment], [CreatedAt], [UpdatedAt], [DateOfBirth]) VALUES (11, N'Ghulam', N'123', N'34', N'2ADB076B49', CAST(N'2024-05-17T21:21:19.813' AS DateTime), CAST(N'2024-05-17T21:21:19.813' AS DateTime), CAST(N'1955-02-18' AS Date))
INSERT [dbo].[Registrations] ([RegistrationId], [Name], [Password], [Age], [Enrollment], [CreatedAt], [UpdatedAt], [DateOfBirth]) VALUES (12, N'Ahmed', N'12345', N'45', N'27745AF596', CAST(N'2024-05-17T21:38:15.230' AS DateTime), CAST(N'2024-05-17T21:38:15.230' AS DateTime), CAST(N'2024-05-17' AS Date))
SET IDENTITY_INSERT [dbo].[Registrations] OFF
GO
ALTER TABLE [dbo].[CourseDetails] ADD  DEFAULT (getdate()) FOR [EnrollmentDate]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[CourseDetails]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[CourseDetails]  WITH CHECK ADD FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registrations] ([RegistrationId])
GO


select * from Registrations
select * from CourseDetails
select * from Courses
select * from ImagesTable

use StudentMS
select * from Sys.tables
--truncate table ImagesTable


--Install-Package AForge.Video
--Install-Package AForge.Video.DirectShow

