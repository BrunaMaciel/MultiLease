use ML_635_203263
go

--Procedure to insert a new Lease to the table LeaseP
create procedure InsertLease (@LeaseID int, @ContractDate datetime, @FirstPaymentDate datetime, @MonthlyPayment money,
@NumOfPayments int, @VehicleID nvarchar(30), @CustomerID int, @TermsID int)
as
begin
if (@LeaseID is not null) and (@ContractDate is not null) and (@FirstPaymentDate is not null)
and (@MonthlyPayment is not null) and (@VehicleID is not null) and 
(@CustomerID is not null) and (@TermsID is not null)
	begin
		insert into LeasesP (LeaseID, ContractDate, FirstPaymentDate, MonthlyPayment, NumOfPayments,
VehicleID, CustomerID, TermsID, StatusID)
		values (@LeaseID, @ContractDate, @FirstPaymentDate, @MonthlyPayment,
@NumOfPayments, @VehicleID, @CustomerID, @TermsID, 1)
	end
end;
go

-- Procedure to update a Lease
create procedure UpdateLease (@LeaseID int, @ContractDate datetime, @FirstPaymentDate datetime, @MonthlyPayment money,
@NumOfPayments int, @VehicleID nvarchar(30), @CustomerID int, @TermsID int)
as
begin
if (@LeaseID is not null) and (@ContractDate is not null) and (@FirstPaymentDate is not null)
and (@MonthlyPayment is not null) and (@NumOfPayments is not null) and (@VehicleID is not null) and 
(@CustomerID is not null) and (@TermsID is not null)
	begin
		update LeasesP
		set ContractDate = @ContractDate, FirstPaymentDate = @FirstPaymentDate, MonthlyPayment = @MonthlyPayment,
		NumOfPayments = @NumOfPayments, VehicleID = @VehicleID, CustomerID = @CustomerID, TermsID = @TermsID
		where LeaseID = @LeaseID
		 
	end
end;
go

-- Procedure to delete a Lease
create procedure DeleteLease (@LeaseID int)
as
begin
if @LeaseID is not null
	begin
		delete from LeaseP
		where LeaseID = @LeaseID
	end
end;
go

--Procedure to select a Lease by ID
create procedure SelectLease (@LeaseID int)
as
begin
if @LeaseID is not null
	begin
		select *
		from LeasesP
		where LeaseID = @LeaseID
	end
end;
go

--Procedure to terminate a Lease by ID
create procedure TerminateLease (@LeaseID int = null) as
begin
if @LeaseID is not null
	begin
		update LeaseP 
		set LeaseStatus = 3
		where LeaseID = @LeaseID
	end
end;
go

