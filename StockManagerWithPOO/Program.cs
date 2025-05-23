using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerWithPOO
{
    internal class Program
    {
        static List<IEstoque> estoque = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Fechar}
        static void Main(string[] args)
        {
            Carregar();

            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("Sistema de Gerenciamento de Estoque");
                Console.WriteLine("===================================");
                Console.WriteLine("Selecione uma Opção:\n1 - Listar Estoque\n2 - Cadatrar Produto ao Estoque\n3 - Remover Produto do Estoque\n4 - Adicionar Quantidade a um Produto\n5 - Remover Quantidade de um Produto\n6 - Fechar Progama");
                Console.WriteLine("===================================");
                Console.Write("Opção Selecionada: ");
                int opcao = int.Parse(Console.ReadLine());
                Menu opcaoSelecionada = (Menu)opcao;

                switch (opcaoSelecionada)
                {
                    case Menu.Listar:
                        Listar();
                        break;

                    case Menu.Adicionar:
                        Cadastrar();
                        break;

                    case Menu.Remover:
                        Remover();
                        break;

                    case Menu.Entrada:
                        break;

                    case Menu.Saida:
                        break;

                    case Menu.Fechar:
                        break;
                }
            }

            Console.Clear();            
        }

        static void Listar()
        {
            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("       Listagem De Estoque      ");
            Console.WriteLine("================================");
            int id = 0;
            foreach(IEstoque objeto in estoque)
            {
                Console.WriteLine($"ID: {id}");
                objeto.Exibir();
                id++;
            }
            Console.ReadKey();

            Console.Clear();
        }

        static void Cadastrar()
        {
            Console.Clear();

            Console.WriteLine("===================================");
            Console.WriteLine("          Cadastrar Objeto         ");
            Console.WriteLine("===================================");
            Console.Write("Nome do Objeto a ser Cadastrado: ");
            string nome = Console.ReadLine();
            Console.Write("Quantidade a ser Adicionada: ");
            int quantidade = int.Parse(Console.ReadLine());

            CadastrarObjetoObjeto cadastrarObjeto = new CadastrarObjetoObjeto(nome, quantidade);
            estoque.Add(cadastrarObjeto);
            Salvar();

            Console.Clear();
            Console.WriteLine("Objeto Cadastrado Com Sucesso!\nAperte ENTER Para Retornar Ao Menu.");
            Console.ReadKey();

            Console.Clear();
        }

        static void Remover()
        {
            Console.Clear();

            bool opcaoInvalida = false;
            while (!opcaoInvalida)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("           Remover Objeto          ");
                Console.WriteLine("===================================");
                Console.Write("Digite o ID do Objeto a ser Removido:");
                int id = int.Parse(Console.ReadLine());

                if (id >= 0 && id < estoque.Count)
                {
                    Console.Clear();
                    estoque.RemoveAt(id);
                    Console.WriteLine("O Objeto Foi Removido Com Sucesso!");
                    Console.WriteLine("Aperte ENTER Para Retornar Ao Menu!");
                    Console.ReadKey();
                    opcaoInvalida = true;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("O ID Digitado E Invalido, Aperte ENTER Para Continuar");
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("Objects.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, estoque);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("objects.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                estoque = (List<IEstoque>)encoder.Deserialize(stream);

                if (estoque == null)
                {
                    estoque = new List<IEstoque>();
                }
                
            }
            catch (Exception ex)
            {
                estoque = new List<IEstoque>();
            }

            stream.Close();
        }
    }
}
