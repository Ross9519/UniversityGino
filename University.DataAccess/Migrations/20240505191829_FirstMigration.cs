using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "office_staff",
                columns: table => new
                {
                    staff_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fiscal_code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telephone_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office_staff", x => x.staff_id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_no = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fiscal_code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telephone_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    subject_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hours_no = table.Column<int>(type: "int", nullable: false),
                    professor_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    professor_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_id = table.Column<long>(type: "bigint", maxLength: 100, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fiscal_code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telephone_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor", x => x.professor_id);
                    table.ForeignKey(
                        name: "FK_professor_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "student_subject",
                columns: table => new
                {
                    student_id = table.Column<long>(type: "bigint", nullable: false),
                    subject_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_subject", x => new { x.student_id, x.subject_id });
                    table.ForeignKey(
                        name: "FK_student_subject_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id");
                    table.ForeignKey(
                        name: "FK_student_subject_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id");
                });

            migrationBuilder.CreateTable(
                name: "exam",
                columns: table => new
                {
                    student_id = table.Column<long>(type: "bigint", nullable: false),
                    professor_id = table.Column<long>(type: "bigint", nullable: false),
                    subject_id = table.Column<long>(type: "bigint", nullable: false),
                    exam_grade = table.Column<int>(type: "int", nullable: false),
                    exam_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam", x => new { x.student_id, x.professor_id, x.subject_id });
                    table.ForeignKey(
                        name: "FK_exam_professor_professor_id",
                        column: x => x.professor_id,
                        principalTable: "professor",
                        principalColumn: "professor_id");
                    table.ForeignKey(
                        name: "FK_exam_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exam_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id");
                });

            migrationBuilder.InsertData(
                table: "office_staff",
                columns: new[] { "staff_id", "active", "address", "first_name", "fiscal_code", "last_name", "telephone_no" },
                values: new object[,]
                {
                    { 1L, true, "123 Main St", "Alice", "ABC123", "Jones", "555-1234" },
                    { 2L, true, "456 Oak St", "Bob", "DEF456", "Smith", "555-5678" },
                    { 3L, true, "789 Elm St", "Carol", "GHI789", "Brown", "555-9012" },
                    { 4L, false, "012 Pine St", "David", "JKL012", "Wilson", null },
                    { 5L, true, "345 Cedar St", "Eva", "MNO345", "Marquez", "555-3456" }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "student_id", "active", "address", "first_name", "fiscal_code", "last_name", "student_no", "telephone_no" },
                values: new object[,]
                {
                    { 1L, true, "123 Main St", "Alice", "ABC123", "Smith", "STU001", "555-1234" },
                    { 2L, true, "456 Oak St", "Bob", "DEF456", "Johnson", "STU002", "555-5678" },
                    { 3L, true, "789 Elm St", "Charlie", "GHI789", "Brown", "STU003", "555-9012" },
                    { 4L, false, "012 Pine St", "Diana", "JKL012", "Wilson", "STU004", null },
                    { 5L, true, "345 Cedar St", "Eva", "MNO345", "Garcia", "STU005", "555-3456" }
                });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "subject_id", "hours_no", "subject_name", "professor_id" },
                values: new object[,]
                {
                    { 1L, 4, "Mathematics", 1L },
                    { 2L, 3, "Physics", 2L },
                    { 3L, 3, "Chemistry", 3L },
                    { 4L, 3, "Biology", 4L },
                    { 5L, 2, "English Literature", 5L }
                });

            migrationBuilder.InsertData(
                table: "professor",
                columns: new[] { "professor_id", "active", "address", "first_name", "fiscal_code", "last_name", "subject_id", "telephone_no" },
                values: new object[,]
                {
                    { 1L, true, "123 Main St", "John", "ABC123", "Doe", 1L, "555-1234" },
                    { 2L, true, "456 Oak St", "Jane", "DEF456", "Smith", 2L, "555-5678" },
                    { 3L, true, "789 Elm St", "Michael", "GHI789", "Johnson", 3L, "555-9012" },
                    { 4L, false, "012 Pine St", "Emily", "JKL012", "Brown", 4L, null },
                    { 5L, true, "345 Cedar St", "Daniel", "MNO345", "Wilson", 5L, "555-3456" }
                });

            migrationBuilder.InsertData(
                table: "student_subject",
                columns: new[] { "student_id", "subject_id" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 2L },
                    { 2L, 1L },
                    { 2L, 3L },
                    { 3L, 2L }
                });

            migrationBuilder.InsertData(
                table: "exam",
                columns: new[] { "professor_id", "student_id", "subject_id", "exam_date", "exam_grade" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 5, 5, 21, 18, 27, 927, DateTimeKind.Local).AddTicks(2123), 85 },
                    { 2L, 1L, 2L, new DateTime(2024, 4, 14, 21, 18, 27, 932, DateTimeKind.Local).AddTicks(6872), 78 },
                    { 1L, 2L, 1L, new DateTime(2024, 3, 24, 21, 18, 27, 932, DateTimeKind.Local).AddTicks(6924), 92 },
                    { 2L, 2L, 3L, new DateTime(2024, 3, 3, 21, 18, 27, 932, DateTimeKind.Local).AddTicks(6929), 89 },
                    { 1L, 3L, 2L, new DateTime(2024, 2, 11, 21, 18, 27, 932, DateTimeKind.Local).AddTicks(6932), 75 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_exam_professor_id",
                table: "exam",
                column: "professor_id");

            migrationBuilder.CreateIndex(
                name: "IX_exam_subject_id",
                table: "exam",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_professor_subject_id",
                table: "professor",
                column: "subject_id",
                unique: true,
                filter: "[subject_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_student_subject_subject_id",
                table: "student_subject",
                column: "subject_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exam");

            migrationBuilder.DropTable(
                name: "office_staff");

            migrationBuilder.DropTable(
                name: "student_subject");

            migrationBuilder.DropTable(
                name: "professor");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject");
        }
    }
}
