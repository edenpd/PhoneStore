using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneStore.Migrations
{
    public partial class weight_col_added_to_phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Phone",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Phone");
        }
    }
}
