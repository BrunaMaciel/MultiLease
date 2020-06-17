--BRUNA DE FREITAS MACIEL
use MultiLease
go


create view LeasesDetails
as select LeaseID, FirstName+' '+LastName as "Customer",
convert(varchar,ContractDate,23) as "ContractDate",
Description as Status,
convert(varchar,FirstPaymentDate,23) as "FirstPaymentDate",
MonthlyPayment, NumOfPayments, VehicleID, NumOfYears, MaxKM, PremiumCharge
from LeasesP join LeaseTerms
on LeasesP.TermsID = LeaseTerms.LeaseTermID
join Customers 
on LeasesP.CustomerID = Customers.CustomerID
join LeaseStatus
on LeasesP.StatusID = LeaseStatus.StatusID
go

select * from LeasesDetails