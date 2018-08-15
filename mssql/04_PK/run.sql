--======================================================
--
-- Author: Radim Baca
-- Usage: This script runs the single_pk_test procedure with different indexes.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================


/***********************************************************/
/********************** Queries (HEAP) *********************/
/***********************************************************/

execute single_pk_test
go
PRINT '**** HEAP **** '
SET STATISTICS TIME on
execute single_pk_test
go


/***********************************************************/
/***************** Queries (NON-CLUSTERED) *****************/
/***********************************************************/

SET STATISTICS TIME off

--nonclustered index 
CREATE NONCLUSTERED INDEX ix_TestTable_local_search
ON [dbo].[TestTable] (local_search)
GO

execute single_pk_test
go
PRINT '**** NON-CLUSTERED I **** '
SET STATISTICS TIME on
execute single_pk_test
go

SET STATISTICS TIME off

-- drop the indexes
drop index TestTable.ix_TestTable_local_search
go
