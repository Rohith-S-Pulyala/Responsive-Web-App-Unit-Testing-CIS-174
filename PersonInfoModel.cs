/*
 * Rohith Pulyala
 * CIS 174
 * 1/20/2026
 */

using System.ComponentModel.DataAnnotations;

namespace FirstResponsiveWebAppPulyala.Models
{
    public class PersonInfoModel
    {
        //Constant for current year
        public const int CURRENT_YEAR = 2026;

        //Getters and setters

        [Required(ErrorMessage = "Please enter your name.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter your birth year.")]
        [Range(1900, CURRENT_YEAR, ErrorMessage = "Year must be between 1900 and 2026.")]
        public int? BirthYear { get; set; }

        /*
         * Age This year
         * 
         * @return Person's age on December 31st
         */
        public int? AgeThisYear()
        {
            return CURRENT_YEAR - BirthYear;
        }
    }
}
