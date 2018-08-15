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
-- Test compare two basic approaches that can be used to compute summaries.
-- The first query compute summarie using subqueries behind SELECT.
-- The second query compute summaries using GROUP BY with JOIN.
CREATE Procedure join_test as
begin
	--1. Subquery behind SELECT
	PRINT '1. Subquery behind SELECT'
	select b1.groupby,
	     (
		    select sum(b2.local_search)
			from TestTable b2
			where b2.groupby = b1.groupby
		 ),
	     (
		    select min(a.id)
			from TestTable b2
			join Table1 a on b2.id = a.local_search
			where b2.groupby = b1.groupby
		 ) min_id
	from (select distinct groupby from TestTable ) b1
	option(maxdop 1)
	

	--2. GROUP BY with JOIN
	PRINT '2. GROUP BY with JOIN'
	select b1.groupby, t1.sum_local_search, t2.min_id
	from (select distinct groupby from TestTable ) b1
	left join (
		select b2.groupby, sum(b2.local_search) sum_local_search
		from TestTable b2
		group by b2.groupby
	) t1 on b1.groupby = t1.groupby
	left join (
		select b2.groupby, min(a.id) min_id
		from TestTable b2
		join Table1 a on b2.id = a.global_search
		group by b2.groupby
	) t2 on b1.groupby = t2.groupby
	option(maxdop 1)

end
go



