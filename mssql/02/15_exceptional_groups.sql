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
-- This is quite common non-trivial task where we search for groups where all rows in group satisfy certain condition.
CREATE Procedure single_II_test as
begin

	--1. Having variant
	PRINT 'HAVING'
	select groupby
	from TestTable
	group by groupby
	having count(case when local_search < 600 or local_search IS NULL then 1 end) = count(*)
	option(maxdop 1)

	--2. NOT EXISTS subquery variant
	PRINT 'NOT EXISTS subquery variant'
	select groupby
	from (
	  select distinct groupby from TestTable
	) a
	where not exists (
	  select 1
	  from TestTable b
	  where b.local_search >= 600 and
			a.groupby = b.groupby
	)  
	option(maxdop 1)


	--3. Difference variant
	PRINT 'Difference variant'
	select distinct groupby
	from TestTable
    except
	select groupby
	from TestTable
	where local_search >= 600
	option(maxdop 1)

end
go
