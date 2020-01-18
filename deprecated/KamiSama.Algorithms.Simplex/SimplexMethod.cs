namespace KamiSama.Algorithms.Simplex
{
	public static class SimplexMethod
	{
		public static SimplexResult CalculateMin(this SimplexProblem problem)
		{
			var method = new MinSimplexMethod(problem);

			method.Solve();

			return method.Result;
		}
		public static SimplexResult CalculateMax(this SimplexProblem problem)
		{
			var method = new MaxSimplexMethod(problem);

			method.Solve();

			return method.Result;
		}
	}
}
