--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
go


create view LeasesAndTerms
as select LeaseID, FirstName+' '+LastName as "Customer",
convert(varchar,ContractDate,101) as "Contract Date",
convert(varchar,FirstPaymentDate,101) as "First Payment Date",
MonthlyPayment, NumOfPayments, VehicleID, NumOfYears, MaxKM, PremiumCharge
from Leases join LeaseTerms
on Leases.TermsID = LeaseTerms.LeaseTermID
join Customers 
on Leases.CustomerID = Customers.CustomerID
go

select * from LeasesAndTerms;