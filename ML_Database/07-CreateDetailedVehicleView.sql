--BRUNA DE FREITAS MACIEL
use MultiLease
go

create view DetailedVehicle
as select v.VIN, m.Description as "Model", t.Description as "Type", c.Description as "Color", Year,Kilometers,
case 
	when NewLease = 1 then 'Yes'
	else 'No'
end as "New Lease",
BookValue,
case 
	when AutoTransmission = 1 then 'Yes'
	else 'No'
end as "Automatic Transmission",
case 
	when AC = 1 then 'Yes'
	else 'No'
end as "AC",
case 
	when PowerLocks = 1 then 'Yes'
	else 'No'
end as "Power Locks"
from Vehicles v left join Models m 
on v.ModelID = m.ModelID
 left join Types t
on v.TypeID = t.TypeID
 left join Colors c
on v.ColorID = c.ColorID
go

select * from DetailedVehicle;