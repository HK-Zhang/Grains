using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
	public enum Level
	{
		Off,
		Fatal,
		Error,
		Warn,
		Info,
		Debug,
		All
	}

	public class EnumDemo
	{
		public Level Lv { get; set; }

		public void Execute()
		{
		    Console.WriteLine(Level.All.ToString());
//			Compare(Level.Fatal);
		}

		public void Compare(Level lv)
		{
			if (lv > Lv)
			{
				Console.WriteLine(">");
			}
			else
			{
				Console.WriteLine("<");
			}
		}
	}
}
