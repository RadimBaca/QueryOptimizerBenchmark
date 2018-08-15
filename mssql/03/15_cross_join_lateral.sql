--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure join_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS join_test
go
-- Description: 
---------------
-- Rewriting join to a cross join lateral
CREATE Procedure join_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable a
	join TestTable b on b.local_search = a.id
	where a.global_search = 1 and b.groupby = 10
	option(maxdop 1)

	-- 2. CROSS JOIN LATERAL
	PRINT '2. CROSS JOIN LATERAL'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	cross apply (
	  select global_search 
	  from TestTable a 
	  where b.local_search = a.id
	) a
	where a.global_search = 1 and b.groupby = 10
	option(maxdop 1)

end
go



