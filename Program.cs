using Week10Assignment.Models;

namespace Week10Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            var manage = new BlogManagement();

            do
            {
                Console.WriteLine("1) Create a blog");
                Console.WriteLine("2) View blogs");
                Console.WriteLine("3) Create A post");
                Console.WriteLine("4) View posts");
                Console.WriteLine("5) Edit blog\n6) Remove blog\n7) Edit post\n8) Remove post");
                Console.WriteLine("Enter any other key to exit.");
                // stored user  input 
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        manage.CreateBlog();
                        break;
                    case "2":
                        manage.VeiwBlogs();
                        break;
                    case "3":
                        manage.CreatePost();
                        break;
                    case "4":
                        manage.ViewPosts();
                        break;
                    case "5":
                        manage.UpdateBlog();
                        break;
                    case "6":
                        manage.RemoveBlog();
                        break;
                    case "7":
                        manage.UpdatePost();
                       
                        break;
                    case "8":
                        manage.RemovePost();
                        break;
                }

               
            } while (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8");

        }
    }
}