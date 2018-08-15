--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure single_II_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS single_II_test
go
-- Description: 
---------------
-- Rewrite of the HAVING into a subquery.
CREATE Procedure single_II_test as
begin

	--1. Having variant
	PRINT 'HAVING'
	select groupby
	from TestTable
	group by groupby
	having sum(local_search) < 1000000
	option(maxdop 1)

	--2. Subquery variant
	PRINT 'Subquery variant'
	select groupby
	from (select distinct groupby from TestTable) t
	where 1000000 > (
	  select sum(local_search)
	  from TestTable t2
	  where t2.groupby = t.groupby
	)
	option(maxdop 1)

end
go
