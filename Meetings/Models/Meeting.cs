using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meetings.Models
{
    public class Meeting
    {
        [Key]
        public int Meeting_Id { get; set; }

        [Required]
        public string Meeting_Type { get; set; }

        public DateTime Meeting_Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Minutes { get; set; }

        public List<Meeting_Item> Items { get; set; }

        public Meeting()
        {
            Items = new List<Meeting_Item>();
        }

    }
}
