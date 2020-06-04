using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	static class MathCalculations
	{
		public static double CalculateDistance(Vertex a, Vertex b)
		{
			if (a.z == null)
			{
				return Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
			}
			else
			{
				return Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y) + (double)((a.z - b.z) * (a.z - b.z)));
			}
		}
		public static (double A, double B, double C, double D) SurfaceCoeficients(Vertex t1, Vertex t2, Vertex t3)
		{
			double A_coef = (double)(t1.y * (t2.z - t3.z) + t2.y * (t3.z - t1.z) + t3.y * (t1.z - t2.z));
			double B_coef = (double)(t1.z * (t2.x - t3.x) + t2.z * (t3.x - t1.x) + t3.z * (t1.x - t2.x));
			double C_coef = t1.x * (t2.y - t3.y) + t2.x * (t3.y - t1.y) + t3.x * (t1.y - t2.y);
			double D_coef = -(double)(t1.x * (t2.y * t3.z - t3.y * t2.z) + t2.x * (t3.y * t1.z - t1.y * t3.z) + t3.x * (t1.y * t2.z - t2.y * t1.z));
			return (A: A_coef, B: B_coef, C: C_coef, D: D_coef);
		}

		public static bool OnOneLine(List<Vertex> figure, Vertex vertice)
		{
			if (figure.Count > 2)
			{
				if (vertice.z == null)
				{
					for (int i = 0; i < figure.Count; i++)
					{
						double param_A = figure[i].y - vertice.y;
						double param_B = vertice.x - figure[i].x;
						double param_C = figure[i].x * vertice.y - vertice.x * figure[i].y;
						var sel = figure.Except(new List<Vertex>(1) { figure[i] });
						var result = sel.Select(vertex => param_A * vertex.x + param_B * vertex.y + param_C == 0);
						if (result.Any())
						{
							return true;
						}
					}
					return false;
				}
				else
				{
					for (int i = 0; i < figure.Count; i++)
					{
						var sel = figure.Except(new List<Vertex>(1) { figure[i] });
						var result = sel.Select(vertex => ((vertex.x - figure[i].x) / (vertice.x - figure[i].x)) ==
														  ((vertex.y - figure[i].y) / (vertice.y - figure[i].y)) &&
														  ((vertex.y - figure[i].y) / (vertice.y - figure[i].y)) ==
														  ((vertex.z - figure[i].z) / (vertice.z - figure[i].z))
											   );
						if (result.Any())
						{
							return true;
						}
					}
					return false;
				}
			}
			else return false;
		}

		public static double CalculateArea(List<Vertex> figure)
		{
			double tempSum1 = 0;
			double tempSum2 = 0;
			for (int i = 0; i < figure.Count - 1; i++)
			{
				tempSum1 += (figure[i].x * figure[i + 1].y);
				tempSum2 += (figure[i + 1].x * figure[i].y);
			}
			return 0.5 * Math.Abs(tempSum1 + (figure.Last().x * figure.First().y) - tempSum2 - (figure.First().x * figure.Last().y));
		}
	}
}