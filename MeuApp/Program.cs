using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MeuApp;
namespace MeuApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Moldura.bordas();

            //Nome
            Console.SetCursorPosition(30, 10);
            Console.Write("Nome completo: ");
            Usuario usuario = new Usuario();
            usuario.Nomes = Console.ReadLine();

            //E-mail

            Console.SetCursorPosition(30, 12);
            Console.Write("E-mail: ");
            Usuario email = new Usuario();
            email.Email = Console.ReadLine();

            //Nome da Conta

            Console.SetCursorPosition(30, 14);
            Console.Write("Nome da sua Conta: ");
            Usuario conta = new Usuario();
            conta.Conta = Console.ReadLine();

            //Senha

            Console.SetCursorPosition(30, 16);
            Console.Write("Senha: ");
            Usuario senha = new Usuario();
            senha.Senha = Console.ReadLine();


        //Status da conta Ativo?
            volta:
            Console.SetCursorPosition(30, 18);
            Console.WriteLine("Usuário Ativo:");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine("1 - Sim");
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("0 - Não");
            Console.SetCursorPosition(45, 20);
            Console.Write("[ ]");
            Console.SetCursorPosition(46, 20);

            Usuario status = new Usuario();
            status.Status = 0;

            ConsoleKeyInfo cki;
            bool contLoop = true;
            while (contLoop)
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.NumPad1:
                            {
                                status.Status = 1;
                                Console.SetCursorPosition(46, 20);
                                Console.Write(status.Status);
                                goto continua;
                            }
                        case ConsoleKey.NumPad0:
                            {
                                status.Status = 0;
                                Console.SetCursorPosition(46, 20);
                                Console.Write(status.Status);
                                goto continua;
                            }
                        default:
                            {
                                Console.SetCursorPosition(49, 20);
                                Console.Write("Número inválido");
                                Console.ReadKey();
                                Console.SetCursorPosition(49, 20);
                                Console.Write("                 ");
                                Console.SetCursorPosition(46, 20);
                                goto volta;
                            }
                    }
                }
        continua:

        volta2:
            //Nivel
            Console.SetCursorPosition(30, 22);
            Console.Write("Digite o nível de acesso:");
            Console.SetCursorPosition(30, 23);
            Console.Write("1 - Administrador");
            Console.SetCursorPosition(30, 24);
            Console.WriteLine("2 - Coordenador");
            Console.SetCursorPosition(30, 25);
            Console.Write("3 - Professor");
            Console.SetCursorPosition(45, 25);
            Console.Write("[ ]");
            Console.SetCursorPosition(46, 25);

            Usuario nivel = new Usuario();
            nivel.Nivel = 0;

            ConsoleKeyInfo cki2;
            bool contLoop2 = true;
            while (contLoop2)
                if (Console.KeyAvailable)
                {
                    cki2 = Console.ReadKey(true);
                    switch (cki2.Key)
                    {
                        case ConsoleKey.NumPad1:
                            {
                                nivel.Nivel = 1;
                                Console.SetCursorPosition(46, 25);
                                Console.Write(nivel.Nivel);
                                goto continua2;
                            }
                        case ConsoleKey.NumPad2:
                            {
                                nivel.Nivel = 2;
                                Console.SetCursorPosition(46, 25);
                                Console.Write(nivel.Nivel);
                                goto continua2;
                            }
                        case ConsoleKey.NumPad3:
                            {
                                nivel.Nivel = 3;
                                Console.SetCursorPosition(46, 25);
                                Console.Write(nivel.Nivel);
                                goto continua2;
                            }
                        default:
                            {
                                Console.SetCursorPosition(49, 25);
                                Console.Write("Número inválido");
                                Console.ReadKey();
                                Console.SetCursorPosition(49, 25);
                                Console.Write("                 ");
                                Console.SetCursorPosition(46, 25);
                                goto volta2;
                            }
                    }
                }
        continua2:
            Console.SetCursorPosition(30, 28);
            Usuario data = new Usuario();
            data.Datacad = DateTime.Now;
            Console.Write("Data de cadastro é: " + data.Datacad);

            Console.SetCursorPosition(65, 35);
            Console.Write("Deseja salvar o Cadastro (S/N): ");

            //consulta de teclas nesse caso para (S/N)
            ConsoleKeyInfo cke;
            bool continuarLoop = true;
            while (continuarLoop)
                if (Console.KeyAvailable)
                {
                    cke = Console.ReadKey(true);
                    switch (cke.Key)
                    {
                        case ConsoleKey.S:
                            try
                            {
                                string StrCon = @"Data Source=NOTE-JEREMIAS\SQLEXPRESS;Initial Catalog=cadastro;Integrated Security=True";
                                SqlConnection cn = new SqlConnection(StrCon);
                                cn.Open();

                                string query = "INSERT INTO usuarios (nome, email, conta, senha, estatus, nivel, datacad) VALUES(@nome, @email, @conta, @senha, @estatus, @nivel, @datacad)";
                                SqlCommand command = new SqlCommand(query, cn);

                                command.Parameters.AddWithValue("@nome", usuario.Nomes);
                                command.Parameters.AddWithValue("@email", email.Email);
                                command.Parameters.AddWithValue("@conta", conta.Conta);
                                command.Parameters.AddWithValue("@senha", senha.Senha);
                                command.Parameters.AddWithValue("@estatus", status.Status);
                                command.Parameters.AddWithValue("@nivel", nivel.Nivel);
                                command.Parameters.AddWithValue("@datacad", data.Datacad);

                                command.ExecuteNonQuery();
                                Console.SetCursorPosition(2, 34);
                                Console.WriteLine("Dados salvos com SUCESSO!!!");

                                cn.Close();
                                Environment.Exit(0);
                            }
                            catch (Exception ex)
                            {
                                Console.SetCursorPosition(2, 34);
                                Console.WriteLine("Falha ao tentar se conectar: " + ex.Message);
                                Console.ReadLine();
                                Environment.Exit(0);
                            }


                            break;

                        case ConsoleKey.N:
                            continuarLoop = false;
                            Environment.Exit(0);
                            break;
                    }
                }

            Console.ReadKey();


        }
    }
}
