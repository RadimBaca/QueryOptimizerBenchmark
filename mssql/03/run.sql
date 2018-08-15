--======================================================
--
-- Author: Radim Baca
-- Usage: This script runs the join_test procedure with different indexes.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================


/***********************************************************/
/********************** Queries (HEAP) *********************/
/***********************************************************/

execute join_test
go
PRINT '**** HEAP **** '
SET STATISTICS TIME on
execute join_test
go


/***********************************************************/
/**************** Queries (NON-CLUSTERED I) ****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_localsearch_groupby
ON TestTable (local_search, groupby)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_globalsearch_id
ON TestTable (global_search,id)
GO

execute join_test
go
PRINT '**** NON-CLUSTERED I **** '
SET STATISTICS TIME on
execute join_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_localsearch_groupby
go
drop index TestTable.ix_TestTable_globalsearch_id
go


/***********************************************************/
/*************** Queries (NON-CLUSTERED II) ****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_groupby_localsearch
ON TestTable (groupby, local_search)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_globalsearch_id
ON TestTable (global_search,id)
GO

execute join_test
go
PRINT '**** NON-CLUSTERED II **** '
SET STATISTICS TIME on
execute join_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_groupby_localsearch
go
drop index TestTable.ix_TestTable_globalsearch_id
go



/***********************************************************/
/**************** Queries (NON-CLUSTERED III) ****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_localsearch_groupby
ON TestTable (local_search, groupby)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_id_globalsearch
ON TestTable (id)
include(global_search)
GO

execute join_test
go
PRINT '**** NON-CLUSTERED III **** '
SET STATISTICS TIME on
execute join_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_localsearch_groupby
go
drop index TestTable.ix_TestTable_id_globalsearch
go


/***********************************************************/
/*************** Queries (NON-CLUSTERED IV) ****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_groupby_localsearch
ON TestTable (groupby, local_search)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_id_globalsearch
ON TestTable (id)
include(global_search)
GO

execute join_test
go
PRINT '**** NON-CLUSTERED IV **** '
SET STATISTICS TIME on
execute join_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_groupby_localsearch
go
drop index TestTable.ix_TestTable_id_globalsearch
go



/***********************************************************/
/*************** Queries (NON-CLUSTERED IV) ****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_groupby
ON TestTable (groupby)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_localsearch
ON TestTable (local_search)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_id
ON TestTable (id)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_globalsearch
ON TestTable (global_search)
GO

execute join_test
go
PRINT '**** NON-CLUSTERED V **** '
SET STATISTICS TIME on
execute join_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_groupby
go
drop index TestTable.ix_TestTable_localsearch
go
drop index TestTable.ix_TestTable_id
go
drop index TestTable.ix_TestTable_globalsearch
go



