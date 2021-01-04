using MVC.Helper;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Data
{
    public class ImpCategoryService : ICategoryService
    {
        private readonly InitApi _initapi;

        private readonly List<CategoryModel> l_cat;

        public ImpCategoryService(InitApi initapi)
        {
            _initapi = initapi;
        }
        public void CreateCategory(CategoryModel cat)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(CategoryModel cat)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryModel> GetAllCategoty()
        {
            IEnumerable<CategoryModel> cat = null;
            var client = _initapi.Initial();
            try
            {
                var res = client.GetAsync(ConfigurationManager.AppSettings["CategoryApiUrl"]);
                res.Wait();
                var readdata = res.Result;
                if (readdata.IsSuccessStatusCode)
                {
                    var resulte = readdata.Content.ReadAsAsync<IList<CategoryModel>>();
                    resulte.Wait();
                    cat = resulte.Result;
                }
                return cat;
            }
            catch (Exception e)
            {
                return cat;
            }
        }

        public CategoryModel GetCategoryById(int? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(CategoryModel cat)
        {
            throw new NotImplementedException();
        }


    }
}