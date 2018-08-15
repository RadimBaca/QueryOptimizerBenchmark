--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure single_II_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS single_II_test
go
-- Description: 
---------------
-- Rewrite of a window function using a correlated subquery with aggregate.
CREATE Procedure single_II_test as
begin

	--1. Window function variant
	PRINT 'Window function variant'
	select id, 
	       groupby, 
		   local_search, 
		   count(*) over (partition by groupby) ct
	from TestTable
	where id < 100
	option(maxdop 1)


	--2. Subquery variant
	PRINT 'Subquery variant'
	select id, 
	       groupby, 
		   local_search, 
		   (
		     select count(*) 
			 from TestTable b
			 where b.groupby = a.groupby
		   ) ct
	from TestTable a
	where id < 100
	option(maxdop 1)

end
go
