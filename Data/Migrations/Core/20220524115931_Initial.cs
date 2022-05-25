using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations.Core
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListItemCategory",
                columns: table => new
                {
                    ListCategoryId = table.Column<string>(type: "text", nullable: false),
                    ListCategoryName = table.Column<string>(type: "text", nullable: false),
                    InsertPersonId = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatePersonId = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItemCategory", x => x.ListCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    InsertPersonId = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatePersonId = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    ProductCode = table.Column<string>(type: "text", nullable: false),
                    ParentProductId = table.Column<string>(type: "text", nullable: true),
                    InsertPersonId = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatePersonId = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    RoleSystemName = table.Column<string>(type: "text", nullable: false),
                    InsertPersonId = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatePersonId = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ListItem",
                columns: table => new
                {
                    ListItemId = table.Column<string>(type: "text", nullable: false),
                    ListItemName = table.Column<string>(type: "text", nullable: false),
                    ListItemCategoryId = table.Column<string>(type: "text", nullable: false),
                    InsertPersonId = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatePersonId = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItem", x => x.ListItemId);
                    table.ForeignKey(
                        name: "FK_ListItem_ListItemCategory_ListItemCategoryId",
                        column: x => x.ListItemCategoryId,
                        principalTable: "ListItemCategory",
                        principalColumn: "ListCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PersonId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    InsertPersonId = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatePersonId = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<string>(type: "text", nullable: false),
                    VendorName = table.Column<string>(type: "text", nullable: false),
                    VendorTypeListItem = table.Column<string>(type: "text", nullable: false),
                    VendorStatusListItem = table.Column<string>(type: "text", nullable: false),
                    TaxRegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    InsertPersonId = table.Column<string>(type: "text", nullable: false),
                    InsertDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatePersonId = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                    table.ForeignKey(
                        name: "FK_Vendor_ListItem_VendorStatusListItem",
                        column: x => x.VendorStatusListItem,
                        principalTable: "ListItem",
                        principalColumn: "ListItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendor_ListItem_VendorTypeListItem",
                        column: x => x.VendorTypeListItem,
                        principalTable: "ListItem",
                        principalColumn: "ListItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ListItemCategory",
                columns: new[] { "ListCategoryId", "InsertDate", "InsertPersonId", "ListCategoryName", "UpdateDate", "UpdatePersonId" },
                values: new object[,]
                {
                    { "VS-01", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1315), new TimeSpan(0, 0, 0, 0, 0)), "1", "Vendor Status", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1316), new TimeSpan(0, 0, 0, 0, 0)), "1" },
                    { "VT-01", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1305), new TimeSpan(0, 0, 0, 0, 0)), "1", "Vendor Type", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1306), new TimeSpan(0, 0, 0, 0, 0)), "1" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "InsertDate", "InsertPersonId", "Name", "UpdateDate", "UpdatePersonId" },
                values: new object[,]
                {
                    { "che32092d-d2dc-4a6a-a0b0-a4a482d21c07", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1282), new TimeSpan(0, 0, 0, 0, 0)), "1", "Check", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1282), new TimeSpan(0, 0, 0, 0, 0)), "1" },
                    { "fc32092d-d2dc-4a6a-a0b0-a4a482d21c07", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1246), new TimeSpan(0, 0, 0, 0, 0)), "1", "superadmin", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1247), new TimeSpan(0, 0, 0, 0, 0)), "1" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "InsertDate", "InsertPersonId", "RoleName", "RoleSystemName", "UpdateDate", "UpdatePersonId" },
                values: new object[] { "d0b3eab9-9f9d-45cc-95c0-b28fb7062868", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1109), new TimeSpan(0, 0, 0, 0, 0)), "1", "Super Admin", "superadmin", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1114), new TimeSpan(0, 0, 0, 0, 0)), "1" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Email", "InsertDate", "InsertPersonId", "PasswordHash", "PersonId", "PhoneNumber", "RoleId", "UpdateDate", "UpdatePersonId", "UserName" },
                values: new object[,]
                {
                    { "5b6cd63e-e6bb-4168-bb33-ae73952c716f", "superadmin@project.com", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1267), new TimeSpan(0, 0, 0, 0, 0)), "1", "AQAAAAEAAYagAAAAECYRvg4UxADgEMkvzWBbZ7BzwVeMhe23Iu/Yc2XANppkQ3VwbLpWuwPjziLJHQfoyA==", "fc32092d-d2dc-4a6a-a0b0-a4a482d21c07", "9841111111", "d0b3eab9-9f9d-45cc-95c0-b28fb7062868", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1268), new TimeSpan(0, 0, 0, 0, 0)), "1", "superadmin" },
                    { "test555-e6bb-4168-bb33-ae73952c716f", "test@mail.com", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1293), new TimeSpan(0, 0, 0, 0, 0)), "1", "AQAAAAEAAYagAAAAECYRvg4UxADgEMkvzWBbZ7BzwVeMhe23Iu/Yc2XANppkQ3VwbLpWuwPjziLJHQfoyA==", "che32092d-d2dc-4a6a-a0b0-a4a482d21c07", "984111111", "d0b3eab9-9f9d-45cc-95c0-b28fb7062868", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1294), new TimeSpan(0, 0, 0, 0, 0)), "1", "Test" }
                });

            migrationBuilder.InsertData(
                table: "ListItem",
                columns: new[] { "ListItemId", "InsertDate", "InsertPersonId", "ListItemCategoryId", "ListItemName", "UpdateDate", "UpdatePersonId" },
                values: new object[,]
                {
                    { "VSL-01", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1341), new TimeSpan(0, 0, 0, 0, 0)), "1", "VS-01", "Active", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1342), new TimeSpan(0, 0, 0, 0, 0)), "1" },
                    { "VSL-02", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1348), new TimeSpan(0, 0, 0, 0, 0)), "1", "VS-01", "Inactive", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1349), new TimeSpan(0, 0, 0, 0, 0)), "1" },
                    { "VTI-01", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1325), new TimeSpan(0, 0, 0, 0, 0)), "1", "VT-01", "PAN", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1325), new TimeSpan(0, 0, 0, 0, 0)), "1" },
                    { "VTI-02", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1333), new TimeSpan(0, 0, 0, 0, 0)), "1", "VT-01", "VAT", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1334), new TimeSpan(0, 0, 0, 0, 0)), "1" }
                });

            migrationBuilder.InsertData(
                table: "Vendor",
                columns: new[] { "VendorId", "InsertDate", "InsertPersonId", "TaxRegistrationNumber", "UpdateDate", "UpdatePersonId", "VendorName", "VendorStatusListItem", "VendorTypeListItem" },
                values: new object[] { "V-01", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1363), new TimeSpan(0, 0, 0, 0, 0)), "1", "123456789", new DateTimeOffset(new DateTime(2022, 5, 24, 11, 59, 30, 796, DateTimeKind.Unspecified).AddTicks(1363), new TimeSpan(0, 0, 0, 0, 0)), "1", "SK Suppliers", "VSL-01", "VTI-01" });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonId",
                table: "Employee",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId",
                table: "Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserName",
                table: "Employee",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ListItemCategoryId",
                table: "ListItem",
                column: "ListItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ListItemName",
                table: "ListItem",
                column: "ListItemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListItemCategory_ListCategoryName",
                table: "ListItemCategory",
                column: "ListCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCode",
                table: "Product",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductName_ParentProductId",
                table: "Product",
                columns: new[] { "ProductName", "ParentProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_VendorName",
                table: "Vendor",
                column: "VendorName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_VendorStatusListItem",
                table: "Vendor",
                column: "VendorStatusListItem");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_VendorTypeListItem",
                table: "Vendor",
                column: "VendorTypeListItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "ListItemCategory");
        }
    }
}
