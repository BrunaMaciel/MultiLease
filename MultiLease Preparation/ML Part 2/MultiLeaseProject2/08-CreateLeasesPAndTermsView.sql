--BRUNA DE FREITAS MACIEL
use [ML_635_203263]
go


create view LeasesPAndTerms
as select LeaseID, FirstName+' '+LastName as "Customer",
convert(varchar,ContractDate,101) as "Contract Date",
convert(varchar,FirstPaymentDate,101) as "First Payment Date",
MonthlyPayment, NumOfPayments, VehicleID, NumOfYears, MaxKM, PremiumCharge
from LeasesP join LeaseTerms
on LeasesP.TermsID = LeaseTerms.LeaseTermID
join Customers 
on LeasesP.CustomerID = Customers.CustomerID
go

select * from LeasesPAndTerms;