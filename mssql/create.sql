--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates the testing table and fill it with data. This is the first testing step for any test.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================



/***********************************************************/
/**********************    Create   ************************/
/***********************************************************/

SET STATISTICS TIME off

IF OBJECT_ID('dbo.TestTable', 'U') IS NOT NULL  DROP TABLE dbo.TestTable
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
	SELECT  b.id, b.groupby, row_number() over (partition by groupby order by id) orderby
	FROM t2 b
)
SELECT  id, 
        groupby, 
		cast(orderby as int) orderby,
        cast(orderby % (groupby * 100 + 1) as int) local_search, 
		id % 10000 global_search, 
		LEFT('Value ' + CAST(CHECKSUM(NEWID()) AS VARCHAR) + ' ' + REPLICATE('*', 1000), 1000) as padding
	INTO TestTable
FROM t3
go

insert into TestTable(id, groupby, orderby, local_search, global_search, padding) values (1000000, null, null, null, null, '*');
insert into TestTable(id, groupby, orderby, local_search, global_search, padding) values (1000001, 100, null, null, null, '*');
insert into TestTable(id, groupby, orderby, local_search, global_search, padding) values (1000002, 99, 10000, null, null, '*');

alter table TestTable alter column id int not null
go