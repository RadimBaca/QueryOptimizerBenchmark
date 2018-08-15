--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure single_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS single_test
go
-- Description: 
---------------
-- Test of predicate ordering of conjuctive query (predicates with different selectivity)
CREATE Procedure single_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.local_search = 1 and a.global_search < 100
	option(maxdop 1)

	--2. Swap of predicates
	PRINT '2. Swap of predicates'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.global_search < 100 and a.local_search = 1
	option(maxdop 1)

end
go
