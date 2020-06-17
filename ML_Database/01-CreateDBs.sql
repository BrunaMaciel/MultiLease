-- BRUNA DE FREITAS MACIEL

IF NOT EXISTS(SELECT * FROM sys.databases
          WHERE name = N'MultiLease')
	CREATE DATABASE "MultiLease"
GO

/* Use script CreateMLTables.sql to create this DB tables
*/

IF NOT EXISTS(SELECT * FROM sys.databases
          WHERE name = N'ML_E_635_203263')
	CREATE DATABASE "ML_E_635_203263"
GO

/* For the ML_E_635-203263 table import using the wizard the excel file ML_Employees.xls
	Remember to unmark the option that allows null in the field EMPID
	After the import is complete, change the name of the table to Employees and make EMPID primary key
*/
