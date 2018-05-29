# Query Optimizer Benchmark

There will be a subdir for each database system supported. Let us call such subdir as a database system benchmark directory. Currently we support just MS SQL Server.

## Purpose of the benchmark
The main aim of the benchmark is to test a database system ability to compile same query plans for equivalent SQL commands (with different syntax). In other words, we test database system ability to find the same query plan despite the syntactic approach. 

## Database system benchmark directory (DSBD) structure

Each DSBD contains a set of directories and each directory contains simple tests. Each test contains at least two equivalent SQL queries written with differenct SQL syntax. The tests in one directory share two things: (1) the same table structure and the same data, and (2) SQL queries have the same access paths to the tables. 

Let us start with description of the tables used accross all tests.
- `MainTable(id, groupby, orderby, local_search, global_search, padding)` - 1M rows
- `GroupByTable(groupby, local_search, padding)` - 100 rows

`MainTable` attribute description:
- `id` - has unique values. If the directory has PK in the suffix of its name, then `id` is defined as a primary key
- `groupby` - counted as `id % 100`.
- `orderby` - has unique value per `groupby`. Idealy are values generated using row_number().
- `local_search` - values per `groupby` may repeat. It is counted as `orderby % groupby`.
- `global_search` - it is counted as `id % 1000`.
