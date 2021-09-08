using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp9
{
	class Program
	{
		static void Main(string[] args)
		{
			Govornik g = new();
			Slusaoc s1 = new Slusaoc(g, "s1");
			Slusaoc s2 = new Slusaoc(g, "s2"); 
			Slusaoc s3 = new Slusaoc(g, "s3" );
			Diktafon d1 = new Diktafon(g);

			g.Govori();
		}

		class Govornik
		{
			public event Action<string> Govor;

			public void Govori()
				=> Govor?.Invoke("asd");

		}

		class Slusaoc
		{
			public Slusaoc(Govornik gov, string i)
			{
				gov.Govor += Slusam;
				Ime = i;
			}

			
			public string Cuo;
			public string Ime;

			private void Slusam(string s)
				=> Console.WriteLine($"{Ime} cuo {s}");
		}

		class Diktafon
		{
			public Diktafon(Govornik g)
			{
				g.Govor += null;
			}
			public void Snimi(string s) => File.WriteAllText("snimak.txt", s);
		}
	}
}
