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

	}
}