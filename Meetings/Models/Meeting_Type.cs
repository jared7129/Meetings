using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meetings.Models
{
    public class Meeting_Type
    {
        [Key]
        public int Meeting_Type_Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
