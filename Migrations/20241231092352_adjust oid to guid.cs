using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Migrations
{
    /// <inheritdoc />
    public partial class adjustoidtoguid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Xóa khóa chính hiện tại
            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            // 2. Tạo cột mới với GUID
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Votes",
                nullable: false,
                defaultValueSql: "NEWID()");

            // 3. Sao chép dữ liệu từ cột cũ (nếu cần giữ)
            migrationBuilder.Sql(
                "UPDATE Votes SET TempId = NEWID()");

            // 4. Đặt cột mới làm khóa chính
            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "TempId");

            // 5. Xóa cột cũ
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Votes");

            // 6. Đổi tên cột mới thành 'Id' (giữ nguyên tên cột)
            migrationBuilder.RenameColumn(
                name: "TempId",
                newName: "Id",
                table: "Votes");
            // 1. Xóa khóa chính hiện tại
            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            // 2. Tạo cột mới với kiểu uniqueidentifier
            migrationBuilder.AddColumn<Guid>(
                name: "TempId",
                table: "Votes",
                nullable: false,
                defaultValueSql: "NEWID()"); // Tạo GUID tự động

            // 3. Đặt cột mới làm khóa chính
            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "TempId");

            // 4. Xóa cột cũ
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Votes");

            // 5. Đổi tên cột mới thành 'Id' (giữ nguyên tên cột)
            migrationBuilder.RenameColumn(
                name: "TempId",
                newName: "Id",
                table: "Votes");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Votes",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
