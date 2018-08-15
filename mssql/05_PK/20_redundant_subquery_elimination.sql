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
-- Introducing redundant self-join in a subquery instead regular column projection
-- The rewrite is possible due to the following reasons:
--              1. The subquery access the superset relation when compared the outer relation. 
--              2. The correlated join is according to the primary key (the join can not multiply).
CREATE Procedure join_pk_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select b.id, b.groupby, b.orderby, b.padding
	from TestTable b
	where b.groupby < 10
	option(maxdop 1)

	-- 2. Redundant subquery 
	PRINT '2. Redundant subquery'
	select b1.id, b1.groupby, b1.orderby, (
	         select b2.padding
			 from TestTable b2
			 where b1.id = b2.id -- this subquery can be eliminated if the TestTable.id attribute is the primary key
		   )
	from TestTable b1
	where b1.groupby < 10
	option(maxdop 1)

end
go

