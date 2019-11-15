

CREATE TABLE [dbo].[Bookings] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [RoomId]   INT            NOT NULL,
	[CustomerId]   NVARCHAR (128)       NOT NULL,
    [Price]        NVARCHAR (MAX) NOT NULL,
    [NumOfPeople] NVARCHAR (MAX) NOT NULL,
	[Description]        NVARCHAR (MAX) NOT NULL,
    [BookingDate]        datetime NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]),
	FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

CREATE TABLE [dbo].[Ratings] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [ShipId]   INT NOT NULL,
	[CustomerId] NVARCHAR (128) NOT NULL,
	[Rating]  Decimal(18,2) NOT NULL,
	[Description]        NVARCHAR (MAX) NOT NULL,
    [PublishDate]     datetime NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ShipId]) REFERENCES [dbo].[Ships] ([Id]),
	FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);