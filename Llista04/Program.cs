using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Llista04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fitxer = "Llibres.txt";

            Llibres.Separar(fitxer);
            Llibres.Biblioteca = Llibres.Llegeix(fitxer);

            int opcio;
            bool sortir = false;

            while (!sortir)
            {
                Console.Clear();

                Console.WriteLine("Gestió de la Biblioteca Digital Hispanica\n");
                Console.WriteLine("1. Desa Biblioteca en Fitxer CSV.");
                Console.WriteLine("2. Afegir un llibre.");
                Console.WriteLine("3. Elimina llibre.");
                Console.WriteLine("4. Elimina llibre per posició.");
                Console.WriteLine("5. Llista Països de Procedència Diferents.");
                Console.WriteLine("6. Llista Llibres per País.");
                Console.WriteLine("7. Llista Idiomes Diferents.");
                Console.WriteLine("8. Llista Llibres per Idioma.");
                Console.WriteLine("9. Llista Dades d'un Llibre per IdBNE.");
                Console.WriteLine("10. Llista Llibre per Posicio.");
                Console.WriteLine("11. Llista Llibres per Rang de Posicions.");
                Console.WriteLine("12. Sortir.");
                Console.Write("\nSeleccioneu una opció: ");
                opcio = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (opcio)
                {
                    case 1:
                        Console.WriteLine("Introdueix nom arxiu: ");
                        fitxer = Console.ReadLine();
                        Llibres.Desa(fitxer);
                        break;
                    case 2:
                        Llibres llibre = Llibres.OmpleLlibre();
                        Llibres.AltaLlibre(llibre);
                        break;
                    case 3:
                        Console.WriteLine("Introdueix idBNE: ");
                        string idBNE = Console.ReadLine();
                        Llibres.EliminaLlibre(idBNE);
                        break;
                    case 4:
                        Console.WriteLine("Introdueix posició: ");
                        int posició = Convert.ToInt32(Console.ReadLine());
                        Llibres.EliminaPosicio(posició);
                        break;
                    case 5:
                        Llibres.LlistaPaisos();
                        break;
                    case 6:
                        Console.WriteLine("Introdueix país: ");
                        string pais = Console.ReadLine();
                        Llibres.LlistaPais(pais);
                        break;
                    case 7:
                        Llibres.LlistaIdiomes();
                        break;
                    case 8:
                        Console.WriteLine("Introdueix idioma: ");
                        string idioma = Console.ReadLine();
                        Llibres.LlistaIdioma(idioma);
                        break;
                    case 9:
                        Console.WriteLine("Introdueix idBNE: ");
                        idBNE = Console.ReadLine();
                        Llibres.LlistaLlibre(idBNE);
                        break;
                    case 10:
                        Console.WriteLine("Introdueix posició: ");
                        posició = Convert.ToInt32(Console.ReadLine());
                        Llibres.LlistaPos(posició);
                        break;
                    case 11:
                        Console.WriteLine("Introdueix posició 1: ");
                        int posició1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Introdueix posició 2: ");
                        int posició2 = Convert.ToInt32(Console.ReadLine());
                        Llibres.LlistaRang(posició1, posició2);
                        break;
                    case 12:
                        sortir = true;
                        break;
                    default:
                        Console.WriteLine("Opció no vàlida.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
            
        


