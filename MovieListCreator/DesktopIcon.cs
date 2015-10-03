using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace DIconManager
{
	class DesktopIcon
	{
		private string _name;
		private Point _position;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public Point Position
		{
			get { return _position; }
			set { _position = value; }
		}

		public DesktopIcon(string name, Point position)
		{
			Name = name;
			Position = position;
		}
	}
}
