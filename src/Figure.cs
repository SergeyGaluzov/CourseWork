using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public abstract class Figure
	{
		public int VertexNumber { private set; get; }
		public List<Vertex> FigureStructure;
		public Figure(List<Vertex> vertices)
		{
			FigureStructure = vertices;
		}
		public int GetVertexNumber() => VertexNumber;
	}

	public class PlaneFigure : Figure
	{
		public PlaneFigure(List<Vertex> vertices) : base(vertices) { }

	}

	public class VolumetricFigure : Figure
	{
		public VolumetricFigure(List<Vertex> vertices) : base(vertices) { }
	}
}
