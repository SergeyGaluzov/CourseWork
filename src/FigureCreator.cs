using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public abstract class FigureCreator
	{
		public abstract Figure CreateFigure(List<Vertex> vertices, string type);
	}

	public class PlaneFigureCreator : FigureCreator
	{
		private List<Vertex> AddVertices(double sideA_length, double sideB_length, Vertex start, List<Vertex> vertices)
		{
			double x_coordinate = start.x;
			double y_coordinate = start.y;

			vertices.Add(new Vertex(x_coordinate, y_coordinate));
			vertices.Add(new Vertex(x_coordinate, y_coordinate + sideA_length));
			vertices.Add(new Vertex(x_coordinate + sideB_length, y_coordinate + sideA_length));
			vertices.Add(new Vertex(x_coordinate + sideB_length, y_coordinate));

			return vertices;
		}
		public override Figure CreateFigure(List<Vertex> vertices, string type)
		{
			if (type == "arbitrary")
			{
				for (int i = 0; i < vertices.Capacity; i++)
				{
					Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate);
					vertices.Add(new Vertex(x_coordinate, y_coordinate));
				}
				return new PlaneFigure(vertices);
			}
			else
			{
				switch (type)
				{
					case "rectangular":
						{
							Console.Write("Enter the first side length of rectangular: ");
							double sideA_length = Int32.Parse(Console.ReadLine());
							Console.Write("Enter the second side length of rectangular: ");
							double sideB_length = Int32.Parse(Console.ReadLine());
							Console.WriteLine("Enter the coordinates of start vertex below");
							Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate);

							return new Rectangular(AddVertices(sideA_length, sideB_length, new Vertex(x_coordinate, y_coordinate), vertices));
						}
					case "square":
						{
							Console.Write("Enter the side length of square: ");
							double side_length = Int32.Parse(Console.ReadLine());
							Console.WriteLine("Enter the coordinates of start vertex below");
							Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate);

							return new Square(AddVertices(side_length, side_length, new Vertex(x_coordinate, y_coordinate), vertices));
						}
					default:
						return new PlaneFigure(vertices);
				}
			}
		}
	}

	public class VolumetricFigureCreator : FigureCreator
	{
		public override Figure CreateFigure(List<Vertex> vertices, string type)
		{
			if (type == "pyramid")
			{
				while (vertices.Count < vertices.Capacity)
				{
					Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate, out double z_coordinate);

					vertices.Add(new Vertex(x_coordinate, y_coordinate, z_coordinate));

					if (vertices.Count % vertices.Capacity == 0)
					{
						vertices.Add(vertices[vertices.Count - vertices.Capacity]);
					}
				}
				return new Pyramid(vertices);
			}
			else
			{
				while (vertices.Count < vertices.Capacity)
				{
					Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate, out double z_coordinate);

					vertices.Add(new Vertex(x_coordinate, y_coordinate, z_coordinate));

					if (vertices.Count % vertices.Capacity == 0)
					{
						vertices.Add(vertices[vertices.Count - vertices.Capacity]);
						vertices.Add(vertices[vertices.Count - vertices.Capacity]);
					}
				}
				return new Prism(vertices);
			}


		}
	}

}