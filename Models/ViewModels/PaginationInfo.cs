namespace Mission11_Ashcroft.Models.ViewModels
{
    public class PaginationInfo
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        //Calculation to dynamically find the total number of pages based on the total items and the set number of items per page
        public int TotalPages => (int)(Math.Ceiling((decimal)TotalItems / ItemsPerPage));
    }
}
