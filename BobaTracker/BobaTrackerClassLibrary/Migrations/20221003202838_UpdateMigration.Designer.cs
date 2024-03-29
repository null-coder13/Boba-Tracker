﻿// <auto-generated />
using System;
using BobaTrackerDataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BobaTrackerClassLibrary.Migrations
{
    [DbContext(typeof(BobaTrackerDBContext))]
    [Migration("20221003202838_UpdateMigration")]
    partial class UpdateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("BobaTrackerClassLibrary.Models.Entry", b =>
                {
                    b.Property<DateTime>("DateTimeId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("hasPeed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("hasPooped")
                        .HasColumnType("INTEGER");

                    b.HasKey("DateTimeId");

                    b.ToTable("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
