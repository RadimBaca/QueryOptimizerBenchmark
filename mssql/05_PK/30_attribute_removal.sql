--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure join_pk_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS join_pk_test
go
-- Description: 
---------------
-- Test of possible attribute removal from a GROUP BY attribute list. 
-- The `TestTable.global_search` attribute can be removed from the aggregation if the `TestTable.id` attribute is a primary key.
CREATE Procedure join_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select a.id, a.global_search, count(*)
	from TestTable a
	join TestTable b on a.id = b.local_search
	where a.global_search < 10
	group by a.id, a.global_search
	option(maxdop 1)

	--2. Removal of an attribute from GROUP BY
	PRINT '2. Removal of an attribute from GROUP BY'
	select a.id, min(a.global_search), count(*)
	from TestTable a
	join TestTable b on a.id = b.local_search
	where a.global_search < 10
	group by a.id
	option(maxdop 1)

end
go