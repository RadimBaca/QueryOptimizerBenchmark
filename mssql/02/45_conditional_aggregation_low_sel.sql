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
-- Conditional aggreagtion versus solution using subquery with distinct. 
-- This test uses a medium selectivity condition in the predicate (100% of rows per group).
CREATE Procedure single_II_test as
begin

	-- 1. Conditional aggregation
	PRINT '1. Conditional aggregation'
	select groupby,
		   count(case when local_search < 5000 then 1 end) as orderby1,
		   count(case when local_search > 5000 then 1 end) as orderby2
	from TestTable
	group by groupby
	option(maxdop 1)

	-- 2. Subquery + distinct
	PRINT '2. Subquery + distinct'
	select distinct g1.groupby,
		   (select count(*) from TestTable g2 where local_search < 5000 and g1.groupby = g2.groupby) as orderby1,
		   (select count(*) from TestTable g2 where local_search > 5000 and g1.groupby = g2.groupby) as orderby2
	from TestTable g1
	option(maxdop 1)


end
go


