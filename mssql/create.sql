--======================================================
--
-- Author: Radim Baca
-- Create date: 17.1.2017
-- Description: Script creates a testing data for the benchmark.
-- License: This code was writtend by Radim Baca and is the property of VSB-TUO 
--          This code MAY NOT BE USED without the expressed written consent of VSB-TUO.
-- Change history:
--
--======================================================



/***********************************************************/
/**********************    Create   ************************/
/***********************************************************/

SET STATISTICS TIME off

IF OBJECT_ID('dbo.Table1', 'U') IS NOT NULL  DROP TABLE dbo.Table1
IF OBJECT_ID('dbo.Table2', 'U') IS NOT NULL  DROP TABLE dbo.Table2
go


WITH x AS 
(
  SELECT n FROM (VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) v(n)
), t1 AS
(
  SELECT ones.n + 10 * tens.n + 100 * hundreds.n + 1000 * thousands.n + 10000 * tenthousands.n as id  
  FROM x ones,     x tens,      x hundreds,       x thousands,       x tenthousands
), t2 AS
(
	SELECT  id,
			id % 100 groupby
	FROM t1
), t3 AS
(
	--SELECT  b.id, b.groupby, count(*) orderby
	--FROM t2 b
	--JOIN t2 b on b.groupby = b.groupby and b.id > b.id
	--group by b.id, b.groupby		

	SELECT  b.id, b.groupby, row_number() over (partition by groupby order by id) orderby
	FROM t2 b
)
SELECT  id, 
        groupby, 
		cast(orderby as int) orderby,
        cast(orderby % (groupby * 100 + 1) as int) local_search, 
		cast((exp(- square(cast(id as float)/50000)) / sqrt(3.1428)) * groupby as int)  local_gauss,
		id % 1000 global_search,
		LEFT('Value ' + CAST(CHECKSUM(NEWID()) AS VARCHAR) + ' ' + REPLICATE('*', 1000), 1000) as padding
	INTO Table1
FROM t3
go


WITH x AS 
(
  SELECT n FROM (VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9)) v(n)
), t1 AS
(
  SELECT ones.n + 10 * tens.n + 100 * hundreds.n + 1000 * thousands.n + 10000 * tenthousands.n + 100000 * hundredthousands.n as id  
  FROM x ones,     x tens,      x hundreds,       x thousands,       x tenthousands,       x hundredthousands
), t2 AS
(
	SELECT  id,
			id % 100 groupby
	FROM t1
), t3 AS
(
	--SELECT  b.id, b.groupby, count(*) orderby
	--FROM t2 b
	--JOIN t2 b on b.groupby = b.groupby and b.id > b.id
	--group by b.id, b.groupby	
		
	SELECT  b.id, b.groupby, row_number() over (partition by groupby order by id) orderby
	FROM t2 b
)
SELECT  id, 
        groupby, 
		cast(orderby as int) orderby,
        cast(orderby % (groupby * 100 + 1) as int) local_search, 
		cast((exp(- square(cast(id as float)/50000)) / sqrt(3.1428)) * groupby as int)  local_gauss,
		id % 10000 global_search, 
		LEFT('Value ' + CAST(CHECKSUM(NEWID()) AS VARCHAR) + ' ' + REPLICATE('*', 1000), 1000) as padding
	INTO Table2
FROM t3
go

insert into table1(id, groupby, orderby, local_search, local_gauss, global_search, padding) values (100000, null, null, null, null, null, '*');
insert into table2(id, groupby, orderby, local_search, local_gauss, global_search, padding) values (1000000, null, null, null, null, null, '*');
insert into table1(id, groupby, orderby, local_search, local_gauss, global_search, padding) values (100001, 100, null, null, null, null, '*');
insert into table2(id, groupby, orderby, local_search, local_gauss, global_search, padding) values (1000001, 100, null, null, null, null, '*');
insert into table2(id, groupby, orderby, local_search, local_gauss, global_search, padding) values (1000002, 99, 10000, null, null, null, '*');

alter table Table1 alter column id int not null
go
alter table Table2 alter column id int not null
go






-- TODO 2: scale number of items per group, scale size of padding (small, middle, large)
