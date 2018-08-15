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
-- Rewrite of the HAVING condition which eliminate one aggregate function.
CREATE Procedure single_II_test as
begin

	--1. HAVING with two aggregates
	PRINT 'HAVING with two aggregates'
	select groupby
	from TestTable
	group by groupby
	having count(case when local_search < 600 or local_search IS NULL then 1 end) = count(*)
	option(maxdop 1)

	--2. HAVING with one aggregate
	PRINT 'HAVING with one aggregate'
	select groupby
	from TestTable
	group by groupby
	having count(case when local_search >= 600 then 1 end) = 0
	option(maxdop 1)

end
go
