using System;
using System.IO;
using System.Text;

namespace Dissident_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string passPhrase = "";
            string saltValue = "Th3r35N0Kn0w13d63Th4tI5N0P0w3r";
            string hashAlgorithm = "SHA1";
            int passwordIterations = 2;
            string initVector = "NTHGHTDYGDCRTDTR";
            int keySize = 256;

            string opcion = "";
            string directorioLocal = System.IO.Directory.GetCurrentDirectory();
            string[] listaArchivos = Directory.GetFiles(directorioLocal, "*.kdp");
            string nombreArchivo = "";
            string tituloArchivo = "";
            string tituloArchivoEncriptado = "";
            string contenidoArchivo = "";
            string contenidoArchivoDesencriptado = "";
            string passwordArchivo = "";

            int contadorArchivos = 0;

            Console.Title = "Dissident Project 1.0 por Kuraimauri - http://kmplayground.blogspot.com";
            Auxiliar.mostrar_cabecera("Inicio - Encriptador Dissident Project 1.0");
            Console.Write("Password: ");
            Console.ForegroundColor = ConsoleColor.Black;
            passPhrase = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;

            while (true)
            {
                //código de las opciones del menu
                switch (opcion)
                {
                    case "1":
                        //desencriptar archivo
                        Console.Clear();
                        Auxiliar.mostrar_cabecera("Abrir archivo - Encriptador Dissident Project 1.0");
                        Console.Write("Nombre de archivo: ");
                        tituloArchivo = Console.ReadLine();
                        tituloArchivoEncriptado = RijndaelSimple.Encrypt(tituloArchivo,
                                                            passPhrase,
                                                            saltValue,
                                                            hashAlgorithm,
                                                            passwordIterations,
                                                            initVector,
                                                            keySize);
                        try
                        {
                            StreamReader archivoleido = new StreamReader(directorioLocal + "\\" + tituloArchivoEncriptado + ".kdp");
                            contenidoArchivoDesencriptado = RijndaelSimple.Decrypt(archivoleido.ReadLine(),
                                                                passPhrase,
                                                                saltValue,
                                                                hashAlgorithm,
                                                                passwordIterations,
                                                                initVector,
                                                                keySize);
                            Console.WriteLine(contenidoArchivoDesencriptado);
                            archivoleido.Close();
                        }
                        catch (Exception ex)
                        {

                        }
                        Console.WriteLine("\nOperacion concluida. Cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        break;
                    case "2":
                        //nuevo archivo encriptado
                        Console.Clear();
                        Auxiliar.mostrar_cabecera("Crear archivo - Encriptador Dissident Project 1.0");
                        Console.Write("Nombre de archivo: ");
                        tituloArchivo = Console.ReadLine();
                        Console.Write("Password: ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        passwordArchivo = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Contenido: ");
                        contenidoArchivo = Console.ReadLine();
                        tituloArchivoEncriptado = RijndaelSimple.Encrypt(tituloArchivo,
                                                            passwordArchivo,
                                                            saltValue,
                                                            hashAlgorithm,
                                                            passwordIterations,
                                                            initVector,
                                                            keySize);
                        if (!File.Exists(directorioLocal + "\\" + tituloArchivoEncriptado + ".kdp"))
                        {
                            StreamWriter archivoCreado;
                            try
                            {
                                archivoCreado = File.CreateText(directorioLocal + "\\" + tituloArchivoEncriptado + ".kdp");
                                archivoCreado.Write(RijndaelSimple.Encrypt(contenidoArchivo,
                                                                    passwordArchivo,
                                                                    saltValue,
                                                                    hashAlgorithm,
                                                                    passwordIterations,
                                                                    initVector,
                                                                    keySize));
                                archivoCreado.Close();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\nEl archivo no pudo ser creado. Falló la encriptación.");
                            }
                        }
                        else
                        {
                            //No se informa de nada pero no se efectuan cambios.
                            Console.WriteLine("\nEl archivo no pudo ser creado. Falló la encriptación.");
                        }
                        Console.WriteLine("\nOperacion concluida. Cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        break;
                    case "3":
                        //listar archivos
                        Console.Clear();
                        Auxiliar.mostrar_cabecera("Lista de archivos - Encriptador Dissident Project 1.0");
                        listaArchivos = Directory.GetFiles(directorioLocal, "*.kdp");
                        listaArchivos = RandomStringArrayTool.RandomizeStrings(listaArchivos);
                        contadorArchivos = 0;
                        foreach (string archivo in listaArchivos)
                        {
                            contadorArchivos++;
                            nombreArchivo = archivo.Substring(directorioLocal.Length + 1);
                            nombreArchivo = nombreArchivo.Remove(nombreArchivo.Length - 4, 4);
                            try
                            {
                                nombreArchivo = RijndaelSimple.Decrypt(nombreArchivo,
                                                                passPhrase,
                                                                saltValue,
                                                                hashAlgorithm,
                                                                passwordIterations,
                                                                initVector,
                                                                keySize);
                                if (contadorArchivos < 10) Console.Write("0");
                                Console.WriteLine(contadorArchivos.ToString() + " - " + nombreArchivo);
                            }
                            catch (Exception ex)
                            {
                                if (contadorArchivos < 10) Console.Write("0");
                                Console.WriteLine(contadorArchivos.ToString() + " - XXXXXXXXXXXXXXXXXXXXXXXX");
                            }
                            if ((contadorArchivos % 20 == 0)&&(listaArchivos.Length != contadorArchivos))
                            {
                                Console.WriteLine("\nCualquier tecla para visualizar más archivos...");
                                Console.ReadKey();
                                Console.Clear();
                                Auxiliar.mostrar_cabecera("Lista de archivos - Encriptador Dissident Project 1.0");
                            }
                        }
                        Console.WriteLine("\nOperacion concluida. Cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        break;
                    case "4":
                        //cambiar entre passwords
                        Console.Clear();
                        Auxiliar.mostrar_cabecera("Cambiar entre passwords - Encriptador Dissident Project 1.0");
                        Console.Write("Password: ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        passPhrase = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "5":
                        //mostrar la ayuda
                        Console.Clear();
                        Auxiliar.mostrar_cabecera("Ayuda - Encriptador Dissident Project 1.0");
                        Auxiliar.mostrar_ayuda();
                        Console.WriteLine("\nOperacion concluida. Cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        break;
                    case "6":
                        //mostrar el acerca de
                        Console.Clear();
                        Auxiliar.mostrar_cabecera("Acerca de este programa - Encriptador Dissident Project 1.0");
                        Auxiliar.mostrar_nota();
                        Console.WriteLine("\nOperacion concluida. Cualquier tecla para regresar al menu.");
                        Console.ReadKey();
                        break;
                    case "7":
                        //salir
                        return;
                }
                Console.Clear();
                int a = 15;
                int b = 3;
                
                Auxiliar.mostrar_cabecera("Menu principal - Encriptador Dissident Project 1.0");
                Console.WriteLine("1 - Desencriptar archivo");
                Console.WriteLine("2 - Nuevo archivo encriptado");
                Console.WriteLine("3 - Listar archivos");
                Console.WriteLine("4 - Cambiar entre passwords");
                Console.WriteLine("5 - Ayuda");
                Console.WriteLine("6 - Acerca de este programa");
                Console.WriteLine("7 - Salir");
                Console.WriteLine(--b * a++ / b);
                Console.Write("\nOpción: ");
                opcion = Console.ReadLine();

            }
        }
    }
}
