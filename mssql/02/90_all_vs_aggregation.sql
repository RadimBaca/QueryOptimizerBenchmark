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
-- Find max `local_search` per `groupby`. Find all occurences.
-- This test compare all solution versus group by solution. 
-- Both queries are using a dependent subquery.
CREATE Procedure single_II_test as
begin

	select t.id, t.groupby, t.local_search, t.padding
	from TestTable t
	where t.local_search >= all(
	  select local_search
	  from TestTable t2
	  where t.groupby = t2.groupby  and local_search is not null
	) and groupby > 25 and local_search is not null
	option(maxdop 1)

	select t.id, t.groupby, t.local_search, t.padding
	from TestTable t
	where t.groupby > 25 and t.local_search =
		(
			SELECT max(t1.local_search) gmax
			from TestTable t1
			where t1.groupby = t.groupby
		) 
	option(maxdop 1)

end
go

