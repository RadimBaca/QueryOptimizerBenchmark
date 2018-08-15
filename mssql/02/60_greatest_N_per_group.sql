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
-- Two solutions for the problem:
-- "Find N max occurences per group."
-- More specificaly for each `groupby` value we search  for 5 rows with highest `local_search`.
CREATE Procedure single_II_test as
begin

	--1. WINDOW FUN
	PRINT 'WINDOW FUN'
	select t.id, t.groupby, t.local_search, t.padding
	from
	(
	   select *, 
		   row_number() over (partition by groupby order by local_search desc) rn
	   from TestTable
	   where groupby > 80
	) t
	where t.rn <= 5
	option(maxdop 1)

	--2. CROSS APPLY
	PRINT 'CROSS APPLY'
	select t.id, t.groupby, t.local_search, t.padding
	from (
	  select groupby
	  from TestTable
	  where groupby > 80
	  group by groupby
	) t1
	cross apply
	(
		SELECT top 5 t2.*
		from TestTable t2
		where t1.groupby = t2.groupby
		order by t2.local_search desc
	) t
	option(maxdop 1)

end
go
