USE [ParkingGarageVenice]
GO
SET IDENTITY_INSERT [dbo].[floor] ON 

INSERT [dbo].[floor] ([Id], [PhysicalFloor], [FloorType], [FloorCode]) VALUES (1, 1, 0, N'AA')
INSERT [dbo].[floor] ([Id], [PhysicalFloor], [FloorType], [FloorCode]) VALUES (2, 2, 0, N'AB')
INSERT [dbo].[floor] ([Id], [PhysicalFloor], [FloorType], [FloorCode]) VALUES (4, 3, 1, N'AC')
SET IDENTITY_INSERT [dbo].[floor] OFF
GO
SET IDENTITY_INSERT [dbo].[parking_slot] ON 

INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (1, 30000, 1, 1, N'AA001', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (2, 30000, 1, 1, N'AA002', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (3, 30000, 1, 1, N'AA003', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (4, 30000, 1, 1, N'AA004', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (5, 30000, 1, 1, N'AA005', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (6, 30000, 1, 1, N'AA006', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (7, 30000, 1, 1, N'AA007', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (8, 30000, 1, 1, N'AA008', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (9, 30000, 1, 1, N'AA009', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (10, 30000, 1, 1, N'AA010', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (11, 5500, 1, 2, N'AB001', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (12, 5500, 1, 2, N'AB002', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (13, 5500, 1, 2, N'AB003', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (14, 5500, 1, 2, N'AB004', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (15, 5500, 1, 2, N'AB005', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (16, 5500, 1, 2, N'AB006', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (17, 5500, 1, 2, N'AB007', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (18, 5500, 1, 2, N'AB008', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (19, 5500, 1, 2, N'AB009', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (20, 5500, 1, 2, N'AB010', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (21, 5500, 1, 2, N'AB011', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (22, 5500, 1, 2, N'AB012', 0)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (35, 6000, 1, 4, N'AC001', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (36, 6000, 1, 4, N'AC002', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (37, 6000, 1, 4, N'AC003', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (38, 6000, 1, 4, N'AC004', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (39, 6000, 1, 4, N'AC005', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (40, 6000, 1, 4, N'AC006', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (41, 6000, 1, 4, N'AC007', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (42, 6000, 1, 4, N'AC008', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (43, 6000, 1, 4, N'AC009', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (44, 6000, 1, 4, N'AC010', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (45, 6000, 1, 4, N'AC011', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (46, 6000, 1, 4, N'AC012', 1)
INSERT [dbo].[parking_slot] ([Id], [PricePerHour], [Status], [FloorId], [SlotCode], [VehicleType]) VALUES (47, 6000, 1, 4, N'AC013', 1)
SET IDENTITY_INSERT [dbo].[parking_slot] OFF
GO
INSERT [dbo].[roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'role_admin', N'ROLE_ADMIN', N'ROLE_ADMIN', N'1279be58-858a-4e90-b22c-7f30f30757a4')
INSERT [dbo].[roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'role_security', N'ROLE_SECURITY', N'ROLE_SECURITY', N'b1f015a7-3860-4943-93fa-b687d6118748')
GO
INSERT [dbo].[users] ([Id], [Login], [first_name], [last_name], [image_url], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f38d0c0e-78fa-4b05-a112-6aa676dd8a57', N'security', N'John', N'Jon', N'', N'security', N'SECURITY', N'security1@gmail.com', N'SECURITY1@GMAIL.COM', 0, N'$2a$11$SuIC5tlfoAOSqcSbvNwoy.K.LRt/Iqm.GsjEXbCXMxyC.XfuCY.N.', N'ERAPNLCO5LER42DCTV27W6XTFKJAPG4S', N'686295d3-1067-49f2-b7cf-a415cdc34adc', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[users] ([Id], [Login], [first_name], [last_name], [image_url], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'user-2', N'admin', N'admin', N'Administrator', N'', N'admin', N'ADMIN', N'admin@localhost', N'ADMIN@LOCALHOST', 0, N'$2a$10$gSAhZrxMllrbgj/kkK9UceBPpChGWJA7SYIb1Mqo.n5aNLq1/oRrC', N'M7JALOXTWDXSNLV5PYIDZIKJPVUQBRY6', N'a0fea38f-4c38-4f0e-8459-d81cc3018e27', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'user-2', N'role_admin')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f38d0c0e-78fa-4b05-a112-6aa676dd8a57', N'role_security')
GO
INSERT [dbo].[vehicle] ([Id], [Type], [ParkingStatus]) VALUES (N'A12345', 1, 1)
INSERT [dbo].[vehicle] ([Id], [Type], [ParkingStatus]) VALUES (N'A12346', 1, 1)
INSERT [dbo].[vehicle] ([Id], [Type], [ParkingStatus]) VALUES (N'AB123CD', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[ticket] ON 

INSERT [dbo].[ticket] ([Id], [ParkTime], [LeaveTime], [TicketFee], [VehicleId], [ParkingSlotId], [VehicleType], [Status]) VALUES (1, CAST(N'2024-04-08T13:27:29.0908608' AS DateTime2), CAST(N'2024-04-08T14:13:03.7379287' AS DateTime2), 30000, N'AB123CD', 1, 0, 1)
INSERT [dbo].[ticket] ([Id], [ParkTime], [LeaveTime], [TicketFee], [VehicleId], [ParkingSlotId], [VehicleType], [Status]) VALUES (2, CAST(N'2024-04-08T14:06:55.5043139' AS DateTime2), CAST(N'2024-04-08T14:13:04.8582916' AS DateTime2), 30000, N'AB123CD', 1, 0, 1)
INSERT [dbo].[ticket] ([Id], [ParkTime], [LeaveTime], [TicketFee], [VehicleId], [ParkingSlotId], [VehicleType], [Status]) VALUES (3, CAST(N'2024-04-09T05:03:20.1649822' AS DateTime2), CAST(N'2024-04-09T05:30:57.1392286' AS DateTime2), 6000, N'A12345', 35, 1, 1)
SET IDENTITY_INSERT [dbo].[ticket] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240407053542_FirstMigration', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240407102300_SecondMigration', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240408032839_ThirdMigration', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240408055719_FourthMigration', N'8.0.3')
GO
