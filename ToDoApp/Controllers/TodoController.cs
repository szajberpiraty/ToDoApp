using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class TodoController:Controller
    {
       


        public ActionResult Index()
        {
                                   

            //ViewBag.lista = lista;

            return View(MyDb.Lista);
        }

        public ActionResult Create(string Name)
        {

            if (!string.IsNullOrEmpty(Name))
            {
                MyDb.Lista.Add(new TodoItem() { Name = Name, Done = true });
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}