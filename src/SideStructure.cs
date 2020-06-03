using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public abstract class SideElement
	{
		public List<Vertex> vertices;
	}
	public class Edge : SideElement
	{
		public double Length {private set; get;}
		public Edge(Vertex a, Vertex b)
		{
			vertices = new List<Vertex>(2) { a, b };
			Length = MathCalculations.CalculateDistance(a, b);
		}
	}
	class Side : SideElement
	{
		public List<Edge> edges;
		public Side(int edgeNumber)
		{
			edges = new List<Edge>(edgeNumber);
		}
	}
}
