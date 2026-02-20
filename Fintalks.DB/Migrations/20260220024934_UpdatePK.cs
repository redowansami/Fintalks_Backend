using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fintalks.DB.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Users", table: "Users");

            migrationBuilder
                .AddColumn<int>(
                    name: "ID",
                    table: "Users",
                    type: "int",
                    nullable: false,
                    defaultValue: 0
                )
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(name: "PK_Users", table: "Users", column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID",
                table: "Users",
                column: "UserID",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Users", table: "Users");

            migrationBuilder.DropIndex(name: "IX_Users_UserID", table: "Users");

            migrationBuilder.DropColumn(name: "ID", table: "Users");

            migrationBuilder.AddPrimaryKey(name: "PK_Users", table: "Users", column: "UserID");
        }
    }
}
