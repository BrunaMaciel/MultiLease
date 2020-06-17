--BRUNA DE FREITAS MACIEL
use [ML_635-203263]
go

create trigger Payments_bd_trg
on Payments
instead of delete
as
print 'delete on Payments table disallowed'
go