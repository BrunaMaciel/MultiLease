use ML_635_203263
go

IF NOT EXISTS 
(
  SELECT *
    FROM sys.database_principals
    WHERE type_desc = 'DATABASE_ROLE'
    AND name = 'Manager'
)
BEGIN
create role Manager
END;
go

IF NOT EXISTS 
(
  SELECT *
    FROM sys.database_principals
    WHERE type_desc = 'DATABASE_ROLE'
    AND name = 'Associate'
)
BEGIN
create role	Associate
END;
GO

--granting permissions to Manager role
grant select on DetailedVehicle to Manager;
grant select on LeasesPAndTerms to Manager;
grant select on Customers to Manager;
grant select on Payments to Manager;
grant select on Vehicles to Manager;
grant select on Models to Manager;
grant select on Types to Manager;
grant select on Colors to Manager;
grant select on LeasesP to Manager;
grant select on LeaseTerms to Manager;
grant select on LeaseStatus to Manager;

grant insert on Payments to Manager;


grant update on Customers to Manager;
grant update on LeasesP to Manager;
grant update on LeaseTerms to Manager;
grant update on Payments(Valid) to Manager;

grant execute on InsertPayment to Manager;
grant execute on VoidPayment to Manager;
grant execute on SelectLease to Manager;
grant execute on UpdateLease to Manager;
grant execute on TerminateLease to Manager;


--granting permissions to Associate role
grant select on DetailedVehicle to Associate;
grant select on LeasesPAndTerms to Associate;
grant select on Customers to Associate;
grant select on Payments to Associate;
grant select on Vehicles to Associate;
grant select on Models to Associate;
grant select on Types to Associate;
grant select on Colors to Associate;
grant select on LeasesP to Associate;
grant select on LeaseTerms to Associate;
grant select on LeaseStatus to Associate;

grant insert on Vehicles to Associate;
grant insert on Models to Associate;
grant insert on Types to Associate;
grant insert on LeasesP to Associate;
grant insert on LeaseTerms to Associate;
grant insert on Customers to Associate;

grant update on Customers to Associate;
grant update on LeasesP to Associate;
grant update on LeaseTerms to Associate;

revoke update on LeasesP (StatusID) to Associate;

grant execute on InsertLease to Associate;
grant execute on SelectLease to Associate;
grant execute on UpdateLease to Associate;


IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'MarcouxK')
BEGIN
    CREATE LOGIN MarcouxK WITH PASSWORD = N'password'
END;
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'MarcouxK')
BEGIN
    CREATE USER [MarcouxK] FOR LOGIN [MarcouxK]
    EXEC sp_addrolemember N'Associate', N'MarcouxK'
END;
GO

IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'CarlingT')
BEGIN
    CREATE LOGIN CarlingT WITH PASSWORD = N'password'
END;
GO
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'CarlingT')
BEGIN
    CREATE USER [CarlingT] FOR LOGIN [CarlingT]
    EXEC sp_addrolemember N'Manager', N'CarlingT'
END;
GO