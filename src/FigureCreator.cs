using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public abstract class FigureCreator
	{
		public abstract Figure CreateFigure(List<Vertex> vertices);
	}

	public class PlainFigureCreator : FigureCreator
	{
		public override Figure CreateFigure(List<Vertex> vertices)
		{
			return new PlaneFigure(vertices);
		}
	}

	/*public class VolumetricFigureCreator : FigureCreator
	{

	}*/

}