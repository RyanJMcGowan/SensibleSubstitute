using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensibleComponents.Categories
{
    public class CategoryServices
    {
        public static bool IsComplete(Category category)
        {
            if (HasName(category)
                && HasOrder(category))
                return true;
            return false;
        }

        public static bool HasName(Category category)
        {
            if (category.Name == null)
                return false;
            return true;
        }

        public static bool HasOrder(Category category)
        {
            if (category.Order == null)
                return false;
            return true;
        }

    }
}