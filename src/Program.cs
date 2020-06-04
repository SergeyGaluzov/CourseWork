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
			bool quitFlag = true;
			while (quitFlag)
			{
				try
				{
					switch (dimensionType)
					{
						case "2D":
							Console.Write("What type of plain figure do you want to create? (arbitrary, specific): ");
							figureType = Console.ReadLine().ToLower();
							switch (figureType)
							{
								case "specific":
									{
										side_number = 4;
										Console.Write("What type of specific plain figure do you want to create? (square, rectangular): ");
										figureType = Console.ReadLine().ToLower();
										if (figureType != "square" && figureType != "rectangular")
										{
											throw new IncorrectFigureType("Incorrect figure type! Try again");
										}
										break;
									}
								case "arbitrary":
									{
										Console.Write("Enter the number of sides in the figure: ");
										side_number = Int32.Parse(Console.ReadLine());
										if (side_number <= 2) throw new IncorrectSideNumber("Incorrect side number! Try again");
										break;
									}
								default:
									throw new IncorrectFigureType("Incorrect figure type! Try again");
							}
							creator = new PlaneFigureCreator();
							result = creator.CreateFigure(vertices, figureType, side_number);
							Console.WriteLine();
							result.GetInfo();
							break;
						case "3D":
							Console.Write("Enter the type of volumetric figure (pyramid, prism, parallelepiped, cube): ");
							figureType = Console.ReadLine().ToLower();
							if (figureType != "pyramid" && figureType != "prism" && figureType != "parallelepiped" && figureType != "cube")
							{
								throw new IncorrectFigureType("Incorrect figure type! Try again");
							}
							if (figureType == "pyramid" || figureType == "prism")
							{
								Console.Write("Enter the number of sides in the figure: ");
								side_number = Int32.Parse(Console.ReadLine());
								if (side_number <= 2) throw new IncorrectSideNumber("Incorrect side number! Try again");
								break;
							}
							else side_number = 4;
							creator = new VolumetricFigureCreator();
							result = creator.CreateFigure(vertices, figureType, side_number);
							Console.WriteLine();
							result.GetInfo();
							break;
						default:
							throw new IncorrectCommonFigureType("Incorrect common figure type! Try again");
					}
				}
				catch (IncorrectCommonFigureType ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch (IncorrectFigureType ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch (IncorrectSideNumber ex)
				{
					Console.WriteLine(ex.Message);
				}
				finally
				{
					Console.Write("\nEnter \"q\" if you want to finish or something else to continue: ");
					quitFlag = (Console.ReadLine().ToLower() != "q");
				}
			}
		}
	}
}
