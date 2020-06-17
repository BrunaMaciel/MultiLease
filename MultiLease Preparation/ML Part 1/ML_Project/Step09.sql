--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
go

-- list of vehicles (vehicle VIN, model, type, color) that have  air conditioning and power locks

select VIN, Model, Type, Color
from DetailedVehicle
where "AC"='Yes' and "Power Locks"='Yes'