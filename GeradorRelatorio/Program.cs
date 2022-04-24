using System;

namespace GeradorRelatorio
{
    class Program
    {
        static List<ProfissionalDTO> Profissional = new List<ProfissionalDTO>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void DesserializarProfissional()
        {
             if (File.Exists("Pessoas.Json"))
            {
                using( var sr = new StreaReader("Pessoa.Json"))
                {
                    var dados = sr.ReadToend();
                    P
                }
            }
        }

    }
}
