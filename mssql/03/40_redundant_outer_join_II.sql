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
-- This test introduce redundant outer join. 
-- The outer join is eliminated by the `a.id is not null` predicate.
CREATE Procedure join_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable a
	join TestTable b on b.local_search = a.id
	where a.global_search = 1 and b.groupby = 10
	option(maxdop 1)

	-- 2. Unnecessary LEFT JOIN II
	PRINT '2. Unnecessary LEFT JOIN II'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	left join TestTable a on b.local_search = a.id and 
	                        a.global_search = 1
	where a.id is not null and b.groupby = 10
	option(maxdop 1)

end
go



