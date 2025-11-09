using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftLogger.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseModifcationRelationShipCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ShiftStart",
                table: "ShiftDetails",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShiftDetails",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ShiftStatus",
                table: "ShiftDetails",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftDetails_EmployeeId",
                table: "ShiftDetails",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftDetails_EmployeeList_EmployeeId",
                table: "ShiftDetails",
                column: "EmployeeId",
                principalTable: "EmployeeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShiftDetails_EmployeeList_EmployeeId",
                table: "ShiftDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShiftDetails_EmployeeId",
                table: "ShiftDetails");

            migrationBuilder.DropColumn(
                name: "ShiftStatus",
                table: "ShiftDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShiftStart",
                table: "ShiftDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ShiftDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
