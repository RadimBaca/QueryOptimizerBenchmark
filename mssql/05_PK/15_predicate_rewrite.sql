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
-- Simple rewrite of the query predicates may sometimes lead to unexpected behaviour.
-- low-or-equal predicated are handled differently during the query optimization.
CREATE Procedure join_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	join TestTable a on b.local_search = a.id
	where a.global_search = 1 and b.groupby = 10
	option(maxdop 1)

	-- 2. Predicate rewrite 
	PRINT '2. Predicate rewrite'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	join TestTable a on b.local_search = a.id
	where a.global_search = 1 and b.groupby > 9 and b.groupby < 11 
	option(maxdop 1)

end
go
