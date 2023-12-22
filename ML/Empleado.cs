namespace ML
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string? Nombre { get; set; }

        public string? ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public short Estatus { get; set; }

        public List<object> Empleados { get; set; }
    }
}
