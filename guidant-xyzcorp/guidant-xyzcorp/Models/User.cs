using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace guidant_xyzcorp.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public int points { get; set; }

        public string name { get; set; }
    }
}