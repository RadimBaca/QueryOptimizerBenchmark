	SET @sql = '{0}';
	EXEC sql_optimizer_benchmark.sp_GetQueryStatistics @sql, @processingTime OUT, @resultSize OUT, @queryPlan OUT;
	INSERT INTO sql_optimizer_benchmark.variant_results(test_result_id, result_size, query_processing_time, query_plan)
	VALUES (@testResultId, @resultSize, @processingTime, @queryPlan);
