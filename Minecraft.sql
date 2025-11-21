-- Setup: Create and use the database
CREATE DATABASE _Minecraft;
GO
USE _Minecraft;
GO 

-- Account Table
CREATE TABLE Account (
    uID INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(20) NOT NULL,
    charName NVARCHAR(50) NOT NULL UNIQUE
);

-- Mode Table
CREATE TABLE Mode (
    mID INT IDENTITY(1,1) PRIMARY KEY,
    mName NVARCHAR(50) NOT NULL
);

-- Play Table (References Account, Mode)
CREATE TABLE Play (
    pID INT IDENTITY(1,1) PRIMARY KEY,
    uID INT NOT NULL FOREIGN KEY REFERENCES Account(uID),
    mID INT NOT NULL FOREIGN KEY REFERENCES Mode(mID),
    worldName NVARCHAR(30) NOT NULL,
    time DATE NOT NULL,
    exp INT DEFAULT 0,
    hunger FLOAT,
    health FLOAT
);

-- Item Table
CREATE TABLE Item (
    iID INT IDENTITY(1,1) PRIMARY KEY,
    iName NVARCHAR(50) NOT NULL UNIQUE,
    iImg NVARCHAR(255),
    iPrice INT DEFAULT 0,
    iKind INT DEFAULT 0
);

-- Inventory Table (References Play, Item)
CREATE TABLE Inventory (
    inID INT IDENTITY(1,1) PRIMARY KEY,
    pID INT NOT NULL FOREIGN KEY REFERENCES Play(pID),
    iID INT NOT NULL FOREIGN KEY REFERENCES Item(iID),
    quantity INT DEFAULT 0
);

-- Resource Table
CREATE TABLE Resource (
    rID INT IDENTITY(1,1) PRIMARY KEY,
    rName NVARCHAR(30) NOT NULL,
    rImg NVARCHAR(255)
);

-- PlayResource Table (References Play, Resource)
CREATE TABLE PlayResource (
    prID INT IDENTITY(1,1) PRIMARY KEY,
    pID INT NOT NULL FOREIGN KEY REFERENCES Play(pID),
    rID INT NOT NULL FOREIGN KEY REFERENCES Resource(rID),
    quantity INT DEFAULT 0
);

-- Recipe Table (References Item)
CREATE TABLE Recipe (
    rcID INT IDENTITY(1,1) PRIMARY KEY,
    rcName NVARCHAR(100),
    iID INT NOT NULL FOREIGN KEY REFERENCES Item(iID)
);

-- RecipeDetail Table (References Resource, Recipe)
CREATE TABLE RecipeDetail (
    rcldID INT IDENTITY(1,1) PRIMARY KEY,
    rID INT NOT NULL FOREIGN KEY REFERENCES Resource(rID),
    rcID INT NOT NULL FOREIGN KEY REFERENCES Recipe(rcID),
    quantity INT DEFAULT 1
);

-- Quest Table (References Item, Mode)
CREATE TABLE Quest (
    qID INT IDENTITY(1,1) PRIMARY KEY,
    qName VARCHAR(50) NOT NULL UNIQUE,
    exp INT,
    iID INT FOREIGN KEY REFERENCES Item(iID),
    mID INT FOREIGN KEY REFERENCES Mode(mID)
);

-- DoQuest Table (References Quest, Play)
CREATE TABLE DoQuest (
    dqID INT IDENTITY(1,1) PRIMARY KEY,
    status BIT,
    time DATE,
    qID INT NOT NULL FOREIGN KEY REFERENCES Quest(qID),
    pID INT NOT NULL FOREIGN KEY REFERENCES Play(pID)
);

-- Craft Table (References Play, Recipe)
CREATE TABLE Craft (
    cID INT IDENTITY(1,1) PRIMARY KEY,
    pID INT NOT NULL FOREIGN KEY REFERENCES Play(pID),
    rcID INT NOT NULL FOREIGN KEY REFERENCES Recipe(rcID),
    time DATE
);


-- DML (Data Manipulation Language)

-- Account
INSERT INTO Account (email, password, charName)
VALUES 
('user1@gmail.com', 'pass123', N'HeroOne'),
('user2@gmail.com', 'pass456', N'HeroTwo'),
('user3@gmail.com', 'pass789', N'HeroThree'),
('user4@gmail.com', 'pass321', N'HeroFour'),
('user5@gmail.com', 'pass654', N'HeroFive'),
('user6@gmail.com', 'pass987', N'HeroSix'),
('user7@gmail.com', 'pass111', N'HeroSeven'),
('user8@gmail.com', 'pass222', N'HeroEight'),
('user9@gmail.com', 'pass333', N'HeroNine'),
('user10@gmail.com', 'pass444', N'HeroTen');

-- Mode
INSERT INTO Mode (mName)
VALUES 
(N'Adventure'), (N'Survival'), (N'Creative'), (N'Hardcore'),
(N'Battle Royale'), (N'Co-op'), (N'PVE'), (N'PVP'),
(N'Custom'), (N'Tutorial');

-- Play
INSERT INTO Play (uID, mID, worldName, time, exp, hunger, health)
VALUES
(1, 1, N'WorldOne', '2024-11-20', 500, 90.5, 100),
(2, 2, N'WorldTwo', '2024-11-19', 300, 80.0, 90),
(3, 3, N'WorldThree', '2024-11-18', 100, 70.0, 85),
(4, 4, N'WorldFour', '2024-11-17', 200, 75.0, 95),
(5, 5, N'WorldFive', '2024-11-16', 400, 85.0, 88),
(6, 6, N'WorldSix', '2024-11-15', 350, 95.0, 100),
(7, 7, N'WorldSeven', '2024-11-14', 250, 65.0, 78),
(8, 8, N'WorldEight', '2024-11-13', 150, 70.0, 82),
(9, 9, N'WorldNine', '2024-11-12', 100, 60.0, 75),
(10, 10, N'WorldTen', '2024-11-11', 50, 50.0, 70);

-- Item
INSERT INTO Item (iName, iImg, iPrice, iKind)
VALUES 
(N'Sword', N'sword.png', 100, 1),
(N'Armor', N'armor.png', 200, 1),
(N'Potion', N'potion.png', 50, 0),
(N'Food', N'food.png', 30, 0),
(N'Axe', N'axe.png', 150, 1),
(N'Pickaxe', N'pickaxe.png', 180, 1),
(N'Helmet', N'helmet.png', 80, 1),
(N'Shield', N'shield.png', 120, 1),
(N'Toolkit', N'toolkit.png', 90, 0),
(N'MagicWand', N'magicwand.png', 250, 1);

-- Inventory
INSERT INTO Inventory (pID, iID, quantity)
VALUES
(1, 1, 5), (1, 2, 2), (2, 3, 10), (3, 4, 7), (4, 5, 3),
(5, 6, 1), (6, 7, 4), (7, 8, 2), (8, 9, 8), (9, 10, 6);

-- Resource
INSERT INTO Resource (rName, rImg)
VALUES
(N'Wood', 'wood.png'),
(N'Stone', 'stone.png'),
(N'Iron', 'iron.png'),
(N'Gold', 'gold.png'),
(N'Diamond', 'diamond.png'),
(N'Coal', 'coal.png'),
(N'Clay', 'clay.png'),
(N'Sand', 'sand.png'),
(N'Water', 'water.png'),
(N'Air', 'air.png');

-- PlayResource
INSERT INTO PlayResource (pID, rID, quantity)
VALUES
(1, 1, 50), (1, 2, 30), (2, 3, 20), (3, 4, 10), (4, 5, 5),
(5, 6, 15), (6, 7, 25), (7, 8, 40), (8, 9, 35), (9, 10, 60);

-- Recipe
INSERT INTO Recipe (rcName, iID)
VALUES
(N'Iron Sword Recipe', 1),
(N'Gold Armor Recipe', 2),
(N'Health Potion Recipe', 3),
(N'Food Recipe', 4),
(N'Axe Recipe', 5),
(N'Pickaxe Recipe', 6),
(N'Helmet Recipe', 7),
(N'Shield Recipe', 8),
(N'Toolkit Recipe', 9),
(N'Magic Wand Recipe', 10);

-- RecipeDetail
INSERT INTO RecipeDetail (rID, rcID, quantity)
VALUES
(1, 1, 10), (2, 2, 15), (3, 3, 5), (4, 4, 3), (5, 5, 8),
(6, 6, 6), (7, 7, 4), (8, 8, 7), (9, 9, 12), (10, 10, 20);

-- Quest
INSERT INTO Quest (qName, exp, iID, mID)
VALUES
(N'Gather Resources', 100, 1, 1),
(N'Build a Shelter', 200, 2, 2),
(N'Hunt Animals', 150, 3, 3),
(N'Explore the World', 300, 4, 4),
(N'Fight Monsters', 250, 5, 5),
(N'Craft Tools', 180, 6, 6),
(N'Protect Village', 220, 7, 7),
(N'Find Treasure', 400, 8, 8),
(N'Save Hostages', 350, 9, 9),
(N'Defeat Boss', 500, 10, 10);

-- DoQuest
INSERT INTO DoQuest (status, time, qID, pID)
VALUES
(1, '2024-11-10', 1, 1),
(0, '2024-11-11', 2, 2),
(1, '2024-11-12', 3, 3),
(1, '2024-11-13', 4, 4),
(0, '2024-11-14', 5, 5),
(1, '2024-11-15', 6, 6),
(1, '2024-11-16', 7, 7),
(0, '2024-11-17', 8, 8),
(1, '2024-11-18', 9, 9),
(0, '2024-11-19', 10, 10);

-- Craft
INSERT INTO Craft (pID, rcID, time)
VALUES
(1, 1, '2024-11-01'), (2, 2, '2024-11-02'), (3, 3, '2024-11-03'),
(4, 4, '2024-11-04'), (5, 5, '2024-11-05'), (6, 6, '2024-11-06'),
(7, 7, '2024-11-07'), (8, 8, '2024-11-08'), (9, 9, '2024-11-09'),
(10, 10, '2024-11-10');
