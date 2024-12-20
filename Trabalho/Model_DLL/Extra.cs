using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Enums_DLL;


namespace Model_DLL
{
    /// <summary>
    /// A classe <see cref="Extra"/> contém métodos auxiliares para gerenciar operações relacionadas ao carregamento de dados, autenticação de usuários, cálculo de diferença entre datas e exclusão de dados.
    /// </summary>
    public class Extra
    {
        /// <summary>
        /// Realiza o login de um usuário, verificando seu email e senha em uma lista de usuários.
        /// </summary>
        /// <param name="UserList">Lista de usuários carregada em um <see cref="Hashtable"/>.</param>
        /// <param name="email">Email do usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <param name="userType">Tipo de usuário (cliente, vendedor, etc.).</param>
        /// <returns>
        /// Retorna o ID do usuário se o login for bem-sucedido, ou -1 caso contrário.
        /// </returns>
        public static int LogIn(Hashtable UserList, string email, string password, EUserType userType)
        {

            foreach (DictionaryEntry entry in UserList)
            {
                Console.ReadKey();
                User user = (User)UserList[entry.Key];
                if (user.Email == email)
                {
                    if (user.Password == password) return user.IdUser;
                }

            }
            Console.ReadKey();
            return -1;
        }

        /// <summary>
        /// Carrega a lista de usuários de um arquivo JSON e retorna um <see cref="Hashtable"/> com os dados.
        /// </summary>
        /// <returns>Retorna um <see cref="Hashtable"/> contendo os usuários carregados.</returns>
        public static Hashtable LoadUser()
        {
            Hashtable UserList = new Hashtable();
            string caminho = "./Users.txt";
            var options = new JsonSerializerOptions
            {
                Converters = { new UserConverter() },
                WriteIndented = true // Para uma formatação legível do JSON
            };
            try
            {
                if (!File.Exists(caminho)) return UserList;
                string[] strings = File.ReadAllLines(caminho);
                foreach (string str in strings)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        User user = JsonSerializer.Deserialize<User>(str, options);
                        Console.WriteLine($"{str}");
                        UserList.Add(user.IdUser, user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar dados(User): " + ex.Message);
                return null;
            }
            return UserList;
        }

        /// <summary>
        /// Carrega a lista de produtos de um arquivo JSON e retorna um <see cref="Hashtable"/> com os dados.
        /// </summary>
        /// <returns>Retorna um <see cref="Hashtable"/> contendo os produtos carregados.</returns>
        public static Hashtable LoadProduct()
        {
            Hashtable ProductList = new Hashtable();
            string caminho = "./Produtos.txt";
            var options = new JsonSerializerOptions
            {
                Converters = { new UserConverter() },
                WriteIndented = true // Para uma formatação legível do JSON
            };
            try
            {
                if (!File.Exists(caminho)) return ProductList;
                string[] strings = File.ReadAllLines(caminho);
                foreach (string str in strings)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        Produto produto = JsonSerializer.Deserialize<Produto>(str, options);
                        ProductList.Add(produto.ProductId, produto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar dados(Produto): " + ex.Message);
                return ProductList;
            }
            return ProductList;
        }

        /// <summary>
        /// Carrega a lista de marcas de um arquivo JSON e retorna um <see cref="Hashtable"/> com os dados.
        /// </summary>
        /// <returns>Retorna um <see cref="Hashtable"/> contendo as marcas carregadas.</returns>
        public static Hashtable LoadMarca()
        {
            Hashtable MarcaList = new Hashtable();
            string caminho = "./Marcas.txt";
            var options = new JsonSerializerOptions
            {
                Converters = { new UserConverter() },
                WriteIndented = true // Para uma formatação legível do JSON
            };
            try
            {
                if (!File.Exists(caminho)) return MarcaList;
                string[] strings = File.ReadAllLines(caminho);
                foreach (string str in strings)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        Marca marca = JsonSerializer.Deserialize<Marca>(str, options);
                        MarcaList.Add(marca.IdMarca, marca);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar dados(Marca): " + ex.Message);
                return null;
            }
            return MarcaList;

        }

        /// <summary>
        /// Exibe todos os produtos na lista de produtos, chamando o método <see cref="Produto.MostrarDados"/> para cada um.
        /// </summary>
        /// <param name="ProductList">Lista de produtos a ser exibida.</param>
        /// <param name="MarcaList">Lista de marcas associadas aos produtos.</param>
        public static void MostrarProdutos(Hashtable ProductList, Hashtable MarcaList)
        {
            foreach (DictionaryEntry entry in ProductList)
            {
                Produto produto = (Produto)ProductList[entry.Key];
                Console.WriteLine("----");
                produto.MostrarDados(MarcaList);
            }
        }

        /// <summary>
        /// Apaga os dados armazenados em arquivos de acordo com a opção fornecida.
        /// </summary>
        /// <param name="op">
        /// 0 - Apaga todos os dados (usuários, produtos, marcas).
        /// 1 - Apaga os dados de usuários.
        /// 2 - Apaga os dados de produtos.
        /// 3 - Apaga os dados de marcas.
        /// </param>
        public static void ApagarDados(int op)
        {
            if (op == 3 || op == 0) File.Delete("./Marcas.txt");
            if (op == 2 || op == 0) File.Delete("./Produtos.txt");
            if (op == 1 || op == 0) File.Delete("./Users.txt");
        }

        /// <summary>
        /// Calcula a diferença entre duas datas, retornando o valor em dias, meses ou anos, conforme especificado.
        /// </summary>
        /// <param name="startDate">Data de início para o cálculo.</param>
        /// <param name="endDate">Data final para o cálculo.</param>
        /// <param name="unit">Unidade da diferença ("days", "months", ou "years").</param>
        /// <returns>Retorna a diferença entre as datas na unidade especificada.</returns>
        /// <exception cref="ArgumentException">Lançado quando a unidade fornecida é inválida.</exception>
        public static int CalculateDifference(DateTime startDate, DateTime endDate, string unit)
        {
            switch (unit.ToLower())
            {
                case "days":
                    return (endDate - startDate).Days;
                case "months":
                    int months = ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
                    if (endDate.Day < startDate.Day)
                        months--; // Ajusta se o dia do mês de fim for menor que o de início.
                    return months;
                case "years":
                    int years = endDate.Year - startDate.Year;
                    if (endDate.Month < startDate.Month ||
                       (endDate.Month == startDate.Month && endDate.Day < startDate.Day))
                        years--; // Ajusta se ainda não alcançou o aniversário completo.
                    return years;
                default:
                    throw new ArgumentException("Unidade inválida. Use 'days', 'months' ou 'years'.");
            }
        }
    }
}
