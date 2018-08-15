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
-- This test compare two queries where one have the aggregation nested in a subquery.
-- It is equivalent since there are no joins and `g1.groupby` is the only attribute from the outer query that is used in the subqueries.
CREATE Procedure single_II_test as
begin

	-- 1. Subquery + distinct
	PRINT '1. Subquery + distinct'
	select distinct g1.groupby,
		   (select count(*) from TestTable g2 where local_search = 1 and g1.groupby = g2.groupby) as cnt
	from TestTable g1
	option(maxdop 1)

	--2. Subquery + distinct in subquery
	PRINT '2. Subquery + distinct in subquery'
	select g1.groupby,
		   (select count(*) from TestTable g2 where local_search = 1 and g1.groupby = g2.groupby) as cnt
	from (select distinct groupby from TestTable) g1
	option(maxdop 1)

end
go

