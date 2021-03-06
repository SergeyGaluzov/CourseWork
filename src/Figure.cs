using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	public abstract class Figure
	{
		public abstract int VertexNumber { get; }
		public List<SideElement> sideElements;
		public Figure(int sides)
		{
			sideElements = new List<SideElement>(sides);
		}
		public abstract int SideNumber { get; }
		public abstract void GetInfo();
	}
}                                                                                                                                                                                                                                                                                                                                                                                         