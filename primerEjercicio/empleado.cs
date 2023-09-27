using System;
using System.Collections.Generic;
using System.IO;

namespace MenuPrincipal
{
    [Serializable]
    class Empleado
    {
        private static int contadorEmpleados = 1;

        public int NumeroEmpleado { get; private set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string FechaNacimiento { get; set; }
        public string Titulacion { get; set; }
        public string SeguridadSocial { get; set; }
        public string NumeroCuenta { get; set; }

        public Empleado(string nombre, string apellidos, string dni, string fechaNacimiento, string titulacion, string seguridadSocial, string numeroCuenta)
        {
            NumeroEmpleado = contadorEmpleados++;
            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dni;
            FechaNacimiento = fechaNacimiento;
            Titulacion = titulacion;
            SeguridadSocial = seguridadSocial;
            NumeroCuenta = numeroCuenta;
        }
    }

    interface Servicio
    {
        void RegistrarEmpleado();
        void ModificarEmpleado(int numeroEmpleado);
        void ExportarEmpleado(int numeroEmpleado);
        void ExportarTodos();
    }

    class EmpleadoImpl : Servicio
    {
        private readonly List<Empleado> empleados = new List<Empleado>();
        private static readonly string directorioExport = "exports"; // Directorio donde se guardan los archivos de exportación

        public EmpleadoImpl()
        {
            // Crea el directorio de exportación si no existe
            Directory.CreateDirectory(directorioExport);
        }

        public void RegistrarEmpleado()
        {
            Console.WriteLine("Registro de Empleado:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellidos: ");
            string apellidos = Console.ReadLine();

            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            Console.Write("Fecha de Nacimiento: ");
            string fechaNacimiento = Console.ReadLine();

            Console.Write("Titulacion mas Alta: ");
            string titulacion = Console.ReadLine();

            Console.Write("N de Seguridad Social: ");
            string seguridadSocial = Console.ReadLine();

            Console.Write("N de Cuenta Bancaria: ");
            string numeroCuenta = Console.ReadLine();

            Empleado nuevoEmpleado = new Empleado(nombre, apellidos, dni, fechaNacimiento, titulacion, seguridadSocial, numeroCuenta);
            empleados.Add(nuevoEmpleado);

            Console.WriteLine("Empleado registrado con éxito con el N de Empleado: " + nuevoEmpleado.NumeroEmpleado);
        }

        public void ModificarEmpleado(int numeroEmpleado)
        {
            bool encontrado = false;

            foreach (Empleado empleado in empleados)
            {
                if (empleado.NumeroEmpleado == numeroEmpleado)
                {
                    encontrado = true;

                    Console.WriteLine("Modificación de Empleado (N de Empleado: " + numeroEmpleado + "):");

                    Console.Write("Nuevo Nombre: ");
                    string nuevoNombre = Console.ReadLine();
                    empleado.Nombre = nuevoNombre;

                    Console.Write("Nuevo Apellido: ");
                    string nuevoApellido = Console.ReadLine();
                    empleado.Apellidos = nuevoApellido;

                    Console.Write("Nuevo DNI: ");
                    string nuevoDNI = Console.ReadLine();
                    empleado.DNI = nuevoDNI;

                    Console.Write("Nueva Fecha de Nacimiento: ");
                    string nuevaFechaNacimiento = Console.ReadLine();
                    empleado.FechaNacimiento = nuevaFechaNacimiento;

                    Console.Write("Nueva Titulacion mas Alta: ");
                    string nuevaTitulacion = Console.ReadLine();
                    empleado.Titulacion = nuevaTitulacion;

                    Console.WriteLine("Empleado modificado con éxito.");
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Empleado con N de Empleado " + numeroEmpleado + " no encontrado.");
            }
        }

        public void ExportarEmpleado(int numeroEmpleado)
        {
            bool encontrado = false;

            foreach (Empleado empleado in empleados)
            {
                if (empleado.NumeroEmpleado == numeroEmpleado)
                {
                    encontrado = true;

                    string nombreArchivo = Path.Combine(directorioExport, "empleado_" + numeroEmpleado + ".txt");

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(nombreArchivo))
                        {
                            writer.WriteLine("Número de Empleado: " + empleado.NumeroEmpleado);
                            writer.WriteLine("Nombre: " + empleado.Nombre);
                            writer.WriteLine("Apellidos: " + empleado.Apellidos);
                            writer.WriteLine("DNI: " + empleado.DNI);
                            writer.WriteLine("Fecha de Nacimiento: " + empleado.FechaNacimiento);
                            writer.WriteLine("Titulación más Alta: " + empleado.Titulacion);
                        }

                        Console.WriteLine("Empleado exportado con éxito en " + nombreArchivo);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error al exportar el empleado: " + e.Message);
                    }

                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Empleado con Nº de Empleado " + numeroEmpleado + " no encontrado.");
            }
        }

        public void ExportarTodos()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados para exportar.");
                return;
            }

            string nombreArchivo = Path.Combine(directorioExport, "todos_los_empleados.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(nombreArchivo))
                {
                    foreach (Empleado empleado in empleados)
                    {
                        writer.WriteLine("Número de Empleado: " + empleado.NumeroEmpleado);
                        writer.WriteLine("Nombre: " + empleado.Nombre);
                        writer.WriteLine("Apellidos: " + empleado.Apellidos);
                        writer.WriteLine("DNI: " + empleado.DNI);
                        writer.WriteLine("Fecha de Nacimiento: " + empleado.FechaNacimiento);
                        writer.WriteLine("Titulación más Alta: " + empleado.Titulacion);
                        writer.WriteLine();
                    }
                }

                Console.WriteLine("Todos los empleados exportados con éxito en " + nombreArchivo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al exportar los empleados: " + e.Message);
            }
        }
    }
}
