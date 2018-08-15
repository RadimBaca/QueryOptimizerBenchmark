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
-- Test of a predicate elimination.
-- The first SQL query contains predicates that has to be always evaluated to true and 
-- it can be safely eliminated.
CREATE Procedure single_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.global_search > 20 and a.global_search < 100 and
	      a.global_search > 10 and a.global_search < 200
	option(maxdop 1)

	--2. Predicate elimination
	PRINT '2. Predicate elimination'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.global_search > 20 and a.global_search < 100
	option(maxdop 1)

end
go
