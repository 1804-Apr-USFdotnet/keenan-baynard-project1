using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RestaurantModels
{
    public class Review : IReview
    {
        [Required]
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage ="Name Field is too Long ({1} char max)")]
        public string ReviewerName { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(600, ErrorMessage ="Comment Field is too Long ({1} char max)")]
        public string ReviewComment { get; set; }

        [Required(ErrorMessage = "Rating is Required")]
        [RegularExpression(@"[0-4]{0,1}.[0-9]{0,1}", ErrorMessage = "Invalid Rating, Enter Number From [0-5)")]
        public double ReviewRating { get; set; }

        [Required]
        public int RestaurantID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateSubmitted => DateTime.Now;

        public string GetFormattedReview()
        {
            string formatted =
                "Reviewer Name: " + ReviewerName + ": \n\t" +
                "Written Review: (" + ReviewRating + ") " + ReviewComment;
            return formatted;
        }
    }
}
