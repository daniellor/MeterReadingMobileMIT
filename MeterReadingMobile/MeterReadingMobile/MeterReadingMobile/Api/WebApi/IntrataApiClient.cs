using MeterReadingMobile.WebApi.Intrata.Model;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReadingMobile.WebApi.Intrata
{
    public class IntrataApiClient
    {

        readonly LoginUserBase _currentUser;


        public IntrataApiClient(LoginUserBase user)
        {
            _currentUser = user;
        }
        public IntrataApiClient(string urlstring)
        {
            _currentUser = new LoginUserBase(urlstring);
        }

        public string GetLoginName()
        {
            return _currentUser.loginname;
        }
        public int GetCurrentInstallId()
        {
            return _currentUser.install;
        }
        #region login
        public async Task<bool> AreCredentialsValidAsync()
        {
            return await AreCredentialsValidAsync(_currentUser);
        }


        public async Task<bool> AreCredentialsValidAsync(LoginUserBase userlogin)
        {
            try
            {
                LoginUserBase lyears = await GetEntityAsync<LoginUserBase>(userlogin, ApiServices.ApiLogin(), false, "");
                _currentUser.token = null;
                if (lyears != null)
                {
                    _currentUser.token = lyears.token;
                    _currentUser.id = lyears.id;
                }
                return _currentUser.token != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion



        public async Task<T> GetEntityAsync<T>(T filter, string apiPath, bool authorization = true, string resourcepath = "") where T : new()
        {
            var crud = new CrudApi<T>(apiPath, _currentUser, authorization);
            return await crud.GetEntityAsync(filter, resourcepath);
        }

        public async Task<List<T>> GetCollectionsAsync<T>(T filter, string apiPath, bool authorization = true, string resourcepath = "collections", Method methodrest = Method.POST) where T : new()
        {
            var crud = new CrudApi<T>(apiPath, _currentUser, authorization);
            return await crud.GetCollectionAsync(filter, resourcepath, methodrest);
        }

        public async Task<T> AddOrUpdateAsync<T>(T model, string apiPath, bool authorization = true) where T : new()
        {

            var crud = new CrudApi<T>(apiPath, _currentUser, authorization);
            return await crud.AddOrUpdateAsync(model);
        }

        public async Task<bool> DeleteAsync<T>(T model, string apiPath, bool authorization = true) where T : new()
        {
            var crud = new CrudApi<T>(apiPath, _currentUser, authorization);
            return await crud.DeleteAsync(model);
        }

    }

}
