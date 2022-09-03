using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuApp
{
    internal class Moldura
    {
        public static void bordas()
        {
            Console.SetWindowSize(104, 38);
            //Moldura da tela
            int i, j;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ");
            for (i = 0; i < 102; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine(" ");

            for (j = 0; j < 35; j++)
            {
                Console.Write("|");
                for (i = 0; i < 102; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }

            Console.Write(" ");
            for (i = 0; i < 102; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine(" ");

            Console.SetCursorPosition(2, 35);
            Console.Write("Formulário de Usuário");
            Console.SetCursorPosition(43, 0);
            Console.Write("CADASTRO DE USUÁRIOS");
        }
        
    }
}
