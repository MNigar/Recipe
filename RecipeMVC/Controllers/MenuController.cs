using AutoMapper;
using RecipeBLL.DTO;
using RecipeBLL.Repository.Menu;
using RecipeDAL.Repository.Menu;
using RecipeMVC.Models;
using RecipeMVC.ServiceFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuServiceFacade _service;
        private readonly MenuRepository _aaaa;
        //public MenuController(MenuServiceFacade service)
        //{
        //    _service = service;
        //}

        public MenuController()
        {
            var container = new LightInject.ServiceContainer();

            _aaaa = container.GetInstance<IMenuRepository>();
        }

        // GET: Menu
        public ActionResult Form(int id)
        {
            var dto = _service.GetById(id);
            var viewModel = Mapper.Map<MenuViewModel>(dto);
            return View(viewModel);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Remove(int id)
        {
            var response = _service.Remove(id);
            return Json(response);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var response = _service.GetAll();
            var viewModel = Mapper.Map<MenuViewModel>(response);
            return View(viewModel);
        }

        public ActionResult Save(MenuViewModel model)
        {
            var dto = Mapper.Map<MenuDTO>(model);
            var response = _service.Save(dto);
            return Json(response);
        }

    }
}