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
-- Test of a IS NOT NULL predicate elimination. 
-- The `TestTable.id` attribute can not be null since it is the primary key.
-- Therefore, the `IS NOT NULL` predicate can be eliminated.
CREATE Procedure single_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.id IS NOT NULL and
	      a.local_search = 1
	option(maxdop 1)

	--2. Predicate elimination
	PRINT '2. Predicate elimination'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.local_search = 1
	option(maxdop 1)

end
go
