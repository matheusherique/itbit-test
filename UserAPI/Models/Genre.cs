using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class Genre
    {
        [Key]
        public int GenreId{get;set;}
        
        [StringLength(15)]
        public string Description{get;set;}
    }
}