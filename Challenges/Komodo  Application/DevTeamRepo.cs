using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo__Application
{
    public class DevTeamRepo
    {
        //FakeDatabase
        protected readonly List<DevTeam> _contentDirectory = new List<DevTeam>();
        //CRUD
        // CREATE
        public bool AddTeamToDirectory(DevTeam newContent)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(newContent);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // READ
        public List<DevTeam> GetTeam()
        {
            return _contentDirectory;
        }

        public DevTeam GetTeamByDevId(int DevId)
        {
            //get the directory
            //sort through all the items using DevId to find a match
            foreach (DevTeam content in _contentDirectory)
            {

                ///Need to figure out      if (content.DevId == content.DevId(ToString)
                {
                    //I want to return Developer that matches the DevID
                    return content;
                }
            }
            return null;
        }
        // UPDATE
        public bool UpdateExistingTeam(int originalTeamId, DevTeam newContent)
        {
            DevTeam oldContent = GetTeamByTeamId(originalTeamId);
            if (oldContent != null)
            {
                oldContent.TeamName = newContent.TeamName;
                oldContent.TeamId = newContent.TeamId;
                oldContent.Developers = newContent.Developers;
                return true;
            }
            else
            {
                return false;
            }
        }

        public DevTeam GetTeamByTeamId(int originalTeamId)
        {
            //get the directory

            //sort through all the items using DevId to find a match
            foreach (DevTeam content in _contentDirectory)
            {
                if (originalTeamId == content.TeamId)
                {
                    return content;
                }
            }
            return null;
        }

        // DELETE
        public bool DeleteExistingTeam(DevTeam existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
