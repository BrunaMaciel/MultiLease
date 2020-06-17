use ML_635_203263
go

--Procedure to insert a new payment
create procedure InsertPayment (@LeaseID int, @PaymentDate datetime, @Amount money)
as
begin
if (@LeaseID is not null) and (@PaymentDate is not null) and (@Amount is not null)
	begin
		insert into Payments (LeaseID, PaymentDate, Amount, Valid)
		values (@LeaseID, @PaymentDate, @Amount, 'Yes')
		 
	end
end;
go

--Procedute to void a payment
create procedure VoidPayment (@PaymentID int = null) as
begin
if @PaymentID is not null
	begin
		update Payments 
		set Valid = 'No', Amount = 0.00
		where PaymentID = @PaymentID
	end
end;