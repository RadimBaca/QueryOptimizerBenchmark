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

execute single_test
go
PRINT '**** HEAP **** '
SET STATISTICS TIME on
execute single_test
go


/***********************************************************/
/***************** Queries (NON-CLUSTERED) *****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_local_search
ON [dbo].[TestTable] (local_search)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_global_search
ON [dbo].[TestTable] (global_search)
GO

execute single_test
go
PRINT '**** NON-CLUSTERED I **** '
SET STATISTICS TIME on
execute single_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_local_search
go
drop index TestTable.ix_TestTable_global_search
go


/***********************************************************/
/***************** Queries (NON-CLUSTERED) *****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_localsearch_globalsearch
ON [dbo].[TestTable] (local_search, global_search)
GO

execute single_test
go
PRINT '**** NON-CLUSTERED II **** '
SET STATISTICS TIME on
execute single_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_localsearch_globalsearch
go


/***********************************************************/
/***************** Queries (NON-CLUSTERED) *****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_globalsearch_localsearch
ON [dbo].[TestTable] (global_search, local_search)
GO

execute single_test
go
PRINT '**** NON-CLUSTERED III **** '
SET STATISTICS TIME on
execute single_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_globalsearch_localsearch
go


/***********************************************************/
/******************** Queries (CLUSTERED) ******************/
/***********************************************************/


--clustered index
CREATE CLUSTERED INDEX ix_TestTable_localsearch
ON [dbo].[TestTable] (local_search)
GO
CREATE NONCLUSTERED INDEX ix_TestTable_globalsearch
ON [dbo].[TestTable] (global_search)
GO

execute single_test
go
PRINT '**** CLUSTERED I **** '
SET STATISTICS TIME on
execute single_test
go

SET STATISTICS TIME off
-- drop the indexes
drop index TestTable.ix_TestTable_localsearch
go
drop index TestTable.ix_TestTable_globalsearch
go


/***********************************************************/
/******************** Queries (CLUSTERED) ******************/
/***********************************************************/


--clustered index
CREATE NONCLUSTERED INDEX ix_TestTable_localsearch
ON [dbo].[TestTable] (local_search)
GO
CREATE CLUSTERED INDEX ix_TestTable_globalsearch
ON [dbo].[TestTable] (global_search)
GO

execute single_test
go
PRINT '**** CLUSTERED II **** '
SET STATISTICS TIME on
execute single_test
go

SET STATISTICS TIME off
-- drop the indexes
drop index TestTable.ix_TestTable_localsearch
go
drop index TestTable.ix_TestTable_globalsearch
go


/***********************************************************/
/******************** Queries (CLUSTERED) ******************/
/***********************************************************/


--clustered index
CREATE CLUSTERED INDEX ix_TestTable_localsearch_globalsearch
ON [dbo].[TestTable] (local_search, global_search)
GO

execute single_test
go
PRINT '**** CLUSTERED III **** '
SET STATISTICS TIME on
execute single_test
go

SET STATISTICS TIME off
-- drop the indexes
drop index TestTable.ix_TestTable_localsearch_globalsearch
go



/***********************************************************/
/***************** Queries (CLUSTERED) *****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE CLUSTERED INDEX ix_TestTable_globalsearch_localsearch
ON [dbo].[TestTable] (global_search, local_search)
GO

execute single_test
go
PRINT '**** CLUSTERED IV **** '
SET STATISTICS TIME on
execute single_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_globalsearch_localsearch
go
