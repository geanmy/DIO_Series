using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DIO.Series {
	internal class Program {
		public static SeriesRepository seriesRepository = new SeriesRepository();

		public static void Main(string[] args) {
			GetUserOption();
		}

		public static void ListSeries() {
			if(seriesRepository.NextId() == 0) {
				Console.WriteLine($"There are no series in the list!{Environment.NewLine}{Environment.NewLine}Press any key to go back...");

				Console.ReadKey();

				GetUserOption();

				return;
			}

			Console.WriteLine("List of series" + Environment.NewLine);

			List<Series> list = seriesRepository.List();

			for(ushort i = 0; i < list.Count; i++) {
				if(list[i].IsActive()) {
					Console.WriteLine(list[i].GetTitle());
				}
			}

			Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Press any key to go back...");

			Console.ReadKey();

			GetUserOption();
		}

		public static Series AskSeriesDetailsToUser() {
			foreach(int i in Enum.GetValues(typeof(Genders))) {
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genders), i));
			}

			Console.WriteLine("{0}Choose a gender for the serie: ", Environment.NewLine);

			int gender = int.Parse(Console.ReadLine());
			Console.Clear();

			Console.WriteLine("Title: ");

			string title = Console.ReadLine();
			Console.Clear();

			Console.WriteLine("Description: ");

			string description = Console.ReadLine();
			Console.Clear();

			Console.WriteLine("Year: ");

			ushort year = ushort.Parse(Console.ReadLine());
			Console.Clear();

			Console.WriteLine($"Gender: {Enum.GetName(typeof(Genders), gender)}{Environment.NewLine}Title: {title}{Environment.NewLine}Description: {description}{Environment.NewLine}Year: {year}{Environment.NewLine}{Environment.NewLine}Confirm? (Y/ANY): ");

			return new Series(seriesRepository.NextId(), title, description, year, (Genders) gender);
		}

		public static void AddSerie() {
			Series serie = AskSeriesDetailsToUser();
			
			if(Console.ReadLine().ToUpper() == "Y") {
				seriesRepository.Add(serie);
			
				GetUserOption();
			} else {
				GetUserOption();
			}
		}

		// OPTIONS: d = Delete; u = Update; s = Show.
		public static void UpdateOrDeleteOrShow(char option) {
			Console.Clear();

			Console.WriteLine(((option == 'd') ? "Choose a serie to delete:" : "Choose a serie to update:") + Environment.NewLine);

			List<Series> list = seriesRepository.List();

			for(ushort i = 0; i < list.Count; i++) {
				Console.WriteLine("{0} - {1}", i, list[i].GetTitle());
			}

			Console.WriteLine($"{Environment.NewLine}Serie number: ");

			string input = Console.ReadLine();

			if(Regex.IsMatch(input, @"^[0-9]+$")) {
				if(option == 'd') {
					seriesRepository.Delete(int.Parse(input));

					GetUserOption();
				} else {
					if(option == 'u') {
						Series serie = AskSeriesDetailsToUser();
				
						if(Console.ReadLine().ToUpper() == "Y") {
							seriesRepository.Update(int.Parse(input), serie);
						
							GetUserOption();
						} else {
							GetUserOption();
						}
					} else if(option == 's') {
						Console.Clear();
						
						Console.WriteLine(list[int.Parse(input)].ToString());

						Console.WriteLine(Environment.NewLine + "Press any key to go back...");

						Console.ReadKey();

						GetUserOption();
					}
				}
			}
		}

		public static void GetUserOption() {
			string option;
			string newLine = Environment.NewLine;

			Console.Clear();
			Console.WriteLine($"DIO | Series{newLine}{newLine}1 - List series{newLine}2 - Add new serie.{newLine}3 - Update serie{newLine}4 - Delete serie{newLine}5 - Show serie{newLine}Any another key - Exit{newLine}{newLine}Option: ");

			option = Console.ReadLine().ToUpper();

			switch(option) {
				case "1":
					Console.Clear();
					ListSeries();
					break;
				case "2":
					Console.Clear();
					AddSerie();
					break;
				case "3":
					UpdateOrDeleteOrShow('u');
					break;
				case "4":
					UpdateOrDeleteOrShow('d');
					break;
				case "5":
					UpdateOrDeleteOrShow('s');
					break;
				default:
					Environment.Exit(0);
					break;
			}
		}
	}
}