using System;
using System.Collections.Generic;

/**code by Nathan Buron for the Codurence coding test
*First version: 28/08/2015 
*Last update: 28/08/2015
*
*notes:
*in order to simplify the application, the information about users, posts, etc
*will not be saved => closing the application = lost of the data
*
*The "if" chain of the "TreatCommand" method could certainly be simplyfied 
*I didn't create any Unit test for this little application
*But the general structure of the application seems good and the application works well
*
*total development time: 2:20
**/

namespace Twiturence
{
	class MainClass
	{
		
		private const string information = "Hello there!\n" +
											"Welcome to Twiturence…\n\n" +
											"You can post messages, see a wall or follow fellow humans\n" +
											"To do so here are some commands you can use:\n" +
											"Posting: <your name> -> <message>\n" +
											"Reading: <fellow human name>\n" +
											"Following: <your name> follows <fellow human name>\n" +
											"Wall: <your or fellow name> wall\n" +
											"Information: ?\n" +
											"Quit: quit\n\n" +
											"Note:\n" +
											"- a user is created on his first post\n" +
											"- the wall command will show you the posts of the person and all the people He follows\n";
								
		private const string quitting = "Bye!";
		static List<User> users;
		static bool quit;

		public static void Main (string[] args)
		{
			Console.WriteLine (information); //welcome
			quit = false;
			users = new List<User> ();

			//download information

			while (!quit) //routine
			{
				Console.Write (">");
				TreatCommand(Console.ReadLine ());
			}
				
		}

		public static void TreatCommand (string command)
		{
			string[] splittedCommand = command.Split (null);
			User selectedUser = null;

			if (splittedCommand.Length != 0)
			{
				selectedUser = users.Find (x => x.Username == splittedCommand [0]);
			}

			//Commands: ? / quit / Reading
			if (splittedCommand.Length == 1) 
			{ 

				if (splittedCommand [0] == "?") //the user demands the information
				{
					Console.WriteLine (information);
				} 
				else if (splittedCommand [0] == "quit") //close the application
				{
					Console.WriteLine (quitting);
					quit = true;
				} 
				else if (selectedUser != null) 
				{ 
					//the user exist -> Reading command 
					DisplayPosts(selectedUser.Posts);
				}

			} 
			else if (splittedCommand.Length == 2) 
			{
				if (selectedUser != null && splittedCommand[1] == "wall") //wall command
				{  
					DisplayPosts(selectedUser.GetWall());
				}
			}
			else if (splittedCommand.Length > 2) 
			{
				if (splittedCommand[1] == "->") //post command 
				{ 
					if(selectedUser == null) // new user
					{ 
						User newUser = new User (splittedCommand [0]);
						users.Add (newUser);
						newUser.PostMessage (command);
					}
					else
					{
						selectedUser.PostMessage (command);
					}
				}

				if (splittedCommand[1] == "follows" && selectedUser != null && splittedCommand.Length == 3) //follow command 
				{ 
					User toFollow = users.Find (x => x.Username == splittedCommand [2]);
					if(toFollow != null && !selectedUser.UsersFollowed.Contains(toFollow)) // new user
					{ 
						selectedUser.Follow (toFollow);
					}
				}
			}
		}

		public static void DisplayPosts(List<Post> posts)
		{
			foreach (Post post in posts) 
			{
				post.Display ();
			}
		}

	}

}
