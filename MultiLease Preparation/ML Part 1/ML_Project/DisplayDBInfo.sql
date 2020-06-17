USE [ML_635-203263]
GO

--Display information about the objects
SELECT Type, table_name as "Object Name", column_name as "Attribute", data_type as "Data Type", character_maximum_length as "Size"
FROM INFORMATION_SCHEMA.COLUMNS
join ML_Objects
on Name = TABLE_NAME
ORDER BY Type, TABLE_NAME, ORDINAL_POSITION


select * from ML_Constraints