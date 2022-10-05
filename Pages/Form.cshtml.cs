using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Neil.SaveJsonFile_.Pages
{
    public class FormViewModel : PageModel
    {
        [BindProperty]
        public StudentViewModel? ViewModel { get; set; }
        public IActionResult OnGet(string? firstName)
        {
            this.ViewModel = new StudentViewModel();
            this.ViewModel.FirstName = firstName;

            return Page();
        }
        public IActionResult OnPost()
        {
            string fileName = @"C:\Temp\diana.txt";
            {
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    var fileText = "{studentNumber:" + this.ViewModel.StudentNumber + "''";
                    fileText = "{firstName:" + this.ViewModel.FirstName + "''";
                    fileText = "{lastName:" + this.ViewModel.LastName + "''";
                    fileText = "{dateofBirth" + this.ViewModel.DateofBirth + "''";
                    fileText = "{yearLevel:" + this.ViewModel.YearLevel + "''";
                    fileText = "{course:" + this.ViewModel.Course + "''";


                    Byte[] title = new UTF8Encoding(true).GetBytes(fileText);
                    fs.Write(title, 0, title.Length);

                }

            }

            return Page();

        }
        public class StudentViewModel
        {
            public string? StudentNumber { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? YearLevel { get; set; }
            public string? DateofBirth { get; set; }
            public string? Course { get; set; }

        }


        public enum Course
        {
            BSIS,
            BSTM,
            BSCA,
            BSBA,
            BSCRIM
        }

    }

}