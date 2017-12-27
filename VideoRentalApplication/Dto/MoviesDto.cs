using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRentalApplication.Dto
{
    public class MoviesDto
    {
        public int movieID { get; set; }

        [Required(ErrorMessage = "Movie Name is a required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Movie current stock count is a required field")]
        [Range(1, 20, ErrorMessage = "Movie stock count should be between 1 and 20")]
        public Nullable<int> NumberInStock { get; set; }

        [Required(ErrorMessage = "Genre is a required field")]
        public string Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ReleaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateAdded { get; set; }
    }
}