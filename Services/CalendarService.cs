using ExamRoman.Interfaces;
using ExamRoman.Models;
using ExamRoman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamRoman.Services
{
    public class CalendarService : IService
    {
        private AppDbContext _context;
        private bool isLock = false;
        public CalendarService(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(CalendarVM item)
        {
            bool res;
            if (!isLock)
            {
                var tmp = new Calendar()
                {
                    Text = item.Text,
                    Time = item.Time,
                    Description = item.Description,
                    Frequency = item.Frequency
                };
                _context.Calendars.Add(tmp);
                _context.SaveChanges();

                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }

        public bool DeleteById(int id)
        {
            bool res = false;
            if (!isLock)
            {
                var tmp = _context.Calendars.Find(id);
                if (tmp != null)
                {
                    var calendar = _context.Calendars.Where(t => t.Id == tmp.Id).ToList();
                    _context.Calendars.Remove(tmp);
                    _context.SaveChanges();

                    res = true;
                }
            }
            return res;
        }

        public IEnumerable<Calendar> GetAll()
        {
            if(!isLock)
            {
                return _context.Calendars.ToList();
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Calendar> GetById(int id)
        {
            if (isLock) 
            {
                return null;
            }
            return _context.Calendars.Where(t => t.Id == id).ToList();
        }

        public IEnumerable<Calendar> GetByWord(string word)
        {
            if (isLock)
            {
                return null;
            }
            return _context.Calendars.Where(t => t.Text.Contains(word)).ToList();
        }

        public void LockForEveryone()
        {
            isLock = true;
        }

        public void UnLockForEveryone()
        {
            isLock = false;
        }

        public bool UpdateById(int id, CalendarVM item)
        {
            if (isLock)
            {
                return false;
            }
            var tmp = _context.Calendars.Find(id);
            if(tmp == null)
            {
                return false;
            } 
            else
            {
                tmp.Text = item.Text;
                tmp.Time = item.Time;
                tmp.Description = item.Description;
                tmp.Frequency = item.Frequency;
            }
            _context.SaveChanges();
            return true;
        }
    }
}
