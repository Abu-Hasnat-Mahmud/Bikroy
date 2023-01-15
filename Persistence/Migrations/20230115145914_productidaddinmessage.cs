using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class productidaddinmessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Message",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Message_PostId",
                table: "Message",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Post_PostId",
                table: "Message",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Post_PostId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_PostId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Message");
        }
    }
}
