--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
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
  WHERE name = N'fk_Leases_Terms'
         )
	alter table Leases 
	drop constraint fk_Leases_Terms
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
  WHERE name = N'Leases'
         )
  DROP TABLE Leases;
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
  WHERE name = N'AuditLeases'
         )
  DROP TABLE AuditLeases;
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
  WHERE name = N'LeasesAndTerms'
         )
  DROP view LeasesAndTerms;
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
  WHERE name = N'Leases_bu_trg'
         )
  DROP trigger Leases_bu_trg;
--
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'Leases_bd_trg'
         )
  DROP trigger Leases_bd_trg;
--
IF EXISTS(
  SELECT *
  FROM sys.views
  WHERE name = N'Leases_bi_trg'
         )
  DROP trigger Leases_bi_trg;
--