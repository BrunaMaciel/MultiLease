--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
go

--drop existing tables
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'AuditLeases'
         )
  DROP TABLE AuditLeases;
--

create table AuditLeases (
AuditID int identity (1000,1),
AuditDate datetime,
AuditUsername nvarchar(30),
BeforeAfter nvarchar(10),
ChangeType nvarchar(10),
LeaseID int,
ContractDate datetime,
FirstPaymentDate datetime,
MonthlyPayment int,
NumOfPayments int,
VehicleID nvarchar(30),
CustomerID int,
TermsID int,
);
go


create trigger Leases_bu_trg
on Leases
for update
as
	insert into AuditLeases(BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'Before', USER_NAME(), GETDATE(), 'Update',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from deleted;
	insert into AuditLeases (BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'After', USER_NAME(), GETDATE(),'Update',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from inserted;
go

create trigger Leases_bd_trg
on Leases
for delete
as
	insert into AuditLeases(BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'Before', USER_NAME(), GETDATE(), 'Delete',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from deleted;
	insert into AuditLeases (BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'After', USER_NAME(), GETDATE(),'Delete',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from inserted;
go

create trigger Leases_bi_trg
on Leases
for insert
as
	insert into AuditLeases (BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'After', USER_NAME(), GETDATE(),'Insert',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from inserted;
go