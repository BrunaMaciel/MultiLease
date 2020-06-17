--BRUNA DE FREITAS MACIEL
use [ML_635_203263]
go

--drop existing tables
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'Payments'
         )
  DROP TABLE Payments;
--
IF EXISTS(
  SELECT *
  FROM sys.foreign_keys
  WHERE name = N'fk_LeasesP_Terms'
         )
	alter table Leases 
	drop constraint fk_LeasesP_Terms
--
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'LeaseTerms'
         )
  DROP TABLE LeaseTerms;
--
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'LeasesP'
         )
  DROP TABLE LeasesP;
--

IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'Customers'
         )
  DROP TABLE Customers;
--

IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'Vehicles'
         )
  DROP TABLE Vehicles;
--
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'Models'
         )
  DROP TABLE Models;
--
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'Types'
         )
  DROP TABLE Types;
--
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'Colors'
         )
  DROP TABLE Colors;
--
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'AuditLeasesP'
         )
  DROP TABLE AuditLeasesP;
--

--drop existing views
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'DetailedVehicle'
         )
  DROP view DetailedVehicle;
--
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'LeasesPAndTerms'
         )
  DROP view LeasesPAndTerms;
--
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'ML_Constraints'
         )
  DROP view ML_Constraints;
--
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'ML_Objects'
         )
  DROP view ML_Objects;
--

--drop existing triggers
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'Payments_bd_trg'
         )
  DROP trigger Payments_bd_trg;
--
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'LeasesP_bu_trg'
         )
  DROP trigger LeasesP_bu_trg;
--
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'LeasesP_bd_trg'
         )
  DROP trigger LeasesP_bd_trg;
--
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'LeasesP_bi_trg'
         )
  DROP trigger LeasesP_bi_trg;
--