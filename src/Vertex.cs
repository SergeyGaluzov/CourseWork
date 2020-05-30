using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public class Vertex
	{
		public double x { private set; get; }
		public double y { private set; get; }
		public double? z { private set; get; }
		public string name { private set; get; }

		public Vertex(double x, double y, double? z = null)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}
}
