using Komodo__Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoApplication_UI
{
    class ProgramUI
    {
        protected readonly DevTeamRepo _DevTeamRepo = new DevTeamRepo();
        protected readonly DeveloperRepo _DeveloperRepo = new DeveloperRepo();


        public bool HasAcceseToPluralsight { get; private set; }

        //This is the method that runs our User Interface
        public void Run()
        {
            //Putting in seed data to have some starting data
            SeedDeveloperList();


            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                //Writes to the Console
                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. Show all Developer \n" +
                    "2. Show all Teams \n" +
                    "3. Find Developers by Developer ID \n" +
                    "4. Find Teams by Team ID \n" +
                    "5. Add new Developer \n" +
                    "6. Add new  Team\n" +
                    "7. Update existing Developer \n" +
                    "8. Update existing Team \n" +
                    "9. Remove Developer  \n" +
                    "10. Remove Team \n" +
                    "11. Exit\n");

                //Reading user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllDevelopers();
                        //Show all Developers
                        break;
                    case "2":
                        ShowAllTeams();
                        //"2. Show all Teams
                        break;
                    case "3":
                        GetDeveloperById();
                        //"3. Find Developers by Developer ID
                        break;
                    case "4":
                        GetTeamById();
                        //"4. Find Teams by Team ID
                        break;
                    case "5":
                        CreateNewDeveloper();
                        //"5. Add new Developer
                        break;
                    case "6":
                        CreateNewTeam();
                        //"6. Add new  Team
                        break;
                    case "7":
                        //"7. Update existing Developer
                        UpdateDeveloper();
                        break;
                    case "8":
                        //"8. Update existing Team
                        UpdateTeam();
                        break;
                    case "9":
                        //"9. Remove Developer
                        DeleteDeveloper();
                        break;
                    case "10":
                        //"10. Remove Team
                        DeleteTeam();
                        break;
                    //
                    case "11":
                        // Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 10 \n" +
                            "Press Key To Countinue");
                        Console.ReadKey();
                        break;

                }
            }
        }

        //Add New Developers
        private void CreateNewDeveloper()
        {
            Console.Clear();
            //new up


            //string Name
            Console.Write("Please enter a Name: ");
            string DevName = Console.ReadLine();

            //bool HasAcceseToPluralsight
            Console.Write("Does the developer have acsess to Pluralsight?: ");
            bool HasAcceseToPluralsight = bool.Parse(Console.ReadLine());

            //int dev Id
            Console.Write("Please enter a Developer Id: ");
            int DevId = int.Parse(Console.ReadLine());

            //New up Content at end
            Developer content = new Developer(DevName, DevId, HasAcceseToPluralsight);

            //Add to repository
            _DeveloperRepo.AddDeveloperToDirectory(content);
        }

        //Add New Team
        private void CreateNewTeam()
        {
            Console.Clear();
            //new up
            //StreamingContent content = new StreamingContent();

            //string Team name
            Console.Write("Please enter a Team Name: ");
            string TeamName = Console.ReadLine();

            //int developer
            Console.Write("Please enter Developer Id to add to team: ");
            int developers = int.Parse(Console.ReadLine());

            //int Team ID
            Console.Write("Please enter Team Id #: ");
            int TeamId = int.Parse(Console.ReadLine());

            //New up Content at end
            DevTeam content = new DevTeam(TeamName, TeamId);

            //Add to repository
            _DevTeamRepo.AddTeamToDirectory(content);
        }


        //Display All Developers
        private void ShowAllDevelopers()
        {
            Console.Clear();

            //Get Developer
            List<Developer> listOfContent = _DeveloperRepo.GetDeveloper();

            //Loop through Contents
            foreach (Developer content in listOfContent)
            {
                //Console Write (Display Content)
                DisplayDeveloper(content);
            }

            //if invald input
            PressKeyToCountinue();
        }

        //Display All Teams
        private void ShowAllTeams()
        {
            Console.Clear();

            //Get Content
            List<DevTeam> listOfContent = _DevTeamRepo.GetTeam();

            //Loop through Contents
            foreach (DevTeam content in listOfContent)
            {
                //Console Write (Display Content)
                DisplayTeam(content);
            }

            //if invald input
            PressKeyToCountinue();
        }


        //Display Developers By Id
        private void GetDeveloperById()  //Search Functionality
        {
            //What Developer do we want
            Console.WriteLine("What Developer are you looking for?");
            //Getting user input
            int DevId = int.Parse(Console.ReadLine());

            //Get Content
            Developer content = _DeveloperRepo.GetDeveloperByDevId(DevId);

            //If we have it
            if (content != null)
            {
                //Display content
                DisplayDeveloper(content);
            }
            else
            {
                Console.WriteLine("Failed to find Developer");
            }
            PressKeyToCountinue();


            //Display Content

        }

        //Display Teams By Id
        public void GetTeamById()  //Search Functionality
        {
            //What title do we want
            Console.WriteLine("What Team are you looking for?");
            //Getting user input
            int TeamId = int.Parse(Console.ReadLine());

            //Get Content
            DevTeam content = _DevTeamRepo.GetTeamByTeamId(TeamId);

            //If we have it
            if (content != null)
            {
                //Display content
                DisplayTeam(content);
            }
            else
            {
                Console.WriteLine("Failed to find team");
            }
            PressKeyToCountinue();


            //Display Content

        }


        //Delete Developer
        private void DeleteDeveloper()
        {
            Console.Clear();
            //select the Developer to delete
            //get Developer by Developer Id
            Console.WriteLine("Which Developer would you like to remove?");

            //setting up a counter for future use
            int count = 0;

            //display all Developers
            List<Developer> contentList = _DeveloperRepo.GetDeveloper();
            foreach (Developer content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.DevId}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                //delete the content
                //Selecting object to be deleted
                Developer targetContent = contentList[targetIndex];
                //Check to see of deleted
                if (_DeveloperRepo.DeleteExistingDeveloper(targetContent))
                {
                    //success message
                    Console.WriteLine($"{targetContent.DevId} removed from repo");
                }
                else
                {
                    //Fail message
                    Console.WriteLine("Sorry something went wrong");
                }


            }
            //if invald input
            else
            {
                Console.WriteLine("Invalid selection");
            }
            PressKeyToCountinue();
        }

        //Delete Team
        private void DeleteTeam()
        {
            Console.Clear();
            //select the content to delete
            //get Team by Team Id
            Console.WriteLine("What Team would you like to remove? Please enter the teams Id #:");

            //setting up a counter for future use
            int count = 0;

            //display all content
            List<DevTeam> contentList = _DevTeamRepo.GetTeam();
            foreach (DevTeam content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.TeamId}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                //delete the Team
                //Selecting object to be deleted
                DevTeam targetContent = contentList[targetIndex];
                //Check to see of deleted
                if (_DevTeamRepo.DeleteExistingTeam(targetContent))
                {
                    //success message
                    Console.WriteLine($"{targetContent.TeamId} removed from repo");
                }
                else
                {
                    //Fail message
                    Console.WriteLine("Sorry something went wrong");
                }


            }
            //if invald input
            else
            {
                Console.WriteLine("Invalid selection");
            }
            PressKeyToCountinue();
        }



        //Update Developer
        private void UpdateDeveloper()
        {
            Console.Clear();
            //Original Developer ID
            //Ask the user what Developer to update
            Console.WriteLine("What Developer would you like to update?");
            int userInput = int.Parse(Console.ReadLine());
            //New Content (Updated content)
            Developer updatedContent = new Developer();

            Console.Write("What is the Developers new name?");
            updatedContent.DevName = Console.ReadLine();

            Console.Write("Does the Developer have acess to Pluralsight?");
            updatedContent.HasAcceseToPluralsight = bool.Parse(Console.ReadLine());

            Console.Write("What is the Developer Id #:");
            updatedContent.DevId = int.Parse(Console.ReadLine());

            _DeveloperRepo.UpdateExistingDeveloper(userInput, updatedContent);
            //Does this update
            //Did they give me a developer Id
            //Feedback message user
            PressKeyToCountinue();


        }

        //Update Team
        private void UpdateTeam()
        {
            Console.Clear();
            //Original Team Id
            //Ask the user what team to update
            Console.WriteLine("What Team would you like to update?");
            int userInput = int.Parse(Console.ReadLine());
            //New Content (Updated content)
            DevTeam updatedContent = new DevTeam();

            Console.Write("What is the new Team Id?");
            updatedContent.TeamId = int.Parse(Console.ReadLine());

            //setting up a counter for future use
            int count = 0;

            //display all Developers
            List<Developer> contentList = _DeveloperRepo.GetDeveloper();
            foreach (Developer content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.DevName}");
            }

            int userInputs = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            //Did I get valid input
            //delete the developer
            //Selecting object to be updated
            Developer targetContent = contentList[targetIndex];
            //Check to see of deleted
            updatedContent.Developers.Add(targetContent);





            _DevTeamRepo.UpdateExistingTeam(userInput, updatedContent);
            //Does this update
            //Did they give me a team Id
            //Feedback message user
            PressKeyToCountinue();


        }



        //Helper Methods


        public void DisplayDeveloper(Developer content)
        {
            Console.WriteLine($"DevName: {content.DevName}\n" +
                    $"HasAcceseToPluralsight: {content.HasAcceseToPluralsight}\n" +
                    $"DevId: {content.DevId}\n");

        }

        private void DisplayTeam(DevTeam content)
        {
            Console.WriteLine($"TeamName: {content.TeamName}\n" +
                    $"Developers: {content.Developers}\n" +
                    $"TeamId: {content.TeamId}\n");

        }


        private void PressKeyToCountinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }




        //Seed Method Developer
        private void SeedDeveloperList()
        {
            Developer JohnSmith = new Developer("JohnSmith", 789456, HasAcceseToPluralsight = true);
            Developer Sara = new Developer("Sara", 689456, HasAcceseToPluralsight = true);
            Developer Lee = new Developer("Lee", 589456, HasAcceseToPluralsight = false);

            _DeveloperRepo.AddDeveloperToDirectory(JohnSmith);
            _DeveloperRepo.AddDeveloperToDirectory(Sara);
            _DeveloperRepo.AddDeveloperToDirectory(Lee);
        }
        //Seed Method devTeam
        private void SeedTeamList()
        {
            DevTeam TeamRed = new DevTeam("TeamRed", 587654);
            DevTeam TeamBlue = new DevTeam("TeamBlue", 987654);
            DevTeam TeamGreen = new DevTeam("TeamGreen", 745784);

            _DevTeamRepo.AddTeamToDirectory(TeamRed);
            _DevTeamRepo.AddTeamToDirectory(TeamBlue);
            _DevTeamRepo.AddTeamToDirectory(TeamGreen);
        }
    }
}