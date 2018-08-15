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
-- Find rows with max `local_search` value per `groupby`. Find ALL occurences of max per `groupby`.
-- We assume that there can be more than one maximum `local_search` value per one `groupby` value. 
-- This test shows the most common solutions for this problem. 
-- The `55_greatest_in_group_II` test shows also some other solutions.
-- The window function solution usually leads to a sequential scan and to a very simple query plan.
-- On the other hand the group by can utilize the indexes that are available.
CREATE Procedure single_II_test as
begin


	-- 1. GROUP BY
	PRINT '1. GROUP BY'
	select t.id, t.groupby, t.local_search, t.padding
	from TestTable t
	join
	(
		SELECT groupby, max(local_search) gmax
		from TestTable
		where groupby > 25
		group by groupby
	) t2 on t.groupby = t2.groupby and 
	        t.local_search = t2.gmax
	option(maxdop 1)

	--2. WINDOW FUNCTION
	PRINT '2. WINDOW FUNCTION'
	select t.id, t.groupby, t.local_search, t.padding
	from
	(
		select id, groupby, local_search, padding, 
				dense_rank() over (partition by groupby order by local_search desc) rn
		from TestTable
		where groupby > 25
	) t
	where t.rn = 1 and 
	      t.groupby is not null and 
		  t.local_search is not null
	option(maxdop 1)


end
go

