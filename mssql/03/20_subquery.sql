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
-- This script test teh ability to move predicate down in the query tree.
-- The second query nest the table join into a subquery which can be easily rewritten into a basic variant.
CREATE Procedure join_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable a
	join TestTable b on b.local_search = a.id
	where a.global_search = 1 and b.groupby = 10
	option(maxdop 1)

	--2. Nesting join in subquery
	PRINT '2. Nesting join in subquery'
	select b_id, b_groupby, b_orderby, b_padding
	from
	(
	  select b.groupby b_groupby, 
	         b.id b_id, 
			 b.orderby b_orderby, 
			 b.padding b_padding,
			 a.global_search a_global_search
	  from TestTable b
	  join TestTable a on b.local_search = a.id
	) t
	where a_global_search = 1 and 
		  b_groupby = 10
	option(maxdop 1)

end
go



