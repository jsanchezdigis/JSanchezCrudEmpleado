using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new();
            ML.Result result = BL.Empleado.GetAll(empleado);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpPost]
        public ActionResult GetAll(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.GetAll(empleado);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpGet]
        public ActionResult Form(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);
            if (result.Correct)
            {
                ML.Empleado empleado = (ML.Empleado)result.Object;
                return View(empleado);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error en obtener la información";
                return View("Modal");
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            if (empleado.IdEmpleado == 0)
            {
                ML.Result result = BL.Empleado.Add(empleado);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto el registro";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
                return View("Modal");
            }
            else
            {
                ML.Result result = BL.Empleado.Update(empleado);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo el registro";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                }
                return View("Modal");
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);
            if (result.Correct)
            {
                ViewBag.Message = "Se inactivo el registro correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al inactivar el regitro";
            }
            return View("Modal");
        }
    }
}
