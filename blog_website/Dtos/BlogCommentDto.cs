namespace blog_website.Dtos
{
    public class BlogCommentDto
    {
    }

    public class BlogCommentCreateDto
    {
        public string UserId { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int BlogPostId { get; set; }
    }

    public class BlogCommentEditDto : BlogCommentCreateDto
    {
        public int Id { get; set; }
    }
}
