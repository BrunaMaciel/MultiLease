use MultiLease
go

create view LeasesPayments as
select LeasesP.LeaseID, convert(varchar,LeasesP.ContractDate,23) as "ContractDate", Customers.FirstName+' '+ Customers.LastName as Customer,
Customers.Phone, LeasesP.VehicleID, DetailedVehicle.Model, DetailedVehicle.Year, 
Payments.PaymentID, convert(varchar,PaymentDate,23) as "PaymentDate", Payments.Amount, Payments.Valid
from LeasesP 
inner join LeaseTerms on LeaseTerms.LeaseTermID = LeasesP.TermsID
inner join Payments on Payments.LeaseID = LeasesP.LeaseID
inner join Customers on Customers.CustomerID = LeasesP.CustomerID
inner join DetailedVehicle on DetailedVehicle.VIN = LeasesP.VehicleID
