using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
	class IncorrectCommonFigureType : Exception
	{
		public IncorrectCommonFigureType(string message) : base(message)	{ }
	}
	class IncorrectFigureType : Exception
	{
		public IncorrectFigureType(string message) : base(message) { }
	}
	class IncorrectSideNumber : Exception
	{
		public IncorrectSideNumber(string message) : base(message) { }
	}
}