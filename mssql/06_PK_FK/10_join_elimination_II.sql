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
-- The join and TestTable with alias `b` can be eliminated due to the following:
--        1. The `TestTable.id` attribute is primary key,
--        2. the `TestTable.local_search` attribute is foreign key,
--        3. we are not interested about any attribute values of `b` except `b.id`, however, `b.id` is part of the join condition.
-- Due to this, every row in `a` has to have exactly one row in `b`. 
-- In other words, the join neither reduce nor expand the rows of `a`, therefore, we can avoid it.
-- Using the join we just eliminate rows from `a` having null value in the `TestTable.local_search` attribute 
-- which can be simply replaced by `a.local_search is not null` condition.
CREATE Procedure fk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select sum(b.id)
	from TestTable a 
	join TestTable b on b.id = a.local_search
	where b.id < 1000


	--2. Join elimination
	PRINT '2. Join elimination'
	select sum(a.local_search)
	from TestTable a 
	where a.local_search < 1000

end
go
