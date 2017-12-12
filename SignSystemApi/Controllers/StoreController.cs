using System;
using System.Collections.Generic;

using System.Web.Http;
using AutoMapper;
using nightowlsign.data;
using nightowlsign.data.Models.Stores;
using SignSystem.DTO.Models.Store;

namespace SignSystemApi.Controllers
{

    [RoutePrefix("api/Store")]
    public class StoreController : ApiController
    {
        private readonly StoreManager _storeManager;
        private readonly StoreDtoToStore _storeDtoToStore;
        public StoreController()
        {
            _storeManager = new StoreManager();        
            _storeDtoToStore= new StoreDtoToStore();
        }
        //public StoreController(IStoreManager storeManager)
        //{
        //    //_storeManager = storeManager;
        //}

        [HttpGet]
        [Route("getstore/{storeId}")]
        public IHttpActionResult GetStore(int storeId)
        {
            try
            {
                var entity = new Store();
                var storeEntity = _storeManager.GetOneStore(storeId);
                var result = Mapper.Map<IEnumerable<StoreDto>>(storeEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getstores")]
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
     

        [HttpPut]
        [Route("{Id}")]
        public IHttpActionResult Update(int Id, [FromBody] UpdateStoreDto store)
        {
            try
            {
                if (store == null) return BadRequest();
                var storeToUpdate = _storeManager.GetOneStore(Id);
                if (storeToUpdate==null) return NotFound();
                store.Id = Id;
                if (_storeManager.Update(_storeDtoToStore.CreateStore( store)))
                {
                    return Ok( _storeManager.GetOneStore(Id));
                }
               return BadRequest();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult Add([FromBody] StoreDto store)
        {
            try
            {
                if (store == null) return BadRequest();
                var newStore = _storeDtoToStore.CreateNewStore(store);
                if (_storeManager.Insert(newStore))
                {
                    var createdStore = _storeManager.Get(newStore);
                    return Created(Request.RequestUri + "/" + createdStore[0].id.ToString(), createdStore[0]);
                };
                return BadRequest();
           }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                throw;
            }
        }

    }
}
