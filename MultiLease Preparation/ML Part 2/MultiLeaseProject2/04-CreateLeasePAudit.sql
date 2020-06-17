--BRUNA DE FREITAS MACIEL
use [ML_635_203263]
go

--drop existing tables
IF EXISTS(
  SELECT *
  FROM sys.tables
  WHERE name = N'AuditLeasesP'
         )
  DROP TABLE AuditLeasesP;
--

create table AuditLeasesP (
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


create trigger LeasesP_bu_trg
on LeasesP
for update
as
	insert into AuditLeasesP(BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'Before', USER_NAME(), GETDATE(), 'Update',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from deleted;
	insert into AuditLeasesP (BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'After', USER_NAME(), GETDATE(),'Update',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from inserted;
go

create trigger LeasesP_bd_trg
on LeasesP
for delete
as
	insert into AuditLeasesP(BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'Before', USER_NAME(), GETDATE(), 'Delete',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from deleted;
	insert into AuditLeasesP (BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'After', USER_NAME(), GETDATE(),'Delete',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from inserted;
go

create trigger LeasesP_bi_trg
on LeasesP
for insert
as
	insert into AuditLeasesP (BeforeAfter, AuditUsername, AuditDate, ChangeType,
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
	select 'After', USER_NAME(), GETDATE(),'Insert',
	LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID
	from inserted;
go