--======================================================
--
-- Author: Radim Baca
-- Usage: Script creates integrity constraints. This is the second testing step for the fk_test procedure.
-- Database system supported/tested: SQL Server 2016
-- URL of the project: https://github.com/RadimBaca/QueryOptimizerBenchmark
-- License: This code is published under a MIT license
-- Change history:
--
--======================================================



/**************************************************************/
/******************    Create constraints  ********************/
/**************************************************************/

IF OBJECT_ID('dbo.TestTable', 'U') IS NOT NULL  
begin
  alter table TestTable add constraint pk_TestTable_id primary key (id);
  alter table TestTable add constraint fk_TestTable_localsearch foreign key (local_search) references TestTable(id);
end;
go


