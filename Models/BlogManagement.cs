using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Assignment.Models
{
    public class BlogManagement
    {
        public void CreateBlog()
        {
            using (var context = new BlogContext())
            {
                
                Console.WriteLine("Enter a blog name ");
                var blogName = Console.ReadLine();

                var blog = new Blog();
                blog.Name = blogName;

                context.Blogs.Add(blog);
                context.SaveChanges();


            }
        }

      public void VeiwBlogs()
        {
            using (var context = new BlogContext())
            {
                
                var blogsList = context.Blogs.ToList();
                Console.WriteLine("Your Blogs: ");
                foreach (var blog in blogsList)
                {
                    Console.WriteLine($"{blog.Name}");
                }



            }
        }
        public void VeiwBlogsById()
        {
            using (var context = new BlogContext())
            {
                
                var blogsList = context.Blogs.ToList();
                Console.WriteLine("Your Blogs: \n");
                foreach (var blog in blogsList)
                {
                    Console.WriteLine($"Blog ID:{blog.BlogId} Blog Name:{blog.Name}\n");
                }



            }
        }
        public void UpdateBlog()
        {
            using (var context = new BlogContext())
            {
                Console.WriteLine("What Blog Would you like to remove?(Enter Blog ID)");
                VeiwBlogsById();
                var blogId = Convert.ToInt32(Console.ReadLine());

                var blogToUpdate = context.Blogs.Where(b => b.BlogId == blogId).First();

                Console.WriteLine($"Your Choice is {blogToUpdate.Name}");

                Console.WriteLine("What do you want to name the blog?");
                var updatedname = Console.ReadLine();
                blogToUpdate.Name = updatedname;
                context.SaveChanges();


            } 
        }

        public void RemoveBlog()
        {
            using (var context = new BlogContext())
            {
                Console.WriteLine("What Blog Would you like to remove?(Enter Blog ID)");
                VeiwBlogsById();
                var blogId = Convert.ToInt32(Console.ReadLine());

                var blogToUpdate = context.Blogs.Where(b => b.BlogId == blogId).First();

                Console.WriteLine($"Your Choice is {blogToUpdate.Name} Are you sure you want to remove this blog (T)Truth or (F)False");
                var isSure = Console.ReadLine();
                if (isSure.ToUpper() == "T")
                {
                     context.Remove(blogToUpdate);
                    context.SaveChanges();
                    Console.WriteLine("Blog removed");

                }
                else
                {
                    Console.WriteLine("Blogs left Unchanged");
                }




            }


        }
                 public void CreatePost() { 

           
            using (var context = new BlogContext())
            {
              
                Console.WriteLine("Enter a post Title");
                var title = Console.ReadLine();

                Console.WriteLine("Enter post content");
                var postContent = Console.ReadLine();

                Console.WriteLine("What Blog Would you like to post to?(Enter Blog ID)");
                VeiwBlogsById();
                var blogId = Console.ReadLine();


                var post = new Post();
                post.Title = title;
                post.Content = postContent;
                post.BlogId = Convert.ToInt32(blogId);

                context.Posts.Add(post);
                context.SaveChanges();
            }
        }

        public void ViewPosts()
        {
            using (var context = new BlogContext())
            {
                //Read the Blogs
                var postsList = context.Posts.ToList();
                Console.WriteLine("Your Posts: \n");
                foreach (var post in postsList)
                {
                    Console.WriteLine($"Blog:{post.Blog.Name}\nTitle:{post.Title}\nContent:\n{post.Content}\n");
                
                }



            }
        }

        public void UpdatePost()
        {
            using (var context = new BlogContext())
            {
                Console.WriteLine("What Post Would you like to update? [Enter Post ID]");
                ViewPosts();
                var postId = Convert.ToInt32(Console.ReadLine());

                var postToUpdate = context.Posts.Where(p => p.PostId == postId).First();

                Console.WriteLine("What would You like to change\n1)Title\n2)Content ");
                var choice = Console.ReadLine();
                if (choice == "1")
                {

                    Console.WriteLine($"Your Choice is {postToUpdate.Title}");

                    Console.WriteLine("What do you want to change the title to?");
                    var updatedTitle = Console.ReadLine();

                    postToUpdate.Title = updatedTitle;
                    context.SaveChanges();
                }

                else if (choice == "2")
                {

                    Console.WriteLine($"Your Choice is {postToUpdate.Title}");

                    Console.WriteLine("What do you want to change the Content to?");
                    var updatedContent = Console.ReadLine();

                    postToUpdate.Content = updatedContent;
                    context.SaveChanges();
                }

                else { Console.WriteLine("invalid input"); }
            }
        }
      
        public void RemovePost()
        {
            using (var context = new BlogContext())
            {
                Console.WriteLine("What post would you like to remove? [Enter Post ID]");
                VeiwBlogsById();
                var postId = Convert.ToInt32(Console.ReadLine());

                var postToRemove = context.Posts.Where(p => p.PostId == postId).First();

                Console.WriteLine($"Your Choice is {postToRemove.Title} Are you sure you want to remove this post (T)Truth or (F)False");
                var isSure = Console.ReadLine();
                if (isSure.ToUpper() == "T")
                {
                    context.Remove(postToRemove);
                    context.SaveChanges();
                    Console.WriteLine("Post removed");

                }
                else
                {
                    Console.WriteLine("Posts left Unchanged");
                }




            }
        }
       
    }
}
