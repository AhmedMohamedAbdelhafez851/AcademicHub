using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademifyHub.Migrations
{
    /// <inheritdoc />
    public partial class Add_RelationTo_Exam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntrviewExams_Courses_CourseId",
                table: "IntrviewExams");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceExams_Courses_CourseId",
                table: "MultipleChoiceExams");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueAndFalses_Courses_CourseId",
                table: "TrueAndFalses");

            migrationBuilder.DropForeignKey(
                name: "FK_WrittenExams_Courses_CourseId",
                table: "WrittenExams");

            migrationBuilder.DropIndex(
                name: "IX_WrittenExams_CourseId",
                table: "WrittenExams");

            migrationBuilder.DropIndex(
                name: "IX_TrueAndFalses_CourseId",
                table: "TrueAndFalses");

            migrationBuilder.DropIndex(
                name: "IX_MultipleChoiceExams_CourseId",
                table: "MultipleChoiceExams");

            migrationBuilder.DropIndex(
                name: "IX_IntrviewExams_CourseId",
                table: "IntrviewExams");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WrittenExams_CourseId",
                table: "WrittenExams",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrueAndFalses_CourseId",
                table: "TrueAndFalses",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceExams_CourseId",
                table: "MultipleChoiceExams",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IntrviewExams_CourseId",
                table: "IntrviewExams",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IntrviewExams_Courses_CourseId",
                table: "IntrviewExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceExams_Courses_CourseId",
                table: "MultipleChoiceExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrueAndFalses_Courses_CourseId",
                table: "TrueAndFalses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WrittenExams_Courses_CourseId",
                table: "WrittenExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntrviewExams_Courses_CourseId",
                table: "IntrviewExams");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceExams_Courses_CourseId",
                table: "MultipleChoiceExams");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueAndFalses_Courses_CourseId",
                table: "TrueAndFalses");

            migrationBuilder.DropForeignKey(
                name: "FK_WrittenExams_Courses_CourseId",
                table: "WrittenExams");

            migrationBuilder.DropIndex(
                name: "IX_WrittenExams_CourseId",
                table: "WrittenExams");

            migrationBuilder.DropIndex(
                name: "IX_TrueAndFalses_CourseId",
                table: "TrueAndFalses");

            migrationBuilder.DropIndex(
                name: "IX_MultipleChoiceExams_CourseId",
                table: "MultipleChoiceExams");

            migrationBuilder.DropIndex(
                name: "IX_IntrviewExams_CourseId",
                table: "IntrviewExams");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenExams_CourseId",
                table: "WrittenExams",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrueAndFalses_CourseId",
                table: "TrueAndFalses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceExams_CourseId",
                table: "MultipleChoiceExams",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_IntrviewExams_CourseId",
                table: "IntrviewExams",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntrviewExams_Courses_CourseId",
                table: "IntrviewExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceExams_Courses_CourseId",
                table: "MultipleChoiceExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueAndFalses_Courses_CourseId",
                table: "TrueAndFalses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WrittenExams_Courses_CourseId",
                table: "WrittenExams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
