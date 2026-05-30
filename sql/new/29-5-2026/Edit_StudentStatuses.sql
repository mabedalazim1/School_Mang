use KPS_DATA_2023;
Go
DBCC CHECKIDENT ('StudentStatuses', RESEED, 6);

ALTER TABLE StudentStatuses
ALTER COLUMN StatusDesc NVARCHAR(30);

INSERT INTO StudentStatuses(StatusDesc)
VALUES (N' ÕÊÌ· √À‰«¡ «·⁄«„');