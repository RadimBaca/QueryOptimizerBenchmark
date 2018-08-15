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
-- This test remove the conditional aggregation since the CASE condition has to be always satisfied.
-- That is caused by the fact that the condition is already in WHERE predicate.
-- Please note that removing the COUNT CASE is tricky and we should be aware of NULLs.
CREATE Procedure single_II_test as
begin

	-- 1. Conditional aggreagtion
	PRINT '1. Conditional aggreagtion'
	select g1.groupby,
		   count(case when local_search = 1 then 1 end) as c,
		   max(case when local_search = 1 then local_search end) as local_search
	from TestTable g1
	where local_search = 1 or local_search IS NULL
	group by groupby
	option(maxdop 1)

	
	-- 1. Without CASE
	PRINT '1. Without CASE'
	select g1.groupby,
		   count(orderby) as c,
		   max(local_search) as local_search
	from TestTable g1
	where local_search = 1 or local_search IS NULL
	group by groupby
	option(maxdop 1)
end
go

