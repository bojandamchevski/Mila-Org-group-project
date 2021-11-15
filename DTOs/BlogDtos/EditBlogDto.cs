namespace DTOs.BlogDtos
{
    public class EditBlogDto 
    {
        public string Title { get; set; }
        public string ImgURL { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
