Each directory contains set of tests, where each test contains at least two equivalent SQL queries written with differenct SQL syntax. The tests in one directory share two things: (1) the same table structure and the same data, and (2) SQL queries have the same access paths to the tables. 

Let us start with description of the tables used accross all tests.
`Table1(id, groupby, orderby, local_search, global_search, padding)` - 100K rows
`Table2(id, groupby, orderby, local_search, global_search, padding)` - 1M rows
`id` - has unique values. If the directory has PK in the suffix of its name, then `id` is defined as a primary key
`groupby` - counted as `id % 100`.
`orderby` - has unique value per `groupby`. Idealy are values generated using row_number().
`local_search` - values per `groupby` may repeat. It is counted as `orderby % groupby`.
`global_search` - it is counted as `id % 1000`.

In the following list we describe the access paths that are used in each directory. We mention attributes that occurs in some predicate (also the join predicate) or are part of some groupby.
1_oneTable_I 
        Table2: local_search, global_search

2_oneTable_I_PK
        Table2: local_search

3_oneTable_II
        Table2: local_search, global_search, groupby
		
5_oneTable_III
        Table2: groupby, orderby

11_join
		Table2: orderby, groupby
		Table1: global_search, id
		
12_join_PK
		Table2: orderby, groupby
		Table1: global_search, id
