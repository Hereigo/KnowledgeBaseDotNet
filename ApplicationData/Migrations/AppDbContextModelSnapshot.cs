﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Profile", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AaaType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("AdditionalName");

                    b.Property<string>("AdditionalNameYomi")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("AdditionalNameYomi");

                    b.Property<string>("Address1City")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1City");

                    b.Property<string>("Address1Country")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Country");

                    b.Property<string>("Address1ExtendedAddress")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1ExtendedAddress");

                    b.Property<string>("Address1Formatted")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Formatted");

                    b.Property<string>("Address1POBox")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1POBox");

                    b.Property<string>("Address1PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1PostalCode");

                    b.Property<string>("Address1Region")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Region");

                    b.Property<string>("Address1Street")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Street");

                    b.Property<string>("Address1Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Type");

                    b.Property<string>("BillingInformation")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("BillingInformation");

                    b.Property<string>("Birthday")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Birthday");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomField1Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomField1Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DirectoryServer")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DirectoryServer");

                    b.Property<string>("Email1Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email1Type");

                    b.Property<string>("Email1Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email1Value");

                    b.Property<string>("Email2Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email2Type");

                    b.Property<string>("Email2Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email2Value");

                    b.Property<string>("Email3Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email3Type");

                    b.Property<string>("Email3Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email3Value");

                    b.Property<string>("Event1Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Event1Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("FamilyName");

                    b.Property<string>("FamilyNameYomi")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("FamilyNameYomi");

                    b.Property<string>("FileUploaded")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Gender");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("GivenName");

                    b.Property<string>("GivenNameYomi")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("GivenNameYomi");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupMembership")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("GroupMembership");

                    b.Property<string>("Hobby")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Hobby");

                    b.Property<string>("IM1Service")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("IM1Service");

                    b.Property<string>("IM1Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("IM1Type");

                    b.Property<string>("IM1Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("IM1Value");

                    b.Property<string>("IM2Service")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("IM2Service");

                    b.Property<string>("IM2Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("IM2Type");

                    b.Property<string>("IM2Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("IM2Value");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Initials");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Language");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Location");

                    b.Property<string>("MaidenName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("MaidenName");

                    b.Property<string>("Mileage")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Mileage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<string>("NamePrefix")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("NamePrefix");

                    b.Property<string>("NameSuffix")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("NameSuffix");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nickname");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Notes");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Occupation");

                    b.Property<string>("Organization1Department")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Department");

                    b.Property<string>("Organization1JobDescription")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("OrganizationJobDescription");

                    b.Property<string>("Organization1Location")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Location");

                    b.Property<string>("Organization1Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Name");

                    b.Property<string>("Organization1Symbol")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Symbol");

                    b.Property<string>("Organization1Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Title");

                    b.Property<string>("Organization1Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Type");

                    b.Property<string>("Organization1YomiName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1YomiName");

                    b.Property<string>("Phone1Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone1Type");

                    b.Property<string>("Phone1Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone1Value");

                    b.Property<string>("Phone2Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone2Type");

                    b.Property<string>("Phone2Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone2Value");

                    b.Property<string>("Phone3Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone3Type");

                    b.Property<string>("Phone3Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone3Value");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Photo");

                    b.Property<string>("PhotoFileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Priority");

                    b.Property<string>("ProfileID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sensitivity")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Sensitivity");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ShortName");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Subject");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Website1Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Website1Type");

                    b.Property<string>("Website1Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Website1Value");

                    b.Property<string>("Website2Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Website2Type");

                    b.Property<string>("Website2Value")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Website2Value");

                    b.Property<string>("YomiName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("YomiName");

                    b.HasKey("ID");

                    b.ToTable("Profiles");
                });
#pragma warning restore 612, 618
        }
    }
}
