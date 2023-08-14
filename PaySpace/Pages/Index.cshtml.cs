using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using PaySpace.Api.Controllers;
using PaySpace.Strategy.ConcreteStrategy;
using PaySpace.Strategy.Context;

namespace PaySpace.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaxController _taxController;
        private TaxCalculatorContext _context;
        private int _nettPay;

        [BindProperty]
        public int Income { get; set; }

        [BindProperty]
        public string PostalCode { get; set; }

        public int PostalCodeId { get; set; }

        public IndexModel()
        {
             _taxController = new TaxController();
        }

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

            // Call the different context strategies depending on income range then save to the database
            switch (this.PostalCodeId)
            {
                case 1:
                    _context.TaxCalculator(new ProgressiveTaxCalculator());
                    _nettPay = _context.ContextInterface(this.Income);
                    //_taxController.CalculateTax();
                    break;

                case 2:
                    _context.TaxCalculator(new FlatValueTaxCalculator());
                    _nettPay = _context.ContextInterface(this.Income);
                    //_taxController.CalculateTax();
                    break;

                case 3:
                    _context.TaxCalculator(new FlatRateTaxCalculator());
                    _nettPay = _context.ContextInterface(this.Income);
                    //_taxController.CalculateTax();
                    break;

                case 4:
                    _context.TaxCalculator(new ProgressiveTaxCalculator());
                    _nettPay = _context.ContextInterface(this.Income);
                    //_taxController.CalculateTax();
                    break;
            }

            return Page(); // Return the same page after form submission.
        }
    }
}
