using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Exercice.Persistance
{

    [Table("UserInfo")]

    public class UserInfoEntity
    {

        [Key, DataMember]
        [Column("UserInfoId")]
        [Required, MaxLength(20)]
        public int UserId { get; set; }
        

        [Column("FirstName")]
        [StringLength(100)]
        public string UserFirstName { get; set; }
        

        [Column("LastName")]
        [StringLength(100)]
        public string UserLastName { get; set; }
        

        [Column("EmailAddress")]
        [Required, StringLength(160), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        

        
        [Column("CompanyName")]
        [StringLength(100)]
        public string CompanyName { get; set; }
        

        
        [Column("Phone")]
        [StringLength(100)]
        public string Phone { get; set; }

        public UserInfoEntity()
        {

        }
        public UserInfoEntity(int userId, string userFirstName, string userLastName, string emailAddress, string companyName, string phone)
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
