use MultiLease
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
create procedure UpdateLease (@LeaseID int, @MonthlyPayment money,
@NumOfPayments int, @VehicleID nvarchar(30), @CustomerID int, @TermsID int)
as
begin
if (@LeaseID is not null) and (@MonthlyPayment is not null) and (@NumOfPayments is not null) and 
	(@VehicleID is not null) and (@CustomerID is not null) and (@TermsID is not null)
	begin
		update LeasesP
		set MonthlyPayment = @MonthlyPayment, NumOfPayments = @NumOfPayments, 
		VehicleID = @VehicleID, CustomerID = @CustomerID, TermsID = @TermsID
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
		delete from LeasesP
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

create procedure TerminateLeaseUpdates (@LeaseID int = null, @KM int = null) as
begin
if (@LeaseID is not null) and (@KM is not null)
	begin
	declare @VIN nvarchar(30);
	
	update LeasesP 
	set StatusID = 2
	where LeaseID = @LeaseID;

	set @VIN = (select VehicleID from LeasesP where LeaseID = @LeaseID);

	update Vehicles
	set Kilometers = @KM
	where VIN = @VIN;
	end;
end;
go

--Function to terminate a Lease by ID
create function CalculatePremiumFee (@LeaseID int = null, @KM int) returns money as 
begin
if (@LeaseID is not null) and (@KM is not null)
	begin
	declare @VIN nvarchar(30);
	declare @Terms int;
	declare @MaxKM int;
	declare @OldKM int;
	declare @DiffKM int;
	declare @Charge money;

	set @VIN = (select VehicleID from LeasesP where  LeaseID = @LeaseID);
	set @Terms = (select TermsID from LeasesP where   LeaseID = @LeaseID);
	set @MaxKM = (select MaxKM from LeaseTerms where LeaseTermID = @Terms);
	set @Charge = (select PremiumCharge from LeaseTerms where LeaseTermID = @Terms);
	set @OldKM =  (select Kilometers from Vehicles where VIN = @VIN);
	set @DiffKM = @KM - @OldKM;

	if (@DiffKM - @MaxKM)>0
		begin
		return (@DiffKM - @MaxKM)*@Charge;
		end;
	end;
	return 0;
end;
go
