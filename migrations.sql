
-- Run this SQL if you don't want to use EF CLI migrations and just want DB + tables directly

CREATE DATABASE AxioSeraOrchestration;
GO

USE AxioSeraOrchestration;
GO

-- Roles Table
CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- Users Table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    RoleId INT FOREIGN KEY REFERENCES Roles(Id)
);

-- Categories Table
CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX)
);

-- Tenants Table
CREATE TABLE Tenants (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    ConnectionString NVARCHAR(MAX)
);

-- Workflow Simulations Table
CREATE TABLE WorkflowSimulations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    WorkflowName NVARCHAR(200),
    Status NVARCHAR(50),
    StartedAt DATETIME,
    CompletedAt DATETIME NULL
);
