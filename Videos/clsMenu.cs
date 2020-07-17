using System;
using System.Collections.Generic;
using System.Text;

namespace Videos
{
    class clsMenu
    {
        public static int options(int menu)
        {
            int option = 0;
                Console.Clear();
                Console.WriteLine("Menu de opciones: \n\nPulse la opción deseada:\n\n");
                Console.WriteLine("1. Crear Usuario");
                if (menu == 2) Console.WriteLine("2. Login\n4. Listar Usuarios\n0. Salir");
                if (menu == 3) Console.WriteLine("2. ReLogin\n3. Crear Video\n4. Listar Usuarios\n5. Listar Videos\n0. Salir");
            try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    option = 0;
                }
            return option;
        }

    }
}
