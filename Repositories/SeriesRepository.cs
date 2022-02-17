using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series {
	public class SeriesRepository : IRepository<Series> {
		private List<Series> listSeries = new List<Series>();

		public List<Series> List() {
			return listSeries;
		}

		public Series GetById(int Id) {
			return listSeries[Id];
		}

		public void Add(Series Entity) => listSeries.Add(Entity);

		public void Update(int Id, Series Entity) => listSeries[Id] = Entity;

		public void Delete(int Id) => listSeries[Id].Delete();

		public int NextId() {
			return listSeries.Count;
		}
	}
}