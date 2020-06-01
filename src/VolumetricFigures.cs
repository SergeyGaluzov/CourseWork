using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public class VolumetricFigure : Figure
	{
		public VolumetricFigure(int sides) : base(sides) { }
		public override void GetInfo()
		{
			Console.WriteLine();
		}
	}
}
