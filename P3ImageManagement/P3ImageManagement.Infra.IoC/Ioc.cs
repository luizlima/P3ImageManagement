using System;
using SimpleInjector;
using P3ImageManagement.Infra.Dao.Repository;
using P3ImageManagement.Domain.Interfaces;
using P3ImageManagement.Infra.Dao.Config;
using P3ImageManagement.Application.Interfaces;
using System.Web.Mvc;
using P3ImageManagement.Application.Services;
using P3ImageManagement.Domain.Models;

namespace P3ImageManagement.Infra.IoC
{
    public class Ioc
    {
        private static Ioc _instance;
        public readonly Container container;

        protected Ioc()
        {
            container = new Container();
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IRepository<Category>, CategoryRepository>();
            container.Register<IRepository<SubCategory>, SubCategoryRepository>();
            container.Register<ICategoryAppService, CategoryAppService>();
            container.Register<ISubCategoryAppService, SubCategoryAppService>();
        }

        public static Ioc Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Ioc();
                }
                return _instance;
            }


        }
    }
}

