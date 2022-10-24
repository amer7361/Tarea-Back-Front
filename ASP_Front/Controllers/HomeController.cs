using Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _url= "https://localhost:7224/api/Empleados";
        private readonly string _urlPuestos= "https://localhost:7224/api/Puestos";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient()) { 
            var respuesta= await client.GetFromJsonAsync<List<EmpleadoResponse>>(_url);
                var result = respuesta.Select(e => new EmpleadoViewModel
                {
                    IdEmpleado=e.IdEmpleado,
                    Nombre=e.Nombre,
                    Apellido=e.Apellido,
                    Direccion=e.Direccion,
                    Telefono=e.Telefono,
                    IdPuesto=e.IdPuesto,
                    Dpi=e.Dpi,
                    FechaNacimiento = e.FechaNacimiento.ToString("dd/MM/yyyy"),
                    FechaIngresoRegresitro= e.FechaIngresoRegresitro,
                    Puesto= e.Puesto,
                }).ToList();
                return View(result);
            }
            
        }

        public async Task<IActionResult> Crear()
        {
            using (var client = new HttpClient())
            {
                var respuesta = await client.GetFromJsonAsync<List<Puesto>>(_urlPuestos);
                var listaPuestos = respuesta.ConvertAll(r=>
                {
                    return new SelectListItem()
                    {
                        Text=r.Puesto1,
                        Value=r.IdPuesto.ToString(),
                        Selected=false
                    };
                });
                ViewBag.listaPuestos = listaPuestos;
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreacionEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            using (var client = new HttpClient())
            {
                var respuesta = await client.PostAsJsonAsync(_url,empleado);
                if (!respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error");
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
        public async Task<IActionResult> modificar(int? id)
        {
            using (var client = new HttpClient())
            {
                var respuesta = await client.GetFromJsonAsync<List<Puesto>>(_urlPuestos);
                var listaPuestos = respuesta.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Puesto1,
                        Value = r.IdPuesto.ToString(),
                        Selected = false
                    };
                });
                var responseEmpleado = await client.GetFromJsonAsync<Empleado>(_url+"/"+id);
                ViewBag.listaPuestos = listaPuestos;
                return View(responseEmpleado);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ModificarEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            using (var client = new HttpClient())
            {
                var respuesta = await client.PutAsJsonAsync(_url+"/"+empleado.IdEmpleado, empleado);
                if (!respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error");
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<string> EliminarEmpleado(int? id)
        {
            using (var client = new HttpClient())
            {
                var respuesta = await client.DeleteAsync(_url + "/" + id);
                if (!respuesta.IsSuccessStatusCode)
                {
                    return "Error";
                }
                return "Exito";
            }
           
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}