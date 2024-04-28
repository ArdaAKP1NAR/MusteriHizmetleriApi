using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerServiceLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerServiceDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HourlyPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customerServiceOffices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerServiceOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customerServiceOffices_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallLogDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Complain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerServiceOfficeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallLogs_customerServiceOffices_CustomerServiceOfficeId",
                        column: x => x.CustomerServiceOfficeId,
                        principalTable: "customerServiceOffices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    customerServiceOfficeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_customerServiceOffices_customerServiceOfficeId",
                        column: x => x.customerServiceOfficeId,
                        principalTable: "customerServiceOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WeeklyWorkingHours = table.Column<int>(type: "int", nullable: false),
                    WageId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerServiceOfficeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Wages_WageId",
                        column: x => x.WageId,
                        principalTable: "Wages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workers_customerServiceOffices_CustomerServiceOfficeId",
                        column: x => x.CustomerServiceOfficeId,
                        principalTable: "customerServiceOffices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PayHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<long>(type: "bigint", nullable: false),
                    HoursWorked = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayHistory_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<long>(type: "bigint", nullable: false),
                    WorkedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoursWorked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHistory_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallLogs_CustomerServiceOfficeId",
                table: "CallLogs",
                column: "CustomerServiceOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_customerServiceOfficeId",
                table: "Customers",
                column: "customerServiceOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_customerServiceOffices_CompanyId",
                table: "customerServiceOffices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PayHistory_WorkerId",
                table: "PayHistory",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CustomerServiceOfficeId",
                table: "Workers",
                column: "CustomerServiceOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WageId",
                table: "Workers",
                column: "WageId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_WorkerId",
                table: "WorkHistory",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallLogs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PayHistory");

            migrationBuilder.DropTable(
                name: "WorkHistory");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Wages");

            migrationBuilder.DropTable(
                name: "customerServiceOffices");

            migrationBuilder.DropTable(
                name: "Companys");
        }
    }
}
