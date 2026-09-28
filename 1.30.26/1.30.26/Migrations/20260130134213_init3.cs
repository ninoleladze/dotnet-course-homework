using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1._30._26.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_courses_CourseId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_students_StudentId",
                table: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudent_CourseId",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseStudent");

            migrationBuilder.RenameTable(
                name: "CourseStudent",
                newName: "courseStudents");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentId",
                table: "courseStudents",
                newName: "IX_courseStudents_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courseStudents",
                table: "courseStudents",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_courseStudents_courses_CourseId",
                table: "courseStudents",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_courseStudents_students_StudentId",
                table: "courseStudents",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseStudents_courses_CourseId",
                table: "courseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_courseStudents_students_StudentId",
                table: "courseStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courseStudents",
                table: "courseStudents");

            migrationBuilder.RenameTable(
                name: "courseStudents",
                newName: "CourseStudent");

            migrationBuilder.RenameIndex(
                name: "IX_courseStudents_StudentId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseStudent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_CourseId",
                table: "CourseStudent",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_courses_CourseId",
                table: "CourseStudent",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_students_StudentId",
                table: "CourseStudent",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
