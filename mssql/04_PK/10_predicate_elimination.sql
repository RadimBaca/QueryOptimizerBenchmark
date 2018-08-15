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
-- Test of `IS NOT NULL` predicate elimination. 
-- The `IS NOT NULL` predicate can be eliminated since the `id` is a primary key, therefore, it can not be null.
CREATE Procedure single_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.id IS NOT NULL and
	      a.local_search = 5000
	option(maxdop 1)

	--2. Predicate elimination
	PRINT '2. Predicate elimination'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.id IS NOT NULL and
	      a.local_search = 5000
	option(maxdop 1)

end
go
