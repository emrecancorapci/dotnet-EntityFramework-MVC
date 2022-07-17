using System.Collections;
using System.Collections.Generic;
using Bookshop.Entities;

namespace Bookshop.Business.Interfaces
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();
    }
}