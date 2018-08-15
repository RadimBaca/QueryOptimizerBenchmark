--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure single_pk_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS single_pk_test
go
-- Description: 
---------------
-- Test of possible aggregation removal. 
-- The aggregation can be rewritten to distinct without aggregation function 
-- if the `local_search` attribute is functionaly dependent on id.
-- In our test `TestTable.id` is primary key.
CREATE Procedure single_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select min(min_local_search)
	from
	(
		select max(local_search) min_local_search
		from TestTable
		group by id
	) t
	option(maxdop 1)

	--2. Aggregation removal
	PRINT '2. Aggregation removal'
	select min(local_search)
	from
	(
		select local_search
		from TestTable
	) t
	option(maxdop 1)

	--3. Nested query removal
	PRINT '3. Nested query removal'
	select min(local_search)
	from TestTable
	option(maxdop 1)

end
go
