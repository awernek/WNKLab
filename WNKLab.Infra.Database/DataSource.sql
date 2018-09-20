CREATE EXTERNAL DATA SOURCE [DataSource] WITH
(  
	TYPE = RDBMS,
	LOCATION = 'myserver.database.windows.net',
	DATABASE_NAME = 'mydb',
	CREDENTIAL = [mycredential]
)