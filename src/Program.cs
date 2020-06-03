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
			string dimensionType = Console.ReadLine().ToUpper();
			int side_number;
			List<Vertex> vertices = new List<Vertex>();
			string figureType;
			FigureCreator creator;
			Figure result;
			switch (dimensionType)
			{
				case "2D":
					Console.Write("Enter the number of sides in the figure: ");
					side_number = Int32.Parse(Console.ReadLine());
					vertices.Capacity = side_number;
					Console.Write("What type of plain figure do you want to create? (arbitrary, specific): ");
					figureType = Console.ReadLine().ToLower();
					if (figureType != "arbitrary")
					{
						Console.Write("What type of specific plain figure do you want to create? (square, rectangular): ");
						figureType = Console.ReadLine().ToLower();
					}
					creator = new PlaneFigureCreator();
					result = creator.CreateFigure(vertices, figureType);
					break;
				case "3D":
					Console.Write("Enter the number of sides in the figure: ");
					side_number = Int32.Parse(Console.ReadLine());
					Console.Write("Enter the type of volumetric figure (pyramid or prism): ");
					figureType = Console.ReadLine().ToLower();
					vertices.Capacity = (figureType == "prism" ? 2 * side_number : side_number + 1);
					creator = new VolumetricFigureCreator();
					result = creator.CreateFigure(vertices, figureType);


					break;
				default:

					break;
			}
		}
	}
}
