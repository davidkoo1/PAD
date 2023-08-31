using DAL.Interfaces;
using Dapper;
using Domain;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class PostRepository : IPostRepository
    {
        public void CreatePost(Post post)
        {
            string query = "INSERT INTO Post(Author, Content) VALUES(@Author, @Content)"; //iD - Error

            using (var conStr = new SqlConnection(DatabaseOptions.databaseString))
            {
                conStr.Execute(query, new { Author = post.Author, Content = post.Content });
            }
        }

        public IList<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();
            string query = "SELECT * FROM Post WHERE Date >= DATEADD(day, -1, GETDATE()) ORDER BY Date DESC";

            using (var conStr = new SqlConnection(DatabaseOptions.databaseString))
            {
                posts = conStr.Query<Post>(query).ToList();
            }
            return posts;
        }
    }
}
