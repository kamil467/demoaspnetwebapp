using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class removedAnnotationForCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "city",
                table: "regions",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "regions",
                newName: "city");
        }
    }
}
