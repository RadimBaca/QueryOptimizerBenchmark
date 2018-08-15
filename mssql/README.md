# SQL Server Benchmark

Here you find scripts that implement the benchmark for the SQL Server. If you want to run any test proceed the following steps:

  - Create an empty database in your SQL Server instance: `CREATE DATABASE qob`
  - Create the `TestTable` using the `create.sql` script.
  - If you want to run a test with constraints then run the `create_constraints.sql` script.
  - Select the script with the test and run it. It prepares the stored procedure with queries.
  - The test is executed using the `run.sql` script. This script creates indexes and run the stored procedure with queries. It measures the run time. If you want to compare the query plans include actual execution plans when running the `run.sql` script.
  - In order to to reset the database run the `drop_constraints.sql` script in the directory where you previously run the `create_constraints.sql` script. Other option is to drop and create the `TestTable` using the `create.sql` script.