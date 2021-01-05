﻿
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data
{
    public interface ICategoryService
    {

        IEnumerable<CategoryModel> GetAllCategoty();

        Task<IEnumerable<CategoryModel>> GetAll_Categoty();
        Task<CategoryModel> GetCategoryById(int? id);

        Task<string> CreateCategory(CategoryModel cat);
        void UpdateCategory(CategoryModel cat);
        void DeleteCategory(CategoryModel cat);
    }
}
