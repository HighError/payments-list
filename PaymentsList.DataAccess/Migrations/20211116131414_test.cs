using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentsList.DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Groups_GroupId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_IssuerId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_RecipientId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_RecipientId",
                table: "Payments",
                newName: "IX_Payments_RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_IssuerId",
                table: "Payments",
                newName: "IX_Payments_IssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_GroupId",
                table: "Payments",
                newName: "IX_Payments_GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Groups_GroupId",
                table: "Payments",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_IssuerId",
                table: "Payments",
                column: "IssuerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_RecipientId",
                table: "Payments",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Groups_GroupId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_IssuerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_RecipientId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Users_Name",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Groups_Name",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_RecipientId",
                table: "Payment",
                newName: "IX_Payment_RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_IssuerId",
                table: "Payment",
                newName: "IX_Payment_IssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_GroupId",
                table: "Payment",
                newName: "IX_Payment_GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Groups_GroupId",
                table: "Payment",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_IssuerId",
                table: "Payment",
                column: "IssuerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_RecipientId",
                table: "Payment",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
