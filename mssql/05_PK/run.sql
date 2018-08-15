--======================================================
--
-- Author: Radim Baca
-- Usage: This script runs the join_pk_test procedure with different indexes.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================


/***********************************************************/
/********************** Queries (HEAP) *********************/
/***********************************************************/

execute join_pk_test
go
PRINT '**** HEAP **** '
SET STATISTICS TIME on
execute join_pk_test
go


/***********************************************************/
/**************** Queries (NON-CLUSTERED I) ****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_localsearch_groupby
ON TestTable (local_search, groupby)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_globalsearch
ON TestTable (global_search)
GO

execute join_pk_test
go
PRINT '**** NON-CLUSTERED I ****'
SET STATISTICS TIME on
execute join_pk_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_localsearch_groupby
go
drop index TestTable.ix_TestTable_globalsearch
go


/***********************************************************/
/*************** Queries (NON-CLUSTERED II) ****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_groupby_localsearch
ON TestTable (groupby, local_search)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_globalsearch
ON TestTable (global_search)
GO

execute join_pk_test
go
PRINT '**** NON-CLUSTERED II ****'
SET STATISTICS TIME on
execute join_pk_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_groupby_localsearch
go
drop index TestTable.ix_TestTable_globalsearch
go

