using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi_test.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalDevices",
                table: "Experiments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeviceToken",
                table: "ExperimentResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExperimentOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevicesCount = table.Column<int>(type: "int", nullable: false),
                    ExperimentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperimentOption_Experiments_ExperimentId",
                        column: x => x.ExperimentId,
                        principalTable: "Experiments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentOption_ExperimentId",
                table: "ExperimentOption",
                column: "ExperimentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperimentOption");

            migrationBuilder.DropColumn(
                name: "TotalDevices",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "DeviceToken",
                table: "ExperimentResults");
        }
    }
}
