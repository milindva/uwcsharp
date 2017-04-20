using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BirthDayCard.Models
{
    public class BirthDay
    {
        [Required(ErrorMessage ="Please enter text in From field")]
        public string From { get; set; }
        [Required(ErrorMessage ="Please enter text in To field")]
        public string To { get; set; }
        [Required(ErrorMessage ="Please enter text in Message field")]
        public string Message { get; set; }
    }
}