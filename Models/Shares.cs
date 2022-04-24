using System;
using System.ComponentModel.DataAnnotations;

namespace SharesAPI.Models
{
    /*public class Shares
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }*/

    public class Shares
    {
        //[Required(ErrorMessage = "Name is required")]
        [Key]
        public string Name { get; set; }

        public double Price { get; set; }

    }
}
