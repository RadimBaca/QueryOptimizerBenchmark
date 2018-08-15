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
-- Merge of two join into one.
-- The merge of joins is possible:
--        1. If `TestTable.id` is a primary key,
--        2. joins are using the same table and the same join condition,
--        3. we are not using attributes from `TestTable` in the SQL output,
--        4. we perform group by according to the attribute in the join.
CREATE Procedure join_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	join TestTable m1 on b.id = m1.local_search and m1.groupby = 20 
	join TestTable m2 on b.id = m2.local_search and m2.groupby = 10
	where b.global_search = 1
	group by b.id, b.groupby, b.orderby, b.padding 
	option(maxdop 1)

	-- 2. Join merge
	PRINT '2. Join merge'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	join TestTable m1 on b.id = m1.local_search and 
	                 (m1.groupby = 10 or m1.groupby = 20)
	where b.global_search = 1
	group by b.id, b.groupby, b.orderby, b.padding 
	having count(distinct m1.groupby) = 2
	option(maxdop 1)
end
go

