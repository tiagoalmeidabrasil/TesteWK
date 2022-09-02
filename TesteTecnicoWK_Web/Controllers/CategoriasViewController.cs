using Microsoft.AspNetCore.Mvc;
using System.Net;
using TesteTecnicoWK_Web.Models;

namespace TesteTecnicoWK_Web.Controllers
{
    public class CategoriasViewController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<CategoriaViewModel> categoria = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");

                var responseTask = client.GetAsync("categorias");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CategoriaViewModel>>();
                    readTask.Wait();
                    categoria = readTask.Result;
                }
                else
                {
                    categoria = Enumerable.Empty<CategoriaViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(categoria);
            }
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(CategoriaViewModel categoria)
        {
            if (categoria == null)
            {
                return NotFound();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<CategoriaViewModel>("categorias", categoria);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(categoria);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CategoriaViewModel categoria = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");

                //HTTP GET
                var responseTask = client.GetAsync("categorias/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoriaViewModel>();
                    readTask.Wait();
                    categoria = readTask.Result;
                }
            }
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(CategoriaViewModel categoria)
        {
            if (categoria == null)
            {
                return NotFound();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");
                var putTask = client.PutAsJsonAsync<CategoriaViewModel>("categorias", categoria);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(categoria);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CategoriaViewModel contato = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");
                var deleteTask = client.DeleteAsync("categorias/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(contato);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CategoriaViewModel categoria = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");
                var responseTask = client.GetAsync("categorias/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoriaViewModel>();
                    readTask.Wait();
                    categoria = readTask.Result;
                }
            }
            return View(categoria);
        }


    }
}
