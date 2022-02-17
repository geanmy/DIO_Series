using System.Collections.Generic;

namespace DIO.Series.Interfaces {
	public interface IRepository<T> {
		public List<T> List();
		T GetById(int Id);
		public void Add(T Entity);
		public void Update(int Id, T Entity);
		public void Delete(int Id);
		public int NextId();
	}
}