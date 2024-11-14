using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "body",
                table: "posts",
                newName: "tryandexpecting");

            migrationBuilder.AddColumn<string>(
                name: "detailproblem",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "detailproblem",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "tryandexpecting",
                table: "posts",
                newName: "body");
        }
    }
}
