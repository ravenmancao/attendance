using System;
using System.Collections.Generic;
using System.Text;

namespace attendanceDataService
{
    internal class dataService
    {

        public class DataService
        {
            public List<string> GetStudents()
            {
                return new List<string>()
            {
                "Ralph Monzon","Brix Sochaco","Manu Masangkay",
                "Jen Villareal","Josh Dator","Gege Graban",
                "Abby Almadin","Laurent Dimapelis","Eichi Aquino",
                "Rave Mancao","Mitch Pichi","Shielo Resaba",
                "Keichiro Shin","Jewell Gestoso","Usher Magbanua"
            };
            }

            public string[,] GetAttendance()
            {
                return new string[,]
                {
                { "P","P","A","E","E" },
                { "P","A","P","P","P" },
                { "A","P","P","E","P" },
                { "P","P","P","P","P" },
                { "P","P","P","E","P" },
                { "P","P","P","P","A" },
                { "P","P","E","E","P"},
                { "P","P","P","P","P"},
                { "P","P","A","P","E"},
                { "P","P","P","E","P"},
                { "E","E","P","P","P"},
                { "P","P","A","P","P"},
                { "P","P","P","P","P"},
                { "P","A","E","P","P"},
                { "P","A","A","A","P"},
                };
            }
        }
    }
}
