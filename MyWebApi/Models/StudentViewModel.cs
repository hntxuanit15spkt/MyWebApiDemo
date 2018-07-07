using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.Models
{
    //This is Data Transfer Object
    public class StudentViewModel
    {
        public Int64 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public StandardViewModel Standard { get; set; }
    }
}