--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure fk_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS fk_test
go
-- Description: 
---------------
-- We can eliminate the join due to the following reasons:
--        1. The `TestTable.id` attribute is primary key,
--        2. the `TestTable.local_search` attribute is foreign key referencing the `TestTable.id` attribute.
--        3. we are not interested about any attribute values of `a` except `a.id`, however, `a.id` is part of the join condition.
-- Due to this, every row in `b` has to have exactly one row in `a`. 
-- In other words, the join neither reduce nor expand the rows of `b`, therefore, we can avoid it.
-- Using the join we just eliminate rows from `b` having null value in the `TestTable.local_search` attribute 
-- which can be simply replaced by `b.local_search is not null` condition.
CREATE Procedure fk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select a.id, b.sum_local_search
	from TestTable a
	join (
	    select local_search, sum(local_search) sum_local_search
		from TestTable
		group by local_search
	) b on a.id = b.local_search
	where a.id < 50

	--2. Join elimination
	PRINT '2. Join elimination'
	select b.local_search, b.sum_local_search
	from (
	    select local_search, sum(local_search) sum_local_search
		from TestTable
		group by local_search
	) b 
	where b.local_search < 50 and b.local_search is not null

end
go
