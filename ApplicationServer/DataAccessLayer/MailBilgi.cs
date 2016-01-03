using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace ModelLayer
{
    //[TableName("MailBilgi")]
    //[PrimaryKey("Id")]
    public partial class MailBilgi
    {
        public int Id { get; set; }

        [Email(ErrorMessage = "Lütfen geçerli mail adresi giriniz.")]
        [Required(ErrorMessage = "Lütfen  mail adresi yazını.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adı yazını.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen mail şifresi yazını.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen SMTP Client yazını.")]
        public string SMTPClient { get; set; }

        [Required(ErrorMessage = "Lütfen smtp portu yazını.")]
        public string Port { get; set; }
    }
}
