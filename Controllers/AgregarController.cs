using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Tarjetero_Virtual.Controllers
{
    public class AgregarController : Controller
    {
        // GET: AgregarController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AgregarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgregarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgregarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgregarController/Edit/5
        public ActionResult Save(string tar_dueño, string tar_banco, string tar_emisor, string tar_numerotarjeta, string tar_ccv, string tar_fechaexpiracion, string tar_estado, IFormFile tar_fotobanco, IFormFile tar_fotoemisor, IFormFile tar_fotofondo)
        {
            string filePath1;
            string filePath2;
            string filePath3;
            if (tar_fotobanco != null && tar_fotoemisor != null && tar_fotofondo != null)
            {
                string fileName = tar_banco + new FileInfo(tar_fotobanco.FileName).Extension;
                filePath1 = Path.Combine("Imagenes/Bancos/", fileName);
                string localFileName = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagenes/Bancos"), fileName);

                string fileName1 = tar_fotoemisor + new FileInfo(tar_fotoemisor.FileName).Extension;
                filePath2 = Path.Combine("Imagenes/Emisor/", fileName1);
                string localFileName1 = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagenes/Emisor"), fileName1);

                string fileName2 = tar_fotofondo + new FileInfo(tar_fotofondo.FileName).Extension;
                filePath3 = Path.Combine("Imagenes/Fondosdetarjetas/", fileName2);
                string localFileName2 = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagenes/Fondosdetarjetas"), fileName2);

                using (var stream = new FileStream(localFileName2, FileMode.Create))
                {
                    tar_fotofondo.CopyTo(stream);
                };


            }
            else
            {
                filePath1 = Path.Combine("Imagenes/Bancos/", tar_banco + ".png");
                filePath2 = Path.Combine("Imagenes/Emisores/", tar_emisor + ".png");
                filePath3 = Path.Combine("Imagenes/Fondosdetarjetas/", "default.png");
            }
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@tar_dueño", tar_dueño),
                new SqlParameter("@tar_banco", tar_banco),
                new SqlParameter("@tar_emisor", tar_emisor),
                new SqlParameter("@tar_numerotarjeta", tar_numerotarjeta),
                new SqlParameter("@tar_ccv", tar_ccv),
                new SqlParameter("@tar_fechaexpiracion", tar_fechaexpiracion),
                new SqlParameter("@tar_estado", tar_estado),
                new SqlParameter("@tar_fotobanco", filePath1),
                new SqlParameter("@tar_fotoemisor", filePath2),
                new SqlParameter("tar_fotofondo", filePath3)
            };

            Database.DatabaseHelper.ExecStoreProcedure("sp_insert_tarjetas", param);


            return RedirectToAction("Index", "Home");
        }

        // POST: AgregarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgregarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgregarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
