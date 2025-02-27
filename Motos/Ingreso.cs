﻿using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Motos
{
    public class Ingreso
    {
        public void Arrancar()
        {
            double opcion = 0;
            List<Datos> lista = new List<Datos>();
            bool iniciar = true;


            while (iniciar)
            {

                Console.Clear();
                Console.WriteLine("********** STORE CAMBIO5 ************");
                Console.WriteLine("Por Favor Seleccione la Opción Que Desea Realizar");
                Console.WriteLine(" 1-  INGRESAR DATOS");
                Console.WriteLine(" 2-  MOSTRAR LISTA");
                Console.WriteLine(" 3-  BUSCAR");
                Console.WriteLine(" 4-  ELIMINAR");
                Console.WriteLine(" 5-  ACTUALIZAR");
                Console.WriteLine(" 0-  SALIR");

                opcion = double.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        bool idvalido = false;
                        while (!idvalido)
                        {
                            Console.WriteLine("ingrese el id");
                            try
                            {
                                int id = Convert.ToInt32(Console.ReadLine());

                                if (lista.Exists(i => i.Id == id))
                                {
                                    Console.WriteLine("El ID que estas Ingresando ya existe, Por Favor ingresar un ID diferente");

                                }
                                else
                                {
                                    idvalido = true;
                                }


                                Console.WriteLine("Ingrese el nombre");
                                string nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese Cilindraje del motor");
                                int motor;
                                while (true)
                                {
                                    try
                                    {
                                        motor = int.Parse(Console.ReadLine());
                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Ingrese un valor valido para el cilindraje del motor");
                                    }
                                }

                                Console.WriteLine("Ingrese la Cantidad de ruedas");
                                int ruedas;
                                while (true)
                                {
                                    try
                                    {
                                        ruedas = int.Parse(Console.ReadLine());
                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Ingrese un valor valido para la cantidad de ruedas");
                                    }
                                }
                                Console.WriteLine("Ingrese la marca");
                                string marca = Console.ReadLine();
                                Datos dato = new Datos(id, nombre, motor, ruedas, marca);
                                lista.Add(dato);

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ingrese un valor valido para el ID del vehiculo");
                            }
                        }
                        break;
                    case 2:
                        foreach (Datos imprimir in lista)
                        {
                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine("Su lista de información de su motocicleta es: ");
                            Console.WriteLine("ID: " + imprimir.Id);
                            Console.WriteLine("NOMBRE: " + imprimir.Nombre);
                            Console.WriteLine("CC MOTOR : " + imprimir.Motor);
                            Console.WriteLine("CANTIDAD RUEDAS: " + imprimir.Ruedas);
                            Console.WriteLine("MARCA: " + imprimir.Marca);
                            Console.WriteLine("----------------------------------------------------------------");
                        }

                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Por favor Ingrese el ID del Vehículo ue Buscas");
                        try
                        {
                            int BuscarId = int.Parse(Console.ReadLine());
                            Datos vehiculo = lista.Find(v => v.Id == BuscarId);
                            if (vehiculo != null)
                            {
                                Console.WriteLine("ID del Vehiculo Encontrado:  " + BuscarId);
                                Console.WriteLine("El nombre del Vehiculo es:  " + vehiculo.Nombre);
                                Console.WriteLine("El Cilindraje de su Vehiculo es:  " + vehiculo.Motor);
                                Console.WriteLine("La Cantidad de Ruedas de su Vehiculo son:  " + vehiculo.Ruedas);
                                Console.WriteLine("La Marca de su Vehiculo es:  " + vehiculo.Marca);
                            }
                            else
                            {
                                Console.WriteLine("¡¡ No se Encontro el ID de su Vehiculo!!");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error:  el Valor ingresado no es un Numero Valido");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ERROR: " + ex.Message); 
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el ID del Vehiculo Que desea Eliminar");
                        try
                        {
                            int BorrarId = int.Parse(Console.ReadLine());
                            Datos vehiculo2 = lista.Find(v => v.Id == BorrarId);

                            if (vehiculo2 != null)
                            {
                                lista.Remove(vehiculo2);
                                Console.WriteLine("El ID del Vehiculo Eliminado es: " + BorrarId);
                                Console.WriteLine("El Nombre del Vehiculo Eliminado es:  " + vehiculo2.Nombre);
                                Console.WriteLine("El Cilindraje del Vehiculo Eliminado es:  " + vehiculo2.Motor);
                                Console.WriteLine("La Cantidad de Ruedas del Vehiculo Eliminado es:  " + vehiculo2.Ruedas);
                                Console.WriteLine("La Marca del Vehiculo Eliminado es:  " + vehiculo2.Marca);
                            }
                            else
                            {
                                Console.WriteLine("¡¡ No se Encontro el ID de su Vehiculo!!");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: El numero ingresado no es Valido");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el ID del Vehiculo Que Quiere Actualizar");
                        try
                        {
                            int EditarId = int.Parse(Console.ReadLine());
                            Datos vehiculo3 = lista.Find(v => v.Id == EditarId);
                            if (vehiculo3 != null)
                            {
                                Console.WriteLine("Ingrese el Nuevo Nombre");
                                vehiculo3.Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el Nuevo Cilindraje del motor");
                                vehiculo3.Motor = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese la Nueva Cantidad de ruedas");
                                vehiculo3.Ruedas = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese la Nueva marca");
                                vehiculo3.Marca = Console.ReadLine();

                                Console.WriteLine("¡¡ Vehiculo Actualizado Exitosamente " +
                                    "!!");
                            }
                            else
                            {
                                Console.WriteLine("¡¡ No se Encontro el ID del Vehiculo !!");
                            }
                        }
                        catch(FormatException)
                        {
                            Console.Write("Error: El numero ue ingreso no es Valido");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("Gracias Por Utilizar Nuestros Servicios, !Vuelva Pronto!");
                        Console.ReadKey();
                        iniciar = false;
                        break;
                    default:

                        break;
                }
            }

        }
   }     
}

public class Datos
{
    public  int Id { get; set; }
    public  string Nombre { get; set; }
    public int Motor { get; set; }
    public int Ruedas { get; set; }
    public string Marca { get; set; }

    public Datos(int id, string nombre, int motor, int ruedas, string marca)
    {
        Id = id;
        Nombre = nombre;
        Motor = motor;
        Ruedas = ruedas;
        Marca = marca;
    }
}

    


    

       