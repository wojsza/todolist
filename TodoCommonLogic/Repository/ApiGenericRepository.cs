using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using TodoCommonLogic.Repository.Interfaces;
using TodoDataAccess;

namespace TodoCommonLogic.Repository
{
    public class ApiGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TodoApiContext _context;
        private readonly HttpClient _apiClient;

        public ApiGenericRepository(TodoApiContext context)
        {
            _context = context;
            _apiClient = context.Client;
        }

        public IEnumerable<TEntity> GetAll()
        {
            HttpResponseMessage response = _apiClient.GetAsync("/api/list/GetActivieties").Result;
            string content = response.Content.ReadAsStringAsync().Result;
            List<TEntity> deserilizedData = JsonConvert.DeserializeObject<List<TEntity>>(content);
            return deserilizedData;
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity entity)
        {
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _apiClient.PostAsync("/api/list/CreateActivity", contentData).Result;
            TEntity deserilizedData = JsonConvert.DeserializeObject<TEntity>(response.Content.ReadAsStringAsync().Result);

            return deserilizedData;
        }

        public TEntity Edit(TEntity entity)
        {
            string stringData = JsonConvert.SerializeObject(entity);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            PropertyInfo propInfo = entity.GetType().GetProperty("Id");
            int id = (int)propInfo.GetValue(entity, null);

            HttpResponseMessage response = _apiClient.PutAsync($"/api/list/UpdateActiviety/{id}", contentData).Result;
            TEntity deserilizedData = JsonConvert.DeserializeObject<TEntity>(response.Content.ReadAsStringAsync().Result);

            return deserilizedData;
        }

        public void Delete(TEntity entity)
        {
            PropertyInfo propInfo = entity.GetType().GetProperty("Id");
            int id = (int)propInfo.GetValue(entity, null);
            HttpResponseMessage response = _apiClient.DeleteAsync($"/api/list/DeleteActivity/{id}").Result;
        }
    }
}
