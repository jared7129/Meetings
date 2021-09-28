using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meetings.Models
{
    public class Meeting_Item
    {
        [Key]
        public int Item_Id { get; set; }

        [Required]
        public string Item_Description { get; set; }

        public string Comment { get; set; }

        public DateTime Due_Date { get; set; }

        public string Status { get; set; }

        public string Person_Responsible { get; set; }

    }
}
