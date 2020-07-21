using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Videos
{
    enum status { Ejecutandose, Parado, Pausado };
    class Program
    {
        static void Main(string[] args)
        {
            int intento = 1,idUser=0,idVideo=0;
            string nom, cognom, password, data,url,titol,tag;
            List<List<String>> tagsList = new List<List<string>>();
            List<string> tags = new List<string>();
            List<Usuari> usuaris = new List<Usuari>();
            List<video> videos = new List<video>();
            Usuari login=new Usuari(0,"","","","");

            int option = clsMenu.options(intento);
            do
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Nom del usuari :");
                        nom = Console.ReadLine();
                        Console.WriteLine("Cognom :");
                        cognom = Console.ReadLine();
                        Console.WriteLine("Password :");
                        password = Console.ReadLine();
                        DateTime thisDay = DateTime.Today;
                        data = thisDay.ToString();
                        Usuari user = new Usuari(idUser, nom, cognom, password, data);
                        usuaris.Add(user);
                        idUser++;
                        if (intento==1) intento++;
                        break;
                    case 2:
                        if (intento == 1) Console.WriteLine("Opción no habilitada");
                        else
                        {
                            int error = 0;
                            bool isCorrect = false;
                            do
                            {
                                Console.WriteLine("Nom del usuari :");
                                nom = Console.ReadLine();
                                Console.WriteLine("Password :");
                                password = Console.ReadLine();
                                foreach (var u in usuaris)
                                {
                                    if (u.nom == nom && u.password == password)
                                    {
                                        isCorrect = true;
                                        login.idUsuari = u.idUsuari;
                                        login.nom = u.nom;
                                        login.cognom = u.cognom;
                                        login.password = u.password;
                                        login.data = u.data;
                                        Console.WriteLine(login);
                                    }
                                }
                                if (!isCorrect)
                                {
                                    Console.WriteLine("Usuari o passwords incorrectes");
                                    error++;
                                }
                            } while (error < 3 && isCorrect == false);
                            if (error == 3) Console.WriteLine("Mases intents");
                            else if (isCorrect) intento = 3;
                        }
                        break;
                    case 3:
                        if (intento < 2) Console.WriteLine("Opción no habilitada");
                        else
                        {
                            Console.WriteLine("URL del video :");
                            url = Console.ReadLine();
                            Console.WriteLine("Titol del video :");
                            titol = Console.ReadLine();
                            Console.WriteLine("Tags (separar per ,) :");
                            tag = Console.ReadLine();
                            String pattern = @",";
                            String[] elements = System.Text.RegularExpressions.Regex.Split(tag, pattern);
                            //tagsList.Add(new List<string>() { "" });
                            tags.Clear();
                            foreach (var element in elements)
                                tags.Add(element);
                            tagsList.Add(new List<string>(tags));
                            videos.Add(login.CreateVideo(url, titol, tagsList[idVideo], 1));
                            idVideo++;
                        }
                            break;
                    case 4:
                        if (intento < 1) Console.WriteLine("Opción no habilitada");
                        else
                        {
                            foreach (var u in usuaris)
                            {
                                Console.WriteLine(u);
                            }
                            Console.WriteLine("Pulsa una tecla per continuar");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        if (intento < 2) Console.WriteLine("Opción no habilitada");
                        else
                        {
                            foreach (var v in videos)
                            {
                                if (v.IdUsuari == login.idUsuari) Console.WriteLine(v);
                            }
                            Console.WriteLine("Pulsa una tecla per continuar");
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        
                        if (intento < 2) Console.WriteLine("Opción no habilitada");
                        else
                        {
                            video vResult = videos[idVideo - 1];
                            bool isFind = false;
                            int option2;
                            
                            Console.Clear();
                            foreach (var v in videos)
                            {
                                if (v.IdUsuari == login.idUsuari) Console.WriteLine(v);
                            }
                            Console.WriteLine("Inserte nombre video que desea modificar");
                            string nombre = Console.ReadLine();
                            foreach (var v in videos)
                            {
                                if (v.Titol == nombre)
                                {
                                    vResult = v;
                                    isFind = true;
                                } 
                            }
                            if (!isFind)
                                {
                                    Console.WriteLine("Video no encontrado");
                                    break;
                                }
                            
                            do
                            {
                                Console.Clear();
                                if (vResult.Status==1) Console.WriteLine("Video Parado");
                                if (vResult.Status == 2) Console.WriteLine("Video Ejecutándose");
                                if (vResult.Status == 3) Console.WriteLine("Video en Pausa");
                                
                                Console.WriteLine("Menu de opciones: \n\nPulse la opción deseada:\n\n");
                                Console.WriteLine("1. Añadir Tags\n2. Play\n3. Stop\n4. Pause\n0. Volver");
                                try
                                {
                                    option2 = int.Parse(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    option2 = 0;
                                }
                                switch (option2)
                                {
                                    case 1:
                                        Console.WriteLine(" Introduce nuevos tags a añadir (separar per , ) :");
                                        tag = Console.ReadLine();
                                        String pattern = @",";
                                        String[] elements = System.Text.RegularExpressions.Regex.Split(tag, pattern);
                                        foreach (var element in elements)
                                            vResult.Tags.Add(element);
                                        break;
                                    case 2:
                                        if (vResult.Status == 2)
                                        {
                                            Console.WriteLine("Ya estaba ejecutándose");
                                            Console.ReadKey();
                                        }
                                        else vResult.Status = 2;
                                        break;
                                    case 3:
                                        if (vResult.Status == 1)
                                        {
                                            Console.WriteLine("Ya estaba parado");
                                            Console.ReadKey();
                                        }
                                        else vResult.Status = 1;
                                        break;
                                    case 4:
                                        if (vResult.Status == 1)
                                        {
                                            Console.WriteLine("Ya estaba parado");
                                            Console.ReadKey();
                                        }
                                        if (vResult.Status == 3)
                                        {
                                            Console.WriteLine("Ya estaba en pausa");
                                            Console.ReadKey();
                                        }
                                        vResult.Status = 3;
                                        break;
                                }
                            } while (option2 > 0);
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opción no habilitada");
                        break;
                }
                option = clsMenu.options(intento);
            } while (option > 0);
            
        }
    }
}
