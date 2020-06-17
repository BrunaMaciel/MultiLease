use MultiLease
go

create procedure DeleteCustomer (@CustomerID int)
as
begin
if @CustomerID is not null
	begin
		delete from Customers
		where CustomerID = @CustomerID
	end
end;
