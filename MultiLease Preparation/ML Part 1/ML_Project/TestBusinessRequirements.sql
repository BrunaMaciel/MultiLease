--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
go

--Test ck_LeaseTerms_MaxKM
--Insert error due MaxKM > 150000
insert into LeaseTerms (LeaseTermID, NumOfYears, MaxKM, PremiumCharge) values (1007, 2, 160000, 0.25);

--Test ck_LeaseTerms_NumOfYears
--Insert error due NumOfYears > 4
insert into LeaseTerms (LeaseTermID, NumOfYears, MaxKM, PremiumCharge) values (1008, 5, 160000, 0.25);

--Test ck_NumOfPayments
--Insert error due NumOfPayments > 48
insert into Leases (LeaseID, ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
values (2008, '15-01-2004','15/02/2004',650,50,
(select VIN from Vehicles where VIN = '3W9T1-2Q10D-12D0P-2E1R2'), 
(select CustomerID from Customers where FirstName='Candie' and LastName = 'Wrapper'), 1001);

--Test ck_FirstPaymentDate
--Insert error due FirstPaymentDate < ContractDate
insert into Leases (LeaseID, ContractDate,FirstPaymentDate,MonthlyPayment,NumOfPayments,VehicleID,CustomerID,TermsID)
values (2008, '15-01-2004','14/01/2004',650,36,
(select VIN from Vehicles where VIN = '3W9T1-2Q10D-12D0P-2E1R2'), 
(select CustomerID from Customers where FirstName='Candie' and LastName = 'Wrapper'), 1001);

--Test ck_PowerLocks
--Vehicles cannot have power locks if they do not have air conditioning
----Insert error due PowerLocks cannot be 1 when AC is 0
insert into Vehicles values ('K219M-K129P-V12BP-210G8',
(select ModelID from Models where Description = 'Speedy'), 
(select TypeID from Types where Description = '2dr Coupe'), 
(select ColorID from Colors where Description = 'Silver Grey'),
'2007', 0, 0, 60000, 0,0,1);
