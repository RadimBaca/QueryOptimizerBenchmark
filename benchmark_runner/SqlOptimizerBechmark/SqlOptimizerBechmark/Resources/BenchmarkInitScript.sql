SET ANSI_WARNINGS ON;

GO

SET NOCOUNT ON;

GO

IF NOT EXISTS(
	SELECT *
	FROM sys.schemas
	WHERE name = 'sql_optimizer_benchmark'
) EXEC ('CREATE SCHEMA [sql_optimizer_benchmark];');

GO

IF OBJECT_ID('sql_optimizer_benchmark.sp_GetQueryStatistics') IS NOT NULL
DROP PROCEDURE [sql_optimizer_benchmark].[sp_GetQueryStatistics];

GO

-- =============================================
-- Description:	Gets the query plan and query
--              processing processing time.
-- =============================================
CREATE PROCEDURE [sql_optimizer_benchmark].[sp_GetQueryStatistics](@query NVARCHAR(MAX),
	@processingTime FLOAT OUT, @resultSize INT OUT, @queryPlan NVARCHAR(MAX) OUT) AS
BEGIN
	SET NOCOUNT ON;

	EXEC (@query);
	SET @resultSize = @@ROWCOUNT;

	SELECT TOP 1 @processingTime = last_elapsed_time / 1000000.0
	FROM sys.dm_exec_query_stats qs CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) sqlText
	WHERE sqlText.text = @query
	ORDER BY last_execution_time DESC;

	SET @queryPlan = NULL;

	SELECT
		@queryPlan = ISNULL(@queryPlan + CHAR(13) + CHAR(10), '') + 
		REPLICATE('    ', n.c.value(
		'count(let $n := . for $a in //*:RelOp where $a[.//*:RelOp/@NodeId = $n/@NodeId] return $a)', 'int')) + '|--' +
		n.c.value('@PhysicalOp', 'nvarchar(max)')
	FROM
		(
			SELECT TOP 1 plan_handle
			FROM
				sys.dm_exec_query_stats	qs
				CROSS APPLY	sys.dm_exec_sql_text(qs.sql_handle) sqlText
			WHERE sqlText.text = @query
			ORDER BY last_execution_time DESC
		) stmt
		CROSS APPLY sys.dm_exec_query_plan(plan_handle) p
		CROSS APPLY p.query_plan.nodes('//*:RelOp') AS n(c);
END

GO

IF object_id('sql_optimizer_benchmark.variant_results') IS NOT NULL
BEGIN
	DROP TABLE sql_optimizer_benchmark.variant_results;
END;

IF object_id('sql_optimizer_benchmark.test_results') IS NOT NULL
BEGIN
	DROP TABLE sql_optimizer_benchmark.test_results;
END;

GO

CREATE TABLE sql_optimizer_benchmark.test_results
(
	test_result_id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	test_group NVARCHAR(100),
	configuration NVARCHAR(100),
	test NVARCHAR(100),
	distinct_plans INT
)

GO

CREATE TABLE sql_optimizer_benchmark.variant_results
(
	variant_result_id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	test_result_id INT,
	result_size INT,
	query_processing_time FLOAT,
	query_plan NVARCHAR(MAX)
)