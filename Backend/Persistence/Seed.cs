using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;


namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Activities.Any())
            {
                

                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Meeting with Adam",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Sprint Plannig and Retro",
                        Category = "business",
                        City = "Mumbai",
                        Venue = "City Center",
                        
                    },
                    new Activity
                    {
                        Title = "SDE Interview",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Interview at Krone Tech",
                        Category = "business",
                        City = "Patna",
                        Venue = "Maurya lok",
                        
                    },
                    new Activity
                    {
                        Title = "Trip to Sweden",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "visit to artic circle, and Sweden, Norway",
                        Category = "pleasure",
                        City = "Mumbai",
                        Venue = "na",                 
                    },
                    new Activity
                    {
                        Title = "Movie at 5",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Spiderman - NWH with friends",
                        Category = "pleasure",
                        City = "Noida",
                        Venue = "pvr",
                     
                    },
                    new Activity
                    {
                        Title = "wedding anniversay",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "3 years anniversay celebration with wife and friends",
                        Category = "personal",
                        City = "London",
                        Venue = "Pub",
                        
                    },
                    new Activity
                    {
                        Title = "Crud Api demo",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "demo for krone tech at singapore",
                        Category = "business",
                        City = "Singapore",
                        Venue = "singapore",
                        
                    },
                    new Activity
                    {
                        Title = "Future Activity 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Activity 5 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Punch and Judy",
                      
                    },
                    new Activity
                    {
                        Title = "Future Activity 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Activity 6 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                       
                    },
                    new Activity
                    {
                        Title = "Brother's birthday",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "send some nice gift",
                        Category = "personal",
                        City = "Noida",
                        Venue = "home",
                       
                    },
                    new Activity
                    {
                        Title = "Azure Demo",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Azure vm, webapp,  functions, Azure Storage, and Azure AD",
                        Category = "business",
                        City = "Bengaluru",
                        Venue = "city center",
                       
                    }
                };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }
}
