--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
go

-- script that will show a list of customers (first name, last name, and phone number) 
-- and the total number of vehicles each has leased.

select FirstName, LastName, Phone, COUNT(*) as Leases
from Customers join Leases
on Customers.CustomerID = Leases.CustomerID
group by FirstName,LastName, Phone