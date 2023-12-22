using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new();
            try
            {
                using DL.JsanchezcrudempleadoContext context = new();
                var query = context.Database.ExecuteSql($"EmpleadoAdd {empleado.Nombre},{empleado.ApellidoPaterno},{empleado.ApellidoMaterno},{empleado.Estatus}");
                if (query >= 1)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un error al insertar el registro";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new();
            try
            {
                using DL.JsanchezcrudempleadoContext context = new();
                var query = context.Database.ExecuteSql($"EmpleadoUpdate {empleado.IdEmpleado},{empleado.Nombre},{empleado.ApellidoPaterno},{empleado.ApellidoMaterno},{empleado.Estatus}");
                if (query >= 1)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un error al actualizar el registro";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll(ML.Empleado empleado)
        {
            ML.Result result = new();
            try
            {
                using DL.JsanchezcrudempleadoContext context = new();
                var query = context.Empleados.FromSql($"EmpleadoGetAll {empleado.Estatus}").ToList();
                result.Objects = [];
                if (query != null)
                {
                    foreach (var obj in query)
                    {
                        empleado = new();
                        empleado.IdEmpleado = obj.Idempleado;
                        empleado.Nombre = obj.Nombre;
                        empleado.ApellidoPaterno = obj.Apellidopaterno;
                        empleado.ApellidoMaterno = obj.Apellidomaterno;
                        empleado.Estatus = (short)obj.Estatus!;

                        result.Objects.Add(empleado);
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new();
            try
            {
                using DL.JsanchezcrudempleadoContext context = new();
                var query = context.Empleados.FromSql($"EmpleadoGetById {IdEmpleado}").AsEnumerable().FirstOrDefault();
                if (query != null)
                {
                    var obj = query;
                    ML.Empleado empleado = new()
                    {
                        IdEmpleado = obj.Idempleado,
                        Nombre = obj.Nombre,
                        ApellidoPaterno = obj.Apellidopaterno,
                        ApellidoMaterno = obj.Apellidomaterno,
                        Estatus = (short)obj.Estatus!
                    };

                    result.Object = empleado;
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new();
            try
            {
                using DL.JsanchezcrudempleadoContext context = new();
                var query = context.Database.ExecuteSql($"EmpleadoDelete {IdEmpleado}");
                if (query >= 1)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Ocurrio un error al inactivar el registro";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
