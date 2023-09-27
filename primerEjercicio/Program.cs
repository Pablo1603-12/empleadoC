using System;

namespace MenuPrincipal
{
    class Program
    {
        static void Main(string[] args)
        {
            Servicio empleadoServicio = new EmpleadoImpl();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Cerrar App");
                Console.WriteLine("2. Registro Empleado");
                Console.WriteLine("3. Modificacion Empleado");
                Console.WriteLine("4. Exportar a Fichero");

                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Environment.Exit(0);
                            break;
                        case 2:
                            empleadoServicio.RegistrarEmpleado();
                            break;
                        case 3:
                            Console.WriteLine("Introduce el numero de empleado a modificar:");
                            if (int.TryParse(Console.ReadLine(), out int numeroEmpleado))
                            {
                                empleadoServicio.ModificarEmpleado(numeroEmpleado);
                            }
                            else
                            {
                                Console.WriteLine("Número de empleado inválido");
                            }
                            break;
                        case 4:
                            Console.WriteLine("1. Exportar un empleado");
                            Console.WriteLine("2. Exportar todos los empleados");
                            int opcionExportar;
                            if (int.TryParse(Console.ReadLine(), out opcionExportar))
                            {
                                if (opcionExportar == 1)
                                {
                                    Console.WriteLine("Introduce el numero de empleado a exportar:");
                                    if (int.TryParse(Console.ReadLine(), out int numeroEmpleadoExportar))
                                    {
                                        empleadoServicio.ExportarEmpleado(numeroEmpleadoExportar);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Número de empleado inválido");
                                    }
                                }
                                else if (opcionExportar == 2)
                                {
                                    empleadoServicio.ExportarTodos();
                                }
                                else
                                {
                                    Console.WriteLine("Opcion no valida");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opcion no valida");
                            }
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opcion no valida");
                }
            }
        }
    }
}
