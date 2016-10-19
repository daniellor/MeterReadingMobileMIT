using MeterReadingMobile.WebApi.Intrata.Model;
using RestSharp.Portable;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeterReadingMobile.WebApi.Intrata
{
    public class CrudApi<TModelBase> where TModelBase : new()
    {

        private string _apiPath;
        private LoginUserBase _currentUser;
        private bool _authorization;
        public CrudApi(string apiPath, LoginUserBase currentUser, bool authorization)
        {
            _apiPath = apiPath;
            _currentUser = currentUser;
            _authorization = authorization;
        }
        public async Task<TModelBase> GetEntityAsync(TModelBase filter, string resourcepath)
        {

            var request = RestSharpExt.PrepareRequestJson(_apiPath + resourcepath, Method.POST);
            request.AddJsonBody(filter);
            var response = await request.ExecuteAsync<TModelBase>(_currentUser, _authorization);
            return response;

        }
        public async Task<List<TModelBase>> GetCollectionAsync(TModelBase filter, string resourcepath, Method methodrest = Method.POST)
        {

            var request = RestSharpExt.PrepareRequestJson(_apiPath + resourcepath, methodrest);

            if (filter != null)
                request.AddJsonBody(filter);

            var response = await request.ExecuteAsync<List<TModelBase>>(_currentUser, _authorization);
            return response;

        }

        public async Task<TModelBase> AddOrUpdateAsync(TModelBase model)
        {

            var request = RestSharpExt.PrepareRequestJson(_apiPath + "id/{id}", Method.PUT);
            var m = model as ModelBase;
            request.AddUrlSegment("id", m.id.ToString());
            request.AddJsonBody(model);
            var response = await request.ExecuteAsync<TModelBase>(_currentUser, _authorization);
            return response;

        }

        public async Task<bool> DeleteAsync(TModelBase model)
        {

            var request = RestSharpExt.PrepareRequestJson(_apiPath + "id/{id}", Method.DELETE);
            var m = model as ModelBase;
            request.AddUrlSegment("id", m.id.ToString());
            request.AddJsonBody(model);
            var response = await request.ExecuteAsync<ResponseModel>(_currentUser, _authorization);
            return !response.isError;

        }


    }
}
