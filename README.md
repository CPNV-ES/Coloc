# Coloc
ASP.net project managing the maintenance schedule of equipments

## Requirements
- Microsoft Sql Server 
- Microsoft Sql Server Management Studio
- Visual Studio 2017 
- Net Core 2.1

## Installation
### Database
Execute [this script](https://github.com/CPNV-ES/Coloc/blob/master/docs/database/CreateDbWithSeeder.sql) in Microsoft SQL Server Management Studio to create an operationnal DB.

<aside class="warning">
You need to set an existing path about the files Coloc.mdf and Coloc_log.ldf (exemple below). Make sure you have write access to those folder too.
</aside>

> Be sure your FILENAME path exists.
```sql
 ON  PRIMARY 
( NAME = N'Coloc', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Coloc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Coloc_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Coloc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
```
There is also [this script](https://github.com/CPNV-ES/Coloc/blob/master/docs/database/CreateEmptyColocDB.sql) to create DB without data.

### Project
Clone the current project and open the Coloc.sln file:
- `git clone https://github.com/CPNV-ES/Coloc.git`

### Setup
Once in the project, don't forget to scaffold the models with this command (use the -Force flag if scaffold a second time) :
- `Scaffold-DbContext "Server=localhost;Database=Coloc;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models`
