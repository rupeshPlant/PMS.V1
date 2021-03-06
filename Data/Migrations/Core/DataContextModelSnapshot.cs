// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations.Core
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTimeOffset>("InsertDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InsertPersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatePersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = "5b6cd63e-e6bb-4168-bb33-ae73952c716f",
                            Email = "superadmin@project.com",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5401), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            PasswordHash = "AQAAAAEAAYagAAAAECYRvg4UxADgEMkvzWBbZ7BzwVeMhe23Iu/Yc2XANppkQ3VwbLpWuwPjziLJHQfoyA==",
                            PersonId = "fc32092d-d2dc-4a6a-a0b0-a4a482d21c07",
                            PhoneNumber = "9841111111",
                            RoleId = "d0b3eab9-9f9d-45cc-95c0-b28fb7062868",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1",
                            UserName = "superadmin"
                        },
                        new
                        {
                            EmployeeId = "test555-e6bb-4168-bb33-ae73952c716f",
                            Email = "test@mail.com",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5425), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            PasswordHash = "AQAAAAEAAYagAAAAECYRvg4UxADgEMkvzWBbZ7BzwVeMhe23Iu/Yc2XANppkQ3VwbLpWuwPjziLJHQfoyA==",
                            PersonId = "che32092d-d2dc-4a6a-a0b0-a4a482d21c07",
                            PhoneNumber = "984111111",
                            RoleId = "d0b3eab9-9f9d-45cc-95c0-b28fb7062868",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5425), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1",
                            UserName = "Test"
                        });
                });

            modelBuilder.Entity("Entities.ListItem.ListItem", b =>
                {
                    b.Property<string>("ListItemId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("InsertDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InsertPersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ListItemCategoryId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ListItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatePersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ListItemId");

                    b.HasIndex("ListItemCategoryId");

                    b.HasIndex("ListItemName")
                        .IsUnique();

                    b.ToTable("ListItem");

                    b.HasData(
                        new
                        {
                            ListItemId = "VTI-01",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5457), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            ListItemCategoryId = "VT-01",
                            ListItemName = "PAN",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5458), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        },
                        new
                        {
                            ListItemId = "VTI-02",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5466), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            ListItemCategoryId = "VT-01",
                            ListItemName = "VAT",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5467), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        },
                        new
                        {
                            ListItemId = "VSL-01",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5473), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            ListItemCategoryId = "VS-01",
                            ListItemName = "Active",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5474), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        },
                        new
                        {
                            ListItemId = "VSL-02",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            ListItemCategoryId = "VS-01",
                            ListItemName = "Inactive",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5480), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        });
                });

            modelBuilder.Entity("Entities.ListItem.ListItemCategory", b =>
                {
                    b.Property<string>("ListCategoryId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("InsertDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InsertPersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ListCategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatePersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ListCategoryId");

                    b.HasIndex("ListCategoryName")
                        .IsUnique();

                    b.ToTable("ListItemCategory");

                    b.HasData(
                        new
                        {
                            ListCategoryId = "VT-01",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5438), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            ListCategoryName = "Vendor Type",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5438), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        },
                        new
                        {
                            ListCategoryId = "VS-01",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            ListCategoryName = "Vendor Status",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5447), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        });
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("InsertDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InsertPersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatePersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PersonId");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            PersonId = "fc32092d-d2dc-4a6a-a0b0-a4a482d21c07",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5369), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            Name = "superadmin",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5370), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        },
                        new
                        {
                            PersonId = "che32092d-d2dc-4a6a-a0b0-a4a482d21c07",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5414), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            Name = "Check",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5415), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        });
                });

            modelBuilder.Entity("Entities.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("InsertDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InsertPersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoleSystemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatePersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleId = "d0b3eab9-9f9d-45cc-95c0-b28fb7062868",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5173), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            RoleName = "Super Admin",
                            RoleSystemName = "superadmin",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5180), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1"
                        });
                });

            modelBuilder.Entity("Entities.Vendor.Vendor", b =>
                {
                    b.Property<string>("VendorId")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("InsertDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InsertPersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TaxRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatePersonId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VendorStatusListItem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VendorTypeListItem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VendorId");

                    b.HasIndex("VendorName")
                        .IsUnique();

                    b.HasIndex("VendorStatusListItem");

                    b.HasIndex("VendorTypeListItem");

                    b.ToTable("Vendor");

                    b.HasData(
                        new
                        {
                            VendorId = "V-01",
                            InsertDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5491), new TimeSpan(0, 0, 0, 0, 0)),
                            InsertPersonId = "1",
                            TaxRegistrationNumber = "123456789",
                            UpdateDate = new DateTimeOffset(new DateTime(2022, 5, 24, 7, 28, 55, 489, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 0, 0, 0, 0)),
                            UpdatePersonId = "1",
                            VendorName = "SK Suppliers",
                            VendorStatusListItem = "VSL-01",
                            VendorTypeListItem = "VTI-01"
                        });
                });

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.HasOne("Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Entities.ListItem.ListItem", b =>
                {
                    b.HasOne("Entities.ListItem.ListItemCategory", "ListItemCategory")
                        .WithMany()
                        .HasForeignKey("ListItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ListItemCategory");
                });

            modelBuilder.Entity("Entities.Vendor.Vendor", b =>
                {
                    b.HasOne("Entities.ListItem.ListItem", "StatusListItem")
                        .WithMany()
                        .HasForeignKey("VendorStatusListItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.ListItem.ListItem", "TypeListItem")
                        .WithMany()
                        .HasForeignKey("VendorTypeListItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusListItem");

                    b.Navigation("TypeListItem");
                });
#pragma warning restore 612, 618
        }
    }
}
