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
							double sideA_length = Double.Parse(Console.ReadLine());
							Console.Write("Enter the second side length of rectangular: ");
							double sideB_length = Double.Parse(Console.ReadLine());
							Console.Write("Enter the coordinates of start vertex below");
							Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate);

							return new Rectangular(AddVertices(sideA_length, sideB_length, new Vertex(x_coordinate, y_coordinate), vertices));
						}
					case "square":
						{
							Console.Write("Enter the side length of square: ");
							double side_length = Double.Parse(Console.ReadLine());
							Console.Write("Enter the coordinates of start vertex below");
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
		private List<Vertex> AddVertices(double length, double width, double height, Vertex start, List<Vertex> vertices)
		{
			double x_coordinate = start.x;
			double y_coordinate = start.y;
			double z_coordinate = (double)start.z;

			vertices.Add(new Vertex(x_coordinate, y_coordinate, z_coordinate));
			vertices.Add(new Vertex(x_coordinate, y_coordinate + width, z_coordinate));
			vertices.Add(new Vertex(x_coordinate, y_coordinate, z_coordinate + height));
			vertices.Add(new Vertex(x_coordinate, y_coordinate + width, z_coordinate + height));

			vertices.Add(new Vertex(x_coordinate, y_coordinate + width, z_coordinate + height));
			vertices.Add(new Vertex(x_coordinate, y_coordinate, z_coordinate + height));
			vertices.Add(new Vertex(x_coordinate + length, y_coordinate + width, z_coordinate + height));
			vertices.Add(new Vertex(x_coordinate + length, y_coordinate + width, z_coordinate));

			vertices.Add(new Vertex(x_coordinate + length, y_coordinate + width, z_coordinate));
			vertices.Add(new Vertex(x_coordinate + length, y_coordinate + width, z_coordinate + height));
			vertices.Add(new Vertex(x_coordinate + length, y_coordinate, z_coordinate + height));
			vertices.Add(new Vertex(x_coordinate + length, y_coordinate, z_coordinate));


			vertices.Add(new Vertex(x_coordinate + length, y_coordinate, z_coordinate));
			vertices.Add(new Vertex(x_coordinate + length, y_coordinate, z_coordinate + height));
			vertices.Add(new Vertex(x_coordinate, y_coordinate + width, z_coordinate));
			vertices.Add(new Vertex(x_coordinate, y_coordinate, z_coordinate));

			return vertices;
		}
		public override Figure CreateFigure(List<Vertex> vertices, string type)
		{
			int vertexNumberPerSide = (type == "pyramid" ? 3 : 4);
			if (type == "pyramid")
			{
				while (vertices.Count < vertices.Capacity)
				{
					Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate, out double z_coordinate);

					vertices.Add(new Vertex(x_coordinate, y_coordinate, z_coordinate));

					if (vertices.Count % vertexNumberPerSide == 0)
					{
						vertices.Add(vertices[vertices.Count - 1]);
						vertices.Add(vertices[vertices.Count - 3]);
					}
				}
				return new Pyramid(vertices, vertexNumberPerSide);
			}
			else
			{
				if (type == "prizm")
				{
					while (vertices.Count < vertices.Capacity)
					{
						Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate, out double z_coordinate);

						vertices.Add(new Vertex(x_coordinate, y_coordinate, z_coordinate));

						if (vertices.Count % vertexNumberPerSide == 0)
						{
							vertices.Add(vertices[vertices.Count - 1]);
							vertices.Add(vertices[vertices.Count - 3]);
						}
					}
					return new Prism(vertices, vertexNumberPerSide);
				}
				else
				{
					switch (type)
					{
						case "parallelepiped":
							{
								Console.Write("Enter the length of parallelepiped: ");
								double length = Double.Parse(Console.ReadLine());
								Console.Write("Enter the width of parallelepiped: ");
								double width = Double.Parse(Console.ReadLine());
								Console.Write("Enter the height of parallelepiped: ");
								double height = Double.Parse(Console.ReadLine());
								Console.WriteLine("Enter the coordinates of start vertex below");
								Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate, out double z_coordinate);
								return new Parallelepiped(AddVertices(length, width, height, new Vertex(x_coordinate, y_coordinate, z_coordinate), vertices), vertexNumberPerSide);
							}
						case "cube":
							{
								Console.Write("Enter the side length of cube: ");
								double length = Double.Parse(Console.ReadLine());
								Console.WriteLine("Enter the coordinates of start vertex below");
								Menu.EnterCoordinates(out double x_coordinate, out double y_coordinate, out double z_coordinate);
								return new Cube(AddVertices(length, length, length, new Vertex(x_coordinate, y_coordinate, z_coordinate), vertices), vertexNumberPerSide);
							}
						default:
							return new Prism(vertices, vertexNumberPerSide);
					}
				}
			}


		}
	}

}