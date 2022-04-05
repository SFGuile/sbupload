if not exists (select   *   from   syscolumns   where   [name]= 'sb_sc_bz'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'product')
alter TABLE product add sb_sc_bz char(1) NULL
go
if not exists (select   *   from   syscolumns   where   [name]= 'sb_sc_recipe'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'inv_main')
alter TABLE inv_main add [sb_sc_recipe] [char] (1)  NULL  
go
if not exists (select * from sysobjects where id = object_id(N'[dbo].[sb_recipe_records]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [sb_recipe_records] (
	[id] [numeric](16, 0) IDENTITY (1, 1) NOT NULL primary key,
	[list_no] [char] (13)  NULL ,
	[upload_time] [datetime] NULL ,
	[sfcf] [char] (1)  NULL ,
	[sfsc] [char] (1)  NULL 
)
go
if not exists (select * from sysobjects where id = object_id(N'[dbo].[sb_recipe_records_new]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [sb_recipe_records_new] (
	[list_no] [char] (13)  not NULL ,
	[upload_time] [datetime] not NULL ,
	[sfcf] [char] (1)  NULL ,
	[sfsc] [char] (1)  NULL ,
	primary key(list_no,upload_time)
)
go
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = 'company' AND TABLE_SCHEMA ='dbo') 
ALTER TABLE [dbo].[company] ADD CONSTRAINT [PK_ReturnVoucher] PRIMARY KEY CLUSTERED  ([com_name])
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_main') and name='SB_BZ1')
ALTER TABLE inv_main ADD SB_BZ1 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_main') and name='SB_BZ2')
ALTER TABLE inv_main ADD SB_BZ2 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_main') and name='SB_BZ3')
ALTER TABLE inv_main ADD SB_BZ3 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_main') and name='SB_CFBZ1')
ALTER TABLE inv_main ADD SB_CFBZ1 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_main') and name='SB_CFBZ2')
ALTER TABLE inv_main ADD SB_CFBZ2 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_main') and name='SB_CFBZ3')
ALTER TABLE inv_main ADD SB_CFBZ3 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_sub') and name='SB_BZ1')
ALTER TABLE inv_sub ADD SB_BZ1 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_sub') and name='SB_BZ2')
ALTER TABLE inv_sub ADD SB_BZ2 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_sub') and name='SB_BZ3')
ALTER TABLE inv_sub ADD SB_BZ3 char(50) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('inv_sub') and name='SB_JX')
ALTER TABLE inv_sub ADD SB_JX char(30) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('upd_sub') and name='prod_made')
ALTER TABLE upd_sub ADD prod_made char(64) null  
go
if  not exists(Select * from syscolumns Where ID=OBJECT_ID('upd_sub') and name='mycount')
ALTER TABLE upd_sub ADD mycount numeric(4,0) null  
go

create   procedure cal_month_dep_acm @begdt datetime,@endt datetime
as




declare @prodno char(8),@batchno char(12),@prodadd char(12),@mark char(1)

declare @depno char(16),@depnum numeric(9,3)
declare @listno char(13),@invnum numeric(9,3),@hadbacknum numeric(9,3),@hadretnum numeric(9,3)
declare @invdate datetime ,@depdate datetime,@buyprice numeric(12,6)

declare @invsumnumbak numeric(16,3),@invdatebak datetime
declare @sumdepnum numeric(16,3),@suminvnum numeric(16,3)

declare @thecount int,@invcount int
declare @controllmark1 int,@controllmark2 int




if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempbatch'))
DROP TABLE #tempbatch

create table #tempbatch
(
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   mark char(1) not null default('n'),
   primary key(prod_no,batch_no,prod_add)
)




if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempinv'))
DROP TABLE #tempinv

create table #tempinv
(
   list_no char(13) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   inv_date datetime null,
   inv_num numeric(9,3) null,
   had_back_num numeric(9,3) null,
   thecount int null,
   inv_num_sum numeric(16,3) null,
   dep_num_sum numeric(16,3) null,
   primary key(list_no,prod_no,batch_no,prod_add)
)



if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempdep'))
DROP TABLE #tempdep

create table #tempdep
(
   dep_no char(16) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   dep_num numeric(9,3) null,
   had_ret_num numeric(9,3) null,
   dep_date datetime null,
   buy_price numeric(12,6) null,
   primary key(dep_no,prod_no,batch_no,prod_add)
)


if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempresult'))
DROP TABLE #tempresult

create table #tempresult
(
   dep_no char(16) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   dep_date datetime null,
   dep_num numeric(16,3) null,
   inv_num numeric(16,3) null,
   lest_num numeric(16,3) null,
   buy_price numeric(12,6) null 
   primary key(dep_no,prod_no,batch_no,prod_add)
)

 
 
insert #tempbatch(prod_no,batch_no,prod_add,mark)
select dp.prod_no,dp.batch_no,dp.prod_add,'p' from prod_dep dp left join product p on dp.prod_no=p.prod_no where p.sb_sc_bz is null 


insert #tempbatch(prod_no,batch_no,prod_add,mark)
select distinct ivs.prod_no,ivs.batch_no,ivs.prod_add,'n' from inv_sub ivs 
left join inv_main im on ivs.list_no=im.list_no 
left join product p on ivs.prod_no=p.prod_no 
where  im.inv_date>=@begdt and im.inv_date<=@endt 
 and not exists(select * from #tempbatch t where t.prod_no=ivs.prod_no and t.batch_no=ivs.batch_no and t.prod_add=ivs.prod_add) 
 and p.sb_sc_bz is null 



insert #tempbatch(prod_no,batch_no,prod_add,mark)
select distinct ds.prod_no,ds.batch_no,ds.prod_add,'n' from dep_sub ds 
left join dep_main dm on ds.dep_no=dm.dep_no 
left join product p on ds.prod_no=p.prod_no 
where  dm.dep_date>=@begdt and dm.dep_date<=@endt and 
not exists(select * from #tempbatch t where t.prod_no=ds.prod_no and t.batch_no=ds.batch_no and t.prod_add=ds.prod_add) 
and p.sb_sc_bz is null 
 
 

 





declare cur_batch cursor for select prod_no,batch_no,prod_add,mark from #tempbatch
open cur_batch
fetch next from cur_batch into @prodno,@batchno,@prodadd,@mark
while @@fetch_status=0
begin --#7


if exists(select * from #tempinv)
delete from #tempinv



if exists(select * from #tempdep)
delete from #tempdep

select @sumdepnum=sum(dep_num - had_ret_num) from dep_sub where prod_no=@prodno and batch_no=@batchno and prod_Add=@prodadd

select @thecount=count(*) from dep_sub where prod_no=@prodno and batch_no=@batchno and prod_Add=@prodadd

select @invcount=count(*) from inv_sub where prod_no=@prodno and batch_no=@batchno and prod_Add=@prodadd

select  @suminvnum=sum(inv_num - had_back_num) from inv_sub where prod_no=@prodno and batch_no=@batchno and prod_Add=@prodadd

if @sumdepnum>0 and @thecount>0
begin

  insert #tempdep(dep_no,prod_no,batch_no,prod_add,dep_num,dep_date,buy_price)
    select s.dep_no,s.prod_no,s.batch_no,s.prod_add,s.dep_num - s.had_ret_num,m.dep_date,buy_price from dep_sub s left join dep_main m on s.dep_no=m.dep_no
     where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
    order by m.dep_date,m.dep_no
    
    insert #tempinv(list_no,prod_no,batch_no,prod_add,inv_num,had_back_num,inv_date)
    select s.list_no,s.prod_no,s.batch_no,s.prod_add,isnull(s.inv_num  ,0) as inv_num,isnull(s.had_back_num,0) as had_back_num,m.inv_date from inv_sub s left join inv_main m on s.list_no=m.list_no  
    where s.prod_no=@prodno and s.batch_no=@batchno and s.prod_add=@prodadd 
    order by m.inv_date,m.list_no
    
    
    declare cur_dep cursor for select dep_no,dep_num,dep_date,buy_price from #tempdep        
   open cur_dep
   fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
   
   select @controllmark1=0,@controllmark2=0
   select @invsumnumbak=0.0
   
    while @@fetch_status=0 and @controllmark1=0
    begin
    
      declare cur_inv cursor for select list_no,inv_num,had_back_num,inv_date from #tempinv
   open cur_inv
   fetch next from cur_inv into @listno,@invnum,@hadbacknum,@invdate
   select @controllmark2=0
   while @@fetch_status=0 and @controllmark2=0
   begin
   
     if @depdate<=@invdate
     begin
     --正常情况
     select @invsumnumbak=@invsumnumbak+@invnum -@hadbacknum
     
      if @depnum=@invsumnumbak
       begin
        --进仓数等于销售总数
           
                if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                        update #tempresult set inv_num=@depnum,lest_num=0.0 where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                 else
                         insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                          select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@depnum,0.0 ,@buyprice
                
            
            
             fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
             if @@fetch_status<>0
             begin
              select @controllmark1=1,@controllmark2=1
              break
             
             end
             
             select @invsumnumbak=0.0
             
              
       end
       else if @depnum<@invsumnumbak
       begin
        --进仓数小于销售总数
        
            
                if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                        update #tempresult set  inv_num=@depnum,lest_num=0.0 where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                 else
                         insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                          select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@depnum,0.0 ,@buyprice
                
            
            
            select  @invsumnumbak=@invsumnumbak-@depnum
            select @depnum=0
            
           
           
              fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
              if @@fetch_status<>0
              
                begin
                 select @controllmark1=1,@controllmark2=1
                 insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                 select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),0.0,@invsumnumbak,0.0 ,0.0
     
                 break
            
                end
              
              while @invsumnumbak>0 and @@fetch_status=0
             begin
             
                 if @depdate<=@invdate
                 begin
                    if @invsumnumbak<@depnum
                    begin
                    --进仓数大于等于销售数量合计
                       
                             if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                                update #tempresult set inv_num=@invsumnumbak,lest_num=@depnum - @invsumnumbak where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                             else
                               insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                               select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@invsumnumbak,@depnum - @invsumnumbak ,@buyprice
                             
                        
                        
                        select @depnum=@depnum - @invsumnumbak
                        select @invsumnumbak=0.0 
                        break
                     end
                    else if @invsumnumbak=@depnum
                     begin
                     
                         if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                                update #tempresult set inv_num=@invsumnumbak,lest_num=@depnum - @invsumnumbak where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                             else
                               insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                               select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@invsumnumbak,@depnum - @invsumnumbak ,@buyprice
                       
                        
                         select @invsumnumbak=0.0 
                        
                        
            
                       
                     
                     end
                    
                    else
                    --进仓数小于销售数量合计
                    begin
                            if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                                update #tempresult set inv_num=@depnum,lest_num=0.0 where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                             else
                               insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                               select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@depnum,0.0 ,@buyprice
                             
                              select  @invsumnumbak=@invsumnumbak-@depnum
                              select @depnum=0
                    end
                  end
                  else
                     begin
                      select @controllmark1=1,@controllmark2=1
                      insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                      select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),0.0,@invsumnumbak,0.0 ,0.0
     
                       break
            
                     end
             
              fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
               end
             
       end
       
       else
       begin
        --进仓大于销售数
        
        
            if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
             update #tempresult set inv_num=@invsumnumbak,lest_num=@depnum - @invsumnumbak where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
            else
              insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
             select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@invsumnumbak,@depnum - @invsumnumbak ,@buyprice
          
       --   select @invsumnumbak=0.0
       end
          
     
     
     end
     else
     begin
      --不正常情况
      select @controllmark1=1,@controllmark2=1
      
      insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
      select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),isnull(@sumdepnum,0),isnull(@suminvnum,0),0.0 ,0.0
      
      break
     
     end
   
   
   
    
    fetch next from cur_inv into @listno,@invnum,@hadbacknum,@invdate
   end
   close cur_inv
   deallocate cur_inv
    
    
     
       select @controllmark1=1,@controllmark2=1
       break
     
    
      
       fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
     
    end
    close cur_dep
    deallocate cur_dep

  if @invcount=0 
  begin
  
           
                insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,0.0,@depnum ,@buyprice
        
            
  
  end


end
else if  @suminvnum>0 and @invcount>0
begin
-- 进仓数为0但是销售数量减了退货数仍然大于零，这时出错
insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),isnull(@sumdepnum,0),isnull(@suminvnum,0),0.0 ,0.0

end


fetch next from cur_batch into @prodno,@batchno,@prodadd,@mark
end
close cur_batch
deallocate cur_batch

select  t.dep_no ,t.prod_no ,t.batch_no ,t.prod_add ,t.dep_date ,t.dep_num ,t.inv_num,t.lest_num ,t.buy_price,p.prod_made from  #tempresult t left join product p on t.prod_no=p.prod_no

go

ALTER   procedure cal_month_dep_acm @begdt datetime,@endt datetime
as




declare @prodno char(8),@batchno char(12),@prodadd char(12),@mark char(1)

declare @depno char(16),@depnum numeric(9,3)
declare @listno char(13),@invnum numeric(9,3),@hadbacknum numeric(9,3),@hadretnum numeric(9,3)
declare @invdate datetime ,@depdate datetime,@buyprice numeric(12,6)

declare @invsumnumbak numeric(16,3),@invdatebak datetime
declare @sumdepnum numeric(16,3),@suminvnum numeric(16,3)

declare @thecount int,@invcount int
declare @controllmark1 int,@controllmark2 int




if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempbatch'))
DROP TABLE #tempbatch

create table #tempbatch
(
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   mark char(1) not null default('n'),
   primary key(prod_no,batch_no,prod_add)
)




if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempinv'))
DROP TABLE #tempinv

create table #tempinv
(
   list_no char(13) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   inv_date datetime null,
   inv_num numeric(9,3) null,
   had_back_num numeric(9,3) null,
   thecount int null,
   inv_num_sum numeric(16,3) null,
   dep_num_sum numeric(16,3) null,
   primary key(list_no,prod_no,batch_no,prod_add)
)



if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempdep'))
DROP TABLE #tempdep

create table #tempdep
(
   dep_no char(16) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   dep_num numeric(9,3) null,
   had_ret_num numeric(9,3) null,
   dep_date datetime null,
   buy_price numeric(12,6) null,
   primary key(dep_no,prod_no,batch_no,prod_add)
)


if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempresult'))
DROP TABLE #tempresult

create table #tempresult
(
   dep_no char(16) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   dep_date datetime null,
   dep_num numeric(16,3) null,
   inv_num numeric(16,3) null,
   lest_num numeric(16,3) null,
   buy_price numeric(12,6) null 
   primary key(dep_no,prod_no,batch_no,prod_add)
)

 
 
insert #tempbatch(prod_no,batch_no,prod_add,mark)
select dp.prod_no,dp.batch_no,dp.prod_add,'p' from prod_dep dp left join product p on dp.prod_no=p.prod_no where p.sb_sc_bz is null 


insert #tempbatch(prod_no,batch_no,prod_add,mark)
select distinct ivs.prod_no,ivs.batch_no,ivs.prod_add,'n' from inv_sub ivs 
left join inv_main im on ivs.list_no=im.list_no 
left join product p on ivs.prod_no=p.prod_no 
where  im.inv_date>=@begdt and im.inv_date<=@endt 
 and not exists(select * from #tempbatch t where t.prod_no=ivs.prod_no and t.batch_no=ivs.batch_no and t.prod_add=ivs.prod_add) 
 and p.sb_sc_bz is null 



insert #tempbatch(prod_no,batch_no,prod_add,mark)
select distinct ds.prod_no,ds.batch_no,ds.prod_add,'n' from dep_sub ds 
left join dep_main dm on ds.dep_no=dm.dep_no 
left join product p on ds.prod_no=p.prod_no 
where  dm.dep_date>=@begdt and dm.dep_date<=@endt and 
not exists(select * from #tempbatch t where t.prod_no=ds.prod_no and t.batch_no=ds.batch_no and t.prod_add=ds.prod_add) 
and p.sb_sc_bz is null 
 
 

 





declare cur_batch cursor for select prod_no,batch_no,prod_add,mark from #tempbatch
open cur_batch
fetch next from cur_batch into @prodno,@batchno,@prodadd,@mark
while @@fetch_status=0
begin --#7


if exists(select * from #tempinv)
delete from #tempinv



if exists(select * from #tempdep)
delete from #tempdep

select @sumdepnum=sum(dep_num - had_ret_num) from dep_sub where prod_no=@prodno and batch_no=@batchno and prod_Add=@prodadd

select @thecount=count(*) from dep_sub where prod_no=@prodno and batch_no=@batchno and prod_Add=@prodadd

select @invcount=count(*) from inv_sub where prod_no=@prodno and batch_no=@batchno and prod_Add=@prodadd

select  @suminvnum=sum(inv_num - had_back_num) from inv_sub where prod_no=@prodno and batch_no=@batchno and prod_Add=@prodadd

if @sumdepnum>0 and @thecount>0
begin

  insert #tempdep(dep_no,prod_no,batch_no,prod_add,dep_num,dep_date,buy_price)
    select s.dep_no,s.prod_no,s.batch_no,s.prod_add,s.dep_num - s.had_ret_num,m.dep_date,buy_price from dep_sub s left join dep_main m on s.dep_no=m.dep_no
     where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
    order by m.dep_date,m.dep_no
    
    insert #tempinv(list_no,prod_no,batch_no,prod_add,inv_num,had_back_num,inv_date)
    select s.list_no,s.prod_no,s.batch_no,s.prod_add,isnull(s.inv_num  ,0) as inv_num,isnull(s.had_back_num,0) as had_back_num,m.inv_date from inv_sub s left join inv_main m on s.list_no=m.list_no  
    where s.prod_no=@prodno and s.batch_no=@batchno and s.prod_add=@prodadd 
    order by m.inv_date,m.list_no
    
    
    declare cur_dep cursor for select dep_no,dep_num,dep_date,buy_price from #tempdep        
   open cur_dep
   fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
   
   select @controllmark1=0,@controllmark2=0
   select @invsumnumbak=0.0
   
    while @@fetch_status=0 and @controllmark1=0
    begin
    
      declare cur_inv cursor for select list_no,inv_num,had_back_num,inv_date from #tempinv
   open cur_inv
   fetch next from cur_inv into @listno,@invnum,@hadbacknum,@invdate
   select @controllmark2=0
   while @@fetch_status=0 and @controllmark2=0
   begin
   
     if @depdate<=@invdate
     begin
     --正常情况
     select @invsumnumbak=@invsumnumbak+@invnum -@hadbacknum
     
      if @depnum=@invsumnumbak
       begin
        --进仓数等于销售总数
           
                if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                        update #tempresult set inv_num=@depnum,lest_num=0.0 where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                 else
                         insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                          select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@depnum,0.0 ,@buyprice
                
            
            
             fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
             if @@fetch_status<>0
             begin
              select @controllmark1=1,@controllmark2=1
              break
             
             end
             
             select @invsumnumbak=0.0
             
              
       end
       else if @depnum<@invsumnumbak
       begin
        --进仓数小于销售总数
        
            
                if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                        update #tempresult set  inv_num=@depnum,lest_num=0.0 where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                 else
                         insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                          select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@depnum,0.0 ,@buyprice
                
            
            
            select  @invsumnumbak=@invsumnumbak-@depnum
            select @depnum=0
            
           
           
              fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
              if @@fetch_status<>0
              
                begin
                 select @controllmark1=1,@controllmark2=1
                 insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                 select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),0.0,@invsumnumbak,0.0 ,0.0
     
                 break
            
                end
              
              while @invsumnumbak>0 and @@fetch_status=0
             begin
             
                 if @depdate<=@invdate
                 begin
                    if @invsumnumbak<@depnum
                    begin
                    --进仓数大于等于销售数量合计
                       
                             if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                                update #tempresult set inv_num=@invsumnumbak,lest_num=@depnum - @invsumnumbak where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                             else
                               insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                               select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@invsumnumbak,@depnum - @invsumnumbak ,@buyprice
                             
                        
                        
                        select @depnum=@depnum - @invsumnumbak
                        select @invsumnumbak=0.0 
                        break
                     end
                    else if @invsumnumbak=@depnum
                     begin
                     
                         if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                                update #tempresult set inv_num=@invsumnumbak,lest_num=@depnum - @invsumnumbak where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                             else
                               insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                               select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@invsumnumbak,@depnum - @invsumnumbak ,@buyprice
                       
                        
                         select @invsumnumbak=0.0 
                        
                        
            
                       
                     
                     end
                    
                    else
                    --进仓数小于销售数量合计
                    begin
                            if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
                                update #tempresult set inv_num=@depnum,lest_num=0.0 where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
                             else
                               insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                               select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@depnum,0.0 ,@buyprice
                             
                              select  @invsumnumbak=@invsumnumbak-@depnum
                              select @depnum=0
                    end
                  end
                  else
                     begin
                      select @controllmark1=1,@controllmark2=1
                      insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                      select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),0.0,@invsumnumbak,0.0 ,0.0
     
                       break
            
                     end
             
              fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
               end
             
       end
       
       else
       begin
        --进仓大于销售数
        
        
            if exists(select * from #tempresult where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd)
             update #tempresult set inv_num=@invsumnumbak,lest_num=@depnum - @invsumnumbak where dep_no=@depno and prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
            else
              insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
             select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,@invsumnumbak,@depnum - @invsumnumbak ,@buyprice
          
       --   select @invsumnumbak=0.0
       end
          
     
     
     end
     else
     begin
      --不正常情况
      select @controllmark1=1,@controllmark2=1
      
      insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
      select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),isnull(@sumdepnum,0),isnull(@suminvnum,0),0.0 ,0.0
      
      break
     
     end
   
   
   
    
    fetch next from cur_inv into @listno,@invnum,@hadbacknum,@invdate
   end
   close cur_inv
   deallocate cur_inv
    
    
     
       select @controllmark1=1,@controllmark2=1
       break
     
    
      
       fetch next from cur_dep into @depno,@depnum,@depdate,@buyprice
     
    end
    close cur_dep
    deallocate cur_dep

  if @invcount=0 
  begin
  
           
                insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
                select @depno,@prodno,@batchno,@prodadd,@depdate,@depnum,0.0,@depnum ,@buyprice
        
            
  
  end


end
else if  @suminvnum>0 and @invcount>0
begin
-- 进仓数为0但是销售数量减了退货数仍然大于零，这时出错
insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),isnull(@sumdepnum,0),isnull(@suminvnum,0),0.0 ,0.0

end


fetch next from cur_batch into @prodno,@batchno,@prodadd,@mark
end
close cur_batch
deallocate cur_batch

select  t.dep_no ,t.prod_no ,t.batch_no ,t.prod_add ,t.dep_date ,t.dep_num ,t.inv_num,t.lest_num ,t.buy_price,p.prod_made from  #tempresult t left join product p on t.prod_no=p.prod_no

go

create  procedure [dbo].[cal_month_dep_fast]  @begdt datetime,@endt datetime 
as

declare @prodno char(8),@batchno char(12),@prodadd char(12),@depnum numeric(9,3)

declare @prodnodep char(8),@batchnodep char(12),@prodadddep char(12),@depnumdep numeric(9,3),@depnodep char(16)
declare @buypricedep numeric(12,3),@depdatedep datetime
declare @thecount int
declare @sumdepnum numeric(16,3),@suminvnum numeric(16,3)
declare @sumbacknum numeric(16,3),@sumretnum numeric(16,3),@lestnumdep numeric(9,3)

declare @sumdepnumactually  numeric(16,3),@suminvnumactually numeric(16,3)

if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempbatch'))
DROP TABLE #tempbatch

create table #tempbatch
(
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   primary key(prod_no,batch_no,prod_add)
)


if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempbatchdep'))
DROP TABLE #tempbatchdep

create table #tempbatchdep
(
   dep_no char(16) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   dep_num numeric(9,3) null,
   buy_price numeric(12,6) null,
   dep_date datetime null,
   
   primary key(dep_no,prod_no,batch_no,prod_add)
)

if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempresult'))
DROP TABLE #tempresult

create table #tempresult
(
   dep_no char(16) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   dep_date datetime null,
   dep_num numeric(16,3) null,
   inv_num numeric(16,3) null,
   lest_num numeric(16,3) null,
   buy_price numeric(12,6) null 
   primary key(dep_no,prod_no,batch_no,prod_add)
)



insert #tempbatch(prod_no,batch_no,prod_add)
select distinct s.prod_no,s.batch_no,s.prod_add from inv_sub s 
left join inv_main m on s.list_no=m.list_no left join product p on s.prod_no=p.prod_no 
where  m.inv_date>=@begdt and m.inv_date<=@endt and p.sb_sc_bz is null
union all
select dp.prod_no,dp.batch_no,dp.prod_add from prod_dep dp
 left join( select sb.prod_no,sb.batch_no,sb.prod_add,inv_num,im.inv_date  from inv_sub sb ,inv_main im where sb.list_no=im.list_no and   im.inv_date>=@begdt and im.inv_date<=@endt )ss on dp.prod_no=ss.prod_no and dp.batch_no=ss.batch_no and dp.prod_add=ss.prod_add 
 left join product p2 on dp.prod_no=p2.prod_no 
where   ss.inv_num is null and p2.sb_sc_bz is null 

declare cur_batch cursor for select prod_no,batch_no,prod_add from #tempbatch
open cur_batch
fetch next from cur_batch into @prodno,@batchno,@prodadd
while @@fetch_status=0
begin

select @sumdepnum=convert(numeric(16,3),isnull(sum(dep_num),0)) from dep_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
select @suminvnum=convert(numeric(16,3),isnull(sum(inv_num),0)) from inv_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
select  @sumbacknum=convert(numeric(16,3),isnull(sum(back_num),0)) from back_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
select  @sumretnum=convert(numeric(16,3),isnull(sum(ret_num),0)) from ret_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd

select @thecount=count(*) from dep_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd

select @sumdepnumactually=@sumdepnum - @sumretnum

select @suminvnumactually= @suminvnum - @sumbacknum


if @sumdepnumactually<0
begin
select @lestnumdep=isnull(lest_num,0) from prod_dep where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
select @buypricedep=isnull(buy_price,0) from prod_det where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),isnull(@sumdepnumactually,0),isnull(@suminvnumactually ,0),isnull(@lestnumdep,0) ,isnull(@buypricedep,0)
fetch next from cur_batch into @prodno,@batchno,@prodadd
continue
end





if @sumdepnumactually<@suminvnumactually 
begin

select @lestnumdep=isnull(lest_num,0) from prod_dep where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
select @buypricedep=isnull(buy_price,0) from prod_det where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),isnull(@sumdepnumactually,0),isnull(@suminvnumactually ,0),isnull(@lestnumdep,0) ,isnull(@buypricedep,0)
fetch next from cur_batch into @prodno,@batchno,@prodadd
continue
end




delete from #tempbatchdep

insert #tempbatchdep(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,buy_price) 
select s.dep_no,s.prod_no,s.batch_no,s.prod_add,m.dep_date,s.dep_num - isnull(d.sum_ret_num,0) as dep_num,s.buy_price from dep_sub s 
left join dep_main m on s.dep_no=m.dep_no left join (select rm.dep_no,rs.prod_no,rs.batch_no,rs.prod_add,isnull(sum(ret_num),0) as sum_ret_num from ret_sub rs left join ret_main rm on rs.ret_no=rm.ret_no group by rm.dep_no,rs.prod_no,rs.batch_no,rs.prod_add) d on s.dep_no=d.dep_no and s.prod_no=d.prod_no and s.batch_no=d.batch_no and s.prod_add=d.prod_add
  where s.prod_no=@prodno and s.batch_no=@batchno and s.prod_add=@prodadd 
order by  m.dep_date,s.dep_no

declare cur_dep cursor for select dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num  ,buy_price from #tempbatchdep 
open cur_dep
fetch next from cur_dep into @depnodep,@prodnodep,@batchnodep ,@prodadddep ,@depdatedep,@depnumdep,@buypricedep

while @@fetch_status=0
begin

if @depnumdep<@suminvnumactually
begin
select @suminvnumactually=@suminvnumactually-@depnumdep

end
else
begin

select @lestnumdep=@depnumdep - @suminvnumactually
insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
select @depnodep,@prodnodep,@batchnodep ,@prodadddep,@depdatedep,@depnumdep,convert(numeric(16,3),@suminvnumactually),@lestnumdep ,@buypricedep
select @suminvnumactually=0
end

fetch next from cur_dep into @depnodep,@prodnodep,@batchnodep ,@prodadddep ,@depdatedep,@depnumdep,@buypricedep
end
close cur_dep
deallocate cur_dep



fetch next from cur_batch into @prodno,@batchno,@prodadd
end 
close cur_batch
deallocate cur_batch

select  t.dep_no ,t.prod_no ,t.batch_no ,t.prod_add ,t.dep_date ,t.dep_num ,t.inv_num,t.lest_num ,t.buy_price,p.prod_made from  #tempresult t left join product p on t.prod_no=p.prod_no 
go
ALTER  procedure [dbo].[cal_month_dep_fast]  @begdt datetime,@endt datetime 
as

declare @prodno char(8),@batchno char(12),@prodadd char(12),@depnum numeric(9,3)

declare @prodnodep char(8),@batchnodep char(12),@prodadddep char(12),@depnumdep numeric(9,3),@depnodep char(16)
declare @buypricedep numeric(12,3),@depdatedep datetime
declare @thecount int
declare @sumdepnum numeric(16,3),@suminvnum numeric(16,3)
declare @sumbacknum numeric(16,3),@sumretnum numeric(16,3),@lestnumdep numeric(9,3)

declare @sumdepnumactually  numeric(16,3),@suminvnumactually numeric(16,3)

if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempbatch'))
DROP TABLE #tempbatch

create table #tempbatch
(
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   primary key(prod_no,batch_no,prod_add)
)


if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempbatchdep'))
DROP TABLE #tempbatchdep

create table #tempbatchdep
(
   dep_no char(16) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   dep_num numeric(9,3) null,
   buy_price numeric(12,6) null,
   dep_date datetime null,
   
   primary key(dep_no,prod_no,batch_no,prod_add)
)

if exists (select  * from tempdb.dbo.sysobjects o where o.xtype in ('U') and o.id = object_id(N'tempdb..#tempresult'))
DROP TABLE #tempresult

create table #tempresult
(
   dep_no char(16) not null,
   prod_no char(8) not null,
   batch_no char(12) not null,
   prod_add char(12) not null,
   dep_date datetime null,
   dep_num numeric(16,3) null,
   inv_num numeric(16,3) null,
   lest_num numeric(16,3) null,
   buy_price numeric(12,6) null 
   primary key(dep_no,prod_no,batch_no,prod_add)
)



insert #tempbatch(prod_no,batch_no,prod_add)
select distinct s.prod_no,s.batch_no,s.prod_add from inv_sub s 
left join inv_main m on s.list_no=m.list_no left join product p on s.prod_no=p.prod_no 
where  m.inv_date>=@begdt and m.inv_date<=@endt and p.sb_sc_bz is null
union all
select dp.prod_no,dp.batch_no,dp.prod_add from prod_dep dp
 left join( select sb.prod_no,sb.batch_no,sb.prod_add,inv_num,im.inv_date  from inv_sub sb ,inv_main im where sb.list_no=im.list_no and   im.inv_date>=@begdt and im.inv_date<=@endt )ss on dp.prod_no=ss.prod_no and dp.batch_no=ss.batch_no and dp.prod_add=ss.prod_add 
 left join product p2 on dp.prod_no=p2.prod_no 
where   ss.inv_num is null and p2.sb_sc_bz is null 

declare cur_batch cursor for select prod_no,batch_no,prod_add from #tempbatch
open cur_batch
fetch next from cur_batch into @prodno,@batchno,@prodadd
while @@fetch_status=0
begin

select @sumdepnum=convert(numeric(16,3),isnull(sum(dep_num),0)) from dep_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
select @suminvnum=convert(numeric(16,3),isnull(sum(inv_num),0)) from inv_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
select  @sumbacknum=convert(numeric(16,3),isnull(sum(back_num),0)) from back_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd
select  @sumretnum=convert(numeric(16,3),isnull(sum(ret_num),0)) from ret_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd

select @thecount=count(*) from dep_sub where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd

select @sumdepnumactually=@sumdepnum - @sumretnum

select @suminvnumactually= @suminvnum - @sumbacknum


if @sumdepnumactually<0
begin
select @lestnumdep=isnull(lest_num,0) from prod_dep where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
select @buypricedep=isnull(buy_price,0) from prod_det where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),isnull(@sumdepnumactually,0),isnull(@suminvnumactually ,0),isnull(@lestnumdep,0) ,isnull(@buypricedep,0)
fetch next from cur_batch into @prodno,@batchno,@prodadd
continue
end





if @sumdepnumactually<@suminvnumactually 
begin

select @lestnumdep=isnull(lest_num,0) from prod_dep where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
select @buypricedep=isnull(buy_price,0) from prod_det where prod_no=@prodno and batch_no=@batchno and prod_add=@prodadd 
insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
select 'error',@prodno,@batchno,@prodadd,convert(datetime,'2100-01-01'),isnull(@sumdepnumactually,0),isnull(@suminvnumactually ,0),isnull(@lestnumdep,0) ,isnull(@buypricedep,0)
fetch next from cur_batch into @prodno,@batchno,@prodadd
continue
end




delete from #tempbatchdep

insert #tempbatchdep(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,buy_price) 
select s.dep_no,s.prod_no,s.batch_no,s.prod_add,m.dep_date,s.dep_num - isnull(d.sum_ret_num,0) as dep_num,s.buy_price from dep_sub s 
left join dep_main m on s.dep_no=m.dep_no left join (select rm.dep_no,rs.prod_no,rs.batch_no,rs.prod_add,isnull(sum(ret_num),0) as sum_ret_num from ret_sub rs left join ret_main rm on rs.ret_no=rm.ret_no group by rm.dep_no,rs.prod_no,rs.batch_no,rs.prod_add) d on s.dep_no=d.dep_no and s.prod_no=d.prod_no and s.batch_no=d.batch_no and s.prod_add=d.prod_add
  where s.prod_no=@prodno and s.batch_no=@batchno and s.prod_add=@prodadd 
order by  m.dep_date,s.dep_no

declare cur_dep cursor for select dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num  ,buy_price from #tempbatchdep 
open cur_dep
fetch next from cur_dep into @depnodep,@prodnodep,@batchnodep ,@prodadddep ,@depdatedep,@depnumdep,@buypricedep

while @@fetch_status=0
begin

if @depnumdep<@suminvnumactually
begin
select @suminvnumactually=@suminvnumactually-@depnumdep

end
else
begin

select @lestnumdep=@depnumdep - @suminvnumactually
insert #tempresult(dep_no ,prod_no,batch_no,prod_add,dep_date,dep_num,inv_num,lest_num,buy_price) 
select @depnodep,@prodnodep,@batchnodep ,@prodadddep,@depdatedep,@depnumdep,convert(numeric(16,3),@suminvnumactually),@lestnumdep ,@buypricedep
select @suminvnumactually=0
end

fetch next from cur_dep into @depnodep,@prodnodep,@batchnodep ,@prodadddep ,@depdatedep,@depnumdep,@buypricedep
end
close cur_dep
deallocate cur_dep



fetch next from cur_batch into @prodno,@batchno,@prodadd
end 
close cur_batch
deallocate cur_batch

select  t.dep_no ,t.prod_no ,t.batch_no ,t.prod_add ,t.dep_date ,t.dep_num ,t.inv_num,t.lest_num ,t.buy_price,p.prod_made from  #tempresult t left join product p on t.prod_no=p.prod_no 
go




if not EXISTS(select   *   from   syscolumns   where   [name]= 'com_kc1_date'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
ALTER TABLE [dbo].[company] ADD  [com_kc1_date] [int] NOT NULL  DEFAULT (0) 
go
if not EXISTS(select   *   from   syscolumns   where   [name]= 'com_kc1_date2'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
ALTER TABLE [dbo].[company] ADD  [com_kc1_date2] [int] NOT NULL DEFAULT (0)
go

if not EXISTS(select   *   from   syscolumns   where   [name]= 'qjwmedshopcode'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
alter table company  add qjwmedshopcode char(30) null
go
if not EXISTS(select   *   from   syscolumns   where   [name]= 'qjwmedshopname'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
alter table company  add qjwmedshopname char(100) null
go
if   EXISTS(Select * from syscolumns Where ID=OBJECT_ID('company') and name='qjwmedshopname' and length=60)
ALTER TABLE company ALTER COLUMN qjwmedshopname char(100) null
go
if not EXISTS(select   *   from   syscolumns   where   [name]= 'qjwcounterno'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
alter table company  add qjwcounterno char(30) null
go
if not EXISTS(select   *   from   syscolumns   where   [name]= 'qjwcountername'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
alter table company  add qjwcountername char(100) null
go
if not EXISTS(select   *   from   syscolumns   where   [name]= 'qjwprovince'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
alter table company  add qjwprovince char(20) not null default('广东')
go
if not EXISTS(select   *   from   syscolumns   where   [name]= 'qjwcity'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
alter table company  add qjwcity char(20) not null default('东莞')
go
if not EXISTS(select   *   from   syscolumns   where   [name]= 'qjwcounty'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
alter table company  add qjwcounty char(20) not null default('东莞')
go
if not EXISTS(select   *   from   syscolumns   where   [name]= 'printusercode'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company' )
alter table company  add printusercode varchar(1) null
go
if not exists (select   *   from   syscolumns   where   [name]= 'ylbusewin7method'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company')
alter table company add ylbusewin7method char(1) not null default('0')
go
if not exists (select   *   from   syscolumns   where   [name]= 'allowsellpricegreatbuyprice'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company')
alter table company add allowsellpricegreatbuyprice char(1) null
go
if not exists (select   *   from   syscolumns   where   [name]= 'ylb_store_stoken'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company ')
alter table company add ylb_store_stoken char(40) null
go
if not exists (select   *   from   syscolumns   where   [name]= 'sb_useaddionalpos'   and   OBJECTPROPERTY(id, 'IsUserTable ')=1   and   object_name(id)= 'company')
ALTER TABLE company ADD sb_useaddionalpos char (1)  not NULL default('1') 
go