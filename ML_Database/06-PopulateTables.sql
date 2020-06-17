--BRUNA DE FREITAS MACIEL
use MultiLease
go

--Populate Colors
delete from Colors;
insert into Colors (Description) values('Deep Blue');
insert into Colors (Description) values('Racey Red');
insert into Colors (Description) values('Lemon Yellow');
insert into Colors (Description) values('Lime Green');
insert into Colors (Description) values('Silver Grey');

--Populate Models
delete from Models;
insert into Models (Description) values ('SC-430');
insert into Models (Description) values ('Pirate');
insert into Models (Description) values ('Expensive');
insert into Models (Description) values ('Rock');
insert into Models (Description) values ('Speedy');

--Populate Types
delete from Types;
insert into Types (Description) values ('2dr Coupe');
insert into Types (Description) values ('4dr Sedan');
insert into Types (Description) values ('Truck');
insert into Types (Description) values ('SUV');
insert into Types (Description) values ('Van');

--Populate Vehicles
delete from Vehicles;
insert into Vehicles values ('3W9T1-2Q10D-12D0P-2E1R2',
(select ModelID from Models where Description = 'SC-430'), 
(select TypeID from Types where Description = '2dr Coupe'), 
(select ColorID from Colors where Description = 'Deep Blue'),
'2003', 0, 0, 90000, 1,1,1);

insert into Vehicles values ('7D901-9W120-Z0029-021P2',
(select ModelID from Models where Description = 'Pirate'), 
(select TypeID from Types where Description = '2dr Coupe'), 
(select ColorID from Colors where Description = 'Racey Red'),
'2000', 100000, 1, 45000, 0,1,1);

insert into Vehicles values ('Z1221-X129A-KO212-9021J',
(select ModelID from Models where Description = 'Expensive'), 
(select TypeID from Types where Description = '4dr Sedan'), 
(select ColorID from Colors where Description = 'Lemon Yellow'),
'2003', 0, 0, 70000, 1,1,0);

insert into Vehicles values ('M21L1-3129S-V1292-L12X1',
(select ModelID from Models where Description = 'Rock'), 
(select TypeID from Types where Description = 'Truck'), 
(select ColorID from Colors where Description = 'Silver Grey'),
'2001', 0, 0, 85000, 0,1,1);

insert into Vehicles values ('M21L1-3129S-V1292-L12X2',
(select ModelID from Models where Description = 'Rock'), 
(select TypeID from Types where Description = 'Truck'), 
(select ColorID from Colors where Description = 'Silver Grey'),
'2001', 127000, 1, 45000, 0,1,1);

insert into Vehicles values ('K219M-K129P-V12BP-210G4',
(select ModelID from Models where Description = 'Speedy'), 
(select TypeID from Types where Description = '2dr Coupe'), 
(select ColorID from Colors where Description = 'Silver Grey'),
'2003', 0, 0, 60000, 0,1,1);

--Populate Customers
delete from Customers;
insert into Customers (FirstName,LastName,Address,City,Province,Zipcode,Phone)
values ('Candie','Wrapper','1000 Lollopop Lane','Halifax','NS','B1X1X1','9021234567');

insert into Customers (FirstName,LastName,Address,City,Province,Zipcode,Phone)
values ('Scali','Wag','80 Plank Walk','Halifax','NS','B2L1L1','9028124567');

insert into Customers (FirstName,LastName,Address,City,Province,Zipcode,Phone)
values ('Inna','Chambers','2 Politician Street','Halifax','NS','B3M1M1','9023414212');

--Populate LeasesTerms
delete from LeaseTerms;
insert into LeaseTerms values ( 1001, 3, 120000, 0.25);

insert into LeaseTerms values (1002, 1, 85000, 0.2);

insert into LeaseTerms values (1003, 2, 150000, 0.2);

insert into LeaseTerms values (1004, 4, 130000, 0.15);

insert into LeaseTerms values (1005, 1, 150000, 0.35);

insert into LeaseTerms values (1006, 1, 100000, 0.25);

--Populate LeaseStatus
delete from LeaseStatus
insert into LeaseStatus (Description) values ('Started')
insert into LeaseStatus (Description) values ('Completed')


--Populate Leases
delete from LeasesP;
insert into LeasesP (LeaseID, ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID,StatusID)
values (2001, '15-01-2004','15/02/2004',650,36,
(select VIN from Vehicles where VIN = '3W9T1-2Q10D-12D0P-2E1R2'), 
(select CustomerID from Customers where FirstName='Candie' and LastName = 'Wrapper'), 1001,2);

insert into LeasesP (LeaseID,ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID,StatusID)
values (2002,'16-03-2004','16/04/2004',350,12, 
(select VIN from Vehicles where VIN = '7D901-9W120-Z0029-021P2'), 
(select CustomerID from Customers where FirstName='Scali' and LastName = 'Wag'), 1002,2);

insert into LeasesP (LeaseID, ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID,StatusID)
values (2003,'01-04-2004','01/05/2004',600,24,
(select VIN from Vehicles where VIN = 'Z1221-X129A-KO212-9021J'), 
(select CustomerID from Customers where FirstName='Inna' and LastName = 'Chambers'), 1003,2);

insert into LeasesP (LeaseID, ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID,StatusID)
values (2004, '20-02-2002','01/03/2002',450,48,
(select VIN from Vehicles where VIN = 'M21L1-3129S-V1292-L12X1'), 
(select CustomerID from Customers where FirstName='Candie' and LastName = 'Wrapper'), 1004,2);

insert into LeasesP (LeaseID, ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID,StatusID)
values (2005, '01-07-2004','15/07/2004',300,12,
(select VIN from Vehicles where VIN = 'M21L1-3129S-V1292-L12X2'), 
(select CustomerID from Customers where FirstName='Inna' and LastName = 'Chambers'), 1005,3);

insert into LeasesP (LeaseID, ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID,StatusID)
values (2006, '01-07-2016','15/07/2016',300,12,
(select VIN from Vehicles where VIN = 'M21L1-3129S-V1292-L12X2'), 
(select CustomerID from Customers where FirstName='Inna' and LastName = 'Chambers'), 1006,2);

--Populate Payments
insert into Payments (LeaseID, Amount, PaymentDate, Valid) values (2001,650,15/02/2004, 'Yes');
insert into Payments (LeaseID, Amount, PaymentDate, Valid) values (2002,350,16/04/2004, 'Yes');
insert into Payments (LeaseID, Amount, PaymentDate, Valid) values (2003,600,01/05/2004, 'Yes');
insert into Payments (LeaseID, Amount, PaymentDate, Valid) values (2004,450,01/03/2002, 'Yes');
insert into Payments (LeaseID, Amount, PaymentDate, Valid) values (2005,300,15/07/2004, 'Yes');
insert into Payments (LeaseID, Amount, PaymentDate, Valid) values (2001,300,15/07/2006, 'Yes');