using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcluirPastaDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            var directory = System.IO.Path.GetDirectoryName(path);

            Console.WriteLine("Listando pastas, aguarde.");

            string[] entries = Directory.GetFileSystemEntries(
                                new Uri(directory).LocalPath, "*.dll", SearchOption.AllDirectories);

            string atual = string.Empty;
            List<string> diretorios = new List<string>();

            foreach (var entry in entries)
            {
                var pt = System.IO.Path.GetDirectoryName(entry);

                if ((entry.Contains("\\bin\\Debug\\") || entry.Contains("\\obj\\Debug\\") || entry.Contains("\\obj\\Release\\"))  && !pt.Equals(atual))
                {
                    atual = pt;
                    Console.WriteLine(pt);
                    diretorios.Add(pt);  
                }
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Precione 's' para excluir os diretórios");

            var resposta = Console.ReadKey().KeyChar;

            if (resposta.Equals('s'))
            {
                Console.WriteLine("Excluindo...");
                foreach (var diretorio in diretorios)
                {
                    if (Directory.Exists(diretorio))
                        Directory.Delete(diretorio,true);
                }
            }
            else { Console.WriteLine("##  Abortado  ##"); }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Finalizado, pressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}
