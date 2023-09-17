using PTIAlgoritmosV2;
internal class Program
{
    private static void Main(string[] args)
    {
        //variável de controle da execução do programa//
        bool programa = true;
        //string para entrada de valores (Console.ReadLine)//
        string entrada;
        //int saída de valores//
        int saida;
        //quantidade de produtos que podem ser armazenados no vetor//
        int quantidadeProdutos = 3;
        //inicia um novo vetor//
        GerenciadorProdutos gerenciador = new GerenciadorProdutos(quantidadeProdutos);
        //controle para avisar caso o usuário atinga o limite do vetor//
        int memoria = gerenciador.TamanhoVetor();       
        //função para converter string para int//
        int ConverterInteiro(string ValorEntrada)
        {
            int ValorSaida;
            bool x = int.TryParse(ValorEntrada, out ValorSaida);
           if(x == true)
            {
                return ValorSaida;
            } else
            {
                return 0;
            }
        }
        //função para converter string para float//
        float ConverterFloat(string ValorEntrada)
        {
            float ValorSaida;
            bool x = float.TryParse(ValorEntrada, out ValorSaida);
            if (x == true)
            {
                return ValorSaida;
            }
            else
            {
                return 0;
            }
        }

        //main//
        while (programa == true)
        {   
            //menu principal//
                //checagem se o limite do vetor foi atingido//
            if (memoria != quantidadeProdutos)
            {
                Console.Write("[1] Novo Produto | ");
            } else
            {
                Console.WriteLine("SISTEMA SEM MEMÓRIA!!");
            }
            Console.Write("[2] Listar Produtos | ");
            Console.WriteLine("[3] Remover Produto\n\n");
            Console.Write("[4] Entrada de Estoque | ");
            Console.WriteLine("[5] Saida de Estoque\n\n");
            Console.WriteLine("[6] SAIR\n\n");
            
            //input do usuário//
            entrada = Console.ReadLine();
            saida = ConverterInteiro(entrada);

            //listagem das opções//
                //checagem do input, lançando erro caso não seja de 1 - 6//
            if (saida == 0 || saida > 6)
            {
                Console.WriteLine("");
                Console.WriteLine("OPÇÃO INVÁLIDA, TENTE NOVAMENTE!\n\n");
                Console.WriteLine("");
            }
            //opção 01//
            else if (saida == 1)
            {   //mostra aviso novamente caso o vetor esteja sem espaço//
                if(memoria == quantidadeProdutos)
                {
                    Console.WriteLine("Sistema sem memória, o produto NÃO será salvo!");
                }
                saida = 0;
                Console.WriteLine("- Cadastro de Produtos\n\n");
                Console.WriteLine("Informe o SKU do produto: \n");
                string sku = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Informe o nome do produto: \n");
                string produto = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Informe o preço do produto: \n");
                entrada = Console.ReadLine();
                float preco = ConverterFloat(entrada);
                while(preco == 0)
                {
                    Console.WriteLine("Valor inválido, informe o valor (somente números, diferente de 0)");
                    entrada = Console.ReadLine();
                    Console.WriteLine("");
                    preco = ConverterFloat(entrada);
                }
                Console.WriteLine("");
                Console.WriteLine("Informar estoque? [S] | [N] | Caso não informe, o saldo será 0\n");
                string e = Console.ReadLine();
                Console.WriteLine("");
                if (e == "S" || e == "s")
                {
                    Console.WriteLine("Informe a quantidade em estoque:\n");
                    entrada = Console.ReadLine();
                    saida = ConverterInteiro(entrada);
                    while(saida == 0)
                    {
                        Console.WriteLine("Quantidade inválida, informe a quantidade em estoque (somente números)");
                        entrada = Console.ReadLine();
                        Console.WriteLine("");
                        saida = ConverterInteiro(entrada);
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("Informe a categoria do produto: \n");
                string categoria = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Informe a marca do produto: \n");
                string marca = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Informe o veículo aplicável: \n");
                string veiculo = Console.ReadLine();
                Console.WriteLine("");
                gerenciador.AdicionarProduto(new produto(sku,produto,preco,saida,categoria,marca,veiculo));
                Console.WriteLine("Produto Cadastrado com Sucesso!\n\n");
            }
            //opção 02//
            else if (saida == 2)
            {
                Console.WriteLine("- Listar Produtos\n");
                gerenciador.ListarProdutos();
                Console.WriteLine("");
            }
            //opção 03//
            else if (saida == 3)
            {
                Console.WriteLine("- Remover Produtos\n");
                Console.WriteLine("- Digite o SKU do produto a ser excluído:\n\n");
                entrada = Console.ReadLine();
                Console.WriteLine("");
                gerenciador.ExcluirProdutoSKU(entrada);
                Console.WriteLine("");

            }
            //opção 04//
            else if (saida == 4)
            {
                int ajusteTipo = 1;
                Console.WriteLine("- Entrada de Estoque\n\n");
                Console.WriteLine("- Digite o SKU do produto:\n\n");
                string sku = Console.ReadLine();
                Console.WriteLine("");
                gerenciador.GetEstoque(sku); 
                Console.WriteLine("");
                Console.WriteLine("- Informe a quantidade a ser acrescida:\n\n");
                int estoque = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                gerenciador.AjusteEstoque(sku, estoque, ajusteTipo);
                Console.WriteLine("");
            }
            //opção 05//
            else if (saida == 5)
            {
                int ajusteTipo = 2;
                Console.WriteLine("- Saída de Estoque\n\n");
                Console.WriteLine("- Digite o SKU do produto:\n\n");
                string sku = Console.ReadLine();
                Console.WriteLine("");
                gerenciador.GetEstoque(sku);
                Console.WriteLine("");
                Console.WriteLine("- Informe a quantidade a ser removida:\n\n");
                int estoque = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                gerenciador.AjusteEstoque(sku, estoque, ajusteTipo);
                Console.WriteLine("");
            }
            else
            {
                programa = false;
                Console.WriteLine("Você escolheu sair, até mais!\n\n");
                break;

            }
        }
    }
}
