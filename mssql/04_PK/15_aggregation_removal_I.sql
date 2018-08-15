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
-- Test of possible aggreagation removal. 
-- The aggregation can be rewritten to distinct without aggregation function if the `TestTable.local_search` attribute is functionaly dependent on `TestTable.id`.
-- The `TestTable.id` attribute is the primary key in this test, therefore, the functional dependency is satisfied.
CREATE Procedure single_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, max(b.local_search)
	from TestTable b
	where b.id < 100
	group by b.id
	option(maxdop 1)

	--2. Aggregation removal
	PRINT '2. Aggregation removal'
	select distinct b.id, b.local_search
	from TestTable b
	where b.id < 100
	option(maxdop 1)

end
go
