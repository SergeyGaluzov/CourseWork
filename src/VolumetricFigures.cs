using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public abstract class VolumetricFigure : Figure
	{
		public abstract double Height { get; }
		public abstract double wholeSurfaceArea { get; }
		public PlaneFigure bottomBase;
		public abstract double Volume { get; }
		public abstract int EdgeNumber { get; }
		public VolumetricFigure(List<Vertex> vertices, int vertexNumberPerSide) : base(vertices.Count / vertexNumberPerSide) 
		{
			List<Vertex> basisVertices = new List<Vertex>();
			for (int i = 0; i < vertices.Count; i += vertexNumberPerSide)
			{
				Side side = new Side(vertexNumberPerSide);
				for (int j = i; j < i + vertexNumberPerSide; j++)
				{
					side.edges.Add(new Edge(vertices[j], vertices[(j + 1) % (i + vertexNumberPerSide)]));
					if (j == i) //if (j == i || j == i + vertexNumberPerSide - 1)
					{
						basisVertices.Add(vertices[j]);
					}
				}
				sideElements.Add(side);
			}
			bottomBase = new PlaneFigure(basisVertices);
		}
	}

	public class Pyramid : VolumetricFigure
	{
		private Vertex upperVertice;
		public override int VertexNumber => sideElements.Count + 1;
		public override int SideNumber => sideElements.Count + 1;
		public override int EdgeNumber => sideElements.Count * 2;

		public Pyramid(List<Vertex> vertices, int vertexNumberPerSide) : base(vertices, vertexNumberPerSide)
		{
			//upperVertice = vertices.GroupBy(vertice => vertice).OrderBy(group => group.Count()).Max().Key;
			upperVertice = vertices[1];
		}
		public double CalculateHeight(Vertex t, (double A, double B, double C, double D) coordinates)
		{
			return Math.Abs(coordinates.A * t.x + coordinates.B * t.y + coordinates.C * (double)t.z + coordinates.D) /
				   Math.Sqrt(coordinates.A * coordinates.A + coordinates.B * coordinates.B + coordinates.C * coordinates.C);
		}
		public override double Height
		{
			get
			{
				return CalculateHeight(upperVertice, MathCalculations.SurfaceCoeficients(bottomBase.sideElements[0].vertices[0],
																						 bottomBase.sideElements[0].vertices[1],
																						 bottomBase.sideElements[1].vertices[1]));
			}
		}
		public override double Volume => bottomBase.Area * Height / 3;
		public override double wholeSurfaceArea => bottomBase.Area + MathCalculations.CalculateArea(
																		sideElements.Select(side => ((Side)side).edges.Select(edge => edge.vertices).SelectMany(x => x).ToList())
																		.SelectMany(y => y).ToList().Distinct().ToList());
		public override void GetInfo()
		{
			Console.WriteLine($"Number of vertices: {VertexNumber}");
			Console.WriteLine($"Number of sides: {SideNumber}");
			Console.WriteLine($"Number of edges: {EdgeNumber}");
			Console.WriteLine($"Height: {Height}");
			Console.WriteLine($"Total surface area: {wholeSurfaceArea}");
			Console.WriteLine($"Volume: {Volume}");
		}
	}

	public class Prism : VolumetricFigure
	{
		public PlaneFigure upperBase;
		public override int VertexNumber => sideElements.Count * 2;
		public override int SideNumber => sideElements.Count + 2;
		public override int EdgeNumber => sideElements.Count * 3;
		public Prism(List<Vertex> vertices, int vertexNumberPerSide) : base(vertices, vertexNumberPerSide) 
		{
			upperBase = new PlaneFigure(vertices.GroupBy(vertice => new { vertice.x, vertice.y, vertice.z })
												.Select(group => group.First()).ToList().Except(bottomBase.allVertices.Distinct()).ToList());
		}
		public override double Height
		{
			get
			{

				var surface1 = MathCalculations.SurfaceCoeficients(upperBase.allVertices[0], upperBase.allVertices[1], upperBase.allVertices[2]);
				var surface2 = MathCalculations.SurfaceCoeficients(bottomBase.allVertices[0], bottomBase.allVertices[1], bottomBase.allVertices[2]);
				return Math.Abs(surface2.D - surface1.D) / Math.Sqrt(surface1.A * surface1.A + surface1.B * surface1.B + surface1.B * surface1.B);
			}
		}
		public override double Volume => Height * bottomBase.Area;
		public override double wholeSurfaceArea => bottomBase.Area + upperBase.Area + MathCalculations.CalculateArea(
																		sideElements.Select(side => ((Side)side).edges.Select(edge => edge.vertices).SelectMany(x => x).ToList())
																		.SelectMany(y => y).ToList().Distinct().ToList());
		public override void GetInfo()
		{
			Console.WriteLine($"Number of vertices: {VertexNumber}");
			Console.WriteLine($"Number of sides: {SideNumber}");
			Console.WriteLine($"Number of edges: {EdgeNumber}");
			Console.WriteLine($"Height: {Height}");
			Console.WriteLine($"Total surface area: {wholeSurfaceArea}");
			Console.WriteLine($"Volume: {Volume}");
		}
	}

	public class Parallelepiped : Prism
	{
		public Parallelepiped(List<Vertex> vertices, int vertexNumberPerSide) : base(vertices, vertexNumberPerSide) { }
	}

	public class Cube : Parallelepiped
	{
		public Cube(List<Vertex> vertices, int vertexNumberPerSide) : base(vertices, vertexNumberPerSide) { }
	}
}
