using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.Json;
using Tarjetero_Virtual.Models;

namespace Tarjetero_Virtual.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index(string bancoxemisor)
        {
            
            ViewBag.TarjetaModel = buscar_tarjetas(bancoxemisor);
            return View();
           
        }


        public List<TarjetaModel> buscar_tarjetas(string bancoxemisor)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Param", bancoxemisor)
            };
            DataTable ds = Database.DatabaseHelper.ExecuteStoreProcedure("obtener_Tarjetas", param);
            List<TarjetaModel> tarjetasList = new List<TarjetaModel>();

            foreach (DataRow row in ds.Rows)
            {
                tarjetasList.Add(new TarjetaModel()
                {
                    tar_id = Convert.ToInt16(row["id"]),
                    tar_dueño = row["dueño"].ToString(),
                    tar_banco = row["banco"].ToString(),
                    tar_emisor = row["emisor"].ToString(),
                    tar_numerotarjeta = row["numerotarjeta"].ToString(),
                    tar_ccv = row["ccv"].ToString(),
                    tar_fechaexpiracion = row["fechaexpiracion"].ToString(),
                    tar_estado = row["estado"].ToString(),
                    tar_fotobanco = row["fotobanco"].ToString(),
                    tar_fotoemisor = row["fotoemisor"].ToString(),
                    tar_fotofondo = row["fotofondo"].ToString(),
                    tar_ultimosd = row["ultimosd"].ToString(),
                    tar_calculo = Convert.ToInt16(row["calculo"]),
                });
            }

            return tarjetasList;

        }

        public ActionResult Update_tarStatus(string tar_id, string New_estado)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@tar_id", tar_id),
                new SqlParameter("@new_tar_estado", New_estado)
            };

            Database.DatabaseHelper.ExecStoreProcedure("sp_update_tar_estado", param);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete_tarjeta(string tar_id)
        {
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@tar_id", tar_id)
            };

            Database.DatabaseHelper.ExecStoreProcedure("spDelete_tarjeta", param);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}