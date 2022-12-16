using ExamRoman.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ExamRoman
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Calendars.Any())
                {
                    context.Calendars.AddRange(new Calendar
                    {
                        Text = "My first text to Database!",
                        Time = "20-11-2022",
                        Description = "Description to the first statement!",
                        Frequency = 2
                    },
                   new Calendar
                   {
                       Text = "My second text to Database!",
                       Time = "12-12-2022",
                       Description = "Description to the second statement!",
                       Frequency = 3
                   });
                }
                context.SaveChanges();
            }
        }
    }
}
