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
-- This test introduce a redundant predicate that is covered by the other parts of the query.
-- More precisely, the `a.global_search = 1` predicate on the same data can be found twice in the second query (once in the subquery and once in the outer query).
CREATE Procedure join_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable a
	join TestTable b on b.local_search = a.id
	where a.global_search = 1 and b.groupby = 10
	option(maxdop 1)

	-- 2. Redundant predicate elimination II
	PRINT '2. Redundant predicate elimination II'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	join (select * from TestTable where global_search = 1) a on b.local_search = a.id
	where a.global_search = 1 and -- this predicate can be eliminated since it is covered by the predicate in the subquery
	      b.groupby = 10
	option(maxdop 1)

end
go



