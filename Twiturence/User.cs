using System;
using System.Collections.Generic;

namespace Twiturence
{
	public class User
	{
		private string username;
		public string Username {
			get {
				return username;
			}
		}

		private List<User> usersFollowed;
		public List<User> UsersFollowed {
			get {
				return usersFollowed;
			}
		}

		private List<Post> posts;
		public List<Post> Posts {
			get {
				return posts;
			}
		}

		public User (string usernameExpected)
		{
			username = usernameExpected;	
			usersFollowed = new List<User> ();
			posts = new List<Post> ();
		}

		public void PostMessage(string message)
		{
			posts.Insert (0, new Post(message));
		}

		public void Follow(User userToFollow)
		{
			usersFollowed.Add (userToFollow);
			PostMessage (username + " follows " + userToFollow.Username);
		}
			
		public List<Post> GetWall ()
		{
			//here merge list post with posts of users followed
			List<Post> mergedPosts = posts;

			foreach (User userFollowed in usersFollowed) 
			{
				mergedPosts.AddRange (userFollowed.Posts);
			}
				
			mergedPosts.Sort(); //check the sort !

			return mergedPosts;
		}

		public int test()
		{
			return -1;
		}
	}

}

