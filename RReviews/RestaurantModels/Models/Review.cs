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
        public int ID { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewComment { get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        [RegularExpression(@"[0-4]{0,1}.[0-9]{0,1}", ErrorMessage = "Invalid Rating")]
        public double ReviewRating { get; set; }
        public int RestaurantID { get; set; }


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
