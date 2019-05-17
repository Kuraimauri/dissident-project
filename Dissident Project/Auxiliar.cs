using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dissident_Project
{
    public static class Auxiliar
    {
        public static void mostrar_cabecera(string titulo)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan; Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(titulo);
            for (int i = 0; i < 80 - titulo.Length; i++)
            {
                Console.Write(" ");
            }
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void mostrar_ayuda()
        {
            Console.WriteLine("Encriptador Dissident Project 1.0");
            Console.WriteLine("Por Kuraimauri, Abril 22 de 2011");
            Console.WriteLine("http://kmplayground.blogspot.com");
            Console.WriteLine("\nEste programa es bastante fácil de manejar. Al inicio se ingresa un password. Este password permitirá el acceso a los archivos que hayan sido creados con ese password.\nLa opción 1 sirve para visualizar archivos. Si se escribe bien el nombre y se ha ingresado con el password correcto el archivo aparecerá. Los nombres de archivo y los passwords distinguen entre mayúsculas y minúsculas. Si hay un fallo en el nombre de archivo o password no se notificará nada. Esto es con el fin de no dar pistas acerca de que fue lo que falló, ya que si por ejemplo se notificara que el password es incorrecto entonces podrían adivinar que un archivo con ese nombre existe, por ejemplo, lo cual es inconveniente.");
            Console.WriteLine("\nCualquier tecla para visualizar más...");
            Console.ReadKey();
            Console.Clear();
            Auxiliar.mostrar_cabecera("Ayuda - Encriptador Dissident Project 1.0");
            Console.WriteLine("La opción 2 sirve para crear archivos. Se ingresa un nombre, un password que puede ser distinto al que uno ingresó arriba, y el contenido, que debe ser de una sola línea y máximo 252 caracteres. Es más que los 140 caracteres de Twitter y más que suficiente. Este no es el programa si quieren encriptar el último libro de su escritor favorito. Si por algún motivo no se puede realizar la encriptación el programa lo notificará pero por seguridad no indicará el motivo, a menudo los fallos se producen porque ya existe un archivo con ese mismo nombre y password o porque se ingresaron caracteres que Windows no permite en los nombres de archivos o porque se usaron caracteres del latín extendido tales como á,ñ,ß,ö, etc. Recomiendo no usarlos. Así mismo, recomiendo no grabar archivos con el mismo password con el que se ha ingresado a la aplicación ya que quedarían visibles automáticamente en la lista de archivos y uno podría dejar por error el programa abierto y otro podría mirar los nombres de los archivos y desencriptarlos. Se puede ingresar con un password y grabar el archivo con otro y usar el password correcto solo para mirar el archivo y salir.");
            Console.WriteLine("\nCualquier tecla para visualizar más...");
            Console.ReadKey();
            Console.Clear();
            Auxiliar.mostrar_cabecera("Ayuda - Encriptador Dissident Project 1.0");
            Console.WriteLine("La opción 3 muestra los archivos que se encuentran disponibles para el password con el que se ha ingresado. El orden en el que se muestran los archivos se cambia cada vez que se muestran de modo aleatorio, así nadie puede adivinar a cual de los archivos externos corresponde cada mensaje encriptado usando el ordenamiento de sus metadatos, ni siquiera el dueño de los archivos. Obviamente, no puede ofrecerse ninguna seguridad sobre los archivos en si, estos pueden ser borrados o dañados desde un editor de texto, la información se perderá pero no podrán saber que contenían los archivos.\nEl sistema para ver los archivos es bastante simple, no contiene opciones para buscar o para abrir los archivos directamente desde acá, asi que yo recomendaría guardar relativamente pocos registros importantes si no se van a recordar los nombres de los archivos u otro programa más avanzado para los que quieran encriptar todos los versos de la biblia.");
            Console.WriteLine("\nCualquier tecla para visualizar más...");
            Console.ReadKey();
            Console.Clear();
            Auxiliar.mostrar_cabecera("Ayuda - Encriptador Dissident Project 1.0");
            Console.WriteLine("La opción 4 permite cambiar el password con el que se estan desencriptando los archivos, para poder visualizar los archivos almacenados con otro password. Bastante evidente. Fin de la ayuda.");
        }

        public static void mostrar_nota()
        {
            Console.WriteLine("Encriptador Dissident Project 1.0");
            Console.WriteLine("Por Kuraimauri, Abril 22 de 2011");
            Console.WriteLine("http://kmplayground.blogspot.com");
            Console.WriteLine("\nProgramé este encriptador con el objetivo de hacerlo lo más sencillo posible. No tiene todas esas opciones técnicamente impresionantes de selección de métodos de encriptación inpronunciables ni esconderá la ISO del último Call of Duty pirata. Solo sirve para esconder mensajes sencillos de no más de 252 bytes. Pero lo que hace lo hace muy bien.");
            Console.WriteLine("Creé este programa con el fin de almacenar mis passwords de un modo seguro dentro de mi memoria flash USB y poder llevarlos para cualquier parte, ya que hoy por hoy los tengo escritos en un archivo de texto, lo cual no es una muy buena práctica que digamos. Pero se puede usar para almacenar cualquier tipo de mensajes.");
            Console.WriteLine("Compartir mensajes es tan simple como grabar una carpeta con la aplicación y los archivos y darle a alguien más el password para abrirlos, incluso si alguien más tiene acceso a la carpeta y ha grabado allí sus propios mensajes, solo podrá ver los que le interesan a el, ya que cada archivo tiene un password distinto. ");
            Console.WriteLine("\nCualquier tecla para visualizar más...");
            Console.ReadKey();
            Console.Clear();
            Auxiliar.mostrar_cabecera("Acerca de este programa - Encriptador Dissident Project 1.0");
            Console.WriteLine("\nTambién pueden usar esto para hacer un diario personal, para grabar los passwords de los correos electrónicos, o lo que quieran, ustedes serán más creativos que yo. Y no se preocupen, sus archivos están más que seguros. Ni siquiera yo que programé esto podría ver los archivos pues no hay ningun password maestro o cosas por el estilo.");
            Console.WriteLine("El como se hace la compresión es obviamente un secreto, pero les puedo decir que sus passwords no están grabados en ninguna parte, y que más bien estos son parte de los varios vectores de bytes que se usan en la compresión. Tristemente esto también hace que si se te olvida el password no exista modo de recuperar el mensaje. El algoritmo hace que los mensajes sean absolutamente indescifrables!");
            Console.WriteLine("Si algún día algún explorador de la red llega a este programa, tengo que decirle que no puedo prestar asistencia técnica ni puedo responder por archivos inutilizables por pérdidas de passwords. Tampoco puedo responder por acciones criminales que se ejecuten usando este programa. Cada cual es responsable de lo que haga con el.");
            Console.WriteLine("\nNo siendo más, muchas gracias por usar el encriptador Dissident y buena suerte!");
            Console.WriteLine("Kuraimauri.");
        }
    }
}
