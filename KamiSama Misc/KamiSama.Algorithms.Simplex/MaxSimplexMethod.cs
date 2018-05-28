using System;
using System.Collections.Generic;
using System.Linq;

namespace KamiSama.Algorithms.Simplex
{
	public class MaxSimplexMethod
	{
		public SimplexProblem Problem { get; }
		public SimplexResult Result { get; private set; }
		internal double[][] arr;

		public MaxSimplexMethod(SimplexProblem problem)
		{
			this.Problem = problem;

			Initialize();
		}

		private int FindMostNegativeColumn(double[] lastRow)
		{
			var index = -1;
			for (int i = 0; i < lastRow.Length - 2; i++)
			{
				var x = lastRow[i];
				if (x >= 0)
					continue;

				if (Enumerable.Range(0, arr.Length - 1).All(xx => arr[xx][i] == 0))
					continue;

				if ((index < 0) || (x < lastRow[index]))
					index = i;
			}

			return index;
		}
		private int FindBestRatio(int columnIndex)
		{
			var index = -1;
			double ratio = 0;

			var rowLength = arr[0].Length;

			for (int i = 0; i < arr.Length - 1; i++)
			{
				var c = arr[i][columnIndex];
				if (c == 0)
					continue;

				var rowRatio = arr[i][rowLength - 1] / c;

				if ((index < 0) || (rowRatio < ratio))
				{
					index = i;
					ratio = rowRatio;
				}
			}

			return index;
		}
		private void Normalize(int rowIndex, int colIndex)
		{
			var row = arr[rowIndex];
			var c = row[colIndex];

			if (c < 0)
				return;

			for (int i = 0; i < row.Length; i++)
				row[i] /= c;
		}
		private void MakeOtherRowsZero(int rowIndex, int columnIndex)
		{
			var rowLength = arr[0].Length;
			var baseRow = arr[rowIndex];
			var c = arr[rowIndex][columnIndex];

			for (int i = 0; i < arr.Length; i++)
			{
				var row = arr[i];

				if ((i == rowIndex) || (row[columnIndex] == 0))
					continue;

				var r = -row[columnIndex] / c;

				for (int j = 0; j < rowLength; j++)
					row[j] += r * baseRow[j];
			}
		}
		private void Initialize()
		{
			var variables = Problem.Variables;
			var constraints = Problem.Constraints;
			arr = new double[Problem.Constraints.Count + 1][];
			var targetFactors = Problem.TargetFactors;

			var length = variables.Length + constraints.Count + 2;
			var lastNewVariable = variables.Length;

			for (int i = 0; i < constraints.Count; i++)
			{
				var row = new double[length];
				arr[i] = row;
				var c = constraints[i];

				for (int j = 0; j < variables.Length; j++)
					row[j] = c.Factors[j];

				row[lastNewVariable] = 1;
				lastNewVariable++;

				row[length - 2] = 0;
				row[length - 1] = c.Value;
			}

			var lastRow = new double[length];
			arr[arr.Length - 1] = lastRow;
			for (int i = 0; i < variables.Length; i++)
				lastRow[i] = -targetFactors[i];

			lastRow[length - 2] = 1;
			lastRow[length - 1] = 0;
		}
		public void Solve()
		{
			var basicVariables = new Dictionary<int, int>();

			var lastRow = arr[arr.Length - 1];
			var rowLength = lastRow.Length;
			int stepNo = 0;


			while (true)
			{
				stepNo++;

				var columnIndex = FindMostNegativeColumn(lastRow);

				if (columnIndex < 0)
					break;

				var rowIndex = FindBestRatio(columnIndex);

				if (rowIndex < 0)
					throw new Exception("Invalid row.");
				basicVariables.Add(columnIndex, rowIndex);

				Normalize(rowIndex, columnIndex);

				MakeOtherRowsZero(rowIndex, columnIndex);
			}

			Result = new SimplexResult
			{
				Variables = Problem.Variables.Clone() as string[],
				Target = arr[arr.Length - 1][rowLength - 1],
				Values = new double[Problem.Variables.Length],
			};

			foreach (var kv in basicVariables)
				if (kv.Key < Problem.Variables.Length)
					Result.Values[kv.Key] = arr[kv.Value][rowLength - 1];
		}
	}
}
