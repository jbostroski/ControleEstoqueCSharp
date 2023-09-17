using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTIAlgoritmosV2
{
    internal class GerenciadorProdutos
    {   
        //atributos//
        private produto[] produtos;
        private int counter;
        
        //construtor//
        public GerenciadorProdutos(int capacidade)
        {
            produtos = new produto[capacidade];
            counter = 0;
        }

        //métodos//
            //método para incluir novo produto no vetor//
        public bool AdicionarProduto(produto produto)
        {
            if (counter < produtos.Length)
            {
                produtos[counter] = produto;
                counter++;
                return true;
            }
            return false;
        }

        //método para listar todos os produtos do vetor//
        public void ListarProdutos()
        {
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine(produtos[i]);
            }
        }

        //método para listar somente o SKU dos produtos//
        public void ListarSKU()
        {
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine(produtos[i].GetSKU());
            }
        }

        //método para checar o tamanho do vetor//
        public int TamanhoVetor()
        {
            return counter;
        }

        //método para excluir produto de dentro do vetor (via SKU, variável X)//
        public bool ExcluirProdutoSKU(string x)
        {
            for (int i = 0; i < counter; i++)
            {
                if (produtos[i].GetSKU() == x)
                { 
                    for (int y = i; y < counter - 1; y++)
                    {
                        produtos[y] = produtos[y + 1];
                    }
                    produtos[counter - 1] = null;
                    counter--;
                    Console.WriteLine($"Produto com SKU {x} removido com sucesso.");
                    return true;
                }
            }
            Console.WriteLine($"Produto com SKU {x} não encontrado.");
            return true;
        }

        //método para mostrar o saldo em estoque//
        public bool GetEstoque(string x)
        {
            for (int i = 0; i < counter; i++)
            {
                if (produtos[i].GetSKU() == x)
                {
                    Console.WriteLine($"Produto com SKU {x} encontrado com sucesso. Saldo atual em estoque é: " + produtos[i].GetEstoque());
                    return true;
                }
            }
            Console.WriteLine($"Produto com SKU {x} não encontrado.");
            return true;
        }

        //método para ajustar estoque (string X = SKU / int y = valor a ser acrescido ou decrescido / int z = tipo da operação (1 = inclui / 2 = remove)//
        public bool AjusteEstoque(string x, int y, int z)
        {
            for (int i = 0; i < counter; i++)
            {
                if (produtos[i].GetSKU() == x)
                {
                    produtos[i].AjusteEstoque(y,z);
                    Console.WriteLine($"Produto com SKU {x} ajustado com sucesso. Novo saldo em estoque é: " + produtos[i].GetEstoque());
                    return true;
                }
            }
            Console.WriteLine($"Produto com SKU {x} não encontrado.");
            return true;
        }
    }
}
