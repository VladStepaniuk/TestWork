namespace TestWork.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<Category> Subcategories { get; set; }
    }
}
