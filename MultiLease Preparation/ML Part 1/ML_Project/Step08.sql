--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
go

-- list of vehicles (vehicle VIN, model, type, color) that have never been leased

select VIN, Model, Type, Color
from DetailedVehicle left join Leases
on DetailedVehicle.VIN = Leases.VehicleID
where LeaseID IS NULL
