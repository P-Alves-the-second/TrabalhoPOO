using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_DLL;    
using System.Collections;
using Enums_DLL;
using System.Security.AccessControl;
using System.ComponentModel;

namespace Trabalho
{
    internal class Program
    {
        /// <summary>
        /// Método principal do programa que inicializa variáveis globais, carrega dados de listas e executa as funções de login e registro de usuários.
        /// </summary>
        static void Main(string[] args)
        {
            /// <summary>
            /// Variável que armazena o usuário atualmente logado. -1 significa nenhum usuário logado.
            /// </summary>
            int CurrentUser = -1;

            /// <summary>
            /// Identificadores únicos incrementais para usuários, produtos, marcas e campanhas.
            /// </summary>
            int CurrentUserId = 1;
            int CurrentProductId = 1;
            int CurrentMarcaId = 1;
            int CurrentCampanhaId = 1;

            /// <summary>
            /// Tipo de usuário atual. Inicialmente definido como Cliente.
            /// </summary>
            EUserType CurrentUserType = EUserType.Cliente;

            /// <summary>
            /// Listas hash para armazenar usuários, produtos, marcas e campanhas.
            /// </summary>
            Hashtable UserList = new Hashtable();
            Hashtable ProductList = new Hashtable();
            Hashtable MarcaList = new Hashtable();
            Hashtable CampanhaList = new Hashtable();

            // Carregar listas de dados a partir de fontes externas.
            UserList = Extra.LoadUser();
            ProductList = Extra.LoadProduct();
            MarcaList = Extra.LoadMarca();


            /// <summary>
            /// Atualiza o próximo ID de usuário com base nos usuários carregados.
            /// </summary>
            foreach (DictionaryEntry entry in UserList) 
            {
                User user = (User)UserList[entry.Key];
                if(user.IdUser>=CurrentUserId)CurrentUserId = user.IdUser+1;
            }
            /// <summary>
            /// Atualiza o próximo ID de produto com base nos produtos carregados, se existirem.
            /// </summary>
            if (ProductList!=null)foreach(DictionaryEntry entry in ProductList) 
            {
                Produto produto = (Produto)ProductList[entry.Key];
                if(produto.ProductId>=CurrentProductId)CurrentProductId = produto.ProductId+1;
            }

            /// <summary>
            /// Atualiza o próximo ID de marca com base nas marcas carregadas.
            /// </summary>
            foreach (DictionaryEntry entry in MarcaList) 
            {
                Marca marca = (Marca)MarcaList[entry.Key];
                if(marca.IdMarca>=CurrentMarcaId)CurrentMarcaId = marca.IdMarca+1;
            }

            /// <summary>
            /// Controle do loop principal do programa. i = 0 encerra o programa.
            /// </summary>
            int i = 1;

            while (i != 0)
            {
                Console.Clear();

                /// <summary>
                /// Loop de autenticação do usuário enquanto nenhum usuário estiver logado.
                /// </summary>
                while (CurrentUser == -1)
                {
                    int aux = 0;

                    /// <summary>
                    /// Menu principal de login e registro.
                    /// </summary>
                    while (aux != 1 && aux != 2)
                    {
                        try
                        {
                            Console.WriteLine("1 - LogIn\n2 - Registar\n0 - Sair");
                            aux = Convert.ToInt32(Console.ReadLine());
                            if (aux == 0) Environment.Exit(0);
                        } 
                        catch(System.FormatException) 
                        {
                            Console.WriteLine("Formato Invalido");
                            Console.Clear();
                        }
                    }
                    Console.Clear();
                    #region LogIn
                    /// <summary>
                    /// Processo de login para usuários já cadastrados.
                    /// </summary>
                    if (aux == 1) 
                    {
                        aux = 0;
                        try
                        {
                            while (aux != 1 && aux != 2)
                            {
                                Console.Clear();
                                Console.WriteLine("----LogIn----");
                                Console.WriteLine("1 - Vendedor");
                                Console.WriteLine("2 - Cliente");
                                aux = Convert.ToInt32(Console.ReadLine());
                            }
                            Console.WriteLine("Email : ");
                            string email = Console.ReadLine();

                            Console.WriteLine("Senha : ");
                            string senha = Console.ReadLine();

                            if (aux == 1) CurrentUserType = EUserType.Vendedor;
                            else CurrentUserType = EUserType.Cliente;
                            CurrentUser = Extra.LogIn(UserList, email, senha, CurrentUserType);
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("Formato Invalido");
                            
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                    #endregion
                    #region Register
                    /// <summary>
                    /// Processo de registro para novos usuários.
                    /// </summary>
                    else
                    {
                        EUserType UserType = EUserType.Vendedor;
                        aux = 0;
                        while (aux != 1 && aux != 2)
                        {
                            Console.WriteLine("----Registar----");
                            Console.WriteLine("1 - Vendedor");
                            Console.WriteLine("2 - Cliente");
                            aux = Convert.ToInt32(Console.ReadLine());
                        }

                        Console.WriteLine("Nome : ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Email : ");
                        string email = Console.ReadLine();

                        Console.WriteLine("Senha : ");
                        string password = Console.ReadLine();

                        if (aux==2) 
                        { 
                            Cliente user = new Cliente(nome,email,password,CurrentUserId);
                            UserList = user.Register(UserList);
                        }
                        else 
                        { 
                            Vendedor user = new Vendedor(nome,email,password,CurrentUserId); 
                            UserList = user.Register(UserList);
                        }
                        CurrentUserId++;
                        foreach(DictionaryEntry entry in UserList) 
                        {
                            User user = (User)UserList[entry.Key];
                            user.Save();
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                    #endregion


                }
                #region Menu
                /// <summary>
                /// Gerencia o menu principal e as respectivas funcionalidades com base no tipo de usuário.
                /// </summary>
                Console.Clear() ;
                Console.WriteLine("----Menu----");
                Console.WriteLine("1 - Mostrar Produtos");
                if (CurrentUserType == EUserType.Cliente)
                {
                    Console.WriteLine("2 - Comprar Produto\n3 - Adicionar Dinheiro\n4 - Checar garantia de um produto");

                }
                else
                {
                    Console.WriteLine("2 - Adicionar Produto\n3 - Adicionar Marca\n4 - Adicionar campanha");
                }
                Console.WriteLine("5 - Mostrar Marcas");
                Console.WriteLine("6 - Mostrar Campanhas");
                Console.WriteLine("7 - Ver Perfil");
                Console.WriteLine("8 - Signout");
                Console.WriteLine("9 - Apagar Dados");
                Console.WriteLine("0 - Sair");
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Formato Invalido");

                }
                #endregion


                /// <summary>
                /// Executa a ação correspondente à opção selecionada no menu.
                /// </summary>
                switch (i)
                {
                  
                    case 1:
                        #region MostrarProdutos
                        /// <summary>
                        /// Mostra os produtos disponíveis.
                        /// </summary>
                        Extra.MostrarProdutos(ProductList, MarcaList);
                        #endregion
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        /// <summary>
                        /// Realiza a compra de um produto (Cliente) ou adiciona um novo produto (Vendedor).
                        /// </summary>
                        #region ComprarProduto
                        if (CurrentUserType == EUserType.Cliente)
                        {
                            Console.WriteLine("Id do Produto : ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Cliente cliente = (Cliente)UserList[CurrentUser];
                            int aux = cliente.Buy(ProductList,UserList,CampanhaList,id);
                            switch (aux) 
                            {
                                case 1:
                                    Console.WriteLine("Sucesso");
                                    break;
                                case 2:
                                    Console.WriteLine("Produto sem estoque");
                                    break;
                                case 3: Console.WriteLine("Saldo insuficiente");
                                    break;
                            }
                            foreach (DictionaryEntry entry in UserList)
                            {
                                User user = (User)UserList[entry.Key];
                                user.Save();
                            }
                        }
                        #endregion
                        #region AdicionarProduto
                        /// <summary>
                        /// Solicita informações para criar um novo produto.
                        /// </summary>
                        else
                        {
                            int aux = 0;
                            Console.Clear();
                            try
                            {
                                Console.WriteLine("Id da Marca :");
                                int marcaid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Nome do Produto :");
                                string nome = Console.ReadLine();
                                Console.WriteLine("Preço :");
                                double preco = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Descrição :");
                                string descricao = Console.ReadLine();
                                Console.WriteLine("Estoque :");
                                int stock = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Categoria do Produto : \n1 - roupas\n2 - sapatos\n3 - utensilios\n4 - eletronicos");
                                while (aux < 1 || aux > 4) aux = Convert.ToInt32(Console.ReadLine());
                                CategoriaProduto categoria = CategoriaProduto.sapatos;
                                switch (aux)
                                {
                                    case 1:
                                        categoria = CategoriaProduto.roupas;
                                        break;
                                    case 2:
                                        categoria = CategoriaProduto.sapatos;
                                        break;
                                    case 3:
                                        categoria = CategoriaProduto.utensilios;
                                        break;
                                    case 4:
                                        categoria = CategoriaProduto.eletronicos;
                                        break;
                                }
                                Console.WriteLine("Tipo de garantia :\n1 - dias\n2 - meses\n3 - anos");
                                aux = 0;
                                GarantiaType garantiatype = GarantiaType.Ano;
                                while (aux < 1 || aux > 3) aux = Convert.ToInt32(Console.ReadLine());
                                switch (aux)
                                {
                                    case 1:
                                        garantiatype = GarantiaType.Dia;
                                        break;
                                    case 2:
                                        garantiatype = GarantiaType.Mes;
                                        break;
                                    case 3:
                                        garantiatype = GarantiaType.Ano;
                                        break;
                                }
                                Console.WriteLine("Garantia(quantidade) : ");
                                int garantia = Convert.ToInt32(Console.ReadLine());

                                Vendedor vendedor = (Vendedor)UserList[CurrentUser];
                                Produto produto = new Produto(vendedor.IdUser, CurrentProductId, marcaid, preco, nome, descricao, stock, categoria, garantia, garantiatype);

                                ProductList.Add(produto.ProductId, produto);
                                CurrentProductId++;
                                vendedor.AddProduto(produto);
                                foreach(DictionaryEntry entry in ProductList) 
                                {
                                    Produto produto1 = (Produto)ProductList[entry.Key];
                                    produto1.Save();
                                }
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Formato Invalido");

                            }
                        }       
                        Console.ReadKey();
                        #endregion
                        break;
                    case 3:
                        #region AdicionarDinheiro
                        /// <summary>
                        /// Permite que o cliente adicione dinheiro à sua conta.
                        /// </summary>
                        if (CurrentUserType == EUserType.Cliente)
                        {
                            int quant = -1;
                            Console.WriteLine("Quantidade a adicionar :");
                            try
                            {
                                while (quant < 0) quant = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Formato Invalido");

                            }
                            Cliente cliente = (Cliente)UserList[CurrentUser];
                            cliente.addCash(quant);
                            foreach (DictionaryEntry entry in UserList)
                            {
                                User user = (User)UserList[entry.Key];
                                user.Save();
                            }
                        }
                        #endregion
                        #region AdicionarMarca
                        /// <summary>
                        /// Permite que o vendedor adicione uma nova marca.
                        /// </summary>
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Nome da marca");
                            string nome = Console.ReadLine();
                            Vendedor vendedor = (Vendedor)UserList[CurrentUser];
                            MarcaList = vendedor.AddMarca(MarcaList,CurrentMarcaId,nome);
                            CurrentMarcaId++;
                            
                            foreach (DictionaryEntry entry in MarcaList) 
                            {
                                Marca marca = (Marca)MarcaList[entry.Key];
                                marca.Save();
                            }
                        }
                        Console.ReadKey();
                        #endregion
                        break;
                    case 4:
                        #region ChecarGarantia
                        /// <summary>
                        /// Permite que o cliente cheque a garantia de um produto.
                        /// </summary>
                        if (CurrentUserType == EUserType.Cliente) 
                        {
                            Console.WriteLine("Id do Produto : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Produto produto = (Produto)ProductList[id];
                            if (produto == null) 
                            {
                                Console.WriteLine("Produto não existe");
                                break;
                            }
                            int aux = produto.ChecarGarantia();
                            if(aux==1) Console.WriteLine("Está na garantia");
                            else Console.WriteLine("Não está na garantia");
                        }
                        #endregion
                        #region AdicionarCampanha
                        /// <summary>
                        /// Permite que o vendedor adicione uma nova campanha ao sistema.
                        /// </summary>
                        else
                        {
                            try
                            {
                                int aux = 0;
                                int j = 0;
                                DescontoType descontotype = DescontoType.porcentagem;
                                Console.WriteLine("Nome : ");
                                string nome = Console.ReadLine();
                                Console.WriteLine("Descrição : ");
                                string descricao = Console.ReadLine();
                                Console.WriteLine("Tipo de desconto :\n1 - Valor\n2 - Porcentagem");
                                while (aux != 1 && aux != 2) aux = Convert.ToInt32(Console.ReadLine());
                                if (aux == 1) descontotype = DescontoType.valor;
                                else descontotype = DescontoType.valor;

                                Console.WriteLine("Desconto : ");
                                double desconto = Convert.ToDouble(Console.ReadLine());
                                Campanha campanha = new Campanha(CurrentCampanhaId, nome, descricao, desconto, descontotype);
                                Console.WriteLine("Adicionar Produtos");
                                while (j == 0)
                                {
                                    Console.WriteLine("Id do Produto : ");
                                    int produtctid = Convert.ToInt32(Console.ReadLine());
                                    aux = campanha.AdicionarProduto(ProductList, produtctid);
                                    if (aux == 1) Console.WriteLine("Produto ja pertence a uma campanha");
                                    else if (aux == 2) Console.WriteLine("Produto ja pertence a essa campanha");
                                    else Console.WriteLine("Produto adicionado");
                                    Console.WriteLine("Gostaria de adicionar mais?\n 1 - Sim\n2 - Não");
                                    aux = Convert.ToInt32(Console.ReadLine());
                                    if (aux == 2) j = 1;
                                }

                                CampanhaList.Add(campanha.CampanhaId, campanha);
                                CurrentCampanhaId++;
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Formato Invalido");

                            }
                        }
                        #endregion
                        break;
                    case 5:
                        Console.Clear();
                        #region MostrarMarcas
                        /// <summary>
                        /// Exibe informações de todas as marcas cadastradas no sistema.
                        /// </summary>
                        foreach (DictionaryEntry entry in MarcaList) 
                        {
                            Marca marca = (Marca)MarcaList[entry.Key];
                            Console.WriteLine("----");
                            marca.MostrarDados();
                            Console.ReadKey();
                        }
                        #endregion
                        break;
                    case 6:
                        Console.Clear();
                        #region MostrarCampanhas
                        /// <summary>
                        /// Exibe informações detalhadas de todas as campanhas cadastradas, incluindo os produtos associados.
                        /// </summary>
                        foreach (DictionaryEntry entry in CampanhaList) 
                        {
                            Console.WriteLine("----");
                            Campanha campanha = (Campanha)CampanhaList[entry.Key];
                            campanha.MostrarDados(ProductList);
                        }
                        Console.ReadKey();
                        #endregion
                        break;
                    case 7:
                        Console.Clear();
                        #region MostrarPerfil
                        /// <summary>
                        /// Exibe as informações do perfil do utilizador atual.
                        /// </summary>
                        if (CurrentUserType == EUserType.Cliente) 
                        {
                            Cliente cliente = (Cliente)UserList[CurrentUser];
                            cliente.MostrarDados(ProductList,MarcaList);
                        }
                        else
                        {
                            Vendedor vendedor = (Vendedor)UserList[CurrentUser];
                            vendedor.MostrarDados(ProductList,MarcaList); 
                        }
                        Console.ReadKey();
                        #endregion
                        break;
                    case 8:
                        #region SignOut
                        /// <summary>
                        /// Realiza o signout do usuário atual, redefinindo o identificador do usuário para -1.
                        /// </summary>
                        CurrentUser = -1;
                        #endregion
                        break;
                    case 9:
                        #region ApagarDados
                        /// <summary>
                        /// Permite que o administrador apague diferentes categorias de dados do sistema.
                        /// Após a remoção, os identificadores relevantes são reiniciados para os valores iniciais.
                        /// </summary>
                        int op = -1;
                        Console.WriteLine("Quais dados gostaria de apagar?\n1 - Users\n2 - Produtos\n3 - Marcas\n4 - Campanhas\n0 - Todos");
                        while(op<0 || op>4)op = Convert.ToInt32(Console.ReadLine());
                        switch (op) 
                        {
                            case 0:
                                UserList.Clear();
                                ProductList.Clear();
                                MarcaList.Clear();
                                CampanhaList.Clear();
                                Extra.ApagarDados(0);
                                CurrentUser = -1;
                                CurrentUserId = 1;
                                CurrentProductId = 1;
                                CurrentMarcaId = 1;
                                CurrentCampanhaId = 1;
                                break;
                            case 1:
                                UserList.Clear();
                                CurrentUserId = 1;
                                CurrentUser = -1;
                                Extra.ApagarDados(1);
                                break;
                            case 2:
                                ProductList.Clear();
                                CurrentProductId = 1;
                                Extra.ApagarDados(2);
                                break;
                            case 3:
                                MarcaList.Clear();
                                CurrentMarcaId = 1;
                                Extra.ApagarDados(3);
                                break;
                            case 4:
                                CampanhaList.Clear();
                                CurrentCampanhaId = 1;
                                break;
                        }
                        #endregion
                        break;
                }
            }

        }
    }
}
