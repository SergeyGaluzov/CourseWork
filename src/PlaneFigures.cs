using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public class PlaneFigure : Figure
	{
		public List<Vertex> allVertices;
		public PlaneFigure(List<Vertex> vertices) : base(vertices.Count)
		{
			allVertices = new List<Vertex>(vertices);
			for (int i = 0; i < sideElements.Capacity; i++)
			{
				sideElements.Add(new Edge(vertices[i], vertices[(i + 1) % sideElements.Capacity]));
			}
		}

		public double Area	{ get {	return CalculateArea();	} }
		protected virtual double CalculateArea()
		{
			double tempSum1 = 0;
			double tempSum2 = 0;
			for (int i = 0; i < sideElements.Count - 1; i++)
			{
				tempSum1 += (allVertices[i].x * allVertices[i + 1].y);
				tempSum2 += (allVertices[i + 1].x * allVertices[i].y);
			}
			return 0.5 * Math.Abs(tempSum1 + (allVertices.Last().x * allVertices.First().y) - tempSum2 - (allVertices.First().x * allVertices.Last().y));
		}

		public double Perimeter { get { return CalculatePerimeter(); } }
		protected virtual double CalculatePerimeter() => sideElements.Select(elem => ((Edge)elem).Length).Sum();

		/*public override void GetInfo()
		{
			Console.WriteLine(Perimeter);
			Console.WriteLine(Area);
		}*/
	}

	public class Rectangular : PlaneFigure
	{
		public Rectangular(List<Vertex> vertices) : base(vertices)
		{

		}
		protected override double CalculateArea() => ((Edge)sideElements[0]).Length * ((Edge)sideElements[1]).Length;
		protected override double CalculatePerimeter() => 2 * (((Edge)sideElements[0]).Length + ((Edge)sideElements[1]).Length);
	}

	public class Square : Rectangular
	{
		public Square(List<Vertex> vertices) : base(vertices)
		{

		}
		protected override double CalculateArea() => Math.Pow(((Edge)sideElements[0]).Length, 2);
		protected override double CalculatePerimeter() => ((Edge)sideElements[0]).Length * 4;
	}


	/*public class Rhombus : PlaneFigure
	{
		public double height;
		public Rhombus(List<Vertex> vertices) : base(vertices)
		{

		}
	}*/
}
