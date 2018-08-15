# Query Optimizer Benchmark

There will be a subdir for each database system supported.

## Purpose of the Benchmark
The main aim of the benchmark is to test a database system ability to compile same query plans for equivalent SQL commands (with different syntax). In other words, we examine database system capability to find the same query plan despite the syntactic approach. 

## Structure of a Database System Benchmark

Each subdir contains a set of directories, and each directory contains a set of tests. Each test includes at least two equivalent SQL queries written with different SQL syntax. The tests in one directory share two things: (1) the same physical design of the database, and (2) SQL queries have the same access paths to the tables. 

All tests use one table with the following structure:
- `TestTable(id, groupby, orderby, local_search, global_search, padding)` - 1M rows

`TestTable` attribute description:
- `id` - has unique values. If a directory has PK in the suffix of its name, then `id` is defined as a primary key and a primary index is created on it.
- `groupby` - counted as `id % 100`.
- `orderby` - has unique value per `groupby`. Ideally are values generated using row_number().
- `local_search` - values per `groupby` may repeat; counted as `orderby % groupby`.
- `global_search` - counted as `id % 10000`.
- `padding` - synthetic fill with 1000 characters.

## Description of the Benchmark Directories 

### 01

The most simple tests using SQL syntax without the following constructs: join, subqueries,aggregates, row goals (Top X), ordering, window functions. 

**Search arguments** in the queries are using attributes `local_search`, `global_search`. 

### 02

Tests do not contain any join between different attributes. Few tests use a self join according to the same attribute. Tests use other advanced techniques, such as subqueries, grouping and row goals.

**Search arguments** in the queries are using attributes `local_search`, `groupby`. 

### 03

Tests use equi-join with the `local_search = id` condition. It also contains many different advanced techniques.

**Search arguments** in the queries are using attributes `global_search`, `groupby`. 

