using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExampleWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]

        //set up a 121 relationship between the Category entity and Product entity
        //use a Navigation Property as below
        //this tells entity framework that two entities (Category and Product) have a relationship
        //Also used to access the related entity when writing code
        //the virtual keyword is used in lazy loading and improves performance.
        //e.g. if you ran a query from within the application to access a Product, the query would
        //not automatically return the Category associated with the Product unless you try to access it,
        //at which point Entity Framework would query the database and load it in. If you do not use the Virtual
        //keyword then all of an entitys relationships will be included in the first Product query.

        public virtual Category? Category { get; set; }
    }
}
