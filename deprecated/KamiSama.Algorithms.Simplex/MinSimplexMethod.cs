using System.Linq;

namespace KamiSama.Algorithms.Simplex
{
	public class MinSimplexMethod
	{
		public SimplexProblem Problem { get; }
		public SimplexResult Result { get; private set; }

		public MinSimplexMethod(SimplexProblem problem)
		{
			this.Problem = problem;
		}

		public void Solve()
		{
			var variablesCount = Problem.Constraints.Count;
			var constraintsCount = Problem.Variables.Length;

			var dualVariables = Enumerable.Range(1, variablesCount).Select(i => "_y" + i).ToArray();

			var dualProblem = new SimplexProblem(dualVariables);

			for (int i = 0; i < constraintsCount; i++)
			{
				var factors = Problem.Constraints.Select(c => c.Factors[i]).ToArray();

				dualProblem.AddConstraint(factors, Problem.TargetFactors[i]); 
			}

			dualProblem.TargetFactors = Problem.Constraints.Select(x => x.Value).ToArray();

			var maxSimplex = new MaxSimplexMethod(dualProblem);

			maxSimplex.Solve();

			var values = new double[Problem.Variables.Length];
			var lastRow = maxSimplex.arr[maxSimplex.arr.Length - 1];

			for (int i = 0; i < values.Length; i++)
				values[i] = lastRow[dualProblem.Variables.Length + i];

			Result = new SimplexResult
			{
				Target = maxSimplex.Result.Target,
				Variables = Problem.Variables.Clone() as string[],
				Values = values,
			};
		}
	}
}
