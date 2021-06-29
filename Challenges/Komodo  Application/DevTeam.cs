using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo__Application
{
    public class DevTeam
    {
        //Constructors 
        //Constructor Empty
        public DevTeam() { }
        //Constructor Full
        public DevTeam(string teamName, int teamId)
        {
            TeamId = teamId;
            TeamName = teamName;
            
        }

        public void AddDevToTeam(Developer dev)
        {
            Developers.Add(dev);
        }

        //POCO *Plain Old C# Object

        //Properties
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public List<Developer> Developers { get; set; }
    }
}