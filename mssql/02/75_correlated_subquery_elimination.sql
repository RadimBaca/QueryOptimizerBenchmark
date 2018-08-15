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
-- We test the capability to omit unnecessary correlation in a subquery.
-- The correlation is unnecessary since the outer query has a specific predicate on the correlation attribute.
CREATE Procedure single_II_test as
begin


	-- 1. Correlated subquery
	PRINT '1. Correlated subquery'
	select t.*
	from TestTable t
	where local_search = (
	  select max(local_search)
	  from TestTable t2
	  where t2.groupby = t.groupby
	) and t.groupby = 1
	option(maxdop 1)

	--2. Independent subquery
	PRINT '2. Independent subquery'
	select t.*
	from TestTable t
	where local_search = (
	  select max(local_search) gmax
	  from TestTable t2
	  where t2.groupby = 1
	) and t.groupby = 1
	option(maxdop 1)


end
go

