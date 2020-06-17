USE [ML_635_203263]
GO

--create Objects view
create view ML_Objects as
select 'Table' as "Type", Name from sys.tables
union
select 'View' , Name from sys.views
union
select 'Trigger', Name from sys.triggers
go

--create Constraints view
create view ML_Constraints as
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