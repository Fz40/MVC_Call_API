using MVC.Helper;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

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

        public async Task<IEnumerable<CategoryModel>> GetAll_Categoty()
        {
            IEnumerable<CategoryModel> cat = null;
            var client = _initapi.Initial();
            try
            {
                HttpResponseMessage res = await client.GetAsync(ConfigurationManager.AppSettings["CategoryApiUrl"]);

                if (res.IsSuccessStatusCode)
                {
                    //var resulte = readdata.Content.ReadAsAsync<IList<CategoryModel>>();
                    var resulte = res.Content.ReadAsStringAsync().Result;

                    cat = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(resulte);
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
            CategoryModel cat = null;
            var client = _initapi.Initial();
            try
            {

                if (id == null)
                {
                    return cat;
                }
                var res = client.GetAsync(ConfigurationManager.AppSettings["CategoryApiUrl"]+"/"+id);
                res.Wait();
                var readdata = res.Result;

                if (readdata.IsSuccessStatusCode)
                {
                    var resulte = readdata.Content.ReadAsAsync<CategoryModel>();
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

        public void UpdateCategory(CategoryModel cat)
        {
            throw new NotImplementedException();
        }


    }
}