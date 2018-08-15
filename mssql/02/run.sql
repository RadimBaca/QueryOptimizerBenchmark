--======================================================
--
-- Author: Radim Baca
-- Usage: This script runs the single_II_test procedure with different indexes.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================


/***********************************************************/
/********************** Queries (HEAP) *********************/
/***********************************************************/

SET STATISTICS TIME off
exec single_II_test
go

SET STATISTICS TIME on
PRINT '**** HEAP ****'
exec single_II_test

go


/***********************************************************/
/***************** Queries (NON-CLUSTERED) *****************/
/***********************************************************/

SET STATISTICS TIME off

--create nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_groupby_localsearch
ON TestTable (groupby,local_search)
GO

exec single_II_test
go
print '**** NON-CLUSTERED I ****'

SET STATISTICS TIME on
exec single_II_test
go


SET STATISTICS TIME off

-- drop the index
drop index TestTable.ix_TestTable_groupby_localsearch
go



/***********************************************************/
/***************** Queries (NON-CLUSTERED) *****************/
/***********************************************************/

SET STATISTICS TIME off

	--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_localsearch
ON TestTable (local_search,groupby)
GO

exec single_II_test
go

print '**** NON-CLUSTERED II ****'
SET STATISTICS TIME on
exec single_II_test
go


SET STATISTICS TIME off
    -- drop the index
drop index TestTable.ix_TestTable_localsearch
go


/***********************************************************/
/******************** Queries (CLUSTERED) ******************/
/***********************************************************/


CREATE CLUSTERED INDEX ix_TestTable_groupby_localsearch
ON TestTable (groupby, local_search)
GO

exec single_II_test
go
print '**** CLUSTERED I ****'
SET STATISTICS TIME on
exec single_II_test
go

SET STATISTICS TIME off
    -- drop the index
drop index TestTable.ix_TestTable_groupby_localsearch
go


/***********************************************************/
/******************** Queries (CLUSTERED) ******************/
/***********************************************************/


CREATE CLUSTERED INDEX ix_TestTable_localsearch_groupby
ON TestTable (local_search, groupby)
GO

exec single_II_test
go
print '**** CLUSTERED II ****'
SET STATISTICS TIME on
exec single_II_test
go

SET STATISTICS TIME off
    -- drop the index
drop index TestTable.ix_TestTable_localsearch_groupby
go
