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
	}
}