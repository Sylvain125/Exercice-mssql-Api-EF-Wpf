using System.Text.Json.Serialization;

namespace Exercice.Model
{
    public class UserInfoModel
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("UserFirstName")]
        public string UserFirstName { get; set; }

        [JsonPropertyName("UserLastName")]
        public string UserLastName { get; set; }

        [JsonPropertyName("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("CompanyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("Phone")]
        public string Phone { get; set; }

        public UserInfoModel(int userId, string userFirstName, string userLastName, string emailAddress, string companyName, string phone)
        {
            UserId = userId;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            EmailAddress = emailAddress;
            CompanyName = companyName;
            Phone = phone;
        }
    }
}