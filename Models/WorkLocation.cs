using System.ComponentModel.DataAnnotations;

namespace MauiExample.Models
{
    public class WorkLocation : Location
    {

        [Key]
        public int Id { get; set; }
    }
}
