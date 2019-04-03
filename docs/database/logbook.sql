use Coloc
GO

Create table logbook (
	id int identity primary key,
	aspNetUser_id nvarchar(450),
	moment datetime,
	eventdescription text
)
GO

ALTER TABLE logbook ADD CONSTRAINT fk_madeby FOREIGN KEY (aspNetUser_id) REFERENCES AspNetUsers(id)
