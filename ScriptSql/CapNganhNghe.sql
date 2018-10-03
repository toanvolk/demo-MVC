
drop table CapNganhNghe
create table CapNganhNghe
(
	NganhNgheID int identity(1,1) primary key,
	MaNganh varchar(10),
	ParentID int,
	TenNganh nvarchar(500),
	GhiChu   nvarchar (2000),
	StatID   bit,
	NguoiTao   nvarchar (500),
	NgayTao   datetime,
	NguoiCapNhat   nvarchar (500) ,
	NgayCapNhat   datetime 
)

select * from CapNganhNghe


alter proc sp_LoadDataCapNganh
as
Select *
Into   #Temp
From   CapNganhNghe
where ISNULL(ParentID,0)= 0

Declare @Id int
Declare @indexrow int
declare @name Nvarchar(500)

declare @TableReturn table
(
	Id int, 
	ParentID int,
	MaNganh varchar(10), 
	TenNganh nvarchar(500), 
	alevel nvarchar(500) --MaCap
)

While (Select Count(*) From #Temp ) > 0
Begin

    Select Top 1 @Id = nganhngheId, @name = MaNganh From #Temp;

	WITH temp(Id,ParentID, MaNganh, TenNganh, alevel)
        as (
                Select nganhngheid as id, ParentID, MaNganh, TenNganh, @name
                From CapNganhNghe
                Where nganhngheId = @Id
                Union All
                Select b.nganhngheid as id, b.ParentID, b.MaNganh, b.TenNganh, @name
                From temp as a, CapNganhNghe as b
                Where a.id = b.ParentID
        )

	insert into @TableReturn 
	Select *
    From temp

    Delete #Temp Where nganhngheId = @Id

End

drop table #Temp
select *,
	CASE WHEN ISNUMERIC(MaNganh) = 0
		then LEFT(CAST(UNICODE(MaNganh) as varchar)+ REPLICATE('0',10),10)
		else 
			LEFT(CAST(UNICODE(alevel) as varchar)+REPLICATE('0',5),5) + LEFT(CAST(MaNganh as varchar)+REPLICATE('0',5),5)
		end 
		as ordernew
from @TableReturn
order by ordernew

