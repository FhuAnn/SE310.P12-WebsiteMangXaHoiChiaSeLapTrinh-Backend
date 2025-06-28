using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Migrations
{
    /// <inheritdoc />
    public partial class editpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "posts");
        }
    }
}
