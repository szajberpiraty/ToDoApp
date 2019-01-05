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
       
        Db db=new Db();

        public ActionResult Index()
        {
                                   

            //ViewBag.lista = lista;

            return View(db.TodoItems.ToList());
        }

        [HttpGet] //annotáció, ez csak GET kéréseket szolgál ki
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost] //ez pedig csak POST-kéréseket kezel
        //Ha az isDone alapból false, akkor nem kell a formban hidden mező
        public ActionResult Create(string name,bool isDone)
        {

            if (!string.IsNullOrEmpty(name))
            {
                
              db.TodoItems.Add(new TodoItem() {Name = name, Done = isDone });
              db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //MyDb.Lista.Where(x=>x.Id==id);

            //Csak akkor jó, ha pontosan egy ilyen elem van!
            var item = db.TodoItems.Single(x=>x.Id==id);

            //Ha ez nem garantálható, akkor
            //var item = MyDb.Lista.SingleOrDefault(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id,string name, bool done)
        {
            var item = db.TodoItems.Single(x => x.Id == id);

            item.Name = name;
            item.Done = done;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = db.TodoItems.Single(x=>x.Id==id);

            return View(item);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = db.TodoItems.Single(x => x.Id == id);

            db.TodoItems.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var item = MyDb.Lista.Single(x => x.Id == id);

            return View(item);
        }

    }
}