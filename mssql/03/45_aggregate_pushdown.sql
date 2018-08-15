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
-- Pushdown the groupby attribute aggregation and using an extra semijoin. 
-- The semijoin is realized using EXISTS, however, we may use any semijoin syntax that is available in DBMS. 
-- Semijoin avoids multiplication of the `TestTable.groupby` values. 
-- The effectivness of this rewritting may be heavily dependent on a number of groupby repetitions and selectivity of the semijoin.
CREATE Procedure join_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select distinct b.groupby
	from TestTable b
	join TestTable a on b.local_search = a.id
	where a.global_search = 1
	option(maxdop 1)

	--2. EXISTS
	PRINT '2. Aggregation pushdown'
	select t.groupby
	from 
	(
	    select distinct groupby from TestTable
	) t
	where exists
	(
	    select 1 
		from TestTable a 
		join TestTable b on b.local_search = a.id
		where a.global_search = 1 and b.groupby = t.groupby
    )
	option(maxdop 1)

end
go



