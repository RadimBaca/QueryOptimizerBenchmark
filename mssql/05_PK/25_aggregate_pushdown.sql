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
-- Pushdown the `groupby` attribute aggregation. 
-- Since the `TestTable.id` attribute is a primary key the join can not multiply the `TestTable.groupby` values.
-- Therefore, it is safe to perform the distinct first and then the join.
CREATE Procedure join_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select distinct b.local_search
	from TestTable b
	join TestTable a on b.local_search = a.id
	where a.global_search < 10
	option(maxdop 1)

	--2. Aggregation pushdown
	PRINT '2. Aggregation pushdown'
	select b.local_search
	from 
	(
	    select distinct local_search from TestTable
	) b
	join TestTable a on b.local_search = a.id
	where a.global_search < 10
	option(maxdop 1)

end
go



