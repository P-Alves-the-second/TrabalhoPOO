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
    public class UserConverter : JsonConverter<User>
    {
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