﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RegattaManager.Data;
using System;

namespace RegattaManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RegattaManager.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RegattaManager.Models.Boatclass", b =>
                {
                    b.Property<int>("BoatclassId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Seats");

                    b.HasKey("BoatclassId");

                    b.ToTable("Boatclass");
                });

            modelBuilder.Entity("RegattaManager.Models.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("VNr");

                    b.HasKey("ClubId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("RegattaManager.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Birthyear");

                    b.Property<int>("ClubId");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.HasKey("MemberId");

                    b.HasIndex("ClubId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("RegattaManager.Models.Oldclass", b =>
                {
                    b.Property<int>("OldclassId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FromAge");

                    b.Property<string>("Name");

                    b.Property<int>("ToAge");

                    b.HasKey("OldclassId");

                    b.ToTable("Oldclass");
                });

            modelBuilder.Entity("RegattaManager.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoatclassId");

                    b.Property<string>("Comment");

                    b.Property<int>("FinishType");

                    b.Property<string>("Gender");

                    b.Property<int>("OldclassId");

                    b.Property<int>("RaceclassId");

                    b.Property<int>("RacestatusId");

                    b.Property<DateTime>("Realstarttime");

                    b.Property<int>("RegattaId");

                    b.Property<DateTime>("Starttime");

                    b.HasKey("RaceId");

                    b.HasIndex("BoatclassId");

                    b.HasIndex("OldclassId");

                    b.HasIndex("RaceclassId");

                    b.HasIndex("RacestatusId");

                    b.HasIndex("RegattaId");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("RegattaManager.Models.Raceclass", b =>
                {
                    b.Property<int>("RaceclassId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Length");

                    b.Property<string>("Name");

                    b.HasKey("RaceclassId");

                    b.ToTable("Raceclass");
                });

            modelBuilder.Entity("RegattaManager.Models.Racestatus", b =>
                {
                    b.Property<int>("RacestatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("RacestatusId");

                    b.ToTable("Racestatus");
                });

            modelBuilder.Entity("RegattaManager.Models.Regatta", b =>
                {
                    b.Property<int>("RegattaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubId");

                    b.Property<DateTime>("FromDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ToDate");

                    b.HasKey("RegattaId");

                    b.HasIndex("ClubId");

                    b.ToTable("Regatta");
                });

            modelBuilder.Entity("RegattaManager.Models.Startboat", b =>
                {
                    b.Property<int>("StartboatId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubId");

                    b.Property<DateTime>("FinishTime");

                    b.Property<int>("Placement");

                    b.Property<int>("RaceId");

                    b.Property<int>("StartboatstatusId");

                    b.Property<int>("Startslot");

                    b.HasKey("StartboatId");

                    b.HasIndex("ClubId");

                    b.HasIndex("RaceId");

                    b.HasIndex("StartboatstatusId");

                    b.ToTable("Startboat");
                });

            modelBuilder.Entity("RegattaManager.Models.StartboatMember", b =>
                {
                    b.Property<int>("StartboatId");

                    b.Property<int>("MemberId");

                    b.Property<int>("SeatNumber");

                    b.Property<int>("StartboatMemberId");

                    b.HasKey("StartboatId", "MemberId");

                    b.HasAlternateKey("StartboatMemberId");

                    b.HasIndex("MemberId");

                    b.ToTable("StartboatMember");
                });

            modelBuilder.Entity("RegattaManager.Models.Startboatstatus", b =>
                {
                    b.Property<int>("StartboatstatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("StartboatstatusId");

                    b.ToTable("Startboatstatus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RegattaManager.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RegattaManager.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RegattaManager.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RegattaManager.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RegattaManager.Models.Member", b =>
                {
                    b.HasOne("RegattaManager.Models.Club", "Club")
                        .WithMany("Members")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RegattaManager.Models.Race", b =>
                {
                    b.HasOne("RegattaManager.Models.Boatclass", "Boatclass")
                        .WithMany("Races")
                        .HasForeignKey("BoatclassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RegattaManager.Models.Oldclass", "Oldclass")
                        .WithMany("Races")
                        .HasForeignKey("OldclassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RegattaManager.Models.Raceclass", "Raceclass")
                        .WithMany("Races")
                        .HasForeignKey("RaceclassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RegattaManager.Models.Racestatus", "Racestatus")
                        .WithMany("Races")
                        .HasForeignKey("RacestatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RegattaManager.Models.Regatta", "Regatta")
                        .WithMany("Races")
                        .HasForeignKey("RegattaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RegattaManager.Models.Regatta", b =>
                {
                    b.HasOne("RegattaManager.Models.Club", "Club")
                        .WithMany("Regatten")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RegattaManager.Models.Startboat", b =>
                {
                    b.HasOne("RegattaManager.Models.Club", "Club")
                        .WithMany("Startboats")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RegattaManager.Models.Race", "Race")
                        .WithMany("Startboats")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RegattaManager.Models.Startboatstatus", "Startboatstatus")
                        .WithMany("Startboats")
                        .HasForeignKey("StartboatstatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RegattaManager.Models.StartboatMember", b =>
                {
                    b.HasOne("RegattaManager.Models.Member", "Member")
                        .WithMany("StartboatMembers")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RegattaManager.Models.Startboat", "Startboat")
                        .WithMany("StartboatMembers")
                        .HasForeignKey("StartboatId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
