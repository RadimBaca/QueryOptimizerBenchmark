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
-- Test of an aggregation removal. The aggregation can be rewritten using `distinct` without aggregation function 
-- if the `TestTable.local_search` attribute is functionaly dependent on the `TestTable.id` attribute which is satisfied in this test.
CREATE Procedure single_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, min(b.local_search)
	from TestTable b
	group by b.id
	option(maxdop 1)

	--2. Aggregation removal
	PRINT '2. Aggregation removal'
	select distinct b.id, b.local_search
	from TestTable b
	option(maxdop 1)

end
go

