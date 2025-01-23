﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250123183434_model2501231")]
    partial class model2501231
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.12");

            modelBuilder.Entity("AProfile", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalName")
                        .HasColumnType("TEXT")
                        .HasColumnName("AdditionalName");

                    b.Property<string>("AdditionalNameYomi")
                        .HasColumnType("TEXT")
                        .HasColumnName("AdditionalNameYomi");

                    b.Property<string>("Address1City")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1City");

                    b.Property<string>("Address1Country")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Country");

                    b.Property<string>("Address1ExtendedAddress")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1ExtendedAddress");

                    b.Property<string>("Address1Formatted")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Formatted");

                    b.Property<string>("Address1POBox")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1POBox");

                    b.Property<string>("Address1PostalCode")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1PostalCode");

                    b.Property<string>("Address1Region")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Region");

                    b.Property<string>("Address1Street")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Street");

                    b.Property<string>("Address1Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Address1Type");

                    b.Property<string>("BillingInformation")
                        .HasColumnType("TEXT")
                        .HasColumnName("BillingInformation");

                    b.Property<string>("Birthday")
                        .HasColumnType("TEXT")
                        .HasColumnName("Birthday");

                    b.Property<string>("Categories")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomField1Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomField1Value")
                        .HasColumnType("TEXT");

                    b.Property<string>("DirectoryServer")
                        .HasColumnType("TEXT")
                        .HasColumnName("DirectoryServer");

                    b.Property<string>("Email1Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Email1Type");

                    b.Property<string>("Email1Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("Email1Value");

                    b.Property<string>("Email2Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Email2Type");

                    b.Property<string>("Email2Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("Email2Value");

                    b.Property<string>("Email3Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Email3Type");

                    b.Property<string>("Email3Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("Email3Value");

                    b.Property<string>("Event1Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Event1Value")
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyName")
                        .HasColumnType("TEXT")
                        .HasColumnName("FamilyName");

                    b.Property<string>("FamilyNameYomi")
                        .HasColumnType("TEXT")
                        .HasColumnName("FamilyNameYomi");

                    b.Property<string>("FileUploaded")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT")
                        .HasColumnName("Gender");

                    b.Property<string>("GivenName")
                        .HasColumnType("TEXT")
                        .HasColumnName("GivenName");

                    b.Property<string>("GivenNameYomi")
                        .HasColumnType("TEXT")
                        .HasColumnName("GivenNameYomi");

                    b.Property<string>("Group")
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupMembership")
                        .HasColumnType("TEXT")
                        .HasColumnName("GroupMembership");

                    b.Property<string>("Hobby")
                        .HasColumnType("TEXT")
                        .HasColumnName("Hobby");

                    b.Property<string>("IM1Service")
                        .HasColumnType("TEXT")
                        .HasColumnName("IM1Service");

                    b.Property<string>("IM1Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("IM1Type");

                    b.Property<string>("IM1Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("IM1Value");

                    b.Property<string>("IM2Service")
                        .HasColumnType("TEXT")
                        .HasColumnName("IM2Service");

                    b.Property<string>("IM2Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("IM2Type");

                    b.Property<string>("IM2Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("IM2Value");

                    b.Property<string>("Initials")
                        .HasColumnType("TEXT")
                        .HasColumnName("Initials");

                    b.Property<bool>("IsBroken")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT")
                        .HasColumnName("Language");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT")
                        .HasColumnName("Location");

                    b.Property<string>("MaidenName")
                        .HasColumnType("TEXT")
                        .HasColumnName("MaidenName");

                    b.Property<string>("Mileage")
                        .HasColumnType("TEXT")
                        .HasColumnName("Mileage");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<string>("NamePrefix")
                        .HasColumnType("TEXT")
                        .HasColumnName("NamePrefix");

                    b.Property<string>("NameSuffix")
                        .HasColumnType("TEXT")
                        .HasColumnName("NameSuffix");

                    b.Property<string>("Nickname")
                        .HasColumnType("TEXT")
                        .HasColumnName("Nickname");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasColumnName("Notes");

                    b.Property<string>("Occupation")
                        .HasColumnType("TEXT")
                        .HasColumnName("Occupation");

                    b.Property<string>("Organization1Department")
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Department");

                    b.Property<string>("Organization1JobDescription")
                        .HasColumnType("TEXT")
                        .HasColumnName("OrganizationJobDescription");

                    b.Property<string>("Organization1Location")
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Location");

                    b.Property<string>("Organization1Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Name");

                    b.Property<string>("Organization1Symbol")
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Symbol");

                    b.Property<string>("Organization1Title")
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Title");

                    b.Property<string>("Organization1Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1Type");

                    b.Property<string>("Organization1YomiName")
                        .HasColumnType("TEXT")
                        .HasColumnName("Organization1YomiName");

                    b.Property<string>("Phone1Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone1Type");

                    b.Property<string>("Phone1Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone1Value");

                    b.Property<string>("Phone2Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone2Type");

                    b.Property<string>("Phone2Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone2Value");

                    b.Property<string>("Phone3Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone3Type");

                    b.Property<string>("Phone3Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("Phone3Value");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT")
                        .HasColumnName("Photo");

                    b.Property<string>("PhotoFileName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Priority")
                        .HasColumnType("TEXT")
                        .HasColumnName("Priority");

                    b.Property<string>("ProfileID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sensitivity")
                        .HasColumnType("TEXT")
                        .HasColumnName("Sensitivity");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT")
                        .HasColumnName("ShortName");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT")
                        .HasColumnName("Subject");

                    b.Property<string>("Version")
                        .HasColumnType("TEXT");

                    b.Property<string>("Website1Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Website1Type");

                    b.Property<string>("Website1Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("Website1Value");

                    b.Property<string>("Website2Type")
                        .HasColumnType("TEXT")
                        .HasColumnName("Website2Type");

                    b.Property<string>("Website2Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("Website2Value");

                    b.Property<string>("YomiName")
                        .HasColumnType("TEXT")
                        .HasColumnName("YomiName");

                    b.HasKey("ID");

                    b.ToTable("Profiles");
                });
#pragma warning restore 612, 618
        }
    }
}
