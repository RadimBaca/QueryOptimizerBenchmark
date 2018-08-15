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
-- Test of conjunction. The `INTERSECT` construct versus the `AND` solution.
CREATE Procedure single_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.local_search = 1 and a.global_search < 100
	option(maxdop 1)

	--2. Intersection
	PRINT '2. Intersection'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.local_search = 1
	intersect
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.global_search < 100
	option(maxdop 1)

end
go
