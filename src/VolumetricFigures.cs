using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public abstract class VolumetricFigure : Figure
	{
		public double height;
		public double base_area;
		public double volume;
		public VolumetricFigure(List<Vertex> vertices, int vertexNumberPerSide) : base(vertices.Count / vertexNumberPerSide) 
		{ 
			for (int i = 0; i < vertices.Count; i += vertexNumberPerSide)
			{
				Side side = new Side(vertexNumberPerSide);
				for (int j = i; j < i + vertexNumberPerSide; j++)
				{
					side.edges.Add(new Edge(vertices[j], vertices[(j + 1) % (i + vertexNumberPerSide)]));
				}
				sideElements.Add(side);
			}
		}
	}

	public class Pyramid : VolumetricFigure
	{
		public Pyramid(List<Vertex> vertices) : base(vertices, 3) {	}
	}

	public class Prism : VolumetricFigure
	{
		public Prism(List<Vertex> vertices) : base(vertices, 4) { }
	}

	public class Parallelepiped : Prism
	{
		public Parallelepiped(List<Vertex> vertices) : base(vertices) { }
	}

	public class Cube : Parallelepiped
	{
		public Cube(List<Vertex> vertices) : base(vertices) { }
	}
}
