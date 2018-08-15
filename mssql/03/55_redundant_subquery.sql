--======================================================
--
-- Author: Radim Baca
-- Create date: 17.1.2017
-- Description: Performance p_test of different SQL queries corresponding to the same problem.
--            Script uses syntax specific for SQL Server 2016 (DROP IF EXISTS)
-- License: This code was writtend by Radim Baca and is the property of VSB-TUO 
--          This code MAY NOT BE USED without the expressed written consent of VSB-TUO.
-- Change history:
--
--======================================================


/***************** Procedures **********************/

DROP PROCEDURE IF EXISTS p_test
go
-- Test of subquery elimination. The first predicate can be rewritten into the most simple form using `IS NOT NULL`.
CREATE Procedure p_test as
begin
	--1. Basic
	PRINT '1. Basic'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.global_search IN (SELECT a.global_search FROM TestTable) and
	      a.local_search = 1

	--2. Predicate rewrite
	PRINT '2. Predicate rewrite'
	select a.id, a.local_search, a.padding
	from TestTable a 
	where a.global_search IS NOT NULL and 
	      a.local_search = 1

end
go
go