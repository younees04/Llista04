using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Llista04
{
    public class Llibres
    {
        public string IdBNE { get; set; }
        public List<string> AutorPersones { get; set; }
        public List<string> AutorEntitats { get; set; }
        public string Titol { get; set; }
        public string Descripcio { get; set; }
        public string Genere { get; set; }
        public string DipositLegal { get; set; }
        public string Pais { get; set; }
        public string Idioma { get; set; }
        public string VersioDigital { get; set; }
        public string TextOCR { get; set; }
        public string ISBN { get; set; }
        public string Tema { get; set; }
        public string Editorial { get; set; }
        public string LlocPublicacio { get; set; }

        // Constructor
        public Llibres(string idBNE, List<string> autorPersones, List<string> autorEntitats, string titol, string descripcio, string genere, string dipositLegal, string pais, string idioma, string versioDigital, string textOCR, string iSBN, string tema, string editorial, string llocPublicacio)
        {
            this.IdBNE = idBNE;
            this.AutorPersones = autorPersones;
            this.AutorEntitats = autorEntitats;
            this.Titol = titol;
            this.Descripcio = descripcio;
            this.Genere = genere;
            this.DipositLegal = dipositLegal;
            this.Pais = pais;
            this.Idioma = idioma;
            this.VersioDigital = versioDigital;
            this.TextOCR = textOCR;
            this.ISBN = iSBN;
            this.Tema = tema;
            this.Editorial = editorial;
            this.LlocPublicacio = llocPublicacio;
        }

        public static List<Llibres> Biblioteca = new List<Llibres>();

        public static List<string> Separar(string s)
        {
            List<string> Separat = new List<string>();

            string[] strings = s.Split("//".ToCharArray());

            foreach (string str in strings)
            {
                Separat.Add(str);
            }

            return Separat;
        }

        public static Llibres Converteix(string s)
        {
            string[] camp = s.Split(";".ToCharArray());

            string idBNE = camp[0];
            List<string> AutorPersones = Separar(camp[1]);
            List<string> AutorEntitats = Separar(camp[2]);
            string Titol = camp[3];
            string Descripcio = camp[4];
            string Genere = camp[5];
            string DipositLegal = camp[6];
            string Pais = camp[7];
            string Idioma = camp[8];
            string VersioDigital = camp[9];
            string TextOCR = camp[10];
            string ISBN = camp[11];
            string tema = camp[12];
            string Editorial = camp[13];
            string LlocPublicacio = camp[14];

            Llibres Llibre = new Llibres(idBNE, AutorPersones, AutorEntitats, Titol, Descripcio, Genere, DipositLegal, Pais, Idioma, VersioDigital, TextOCR, ISBN, tema, Editorial, LlocPublicacio);

            return Llibre;
        }

        public static List<Llibres> Llegeix(string fitxer)
        {
            List<Llibres> llibre = new List<Llibres>();

            try
            {
                using (StreamReader srLlibres = new StreamReader(fitxer))
                {
                    string linia;

                    while ((linia = srLlibres.ReadLine()) != null)
                    {
                        Llibres llibres = Converteix(linia);
                        llibre.Add(llibres);
                    }
                }
            }
            catch
            {
                throw new Exception("L'arxiu no existeix o no es pot llegir");
            }

            return llibre;
        }

        public static void Desa(string fitxer)
        {

            string format = ".csv";

            fitxer = fitxer + format;

            try
            {

                using (StreamWriter swLlibre = new StreamWriter(fitxer))
                {
                    foreach (Llibres llibre in Biblioteca)
                    {
                        swLlibre.WriteLine(llibre.ToString());
                    }
                }

                Console.WriteLine("Archivo guardado con exito");
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


        public static Llibres OmpleLlibre()
        {
            Console.WriteLine("Escriu les dades del llibre: ");
            Console.WriteLine("Escriu el IdBNE: ");
            string idBNE = Console.ReadLine();

            Console.WriteLine("Escriu el AutorPersones: ");
            string AutorPersones = Console.ReadLine();

            Console.WriteLine("Escriu el AutorEntitats: ");
            string AutorEntitats = Console.ReadLine();

            Console.WriteLine("Escriu el Titol: ");
            string Titol = Console.ReadLine();

            Console.WriteLine("Escriu el Descripcio: ");
            string Descripcio = Console.ReadLine();

            Console.WriteLine("Escriu el Genere: ");
            string Genere = Console.ReadLine();

            Console.WriteLine("Escriu el DipositLegal: ");
            string DipositLegal = Console.ReadLine();

            Console.WriteLine("Escriu el Pais: ");
            string Pais = Console.ReadLine();

            Console.WriteLine("Escriu el Idioma: ");
            string Idioma = Console.ReadLine();

            Console.WriteLine("Escriu el VersioDigital: ");
            string VersioDigital = Console.ReadLine();

            Console.WriteLine("Escriu el TextOCR: ");
            string TextOCR = Console.ReadLine();

            Console.WriteLine("Escriu el ISBN: ");
            string ISBN = Console.ReadLine();

            Console.WriteLine("Escriu el Tema: ");
            string Tema = Console.ReadLine();

            Console.WriteLine("Escriu el Editorial: ");
            string Editorial = Console.ReadLine();

            Console.WriteLine("Escriu el LlocPublicacio: ");
            string LlocPublicacio = Console.ReadLine();

            Llibres llibre = new Llibres(idBNE, Separar(AutorPersones), Separar(AutorEntitats), Titol, Descripcio, Genere, DipositLegal, Pais,
                Idioma, VersioDigital, TextOCR, ISBN, Tema, Editorial, LlocPublicacio);

            return llibre;

        }

        public static void AltaLlibre(Llibres llibre)
        {
            Llibres llibreExist = null;

            // Cerca si ja existeix un llibre a la biblioteca amb el mateix IdBNE que el llibre que volem afegir o actualitzar.
            foreach (var existingLlibre in Biblioteca)
            {
                if (existingLlibre.IdBNE == llibre.IdBNE)
                {
                    llibreExist = existingLlibre;
                    break;
                }
            }

            if (llibreExist == null)
            {
                Biblioteca.Add(llibre);
                Console.WriteLine($"El llibre amb IdBNE {llibre.IdBNE} s'ha afegit a la biblioteca.");
            }
            else
            {
                llibreExist.AutorPersones = llibre.AutorPersones;
                llibreExist.AutorEntitats = llibre.AutorEntitats;
                llibreExist.Titol = llibre.Titol;
                llibreExist.Descripcio = llibre.Descripcio;
                llibreExist.Genere = llibre.Genere;
                llibreExist.DipositLegal = llibre.DipositLegal;
                llibreExist.Pais = llibre.Pais;
                llibreExist.Idioma = llibre.Idioma;
                llibreExist.VersioDigital = llibre.VersioDigital;
                llibreExist.TextOCR = llibre.TextOCR;
                llibreExist.ISBN = llibre.ISBN;
                llibreExist.Tema = llibre.Tema;
                llibreExist.Editorial = llibre.Editorial;
                llibreExist.LlocPublicacio = llibre.LlocPublicacio;

                Console.WriteLine($"Les dades del llibre amb IdBNE {llibre.IdBNE} s'han actualitzat.");
            }
        }

        public static void EliminaLlibre(string id)
        {
            bool found = false;

            try
            {
                foreach (var llibre in Biblioteca.ToList())
                {
                    if (llibre.IdBNE == id)
                    {
                        Biblioteca.Remove(llibre);
                        Console.WriteLine($"S'ha trobat i s'ha eliminat el llibre amb IdBNE: {id}");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"El llibre amb IdBNE: {id} no s'ha trobat a la biblioteca.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public static void EliminaPosicio(int pos)
        {
            if (pos >= 0 && pos < Biblioteca.Count)
            {
                Biblioteca.RemoveAt(pos);
                Console.WriteLine($"S'ha eliminat el llibre de la posició {pos} de la biblioteca.");
            }

            else
            {
                Console.WriteLine($"No s'ha trobat cap llibre a la posició {pos} de la biblioteca.");
            }
        }

        public static void LlistaPaisos()
        {
            List<string> paisos = new List<string>();

            foreach (var llibre in Biblioteca)
            {
                string pais = llibre.Pais;

                if (!paisos.Contains(pais))
                {
                    paisos.Add(pais);
                }
            }

            if (paisos.Any())
            {
                Console.WriteLine("Països de procedència diferents dels llibres a la biblioteca:\n");
                foreach (var pais in paisos)
                {
                    Console.WriteLine($" - {pais}");
                }
            }
            else
            {
                Console.WriteLine("No hi ha cap llibre a la biblioteca.");
            }
        }

        public static void LlistaPais(string pais)
        {
            bool trobat = false;
            List<Llibres> coincidits = new List<Llibres>();

            foreach (var llibre in Biblioteca)
            {
                if (llibre.Pais == pais)
                {
                    coincidits.Add(llibre);
                    trobat = true;
                }
            }

            if (trobat)
            {
                Console.WriteLine("Aquesta és la llista de llibres del país " + pais + ":\n");

                foreach (var llibre in coincidits)
                {
                    // Imprimir los detalles del libro
                    Console.WriteLine($"IdBNE: {llibre.IdBNE}");
                    Console.WriteLine($"Autors Persones: {string.Join(" // ", llibre.AutorPersones)}");
                    Console.WriteLine($"Autors Entitats: {string.Join(" // ", llibre.AutorEntitats)}");
                    Console.WriteLine($"Títol: {llibre.Titol}");
                    Console.WriteLine($"Descripció: {llibre.Descripcio}");
                    Console.WriteLine($"Gènere: {llibre.Genere}");
                    Console.WriteLine($"Dipòsit Legal: {llibre.DipositLegal}");
                    Console.WriteLine($"País: {llibre.Pais}");
                    Console.WriteLine($"Idioma: {llibre.Idioma}");
                    Console.WriteLine($"Versió Digital: {llibre.VersioDigital}");
                    Console.WriteLine($"Text OCR: {llibre.TextOCR}");
                    Console.WriteLine($"ISBN: {llibre.ISBN}");
                    Console.WriteLine($"Tema: {llibre.Tema}");
                    Console.WriteLine($"Editorial: {llibre.Editorial}");
                    Console.WriteLine($"Lloc de Publicació: {llibre.LlocPublicacio}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No s'ha trobat cap llibre del país " + pais);
            }
        }



        public static void LlistaIdiomes()
        {
            List<string> idiomes = new List<string>();

            foreach (var llibre in Biblioteca)
            {
                if (!idiomes.Contains(llibre.Idioma))
                {
                    idiomes.Add(llibre.Idioma);
                }
            }

            if (idiomes.Any())
            {
                Console.WriteLine("Idiomes diferents dels llibres a la biblioteca:");
                foreach (var idioma in idiomes)
                {
                    Console.WriteLine(idioma);
                }
            }
            else
            {
                Console.WriteLine("No hi ha cap llibre a la biblioteca.");
            }
        }

        public static void LlistaIdioma(string idiomaSelecionat)
        {
            List<Llibres> llibres = new List<Llibres>();

            foreach (var llibre in Biblioteca)
            {
                if (llibre.Idioma == idiomaSelecionat)
                {
                    llibres.Add(llibre);
                }
            }

            if (llibres.Count > 0)
            {
                Console.WriteLine($"Llibres en idioma '{idiomaSelecionat}':\n");
                foreach (var llibre in llibres)
                {
                    Console.WriteLine($"Títol: {llibre.Titol}");
                    Console.WriteLine($"Autor(s) Persones: {string.Join(", ", llibre.AutorPersones)}");
                    Console.WriteLine($"Autor(s) Entitats: {string.Join(", ", llibre.AutorEntitats)}");
                    Console.WriteLine($"Idioma: {llibre.Idioma}");
                    Console.WriteLine("=========================");
                }
            }
            else
            {
                Console.WriteLine($"No s'han trobat llibres en idioma '{idiomaSelecionat}'.");
            }
        }


        public static void LlistaLlibre(string id)
        {
            bool trobat = false;

            try
            {

                foreach (var llibre in Biblioteca)
                {
                    if (llibre.IdBNE == id)
                    {
                        Console.WriteLine($"Dades del llibre amb IdBNE {id}:\n");
                        Console.WriteLine($"IdBNE: {llibre.IdBNE}");
                        Console.WriteLine($"Autors Persones: {string.Join(" // ", llibre.AutorPersones)}");
                        Console.WriteLine($"Autors Entitats: {string.Join(" // ", llibre.AutorEntitats)}");
                        Console.WriteLine($"Títol: {llibre.Titol}");
                        Console.WriteLine($"Descripció: {llibre.Descripcio}");
                        Console.WriteLine($"Gènere: {llibre.Genere}");
                        Console.WriteLine($"Dipòsit Legal: {llibre.DipositLegal}");
                        Console.WriteLine($"País: {llibre.Pais}");
                        Console.WriteLine($"Idioma: {llibre.Idioma}");
                        Console.WriteLine($"Versió Digital: {llibre.VersioDigital}");
                        Console.WriteLine($"Text OCR: {llibre.TextOCR}");
                        Console.WriteLine($"ISBN: {llibre.ISBN}");
                        Console.WriteLine($"Tema: {llibre.Tema}");
                        Console.WriteLine($"Editorial: {llibre.Editorial}");
                        Console.WriteLine($"Lloc de Publicació: {llibre.LlocPublicacio}");
                        trobat = true;
                        break;
                    }
                }

                if (!trobat)
                {
                    Console.WriteLine($"No s'ha trobat cap llibre amb IdBNE {id} a la biblioteca.");
                }
            }

            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
        }

        public static void LlistaPos(int pos)
        {
            if(pos >= 0 &&  pos < Biblioteca.Count)
            {
                Llibres llibre = Biblioteca[pos];
                Console.WriteLine($"\nDades del llibre amb posició {pos}:\n");
                Console.WriteLine($"IdBNE: {llibre.IdBNE}");
                Console.WriteLine($"Autors Persones: {string.Join(" // ", llibre.AutorPersones)}");
                Console.WriteLine($"Autors Entitats: {string.Join(" // ", llibre.AutorEntitats)}");
                Console.WriteLine($"Títol: {llibre.Titol}");
                Console.WriteLine($"Descripció: {llibre.Descripcio}");
                Console.WriteLine($"Gènere: {llibre.Genere}");
                Console.WriteLine($"Dipòsit Legal: {llibre.DipositLegal}");
                Console.WriteLine($"País: {llibre.Pais}");
                Console.WriteLine($"Idioma: {llibre.Idioma}");
                Console.WriteLine($"Versió Digital: {llibre.VersioDigital}");
                Console.WriteLine($"Text OCR: {llibre.TextOCR}");
                Console.WriteLine($"ISBN: {llibre.ISBN}");
                Console.WriteLine($"Tema: {llibre.Tema}");
                Console.WriteLine($"Editorial: {llibre.Editorial}");
                Console.WriteLine($"Lloc de Publicació: {llibre.LlocPublicacio}");
            }

            else
            {
                Console.WriteLine($"No s'ha trobat cap llibre amb posició {pos} a la biblioteca.");
            }

        }

        public static void LlistaRang(int pos1, int pos2)
        {
            Llibres llibre1 = Biblioteca[pos1];
            Llibres llibre2 = Biblioteca[pos2];

            if(pos1 >= 0 && pos1 < Biblioteca.Count && pos2 >= 0 && pos2 < Biblioteca.Count)
            {
                for(int i = pos1; i <= pos2; i++) 
                {
                    Console.WriteLine($"\nDades del llibre amb posició {pos1} fins la posició {pos2}:\n");
                    Console.WriteLine($"IdBNE: {llibre1.IdBNE}");
                    Console.WriteLine($"Autors Persones: {string.Join(" // ", llibre1.AutorPersones)}");
                    Console.WriteLine($"Autors Entitats: {string.Join(" // ", llibre1.AutorEntitats)}");
                    Console.WriteLine($"Títol: {llibre1.Titol}");
                    Console.WriteLine($"Descripció: {llibre1.Descripcio}");
                    Console.WriteLine($"Gènere: {llibre1.Genere}");
                    Console.WriteLine($"Dipòsit Legal: {llibre1.DipositLegal}");
                    Console.WriteLine($"País: {llibre1.Pais}");
                    Console.WriteLine($"Idioma: {llibre1.Idioma}");
                    Console.WriteLine($"Versió Digital: {llibre1.VersioDigital}");
                    Console.WriteLine($"Text OCR: {llibre1.TextOCR}");
                    Console.WriteLine($"ISBN: {llibre1.ISBN}");
                    Console.WriteLine($"Tema: {llibre1.Tema}");
                    Console.WriteLine($"Editorial: {llibre1.Editorial}");
                    Console.WriteLine($"Lloc de Publicació: {llibre1.LlocPublicacio}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No ha trobat llibres en el rang especificat");
            }

        }

    }
}

