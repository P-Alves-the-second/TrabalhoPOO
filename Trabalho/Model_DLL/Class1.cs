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
            EUserType userType = Enum.Parse<EUserType>(userTypeElement.GetString());

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
                    return new Cliente(name, email, password,iduser); // Exemplo de subclasse
                case EUserType.Vendedor:
                    return new Vendedor(name, email, password, iduser); // Exemplo de subclasse
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