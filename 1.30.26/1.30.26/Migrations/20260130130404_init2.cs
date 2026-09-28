using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1._30._26.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_courses_CoursesId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_students_StudentsId",
                table: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "CourseStudent",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseStudent",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseStudent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedAt",
                table: "CourseStudent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "JoinedAt",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CourseStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseStudent",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "CoursesId", "StudentsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_courses_CoursesId",
                table: "CourseStudent",
                column: "CoursesId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_students_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
