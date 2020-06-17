--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
go

-- list of vehicles (vehicle VIN, model, type, color) and the largest maximum kilometers field from any time the vehicle has been leased

select VIN, Model, Type, Color, MAX(MaxKM) as "Largest Max Kilometres"
from DetailedVehicle join LeasesAndTerms l
on DetailedVehicle.VIN = l.VehicleID
group by VIN, Model, Type, Color

