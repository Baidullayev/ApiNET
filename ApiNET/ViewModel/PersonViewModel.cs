using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiNET.ViewModel
{
    public class PersonViewModel
    {
        [Required(ErrorMessage = "Укажите ИИН")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Пожаулйста введите правильный ИИН")]
        public string Iin { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Поле Имя должно содержать только буквы")]
        [Required(ErrorMessage = "Укажите Имя")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Укажите Фамилия")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Укажите Дату рождения")]
        public DateTime Birthdate { get; set; }
    }
}