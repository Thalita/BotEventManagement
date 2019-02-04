﻿// <auto-generated />
using System;
using EventManager.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventManager.Services.Migrations
{
    [DbContext(typeof(EventManagerContext))]
    partial class EventManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("EventManager")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventManager.Services.Model.Entities.Attendant", b =>
                {
                    b.Property<int>("AttendantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CredentialId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("AttendantId");

                    b.HasIndex("CredentialId");

                    b.ToTable("Attendant");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Credential", b =>
                {
                    b.Property<int>("CredentialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.HasKey("CredentialId");

                    b.HasIndex("EventId");

                    b.ToTable("Credential");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("EventId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Presentation", b =>
                {
                    b.Property<int>("PresentationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("EventId");

                    b.Property<string>("Local");

                    b.Property<string>("Name");

                    b.Property<string>("Theme");

                    b.HasKey("PresentationId");

                    b.HasIndex("EventId");

                    b.ToTable("Presentation");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.PresentationAttendant", b =>
                {
                    b.Property<int>("PresentationId");

                    b.Property<int>("AttendantId");

                    b.HasKey("PresentationId", "AttendantId");

                    b.HasIndex("AttendantId");

                    b.HasIndex("PresentationId", "AttendantId");

                    b.ToTable("PresentationAttendant");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.PresentationCredential", b =>
                {
                    b.Property<int>("PresentationId");

                    b.Property<int>("CredentialId");

                    b.HasKey("PresentationId", "CredentialId");

                    b.HasIndex("CredentialId");

                    b.HasIndex("PresentationId", "CredentialId");

                    b.ToTable("PresentationCredential");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography");

                    b.Property<string>("Name");

                    b.Property<string>("UploadedPhoto");

                    b.HasKey("SpeakerId");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.SpeakerPresentation", b =>
                {
                    b.Property<int>("SpeakerId");

                    b.Property<int>("PresentationId");

                    b.HasKey("SpeakerId", "PresentationId");

                    b.HasIndex("PresentationId");

                    b.HasIndex("SpeakerId", "PresentationId");

                    b.ToTable("SpeakerPresentation");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Sponsor", b =>
                {
                    b.Property<int>("SponsorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.Property<string>("PageURL");

                    b.Property<string>("UploadedPhoto");

                    b.HasKey("SponsorId");

                    b.HasIndex("EventId");

                    b.ToTable("Sponsor");
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Attendant", b =>
                {
                    b.HasOne("EventManager.Services.Model.Entities.Credential", "Credential")
                        .WithMany()
                        .HasForeignKey("CredentialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Credential", b =>
                {
                    b.HasOne("EventManager.Services.Model.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Event", b =>
                {
                    b.OwnsOne("EventManager.Services.Model.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int?>("EventId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnName("City");

                            b1.Property<double>("Latitude")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnName("Longitude");

                            b1.Property<string>("Neighborhood")
                                .HasColumnName("Neighborhood");

                            b1.Property<string>("State")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .HasColumnName("Street");

                            b1.ToTable("Event");

                            b1.HasOne("EventManager.Services.Model.Entities.Event")
                                .WithOne("Address")
                                .HasForeignKey("EventManager.Services.Model.Entities.Address", "EventId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Presentation", b =>
                {
                    b.HasOne("EventManager.Services.Model.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.PresentationAttendant", b =>
                {
                    b.HasOne("EventManager.Services.Model.Entities.Attendant", "Attendant")
                        .WithMany("PresentationAttendants")
                        .HasForeignKey("AttendantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventManager.Services.Model.Entities.Presentation", "Presentation")
                        .WithMany("PresentationAttendants")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.PresentationCredential", b =>
                {
                    b.HasOne("EventManager.Services.Model.Entities.Credential", "Credential")
                        .WithMany("PresentationCredentials")
                        .HasForeignKey("CredentialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventManager.Services.Model.Entities.Presentation", "Presentation")
                        .WithMany("PresentationCredentials")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.SpeakerPresentation", b =>
                {
                    b.HasOne("EventManager.Services.Model.Entities.Presentation", "Presentation")
                        .WithMany("SpeakerPresentations")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventManager.Services.Model.Entities.Speaker", "Speaker")
                        .WithMany("SpeakerPresentations")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventManager.Services.Model.Entities.Sponsor", b =>
                {
                    b.HasOne("EventManager.Services.Model.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
