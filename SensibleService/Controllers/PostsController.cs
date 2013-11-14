using SensibleComponents.Authors;
using SensibleComponents.Categories;
using SensibleComponents.Comments;
using SensibleComponents.Contacts;
using SensibleComponents.Posts;
using SensibleComponents.Schedules;
using SensibleService.Data;
using SensibleService.Models;
using SensibleService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SensibleService.Controllers
{
    public class PostsController : ApiController
    {
        private static PostContext _context = new PostContext();
        private PostRepository postDB = new PostRepository(_context);
        private AuthorRepository authorDB = new AuthorRepository(_context);
        private ScheduleRepository scheduleDB = new ScheduleRepository(_context);
        private CategoryRepository categoryDB = new CategoryRepository(_context);
        private CommentRepository commentDB = new CommentRepository(_context);

        public Post Get(int id)
        {
            Post post = new Post();
            try {post = postDB.GetByID(id);}
            catch (Exception) { post = null; }
            if (post == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            
            return post;
        }

        [HttpGet]
        public IEnumerable<Post> GetDateRange(DateTime beginTime, DateTime endTime)
        {
            try
            {
                IQueryable<Post> posts;
                if (beginTime < endTime)
                    posts = postDB.GetRange(beginTime, endTime);
                else
                    posts = postDB.GetRange(endTime, beginTime);
                if (posts == null)
                {
                    throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));
                }
                return posts;
            }
            catch (HttpResponseException) { }
            Request.CreateResponse(HttpStatusCode.NotFound);
            return null;
        }

        [HttpGet]
        public IEnumerable<Post> GetAllByPaging(int pageSize, int page)
        {
            // TODO: Posts/GetAllByPaging()
            // Check pageSize is 25 or less. if more return badrequest.
            // get Posts.Count. If over page * 25, return page of Posts.Count() / 25. i.e. last page.

            throw new NotImplementedException("Posts/GetAllByPaging is not yet implemented.");
        }

        [HttpGet]
        public IEnumerable<Post> GetAll()
        {
            //TODO: Limit to 25 or so. Send message if over 25 to use GetAllByPaging
            IEnumerable<Post> posts = postDB.GetAll();
            return posts;
        }

        [HttpPost]
        public HttpResponseMessage Post(Post post)
        {
            if (PostServices.Verify(post))
            {
                if (postDB.GetByID(post.ID) == null)
                {
                    if (postDB.Insert(post))
                        return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    if (postDB.Update(post))
                        return Request.CreateResponse(HttpStatusCode.Accepted);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return false;
        }

        [HttpGet]
        public HttpResponseMessage Seed()
        {
            //This method is not optimized for speed and doesn't need to be.
            //It's only function is to run once to populate the databse with fake data.
            if (authorDB.GetByID(1) == null)
                SeedAuthors();
            if (categoryDB.GetByID(1) == null)
                SeedCategories();
            if (postDB.GetByID(1) == null)
                SeedPosts();
            if (commentDB.GetByID(1) == null)
                SeedComments();

            return Request.CreateResponse(HttpStatusCode.Created,"Posts have been seeded.");
        }

        private void SeedPosts()
        {
            int n;
            for (int i = 1; i <= 5; i++)
            {
                Post post = new Post();
                //Populate Author
                Author author;
                int authorId = 1;
                if (i > 2)
                    authorId = 2;
                author = authorDB.GetByID(authorId);

                //Populate Categories
                List<Category> categories = new List<Category>();
                for (n = 0; n < 1; n++)
                {
                    categories.Add(categoryDB.GetByID(n + i));
                }

                //Populate the post itself
                if (i == 1)
                {
                    post.Contents = "Vestibulum sit amet ligula auctor, tempor quam et, placerat odio. Cras cursus, eros non lacinia bibendum, leo nunc rhoncus sapien, in venenatis mauris nulla nec felis. Etiam imperdiet lectus sit amet placerat pulvinar. Vestibulum nec risus lacus. Phasellus aliquet risus vitae pulvinar porttitor. Sed tempus suscipit nibh in malesuada. Etiam condimentum metus mauris, sit amet aliquam ipsum ultricies at. Suspendisse sed dignissim risus. Aenean luctus ut diam nec interdum. Donec pellentesque, ligula non dignissim ultrices, augue risus viverra diam, id elementum nulla urna et dui. In volutpat ullamcorper lacinia. Duis cursus viverra velit, vel luctus nisl adipiscing eu. Cras placerat ac turpis sit amet suscipit. Sed sed ipsum vitae augue lobortis euismod ac in sapien.";
                    post.Title = "Lorem Ipsum";
                    post.Author = author;
                    post.LastEdited = DateTime.Now;
                    post.Schedule = new Schedule();
                    post.Schedule.PublishDate = DateTime.Now + TimeSpan.FromDays(-2);
                }

                if (i == 2)
                {
                    post.Contents = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris a mauris in ligula faucibus ornare. In hendrerit vitae arcu ut porttitor. Integer eu sollicitudin ipsum, ac mattis ipsum. Etiam eros nunc, ultricies vitae mauris eu, volutpat tincidunt tortor. Interdum et malesuada fames ac ante ipsum primis in faucibus. Morbi posuere turpis sed fringilla hendrerit. Cras non dapibus lorem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nam vitae porttitor lorem, eu bibendum nisl. Donec commodo condimentum aliquam.";
                    post.Title = "Vestibulum ante ipsum";
                    post.Author = author;
                    post.LastEdited = DateTime.Now;
                    post.Schedule = new Schedule();
                    post.Schedule.PublishDate = DateTime.Now + TimeSpan.FromDays(2);
                }

                if (i == 3)
                {
                    post.Contents = "Phasellus mi sapien, interdum eget sem sed, vulputate commodo ipsum. Sed pretium erat eget massa aliquam sagittis id a nisi. Pellentesque ullamcorper magna arcu, malesuada elementum odio commodo sed. Nunc purus lectus, feugiat vel elementum vitae, ullamcorper id est. Sed mollis, nunc at iaculis tincidunt, enim mauris convallis metus, nec sodales felis quam at erat. Donec eu elementum massa. Aliquam eros orci, vehicula aliquam porttitor at, posuere id est. Aenean vestibulum, libero at placerat rhoncus, dolor eros lacinia velit, et feugiat erat mauris at elit. Nullam sit amet nisi elementum, tristique dui ac, tempus mi. Suspendisse potenti. Pellentesque neque augue, volutpat malesuada neque eu, ornare sodales dui. Suspendisse potenti. Praesent dignissim id leo vitae volutpat. Ut ullamcorper ligula massa, non faucibus mi dictum eget. Donec commodo, nulla ac pretium vestibulum, sapien nunc rhoncus purus, id fringilla justo eros a libero. Praesent sagittis at leo tincidunt varius.";
                    post.Title = "Lorem Ipsum";
                    post.Author = author;
                    post.LastEdited = DateTime.Now;
                    post.Schedule = new Schedule();
                    post.Schedule.PublishDate = DateTime.Now + TimeSpan.FromDays(20);
                }

                if (i == 4)
                {
                    post.Contents = "Donec eu elementum massa. Aliquam eros orci, vehicula aliquam porttitor at, posuere id est. Aenean vestibulum, libero at placerat rhoncus, dolor eros lacinia velit, et feugiat erat mauris at elit. Nullam sit amet nisi elementum, tristique dui ac, tempus mi. Suspendisse potenti. Pellentesque neque augue, volutpat malesuada neque eu, ornare sodales dui. Suspendisse potenti. Praesent dignissim id leo vitae volutpat. Ut ullamcorper ligula massa, non faucibus mi dictum eget. Donec commodo, nulla ac pretium vestibulum, sapien nunc rhoncus purus, id fringilla justo eros a libero. Praesent sagittis at leo tincidunt varius. Vestibulum sit amet ligula auctor, tempor quam et, placerat odio. Cras cursus, eros non lacinia bibendum, leo nunc rhoncus sapien, in venenatis mauris nulla nec felis. Etiam imperdiet lectus sit amet placerat pulvinar. Vestibulum nec risus lacus. Phasellus aliquet risus vitae pulvinar porttitor. Sed tempus suscipit nibh in malesuada. Etiam condimentum metus mauris, sit amet aliquam ipsum ultricies at.";
                    post.Title = "Lorem Ipsum";
                    post.Author = author;
                    post.LastEdited = DateTime.Now;
                    post.Schedule = new Schedule();
                    post.Schedule.PublishDate = DateTime.Now + TimeSpan.FromDays(90);
                }
                if (i == 5)
                {
                    post.Contents = "Vestibulum sit amet ligula auctor, tempor quam et, placerat odio. Cras cursus, eros non lacinia bibendum, leo nunc rhoncus sapien, in venenatis mauris nulla nec felis. Etiam imperdiet lectus sit amet placerat pulvinar. Vestibulum nec risus lacus. Phasellus aliquet risus vitae pulvinar porttitor. Sed tempus suscipit nibh in malesuada. Etiam condimentum metus mauris, sit amet aliquam ipsum ultricies at. Suspendisse sed dignissim risus. Aenean luctus ut diam nec interdum. Donec pellentesque, ligula non dignissim ultrices, augue risus viverra diam, id elementum nulla urna et dui. In volutpat ullamcorper lacinia. Duis cursus viverra velit, vel luctus nisl adipiscing eu. Cras placerat ac turpis sit amet suscipit. Sed sed ipsum vitae augue lobortis euismod ac in sapien.";
                    post.Title = "Lorem Ipsum";
                    post.Author = author;
                    post.LastEdited = DateTime.Now;
                    post.Schedule = new Schedule();
                    post.Schedule.PublishDate = DateTime.Now + TimeSpan.FromDays(500);
                }

                postDB.Insert(post);
            }
            
            postDB.SaveChanges();
            

        }

        [HttpGet]
        private void SeedComments()
        {
            List<Comment> comments = new List<Comment>();
            for (int i = 1; i <= 8; i++)
            {
                Comment comment = new Comment();
                comment.CommentText = "This is comment number " + i.ToString();
                comment.IsApproved = true;
                comment.IsMarkedAsSpam = false;
                comment.TimeStamp = DateTime.Now;
                comment.IsSpam = false;
                if (i >4)
                    comment.Post = postDB.GetByID(1);
                else
                    comment.Post = postDB.GetByID(2);
                    
                commentDB.Insert(comment);
            }
            commentDB.SaveChanges();
        }

        private void SeedCategories()
        {
            for (int i = 0; i <= 4; i++ )
            {
                Category category = new Category();
                if(i == 0)
                    category.Name = "General";
                if (i == 1)
                    category.Name = "Worksheets";
                if (i == 2)
                    category.Name = "Time Management";
                if (i == 3)
                    category.Name = "Discipline";
                if (i == 4)
                    category.Name = "Montessori";
                categoryDB.Insert(category);
            }
            
            categoryDB.SaveChanges();
        }

        private void SeedAuthors()
        {
            List<Author> authors = new List<Author>();
            int i;
            for (i = 1; i <= 2; i++)
            {
                Author author = new Author();
                if (i == 1)
                {
                    ContactInfo contact = new ContactInfo();
                    Address address = new Address();
                    List<Address> addresses = new List<Address>();
                    Email email = new Email();
                    List<Email> emails = new List<Email>();
                    author.Name = "John Doe";
                    contact.TwitterCallsign = "@JohnDoe";
                    contact.ContactType = ContactType.Home;
                    {
                        address.City = "Los Angeles";
                        address.IsMailing = true;
                        address.IsPublic = false;
                        address.State = "CA";
                        address.Street1 = "1234 Main Street";
                        address.Street2 = "Apt. 203";
                        address.Zip = "90001";
                        address.IsPrimary = true;
                    }
                    addresses.Add(address);
                    contact.Addresses = addresses;
                    {
                        email.EmailAddress = "john@doe.com";
                        email.DisplayName = "John Doe at Home";
                        email.IsSubscribed = true;
                        emails.Add(email);
                        contact.Emails = emails;
                    }

                    author.ContacntInfo = contact;
                    authors.Add(author);
                }
                if (i == 2)
                {
                    ContactInfo contact = new ContactInfo();
                    Address address = new Address();
                    List<Address> addresses = new List<Address>();
                    Email email = new Email();
                    List<Email> emails = new List<Email>();
                    author.Name = "Jane Doe";
                    contact.TwitterCallsign = "@JaneDoe";
                    contact.ContactType = ContactType.Home;
                    Phone phone = new Phone();
                    phone.CountryCode = 1;
                    phone.Number = 1234567890;
                    contact.PrimaryPhoneNumber = phone;
                    {
                        address.City = "New York";
                        address.IsMailing = false;
                        address.IsPublic = true;
                        address.State = "NY";
                        address.Street1 = "4678 Park Ave";
                        address.Street2 = "Apt. 304";
                        address.Zip = "10007";
                        address.IsPrimary = true;
                    }
                    addresses.Add(address);
                    contact.Addresses = addresses;
                    {
                        email.EmailAddress = "jane@doe.com";
                        email.DisplayName = "Jane Doe";
                        email.IsSubscribed = false;
                        emails.Add(email);
                        contact.Emails = emails;
                    }

                    author.ContacntInfo = contact;
                    authors.Add(author);
                }
            }
            foreach (Author a in authors)
            {
                authorDB.Insert(a);
            }
            authorDB.SaveChanges();
        }

    }
}