using knihovnaWebApplication.WebMvcApp.Entities;

namespace knihovnaWebApplication.WebMvcApp.Models
{
    public class BranchDetailModel
    {
        public string BranchName { get; set; }
        public List<Book> BooksInBranch { get; set; }

        public BranchDetailModel(string branchName, List<Book> booksInBranch)
        {
            BranchName = branchName;
            BooksInBranch = booksInBranch;
        }
    }
}
