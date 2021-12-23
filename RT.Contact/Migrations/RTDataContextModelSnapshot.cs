﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RT.Contacts.DataLayer;

namespace RT.Contacts.Migrations
{
    [DbContext(typeof(RTDataContext))]
    partial class RTDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:Collation", "Turkish_Turkey.1252")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("RT.Contact.DataLayer.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("date");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("integer")
                        .HasColumnName("CreateUserID");

                    b.Property<string>("ExternalSystemCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("date");

                    b.Property<int>("UpdateUserId")
                        .HasColumnType("integer")
                        .HasColumnName("UpdateUserID");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("RT.Contact.DataLayer.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("date");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("integer")
                        .HasColumnName("CreateUserID");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("date");

                    b.Property<int>("UpdateUserId")
                        .HasColumnType("integer")
                        .HasColumnName("UpdateUserID");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("UUID");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RT.Contact.DataLayer.UserInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CityId")
                        .HasColumnType("integer")
                        .HasColumnName("CityID");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("date");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("integer")
                        .HasColumnName("CreateUserID");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("date");

                    b.Property<int>("UpdateUserId")
                        .HasColumnType("integer")
                        .HasColumnName("UpdateUserID");

                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInformation");
                });

            modelBuilder.Entity("RT.Contact.DataLayer.UserInformation", b =>
                {
                    b.HasOne("RT.Contact.DataLayer.City", "City")
                        .WithMany("UserInformations")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_City");

                    b.HasOne("RT.Contact.DataLayer.User", "User")
                        .WithMany("UserInformations")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_User_Info")
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RT.Contact.DataLayer.City", b =>
                {
                    b.Navigation("UserInformations");
                });

            modelBuilder.Entity("RT.Contact.DataLayer.User", b =>
                {
                    b.Navigation("UserInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
