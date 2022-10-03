using BobaTrackerDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using BobaTrackerClassLibrary.Models;
using System.Linq;

namespace BobaTrackerClassLibrary
{
    public class EntryRepository
    {
        BobaTrackerDBContext context;

        public EntryRepository()
        {
            context = new BobaTrackerDBContext();
        }

        public bool AddEntry(DateTime dateTime, bool hasPooped, bool hasPeed)
        {
            bool status;
            
            try
            {
                Entry entry = new Entry()
                {
                    DateTimeId = dateTime,
                    HasPooped = hasPooped,
                    HasPeed = hasPeed
                };
                context.Entries.Add(entry);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public Entry GetLastEntry()
        {
            Entry entry;
            try
            {
                entry = context.Entries.OrderByDescending(e => e.DateTimeId).LastOrDefault();
            }
            catch (Exception)
            {
                entry = null;
            }
            return entry;
        }
    }
}
