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

        public Entry AddEntry(DateTime dateTime, bool hasPooped, bool hasPeed)
        {
            Entry entry;
            try
            {
                entry = new Entry()
                {
                    DateTimeId = dateTime,
                    HasPooped = hasPooped,
                    HasPeed = hasPeed
                };
                context.Entries.Add(entry);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                entry = null;
            }
            return entry;
        }

        public Entry GetLastEntry()
        {
            Entry entry;
            try
            {
                entry = context.Entries.OrderByDescending(e => e.DateTimeId).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                entry = null;
            }
            return entry;
        }

        public bool DeleteLastEntry() 
        {
            bool status;
            try 
            {
                Entry lastEntry = context.Entries.OrderByDescending(e => e.DateTimeId).FirstOrDefault();
                if (lastEntry != null) 
                {
                    context.Entries.Remove(lastEntry);
                    context.SaveChanges();
                    status = true;
                }
                else 
                {
                    Console.WriteLine("Error: Entry does not exist");
                    status = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = false;
            }
            return status;
        }
    }
}
