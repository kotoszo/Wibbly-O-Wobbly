using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Hub.Models
{
    public class FormModel
    {
        //[DisplayName("First Name")]
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return FirstName + " " + Email + " " + Password;
        }
    }
}