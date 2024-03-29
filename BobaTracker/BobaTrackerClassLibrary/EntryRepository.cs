﻿using BobaTrackerDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BobaTrackerClassLibrary.Models;
using System.Linq;

namespace BobaTrackerClassLibrary
{
    public class EntryRepository
    {
        public BobaTrackerDBContext context;

        public EntryRepository()
        {
            context = new BobaTrackerDBContext();
        }

        public async Task<Entry> AddEntry(DateTime dateTime, bool hasPooped, bool hasPeed)
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
                await context.Entries.AddAsync(entry);
                await context.SaveChangesAsync();
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

        public async Task<bool> DeleteLastEntry() 
        {
            bool status;
            try 
            {
                Entry lastEntry = context.Entries.OrderByDescending(e => e.DateTimeId).FirstOrDefault();
                if (lastEntry != null) 
                {
                    context.Entries.Remove(lastEntry);
                    await context.SaveChangesAsync();
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

        public DateTime? GetLastPoo() 
        {
            try
            {
                List<Entry> entryList = context.Entries.OrderByDescending(e => e.DateTimeId).ToList();
                foreach(var entry in entryList)
                {
                  if (entry.HasPooped == true)
                  {
                    return entry.DateTimeId;
                  }
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public DateTime? GetLastPee()
        {
            DateTime time;
            try 
            {
                time = context.Entries.OrderByDescending(e => e.DateTimeId).FirstOrDefault(e => e.HasPeed == true).DateTimeId;
                if (DateTime.Compare(time, new DateTime()) != 0)
                {
                    return time;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

    }
}
