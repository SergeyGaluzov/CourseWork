using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public class VolumetricFigure : Figure
	{
		public double height;
		public double base_area;
		public double volume;
		public VolumetricFigure(List<Vertex> vertices) : base(vertices.Count) { }
		public override void GetInfo()
		{
			Console.WriteLine();
		}
	}

	/*public class Pyramid : VolumetricFigure
	{

	}

	public class Prism : VolumetricFigure
	{

	}*/
}
