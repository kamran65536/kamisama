using System;
using System.Collections.Generic;

namespace KamiSama.Algorithms.Simplex
{
	public class SimplexProblem
	{
		public string[] Variables { get; set; }
		public List<SimplexConstraint> Constraints { get; } = new List<SimplexConstraint>();
		public double[] TargetFactors { get; set; }

		public SimplexProblem(params string[] variables)
		{
			this.Variables = variables.Clone() as string[];
		}

		public void AddConstraint(double[] factors, double value)
		{
			if (Variables.Length != factors?.Length)
				throw new ArgumentException("Factors must be the same size as variables.");

			Constraints.Add(new SimplexConstraint
			{
				Factors = factors.Clone() as double[],
				Value = value
			});
		}
	}
}
