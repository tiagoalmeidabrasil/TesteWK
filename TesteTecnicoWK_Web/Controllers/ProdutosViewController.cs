using Microsoft.AspNetCore.Mvc;
using System.Net;
using TesteTecnicoWK_Web.Models;

namespace TesteTecnicoWK_Web.Controllers
{
    public class ProdutosViewController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ProdutosViewModel> produtos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");

                var responseTask = client.GetAsync("produtos");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProdutosViewModel>>();
                    readTask.Wait();
                    produtos = readTask.Result;
                }
                else
                {
                    produtos = Enumerable.Empty<ProdutosViewModel>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(produtos);
            }
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(ProdutosViewModel produto)
        {
            if (produto == null)
            {
                return NotFound();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<ProdutosViewModel>("produtos", produto);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(produto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProdutosViewModel produto = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");

                //HTTP GET
                var responseTask = client.GetAsync("produtos/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProdutosViewModel>();
                    readTask.Wait();
                    produto = readTask.Result;
                }
            }
            return View(produto);
        }

        [HttpPost]
        public ActionResult Edit(ProdutosViewModel produto)
        {
            if (produto == null)
            {
                return NotFound();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");
                var putTask = client.PutAsJsonAsync<ProdutosViewModel>("produtos", produto);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(produto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProdutosViewModel contato = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");
                var deleteTask = client.DeleteAsync("produtos/" + id.ToString());
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
            ProdutosViewModel produto = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7025/api/");
                var responseTask = client.GetAsync("produtos/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProdutosViewModel>();
                    readTask.Wait();
                    produto = readTask.Result;
                }
            }
            return View(produto);
        }


    }
}