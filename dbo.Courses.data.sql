SET IDENTITY_INSERT [dbo].[Courses] ON
INSERT INTO [dbo].[Courses] ([Id], [CourseName], [Price], [HoursToComplete]) VALUES (1, N'algorithm', CAST(5225.00 AS Decimal(15, 2)), 22)
INSERT INTO [dbo].[Courses] ([Id], [CourseName], [Price], [HoursToComplete]) VALUES (2, N'DataStructuers', CAST(666.00 AS Decimal(15, 2)), 105)
INSERT INTO [dbo].[Courses] ([Id], [CourseName], [Price], [HoursToComplete]) VALUES (5, N'Design Pattern', CAST(789.00 AS Decimal(15, 2)), 8)
INSERT INTO [dbo].[Courses] ([Id], [CourseName], [Price], [HoursToComplete]) VALUES (6, N'Cs50', CAST(123.00 AS Decimal(15, 2)), 32)
INSERT INTO [dbo].[Courses] ([Id], [CourseName], [Price], [HoursToComplete]) VALUES (7, N'OOP', CAST(123.00 AS Decimal(15, 2)), 8)
SET IDENTITY_INSERT [dbo].[Courses] OFF
