--BRUNA DE FREITAS MACIEL
use MultiLease
go

create trigger Payments_bd_trg
on Payments
instead of delete
as
print 'delete on Payments table disallowed'
go