using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public class Vertex
	{
		private double x;
		private double y;
		private double? z;

		public Vertex(double x, double y, double? z = null)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}
}
