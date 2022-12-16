using ExamRoman.Models;
using ExamRoman.ViewModels;
using System.Collections.Generic;

namespace ExamRoman.Interfaces
{
    public interface IService
    {
        public IEnumerable<Calendar> GetAll();
        public IEnumerable<Calendar> GetById(int id);
        public IEnumerable<Calendar> GetByWord(string word);
        public bool Add(CalendarVM item);
        public bool UpdateById(int id, CalendarVM item);
        public bool DeleteById(int id);
        /// <summary>
        /// Треба подумати як то реалізувати??
        /// </summary>
        public void LockForEveryone();
        public void UnLockForEveryone();
    }
}
