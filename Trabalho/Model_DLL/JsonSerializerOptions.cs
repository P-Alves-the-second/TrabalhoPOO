using Enums_DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Model_DLL
{
    /// <summary>
    /// A classe <see cref="UserConverter"/> é um conversor personalizado para serializar e desserializar objetos da classe <see cref="User"/> 
    /// utilizando o <see cref="JsonConverter"/>. Ela permite a conversão de objetos JSON para instâncias de subclasses de <see cref="User"/> 
    /// (como <see cref="Cliente"/> e <see cref="Vendedor>) e vice-versa.
    /// </summary>
    public class UserConverter : JsonConverter<User>
    {

        /// <summary>
        /// Método responsável por desserializar um objeto JSON para uma instância da classe <see cref="User"/> 
        /// (ou suas subclasses <see cref="Cliente"/> ou <see cref="Vendedor"/>), dependendo do tipo de usuário fornecido no JSON.
        /// </summary>
        /// <param name="reader">O leitor de JSON que será utilizado para fazer a leitura dos dados.</param>
        /// <param name="typeToConvert">O tipo de objeto a ser convertido (no caso, <see cref="User"/>).</param>
        /// <param name="options">As opções de serialização utilizadas pelo <see cref="JsonSerializer"/>.</param>
        /// <returns>Retorna uma instância da classe <see cref="User"/> ou suas subclasses baseadas no tipo fornecido.</returns>
        /// <exception cref="JsonException">Lançada quando o JSON está mal formado ou o tipo de usuário não pode ser interpretado.</exception>
        public override User Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;

            // Obtenha o tipo do usuário (por exemplo, a partir de uma propriedade "UserType")
            if (!jsonObject.TryGetProperty("UserType", out var userTypeElement))
                throw new JsonException("Faltando a propriedade 'UserType' no JSON.");

            // Parseia o tipo de usuário
            EUserType userType;
            if (userTypeElement.ValueKind == JsonValueKind.String)
            {
                userType = Enum.Parse<EUserType>(userTypeElement.GetString());
            }
            else if (userTypeElement.ValueKind == JsonValueKind.Number)
            {
                userType = (EUserType)userTypeElement.GetInt32();
            }
            else
            {
                throw new JsonException("Formato inválido para 'UserType'.");
            }

            // Extraia dados comuns
            int iduser = jsonObject.GetProperty("IdUser").GetInt32();
            string name = jsonObject.GetProperty("Name").GetString();
            string email = jsonObject.GetProperty("Email").GetString();
            string password = jsonObject.GetProperty("Password").GetString();
            int wallet = jsonObject.GetProperty("Wallet").GetInt32();

            // Determine a subclasse com base no tipo de usuário
            switch (userType)
            {
                case EUserType.Cliente:
                    var cliente = new Cliente(name, email, password, iduser) { Wallet = wallet };

                    // Se houver propriedades adicionais em Cliente, processe aqui.
                    if (jsonObject.TryGetProperty("Compras", out var comprasElement))
                    {
                        cliente.Compras = JsonSerializer.Deserialize<List<int>>(comprasElement.GetRawText());
                    }
                    return cliente;
                case EUserType.Vendedor:
                    var vendedor = new Vendedor(name, email, password, iduser) { Wallet = wallet };

                    // Se houver propriedades adicionais em Vendedor, processe aqui.
                    if (jsonObject.TryGetProperty("Products", out var productsElement))
                    {
                        vendedor.Products = JsonSerializer.Deserialize<List<int>>(productsElement.GetRawText());
                    }
                    if (jsonObject.TryGetProperty("Marcas", out var marcasElement))
                    {
                        vendedor.Marcas = JsonSerializer.Deserialize<List<int>>(marcasElement.GetRawText());
                    }
                    return vendedor;
                default:
                    throw new JsonException($"Tipo de usuário desconhecido: {userType}");
            }
        }

        /// <summary>
        /// Método responsável por serializar um objeto <see cref="User"/> (ou suas subclasses <see cref="Cliente"/> ou <see cref="Vendedor"/>) 
        /// em formato JSON.
        /// </summary>
        /// <param name="writer">O escritor de JSON que será utilizado para gerar a saída JSON.</param>
        /// <param name="value">O valor do tipo <see cref="User"/> que será serializado.</param>
        /// <param name="options">As opções de serialização utilizadas pelo <see cref="JsonSerializer"/>.</param>
        public override void Write(Utf8JsonWriter writer, User value, JsonSerializerOptions options)
        {
            // Serializar os dados comuns da classe User
            writer.WriteStartObject();
            writer.WriteNumber("IdUser", value.IdUser);
            writer.WriteString("Name", value.Name);
            writer.WriteString("Email", value.Email);
            writer.WriteString("Password", value.Password);
            writer.WriteNumber("Wallet", value.Wallet);
            writer.WriteString("UserType", value.UserType.ToString());

           

            writer.WriteEndObject();
        }
    }
}