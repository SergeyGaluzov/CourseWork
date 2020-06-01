using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter the type of geometric figure (2D or 3D): ");
			string figureType = Console.ReadLine().ToUpper();
			int side_number;
			FigureCreator creator;
			Figure result;
			switch (figureType)
			{
				case "2D":
					Console.Write("Enter the number of sides in the figure: ");
					side_number = Int32.Parse(Console.ReadLine());
					List<Vertex> vertices = new List<Vertex>(side_number);
					for (int i = 0; i < side_number; i++)
					{
						Console.Write("Enter x-coordinate: ");
						double x_coordinate = Double.Parse(Console.ReadLine());

						Console.Write("Enter y-coordinate: ");
						double y_coordinate = Double.Parse(Console.ReadLine());

						vertices.Add(new Vertex(x_coordinate, y_coordinate));
					}
					creator = new PlainFigureCreator();
					result = creator.CreateFigure(vertices);
					result.GetInfo();
					break;
				/*case "3D":
					Console.Write("Enter the number of sides in the figure: ");
					side_number = Int32.Parse(Console.ReadLine());
					Console.Write("Enter the type of volumetric figure (pyramid or prism");
					string type = Console.ReadLine().ToLower();
					creator = new VolumetricFigureCreator();
					result = creator.CreateFigure(side_number, type);
					break;*/
				default:

					break;
			}
		}
	}
}
