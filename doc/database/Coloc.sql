-- Date: Feb 2019
-- Author: X. Carrel
-- Goal: Creates the Coloc DB as ASP course material

USE master
GO

-- First delete the database if it exists
IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Coloc'))
BEGIN
	USE master
	ALTER DATABASE Coloc SET SINGLE_USER WITH ROLLBACK IMMEDIATE; -- Disconnect users the hard way (we cannot drop the db if someone's connected)
	DROP DATABASE Coloc -- Destroy it
END
GO

-- Second ensure we have the proper directory structure
SET NOCOUNT ON;
GO
CREATE TABLE #ResultSet (Directory varchar(200)) -- Temporary table (name starts with #) -> will be automatically destroyed at the end of the session

INSERT INTO #ResultSet EXEC master.sys.xp_subdirs 'c:\' -- Stored procedure that lists subdirectories

(Select * FROM #ResultSet where Directory = 'DATA')
	EXEC master.sys.xp_create_subdir 'C:\DATA\' -- create DATA

DELETE FROM #ResultSet -- start over for MSSQL subdir
INSERT INTO #ResultSet EXEC master.sys.xp_subdirs 'c:\DATA'

(Select * FROM #ResultSet where Directory = 'MSSQL')
	EXEC master.sys.xp_create_subdir 'C:\DATA\MSSQL'

DROP TABLE #ResultSet -- Explicitely delete it because the script may be executed multiple times during the same session
GO

-- Everything is ready, we can create the db
CREATE DATABASE Coloc ON  PRIMARY 
( NAME = 'Coloc_data', FILENAME = 'C:\DATA\MSSQL\Coloc.mdf' , SIZE = 20480KB , MAXSIZE = 51200KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = 'Coloc_log', FILENAME = 'C:\DATA\MSSQL\Coloc.ldf' , SIZE = 10240KB , MAXSIZE = 20480KB , FILEGROWTH = 1024KB )

GO

-- Create tables 

USE Coloc
GO

CREATE TABLE roles (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL)

CREATE TABLE users (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  firstname VARCHAR(255) NULL DEFAULT NULL,
  email VARCHAR(255) UNIQUE NOT NULL,
  password VARCHAR(255) NOT NULL)

CREATE TABLE role_user (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  role_id INT NOT NULL,
  user_id INT NOT NULL,
  CONSTRAINT role_user_role_id_foreign
    FOREIGN KEY (role_id)
    REFERENCES roles (id),
  CONSTRAINT role_user_user_id_foreign
    FOREIGN KEY (user_id)
    REFERENCES users (id))

CREATE TABLE todos (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  description TEXT NOT NULL)

CREATE TABLE tasks (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  description TEXT NOT NULL,
  todo_id INT NOT NULL,
  CONSTRAINT tasks_fktodo_foreign
    FOREIGN KEY (todo_id)
    REFERENCES todos (id))

CREATE TABLE user_task (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  task_id INT NOT NULL,
  user_id INT NOT NULL,
  beginTask DATETIME NOT NULL,
  endTask DATETIME NOT NULL,
  finishTask DATETIME NULL DEFAULT NULL,
  state TINYINT NOT NULL,
  CONSTRAINT user_task_task_id_foreign
    FOREIGN KEY (task_id)
    REFERENCES tasks (id),
  CONSTRAINT user_task_user_id_foreign
    FOREIGN KEY (user_id)
    REFERENCES users (id))
