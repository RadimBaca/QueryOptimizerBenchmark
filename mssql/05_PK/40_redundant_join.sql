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
-- The second query contains an extra join.
-- If the `TestTable.id` attribute is a primary key.
CREATE Procedure join_pk_test as
begin
	-- 1. Basic
	PRINT '2. Basic'
	select b.id, b.groupby, b.local_search, b.padding
	from TestTable b
	join TestTable a on b.local_search = a.id
	where a.global_search = 1 and b.groupby < 2
	option(maxdop 1)

	-- 2. Extra join
	PRINT '2. Extra join'
	select b.id, b.groupby, b.local_search, r.padding
	from TestTable b
	join TestTable a on b.local_search = a.id
	join TestTable r on r.id = b.id
	where a.global_search = 1 and b.groupby < 2
	option(maxdop 1)
end
go
