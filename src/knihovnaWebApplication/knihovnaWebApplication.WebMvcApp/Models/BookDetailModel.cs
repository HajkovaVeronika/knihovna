using knihovnaWebApplication.WebMvcApp.Entities;

namespace knihovnaWebApplication.WebMvcApp.Models
{
    public class BookDetailModel
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public Book Book { get; set; }

        public BookDetailModel(int branchId, string branchName, Book book)
        {
            BranchId = branchId;
            BranchName = branchName;
            Book = book;
        }
    }
}
