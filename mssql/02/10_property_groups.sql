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
-- Rewrite of the HAVING into a EXISTS or INTERSECT. 
-- This is quite common non-trivial task where we search for groups having certain set of properties.
CREATE Procedure single_II_test as
begin

	--1. Having variant
	PRINT 'HAVING'
	select groupby
	from TestTable
	where local_search in (500, 501)
	group by groupby
	having count(distinct local_search) = 2
	option(maxdop 1)


	--2. EXISTS subquery variant
	PRINT 'EXISTS subquery variant'
	select groupby
	from (
	  select distinct groupby from TestTable
	) a
	where exists (
	  select 1
	  from TestTable b
	  where b.local_search = 500 and
			a.groupby = b.groupby
	) and exists (
	  select 1
	  from TestTable b
	  where b.local_search = 501 and
			a.groupby = b.groupby
	)
	option(maxdop 1)


	--3. INTERSECT variant
	PRINT 'INTERSECT variant'
	select groupby
	from TestTable
	where local_search = 500
    intersect
	select groupby
	from TestTable
	where local_search = 501
	option(maxdop 1)

end
go
