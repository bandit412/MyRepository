using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace ChinookSystem.Data.Entities
{
    // Point to the SQL table that this file maps to
    [Table("Tracks")]
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        [Required(ErrorMessage = "Name is a required field")]
        [StringLength(200, ErrorMessage = "Name is too long. Max is 200 characters")]
        public string Name { get; set; }
        [Range(1.0, double.MaxValue, ErrorMessage = "Invalid Album. Try selection again")]
        public int? AlbumId { get; set; }
        [Required(ErrorMessage = "Media Type is a required field")]
        [Range(1.0, double.MaxValue, ErrorMessage = "Invalid Media Type. Try selection again")]
        public int MediaTypeId { get; set; }
        [Range(1.0, double.MaxValue, ErrorMessage = "Invalid Genre. Try selection again")]
        public int? GenreId { get; set; }
        [StringLength(220, ErrorMessage = "Composer is too long. Max is 220 characters")]
        public string Composer { get; set; }
        [Required(ErrorMessage = "Milliseconds is a required field")]
        [Range(1.0, double.MaxValue, ErrorMessage = "Invalid Milliseconds. Must be greater than 0.")]
        public int Milliseconds { get; set; }
        [Range(1.0, double.MaxValue, ErrorMessage = "Invalid Bytes. Must be greater than 0.")]
        public int? Bytes { get; set; }
        [Required(ErrorMessage = "Price is a required field")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Invalid price. Must be 0 or greater.")]
        public decimal UnitPrice { get; set; }

        public virtual Album Album { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual Genre Genre { get; set; }
    }
}