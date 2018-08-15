--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure join_pk_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS join_pk_test
go
-- Description: 
---------------
-- Introducing redundant join into a simple SQL
-- The last join in the second query is redundant since the following is true:
--     1. The `TestTable.id` attribute is unique. (therefore it is not possible to multiply the resut adding the join)
--     2. The `m2.id` attribute is the only attribute of m2 used in the query.
--     3. The identical join is already in query
CREATE Procedure join_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	join TestTable a on b.local_search = a.id
	where a.global_search = 1 and b.groupby = 10
	option(maxdop 1)

	-- 2. Redundant join I 
	PRINT '2. Redundant join I'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	join TestTable m1 on b.local_search = m1.id
	join TestTable m2 on b.local_search = m2.id -- this join can be eliminated if the Table1.id attribute is the primary key
	where m1.global_search = 1 and b.groupby = 10
	option(maxdop 1)

end
go

