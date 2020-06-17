use ML_635_203263
go

create view LeasesPayments as
select LeasesP.LeaseID, Customers.FirstName, Customers.LastName,
Customers.Phone, LeasesP.VehicleID, DetailedVehicle.Model, DetailedVehicle.Year, 
Payments.PaymentDate, Payments.Amount
from LeasesP 
inner join LeaseTerms on LeaseTerms.LeaseTermID = LeasesP.TermsID
inner join Payments on Payments.LeaseID = LeasesP.LeaseID
inner join Customers on Customers.CustomerID = LeasesP.CustomerID
inner join DetailedVehicle on DetailedVehicle.VIN = LeasesP.VehicleID
order by LeasesP.LeaseID