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
    [Table("Albums")]
    public class Album
    {
        // Key notations is optional if the SQL Primary Key ends in ID or Id
        // Required if default or if entity is NOT Identity
        // Required if the Primary Key is a compound Primary Key
        // Properties can be fully implemented or auto implemented
        // Property names should use SQL attribute name
        // Properties should be listed in the same order as sql table attributes for easy of maintenance

        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }

        // Navigation properties for use by Linq
        // These properties will be of type vitural
        // There are two types of navigation properties
        // Properties that point to "children" use ICollection<T>
        // Properties that point to "Parent" use ParentName as the data type
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual Artist Artist { get; set; }
    }
}