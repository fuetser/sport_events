-- Создание таблицы Sports
CREATE TABLE Sports (
    SportId SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
);

-- Создание таблицы Venues
CREATE TABLE Venues (
    VenueId SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Location VARCHAR(255),
    Capacity INT
);

-- Создание таблицы Organizers
CREATE TABLE Organizers (
    OrganizerId SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    ContactInfo VARCHAR(255)
);

-- Создание таблицы Participants
CREATE TABLE Participants (
    ParticipantId SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Age INT,
    Gender VARCHAR(50)
);

-- Создание таблицы Teams
CREATE TABLE Teams (
    TeamId SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
);

-- Создание таблицы Events
CREATE TABLE Events (
    EventId SERIAL PRIMARY KEY,
    SportId INT,
    VenueId INT,
    OrganizerId INT,
    StartTime TIMESTAMP,
    EndTime TIMESTAMP,
    FOREIGN KEY (SportId) REFERENCES Sports(SportId),
    FOREIGN KEY (VenueId) REFERENCES Venues(VenueId),
    FOREIGN KEY (OrganizerId) REFERENCES Organizers(OrganizerId)
);

-- Создание таблицы EventParticipants (многие ко многим для Events и Participants)
CREATE TABLE EventParticipants (
    EventId INT,
    ParticipantId INT,
    FOREIGN KEY (EventId) REFERENCES Events(EventId),
    FOREIGN KEY (ParticipantId) REFERENCES Participants(ParticipantId),
    PRIMARY KEY (EventId, ParticipantId)
);

-- Создание таблицы TeamMembers (многие ко многим для Teams и Participants)
CREATE TABLE TeamMembers (
    TeamId INT,
    ParticipantId INT,
    FOREIGN KEY (TeamId) REFERENCES Teams(TeamId),
    FOREIGN KEY (ParticipantId) REFERENCES Participants(ParticipantId),
    PRIMARY KEY (TeamId, ParticipantId)
);

