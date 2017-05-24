using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using nightowlsign.data;
using nightowlsign.data.Models.Stores;

namespace SignSystemApi.Controllers
{


    [System.Web.Http.Route("api")]
    public class StoreController : ApiController
    {
        private readonly IStoreManager _storeManager;

        public StoreController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/store")]

        public IHttpActionResult GetStores()
        {
            try
            {
                var entity = new Store();
                var storeEntities = _storeManager.Get(entity);
                var results = Mapper.Map<IEnumerable<StoreDto>>(storeEntities);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }



    }
}
