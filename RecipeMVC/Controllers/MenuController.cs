using AutoMapper;
using RecipeBLL.DTO;
using RecipeBLL.Repository.Menu;
using RecipeDAL.Repository.Menu;
using RecipeMVC.Models;
using RecipeMVC.ServiceFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace RecipeMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuServiceFacade _service;
        private readonly IMapper _mapper;
        public MenuController(MenuServiceFacade service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //public MenuController()
        //{
        //    var container = new LightInject.ServiceContainer();

        //    _aaaa = container.GetInstance<IMenuRepository>();
        //}

        // GET: Menu
        public ActionResult Form(int id)
        {
            var dto = _service.GetById(id);
            var viewModel = _mapper.Map<RecipeViewModel>(dto);
            return View(viewModel);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SubmitRecipe()
        {
            return View();
        }
        public ActionResult RecipeGrid()
        {
            return View();
        }
        public ActionResult RecipeDetails()
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
            //var viewModel = Mapper.Map<MenuViewModel>(response);
            var viewModel=_mapper.Map<List<RecipeViewModel>>(response);

            return View(viewModel);
           
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var t = _service.GetById(id);
                var dto = _mapper.Map<SaveRecipeViewModel>(t);

                return View(dto);
            }
        }
        [HttpPost]
        public ActionResult Edit(SaveRecipeViewModel model)
        {

            var view = _mapper.Map<RecipeDTO>(model);
            //var dto = _mapper.Map<RecipeDTO>(view);
            var response = _service.Save(view);
            return Json(response);

        }





        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Save(SaveRecipeViewModel model)
        {
            model.CategoryId = 4;
            model.UserId = 1;

            var dto = _mapper.Map<RecipeDTO>(model);
            var response = _service.Save(dto);
            return Json(response);
        }

    }
}