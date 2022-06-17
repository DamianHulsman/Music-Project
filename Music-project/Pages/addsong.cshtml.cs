//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace Music_project.Pages
//{
//    public class addsongModel : PageModel
//    {
//        public void OnGet()
//        {
//        }

//        public void OnPostUpload(List<IFormFile> uploadedFiles)
//        {
//            string path = Environment.WebRootPath + "\\Uploads";
//            if (!Directory.Exists(path))
//            {
//                Directory.CreateDirectory(path);

//            }
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Music_project.Pages
{
    public class addsongModel : PageModel
    {
        private IWebHostEnvironment Environment;

        public addsongModel(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public void OnGet()
        {

        }

        public void OnPostUpload(List<IFormFile> oFile)
        {
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<string> uploadedFiles = new List<string>();
            foreach (IFormFile postedFile in oFile)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                    // this.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }
        }
    }
}