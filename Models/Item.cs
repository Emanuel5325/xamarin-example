using System.ComponentModel.DataAnnotations;

namespace MauiExample.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public string Title { get; set; }
    }
}
