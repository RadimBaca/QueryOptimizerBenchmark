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
-- We test the capability to omit an unnecessary `GROUP BY` clause.
-- The grouping is performed on one group, therefore, there is no need to do include the GROUP BY.
CREATE Procedure single_II_test as
begin


	-- 1. GROUP BY
	PRINT '1. GROUP BY'
	SELECT groupby, max(local_search) gmax
	from TestTable
	where groupby = 1
	group by groupby
	option(maxdop 1)

	--2. GROUP BY eliminated
	PRINT '2. GROUP BY eliminated'
	SELECT 1 groupby, max(local_search) gmax
	from TestTable
	where groupby = 1
	option(maxdop 1)


end
go

