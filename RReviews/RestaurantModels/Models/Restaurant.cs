using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RestaurantModels
{
    public class Restaurant : IRestaurant
    {
        [Required]
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "City is Required")]
        [StringLength(30, ErrorMessage ="City Name is too Long ({1} char max)")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage ="State Name is too Long ({1} char max")]
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }

        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage ="Name is too Long ({1} char max")]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        public virtual List<Review> Reviews { get; set; }

        [StringLength(100, ErrorMessage ="Food Type Field is too Long ({1} char max)")]
        public string FoodType { get; set; }

        [StringLength(200, ErrorMessage ="Operation Hours Field is too Long ({1} char max)")]
        public string OperationHours { get; set; }


        public Restaurant()
        {
            Reviews = new List<Review>();
        }

        public string GetLocation()
        {
            return City + ", " + State;
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }

        public double GetAvgReview()
        {
            double result = Reviews.Sum(x => x.ReviewRating) / Reviews.Count;
            return Math.Round(result, 2);
        }

        public void SetOperationHours(string sun, string mon, string tue, string wed, string thur, string fri, string sat)
        {
            //need to add random opeation hours to json list
            OperationHours =
                "Sunday: " + sun +
                "\nMonday: " + mon +
                "\nTuesday: " + tue +
                "\nWednesday: " + wed +
                "\nThursday: " + thur +
                "\nFriday: " + fri +
                "\nSaturday: " + sat;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Restaraunt Name: {Name}");
            Console.WriteLine($"City: {City}");
            Console.WriteLine($"State: {State}");
            Console.WriteLine($"Food Type: {FoodType}");
            Console.WriteLine($"Hours of Operstion: {OperationHours}");
        }

        public static Review CreateReview()
        {
            Review TempReview = new Review();
            Console.Write("Enter your full name: ");
            TempReview.ReviewerName = Console.ReadLine();
            Console.Write("Enter review score: ");
            TempReview.ReviewRating = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Comment: ");
            TempReview.ReviewComment = Console.ReadLine();
            return TempReview;
        }

        public static Review CreateReview(Restaurant restaurant)
        {
            Review TempReview = new Review();
            TempReview.RestaurantID = restaurant.ID;
            Console.Write("Enter your full name: ");
            TempReview.ReviewerName = Console.ReadLine();
            Console.Write("Enter review score: ");
            TempReview.ReviewRating = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Comment: ");
            TempReview.ReviewComment = Console.ReadLine();
            return TempReview;
        }
    }
}
