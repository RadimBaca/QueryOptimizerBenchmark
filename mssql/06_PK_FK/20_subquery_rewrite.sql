--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates a procedure fk_test. In order to run/test the procedure use the run.sql script that can be found in the same directory of the project.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================

DROP PROCEDURE IF EXISTS fk_test
go
-- Description: 
---------------
-- This test use straightforward rewriting of the subquery behind SELECT into a solution using a JOIN. 
-- This rewrite does not require the primary key and the foreign key integrity constraints.
CREATE Procedure fk_test as
begin
	--2. Basic
	PRINT '2. Basic'
	select a.id,
	  (
	    select sum(b.local_search)
		from TestTable b
		where a.id = b.local_search
	  )
	from TestTable a
	where a.id < 50

	--2. Rewrite into a `JOIN+GROUPBY` solution
	PRINT '2. Rewrite into a `JOIN+GROUPBY` solution'
	select a.id, b.sum_local_search
	from TestTable a
	left join (
	    select local_search, sum(local_search) sum_local_search
		from TestTable
		group by local_search
	) b on a.id = b.local_search
	where a.id < 50

end
go
