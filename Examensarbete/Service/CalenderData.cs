using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examensarbete.Service
{
    public class CalenderData
    {
        KudoxaEntities _context = new KudoxaEntities();

        public CalenderBoking GetCalenderBokingById(int id)
        {
            return _context.CalenderBokings.FirstOrDefault(m => m.Id == id);
        }

        public List<CalenderBoking> GetCalenderBokings()
        {
            return _context.CalenderBokings.ToList();
        }

        public string SaveCalenderBoking(CalenderBoking boking)
        {
            try
            {
                _context.CalenderBokings.Add(boking);
                _context.SaveChanges();
                return "Bokningen är sparad";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}