using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTIAlgoritmosV2
{
    public class produto
    {
        //atributos//
        private string sku;
        private string nome;
        private float preco;
        private int estoque;
        private string categoria;
        private string marca;
        private string veiculo;

        //construtor//
        public produto(string sku, string nome, float preco, int estoque, string categoria, string marca, string veiculo)
        {
            this.sku = sku;
            this.nome = nome;
            this.preco = preco;
            this.estoque = estoque;
            this.categoria = categoria;
            this.marca = marca;
            this.veiculo = veiculo;

        }
        //métodos//
            //retorna todos os atributos do produto//
        public override string ToString()
        {
            return $"SKU: {sku}, Item: {nome}, \nPreço R$: {preco}, Qtd Estoque: {estoque}, \nCategoria: {categoria}, Marca: {marca}, Aplicável Em: {veiculo}\n\n";
        }
            //retorna somente o atributo SKU//
        public string GetSKU()
        {
            return sku;
        }
            //retorna somente o atributo estoque//
        public int GetEstoque()
        {
            return estoque;
        }
            //método que soma ou retira do estoque, dependendo do valor z (1 = inclui / 2 = remover)//
        public int AjusteEstoque(int x, int z)
        {
            if(z == 1)
            {
                estoque = estoque + x;
                return estoque;
            }
            else if(z == 2)
            {
                estoque = estoque - x;
                return estoque;
            }
            return estoque;
        }
    }
}
