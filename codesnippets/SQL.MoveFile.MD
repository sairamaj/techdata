### Moving the SQL files

### Move
USE master; --do this all from the master
ALTER DATABASE fooDb

MODIFY FILE (name='DB_Data1'
             ,filename='X:\NewDBFile\DB_Data1.mdf'); --Filename is new location

### Take the datbase offline             
ALTER DATABASE fooDb SET OFFLINE WITH ROLLBACK IMMEDIATE;

### Move using either move command or File explorer.

### Bring the databse back
ALTER DATABASE fooDb SET ONLINE;