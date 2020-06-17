--BRUNA DE FREITAS MACIEL
use [ML_635_203263]
go

--create new tables

create table Models (
ModelID int identity constraint pk_Models primary key ,
Description nvarchar(15) not null
);

create table Types (
TypeID int identity constraint pk_Type primary key,
Description nvarchar(15) not null
);

create table Colors (
ColorID int identity constraint pk_Colors primary key,
Description nvarchar(15) not null
);

create table Customers (
CustomerID int identity constraint pk_Customers primary key,
FirstName nvarchar(15) not null,
LastName nvarchar(15) not null,
Address nvarchar(30),
City nvarchar(15),
Province nvarchar(15),
Zipcode nvarchar(8),
Phone nvarchar(10) not null
);

create table Vehicles (
VIN nvarchar(30) constraint pk_Vehicles primary key,
ModelID int constraint fk_Vehicles_Models references Models (ModelID),
TypeID int constraint fk_Vehicles_Types references Types (TypeID),
ColorID int constraint fk_Vehicles_Colors references Colors (ColorID),
Year nvarchar(4),
Kilometers int,
NewLease bit,
BookValue money,
AutoTransmission bit,
AC bit,
PowerLocks bit,
constraint ck_PowerLocks check (
(AC=1 and PowerLocks=1) or
(AC=1 and PowerLocks=0) or
(AC=0 and PowerLocks=0))
);

create table LeaseTerms (
LeaseTermID int constraint pk_LeaseTerms primary key,
NumOfYears int not null constraint ck_LeaseTerms_NumOfYears check (NumOfYears between 1 and 4),
MaxKM int not null constraint ck_LeaseTerms_MaxKM check (MaxKM <=150000),
PremiumCharge money
);

create table LeaseStatus (
StatusID int identity constraint pk_LeaseStatus  primary key,
Description nvarchar(30)
);

create table LeasesP
(
LeaseID int ,
ContractDate datetime not null,
FirstPaymentDate datetime,
MonthlyPayment money,
NumOfPayments int default 36 constraint ck_NumOfPayments_LP check (NumOfPayments <= 48),
VehicleID nvarchar(30) constraint fk_Leases_Vehicles_LP references Vehicles (VIN),
CustomerID int constraint fk_Leases_Customers_LP references Customers (CustomerID),
TermsID int constraint fk_Leases_Terms_LP references LeaseTerms (LeaseTermID),
StatusID int constraint fk_Leases_Status_LP references LeaseStatus (StatusID),
constraint ck_FirstPaymentDate_LP check (FirstPaymentDate >= ContractDate),
constraint pk_LeasesP primary key (LeaseID, ContractDate)
)
on LeasesPS (ContractDate)
go

create table Payments (
PaymentID int identity constraint pk_Payments primary key,
LeaseID int,
ContractDate datetime,
PaymentDate datetime,
Amount money,
Valid nvarchar(3),
constraint fk_Payments_Leases foreign key (LeaseID,ContractDate) references LeasesP (LeaseID,ContractDate)
);
