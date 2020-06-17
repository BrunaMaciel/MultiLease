--BRUNA DE FREITAS MACIEL
use MultiLease
go

EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"

--drop existing tables
DROP TABLE if exists Payments;
DROP TABLE if exists LeaseTerms;
DROP TABLE if exists LeasesP;
DROP TABLE if exists Customers;
DROP TABLE if exists Vehicles;
DROP TABLE if exists Models;
DROP TABLE if exists Types;
DROP TABLE if exists Colors;
DROP TABLE if exists LeaseStatus;
DROP TABLE if exists AuditLeasesP;

--drop existing views
DROP view if exists DetailedVehicle;
DROP view if exists LeasesDetails;
DROP view if exists LeasesPayments;
DROP view if exists ML_Constraints;
DROP view if exists ML_Objects;

--drop existing triggers
DROP trigger Payments_bd_trg;
DROP trigger LeasesP_bu_trg;
DROP trigger LeasesP_bd_trg;
DROP trigger LeasesP_bi_trg;

-- drop procedures e functions
DROP PROCEDURE IF EXISTS dbo.DeleteCustomer;
DROP PROCEDURE IF EXISTS dbo.DeleteLease;
DROP PROCEDURE IF EXISTS dbo.InsertLease;
DROP PROCEDURE IF EXISTS dbo.InsertPayment;
DROP PROCEDURE IF EXISTS dbo.SelectLease;
DROP PROCEDURE IF EXISTS dbo.TerminateLeaseUpdates;
DROP PROCEDURE IF EXISTS dbo.UpdateLease;
DROP PROCEDURE IF EXISTS dbo.VoidPayment;
DROP FUNCTION IF EXISTS DBO.CalculatePremiumFee;
 --
