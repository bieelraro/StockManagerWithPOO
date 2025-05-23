using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerWithPOO
{
    [System.Serializable]
    internal class CadastrarObjetoObjeto : Objeto, IEstoque
    {
        public int quantidade = 0;
        public CadastrarObjetoObjeto(string nome, int quantidade)
        {
            this.nome = nome;
            this.quantidade = quantidade;
        }

        public void AdicionarEntrada()
        {

        }

        public void AdicionarSaida()
        {

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do Objeto: {nome}");
            Console.WriteLine($"Quantidade Restante: {quantidade}");
            Console.WriteLine("==================================");
        }
    }
}
