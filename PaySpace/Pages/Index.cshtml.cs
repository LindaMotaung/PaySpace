using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySpace.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int Income { get; set; }

        [BindProperty]
        public string PostalCode { get; set; }

        public int PostalCodeId { get; set; }

        public void OnGet()
        {

        }

        public int MapPostalCodes(string PostalCode)
        {
            if (string.IsNullOrEmpty(PostalCode))
            {
                throw new ArgumentNullException(nameof(PostalCode), "Postal code should not be empty or null.");
            }

            this.PostalCodeId = PostalCode switch
            {
                "7441" => 1,
                "A100" => 2,
                "7000" => 3,
                "1000" => 4,
                _ => throw new ArgumentNullException(nameof(PostalCode),
                    "Postal code should be either 7441, A100, 7000 or 1000")
            };

            return this.PostalCodeId;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ensure PostalCode has the correct value
            if (string.IsNullOrEmpty(PostalCode))
            {
                ModelState.AddModelError("PostalCode", "Postal code should not be empty or null.");
                return Page();
            }

            MapPostalCodes(PostalCode);
            // This method will be executed when the form is submitted using POST.

            // Do something with the entered data (e.g., save to a database or process it).

            return Page(); // Return the same page after form submission.
        }
    }
}
