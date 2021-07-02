using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TrainningStudent.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Input Username")]
        [StringLength(20, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Input Password")]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
