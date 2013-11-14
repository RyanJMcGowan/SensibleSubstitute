using SensibleComponents.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents.Posts
{
    public static class PostServices
    {
        /// <summary>
        /// Checks for null contents.
        /// </summary>
        /// <param name="post"></param>
        /// <returns>true if content exists in all fields.</returns>
        public static bool Verify(Post post)
        {
            if (HasAuthor(post)
                && HasBody(post)
                && HasCategory(post)
                && HasTitle(post))
                return true;
            return false;
        }

        public static bool HasTitle(Post post)
        {
            if (post.Title == null)
                return false;
            return true;
        }

        public static bool HasCategory(Post post)
        {
            if (post.Categories == null)
                return false;
            return true;
        }

        public static bool HasBody(Post post)
        {
            if (post.Contents == null)
                return false;
            return true;
        }

        public static bool HasAuthor(Post post)
        {
            if (post.Author == null)
                return false;
            return true;
        }
    }
}