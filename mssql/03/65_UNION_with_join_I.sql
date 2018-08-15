--======================================================
--
-- Author: Radim Baca
-- Create date: 14.3.2017
-- Description: Performance test of different SQL queries corresponding to the same problem.
-- License: This code was written by Radim Baca and is the property of VSB-TUO 
--          This code MAY NOT BE USED without the expressed written consent of VSB-TUO.
-- Change history:
--
--======================================================



/***************** Procedury **********************/

DROP PROCEDURE IF EXISTS join_test
go
-- 
CREATE Procedure join_test as
begin

	--1. UNION in subquery
	PRINT '1. UNION in subquery'
	select a.id, t.p
	from TestTable a
	join (
	  select local_search c1, padding p
	  from TestTable 
	  where groupby = 1
	  union all
	  select groupby c1, padding p
	  from TestTable 
	  where local_search = 2
	) t on a.id = t.c1 and a.global_search = 1
	option(maxdop 1)
	

	--2. UNION in the outer query
	PRINT '2. UNION in the outer query'
	select a.id, t.padding
	from TestTable a
	join TestTable t on a.id = t.local_search and 
	       a.global_search = 1 and
		   t.groupby = 1
	union all
	select a.id, a.padding
	from TestTable a
	join TestTable t on a.id = t.groupby and 
	       a.global_search = 1 and
		   t.local_search = 2
	option(maxdop 1)

end
go



