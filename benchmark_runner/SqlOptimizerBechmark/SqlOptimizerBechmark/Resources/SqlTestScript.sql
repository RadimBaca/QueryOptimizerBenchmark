BEGIN
	DECLARE @testResultId INT;
	DECLARE @sql NVARCHAR(MAX);
	DECLARE @resultSize INT;
	DECLARE @processingTime FLOAT;
	DECLARE @queryPlan NVARCHAR(MAX);

	INSERT INTO sql_optimizer_benchmark.test_results(test_group, configuration, test)
	VALUES ('{0}', '{1}', '{2}');
	
	SELECT @testResultId = IDENT_CURRENT('sql_optimizer_benchmark.test_results');

{3}

	UPDATE sql_optimizer_benchmark.test_results
	SET distinct_plans = (
		SELECT COUNT(DISTINCT query_plan)
		FROM sql_optimizer_benchmark.variant_results
		WHERE test_result_id = @testResultId)
	WHERE test_result_id = @testResultId;
END;