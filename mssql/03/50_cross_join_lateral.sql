--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure join_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS join_test
go
-- Description: 
---------------
-- The second query uses a cross join lateral + aggregation function to implement the semijoin
CREATE Procedure join_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select distinct b.groupby
	from TestTable b
	join TestTable a on b.local_search = a.id
	where a.global_search = 1
	option(maxdop 1)

	-- 5. CROSS APPLY
	PRINT '5. CROSS APPLY'
	select distinct b.groupby
	from TestTable b
	cross apply (
	  select count(*) table1_c 
	  from TestTable a 
	  where b.local_search = a.id and 
	        a.global_search = 1
	) t
	where t.table1_c > 0
	option(maxdop 1)

end
go



