using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public class Menu
	{
		public static void EnterCoordinates(out double x_coordinate, out double y_coordinate)
		{
			Console.Write("Enter x-coordinate: ");
			x_coordinate = Double.Parse(Console.ReadLine());
			Console.Write("Enter y-coordinate: ");
			y_coordinate = Double.Parse(Console.ReadLine());
		}

		public static void EnterCoordinates(out double x_coordinate, out double y_coordinate, out double z_coordinate)
		{
			EnterCoordinates(out x_coordinate, out y_coordinate);
			Console.Write("Enter z-coordinate: ");
			z_coordinate = Double.Parse(Console.ReadLine());

		}
	}
}
