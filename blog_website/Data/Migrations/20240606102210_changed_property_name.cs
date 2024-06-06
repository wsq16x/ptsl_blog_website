using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog_website.Data.Migrations
{
    /// <inheritdoc />
    public partial class changed_property_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "BlogPosts",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "BlogPosts",
                newName: "content");
        }
    }
}
