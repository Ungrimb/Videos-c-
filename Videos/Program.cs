using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Videos
{
    class Program
    {
        static void Main(string[] args)
        {
            int intento = 1,idUser=0;
            string nom, cognom, password, data,url,titol,tag;
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
                            Console.WriteLine("Tag :");
                            tag = Console.ReadLine();
                            tags.Add(tag);
                            video video = new video(login.idUsuari, url, titol, tags);
                            videos.Add(video);
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
