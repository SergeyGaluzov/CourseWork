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
		public Figure(int sides)
		{
			sideElements = new List<SideElement>(sides);
			VertexNumber = sides;
		}
		//public abstract void GetInfo();
	}
}                                                                                                                                                                                                                                                                                                                                                                                         