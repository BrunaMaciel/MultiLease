use MultiLease
go

alter database MultiLease
add FILEGROUP FG01;
GO
alter database MultiLease
add FILEGROUP FG02;
GO

alter database MultiLease
add file(
	Name = Lease01,
	filename = 'C:\ML_Project2\ML_Leases01.ndf',
	size = 20mb,
	filegrowth = 5mb
) to filegroup FG01

alter database MultiLease
add file(
	Name = Lease02,
	filename = 'C:\ML_Project2\ML_Leases02.ndf',
	size = 20mb,
	filegrowth = 5mb
) to filegroup FG02

create partition function LeasesPF (datetime)
as range right for values ('01-01-2015 00:00:00.000')
go

create partition scheme LeasesPS as
partition LeasesPF to (FG01, FG02)
go

