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
		public List<SideElement> sideElements;
	}

	public class PlaneFigure : Figure
	{
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
		public List<Vertex> vertices;
		public List<double> edges;
		public void AddVertex(Vertex c)
		{
			if (PlaneFigure.OnOneLine(vertices, c)) vertices.Add(c);
		}
		public double Area { private set; get; }
		public double CalculateArea()
		{
			double tempSum1 = 0;
			double tempSum2 = 0;
			for (int i = 0; i < vertices.Count - 1; i++)
			{
				tempSum1 += (vertices[i].x * vertices[i + 1].y);
				tempSum2 += (vertices[i + 1].x * vertices[i].y);
			}
			return 0.5 * Math.Abs(tempSum1 + (vertices.Last().x * vertices.First().y) - tempSum2 - (vertices.First().x * vertices.Last().y));
		}
		public double Perimeter { private set; get; }
		public double CalculatePerimeter()
		{

		}
	}

	public class VolumetricFigure : Figure
	{
		public List<PlaneFigure> FigureStructure;
		/*public VolumetricFigure(List<Vertex> vertices) : base(vertices) { }*/
	}
}
