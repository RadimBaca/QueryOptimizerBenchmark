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
-- Rewriting join to a cross join
CREATE Procedure join_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable a
	join TestTable b on b.local_search = a.id
	where a.global_search = 1 and b.groupby = 10
	option(maxdop 1)

	--2. CROSS JOIN
	PRINT '2. CROSS JOIN'
	select b_id, b_groupby, b_orderby, b_padding
	from (
	  select b.groupby b_groupby, 
	         b.id b_id, 
			 b.orderby b_orderby, 
			 b.local_search b_local_search, 
			 b.padding b_padding,
			 a.id a_id, 
			 a.global_search a_global_search
	  from TestTable b
	  cross join TestTable a
	) t
	where b_local_search = a_id and 
	      a_global_search = 1 and 
		  b_groupby = 10
	option(maxdop 1)

end
go



