using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using nightowlsign.data;
using nightowlsign.data.Models.Signs;
using SignSystem.DTO.Models.Store;
using SignSystemApi;

namespace SignSystemApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
                Ioc.RegisterDependencies();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            AutoMapper.Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Entities.City, SignDto>();
                //cfg.CreateMap<Entities.City, Models.CityDto>();
                //cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
                //cfg.CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
                //cfg.CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>();
                //cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
                cfg.CreateMap<Store, StoreDto>();
                cfg.CreateMap<StoreDto, Store>();
                cfg.CreateMap<StoreAndSign, StoreDto>();
            });

        }
    }
}
