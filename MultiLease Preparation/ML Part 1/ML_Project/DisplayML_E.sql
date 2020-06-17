USE [ML_E_635-203263]
GO

--Display information about the objects
select 'Table' as "Type", Name from sys.tables
union
select 'View' , Name from sys.views
union
select 'Trigger', Name from sys.triggers
go

SELECT a.name AS "TableName", b.name AS "Constraint", b.type_desc AS "Constraint Type"
FROM sys.tables a JOIN sys.key_constraints b
  ON b.parent_object_id = a.object_id
     UNION
SELECT a.name, b.name, b.type_desc
FROM sys.tables a JOIN sys.foreign_keys b
  ON b.parent_object_id = a.object_id
     UNION
SELECT a.name, b.name, b.type_desc
FROM sys.tables a JOIN sys.check_constraints b
  ON b.parent_object_id = a.object_id
     UNION
SELECT a.name, b.name, b.type_desc
FROM sys.tables a JOIN sys.default_constraints b
  ON b.parent_object_id = a.object_id
go

SELECT table_name as "Object Name", column_name as "Attribute", data_type as "Data Type", character_maximum_length as "Size"
FROM INFORMATION_SCHEMA.COLUMNS
ORDER BY  TABLE_NAME, ORDINAL_POSITION