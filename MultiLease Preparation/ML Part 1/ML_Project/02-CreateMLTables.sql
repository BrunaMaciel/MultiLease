--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
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

create table Leases(
LeaseID int constraint pk_Leases primary key,
ContractDate datetime not null,
FirstPaymentDate datetime,
MonthlyPayment money,
NumOfPayments int default 36 constraint ck_NumOfPayments check (NumOfPayments <= 48),
VehicleID nvarchar(30) constraint fk_Leases_Vehicles references Vehicles (VIN),
CustomerID int constraint fk_Leases_Customers references Customers (CustomerID),
TermsID int constraint fk_Leases_Terms references LeaseTerms (LeaseTermID),
constraint ck_FirstPaymentDate check (FirstPaymentDate >= ContractDate)
);

create table Payments (
PaymentID int identity constraint pk_Payments primary key,
LeaseID int constraint fk_Payments_Leases references Leases (LeaseID),
PaymentDate datetime,
Amount money
);
