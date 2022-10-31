using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class SendMessage_ViewModel
    {

        [MinLength(5, ErrorMessage = " {0} حداقل باید {1} کاراکتر باشد")]
        [Display(Name = "پیام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از{1} کاراکتر باشد")]
        public string Message { get; set; }

    }
}
