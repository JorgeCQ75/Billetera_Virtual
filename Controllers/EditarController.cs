using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Tarjetero_Virtual.Models;

namespace Tarjetero_Virtual.Controllers
{
    public class EditarController : Controller
    {
        // GET: EditarController
        public ActionResult Index(int tar_id)
        {
            ViewBag.Tarjeta = load_Tarjeta(tar_id);
            return View();
        }
        private List<TarjetaModel> load_Tarjeta(int tar_id)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@tar_id", tar_id)
            };
            DataTable ds = Database.DatabaseHelper.ExecuteStoreProcedure("sp_select_tarjeta", param);
            List<TarjetaModel> tarjetaList = new List<TarjetaModel>();

            foreach (DataRow row in ds.Rows)
            {
                tarjetaList.Add(new TarjetaModel()
                {
                    tar_id = Convert.ToInt16(row["id"]),
                    tar_dueño = row["dueño"].ToString(),
                    tar_numerotarjeta = row["numerotarjeta"].ToString(),
                    tar_fechaexpiracion = row["fechaexpiracion"].ToString()
                });
            }

            return tarjetaList;
        }

        public ActionResult Update_tarjeta(int id, string tar_dueño, string tar_numerotarjeta , string tar_fechaexpiracion)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@tar_id", id),
                new SqlParameter("@tar_dueño", tar_dueño),
                new SqlParameter("@tar_numerotarjeta", tar_numerotarjeta),
                new SqlParameter("@tar_fechaexpiracion", tar_fechaexpiracion)
            };

            Database.DatabaseHelper.ExecStoreProcedure("sp_update_tarjeta", param);

            return RedirectToAction("Index", "Home");
        }
        // GET: EditarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EditarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditarController/Create
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

        // GET: EditarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EditarController/Edit/5
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

        // GET: EditarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EditarController/Delete/5
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
