using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fintalks.DB.Migrations.v1
{
    /// <inheritdoc />
    public partial class CreateUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nid = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DBUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserInfos_Users_DBUserID",
                        column: x => x.DBUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_DBUserID",
                table: "UserInfos",
                column: "DBUserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
