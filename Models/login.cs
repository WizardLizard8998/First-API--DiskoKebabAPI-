using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace projectServices.Models
{
    [Table("USERS")]
    public class Login
    {
        public string LoginPhone { get; set; }

        public string LoginPassword { get; set; }
    }

}