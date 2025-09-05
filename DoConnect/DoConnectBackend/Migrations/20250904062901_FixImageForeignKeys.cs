using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoConnectBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixImageForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Answers_AnswerId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Questions_QuestionId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Answers_AnswerId",
                table: "Images",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Questions_QuestionId",
                table: "Images",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Answers_AnswerId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Questions_QuestionId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Answers_AnswerId",
                table: "Images",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Questions_QuestionId",
                table: "Images",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
