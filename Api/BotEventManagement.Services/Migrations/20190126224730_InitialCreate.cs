﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManager.Services.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EventManager");

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "EventManager",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                schema: "EventManager",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    UploadedPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                schema: "EventManager",
                columns: table => new
                {
                    SponsorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PageURL = table.Column<string>(nullable: true),
                    UploadedPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.SponsorId);
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                schema: "EventManager",
                columns: table => new
                {
                    CredentialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.CredentialId);
                    table.ForeignKey(
                        name: "FK_Credential_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "EventManager",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presentation",
                schema: "EventManager",
                columns: table => new
                {
                    PresentationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentation", x => x.PresentationId);
                    table.ForeignKey(
                        name: "FK_Presentation_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "EventManager",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventSponsor",
                schema: "EventManager",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    SponsorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSponsor", x => new { x.EventId, x.SponsorId });
                    table.ForeignKey(
                        name: "FK_EventSponsor_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "EventManager",
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSponsor_Sponsor_SponsorId",
                        column: x => x.SponsorId,
                        principalSchema: "EventManager",
                        principalTable: "Sponsor",
                        principalColumn: "SponsorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendant",
                schema: "EventManager",
                columns: table => new
                {
                    AttendantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CredentialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendant", x => x.AttendantId);
                    table.ForeignKey(
                        name: "FK_Attendant_Credential_CredentialId",
                        column: x => x.CredentialId,
                        principalSchema: "EventManager",
                        principalTable: "Credential",
                        principalColumn: "CredentialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresentationCredential",
                schema: "EventManager",
                columns: table => new
                {
                    PresentationId = table.Column<int>(nullable: false),
                    CredentialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationCredential", x => new { x.PresentationId, x.CredentialId });
                    table.ForeignKey(
                        name: "FK_PresentationCredential_Credential_CredentialId",
                        column: x => x.CredentialId,
                        principalSchema: "EventManager",
                        principalTable: "Credential",
                        principalColumn: "CredentialId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PresentationCredential_Presentation_PresentationId",
                        column: x => x.PresentationId,
                        principalSchema: "EventManager",
                        principalTable: "Presentation",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerPresentation",
                schema: "EventManager",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(nullable: false),
                    PresentationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerPresentation", x => new { x.SpeakerId, x.PresentationId });
                    table.ForeignKey(
                        name: "FK_SpeakerPresentation_Presentation_PresentationId",
                        column: x => x.PresentationId,
                        principalSchema: "EventManager",
                        principalTable: "Presentation",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeakerPresentation_Speaker_SpeakerId",
                        column: x => x.SpeakerId,
                        principalSchema: "EventManager",
                        principalTable: "Speaker",
                        principalColumn: "SpeakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresentationAttendant",
                schema: "EventManager",
                columns: table => new
                {
                    PresentationId = table.Column<int>(nullable: false),
                    AttendantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationAttendant", x => new { x.PresentationId, x.AttendantId });
                    table.ForeignKey(
                        name: "FK_PresentationAttendant_Attendant_AttendantId",
                        column: x => x.AttendantId,
                        principalSchema: "EventManager",
                        principalTable: "Attendant",
                        principalColumn: "AttendantId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PresentationAttendant_Presentation_PresentationId",
                        column: x => x.PresentationId,
                        principalSchema: "EventManager",
                        principalTable: "Presentation",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendant_CredentialId",
                schema: "EventManager",
                table: "Attendant",
                column: "CredentialId");

            migrationBuilder.CreateIndex(
                name: "IX_Credential_EventId",
                schema: "EventManager",
                table: "Credential",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSponsor_SponsorId",
                schema: "EventManager",
                table: "EventSponsor",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSponsor_EventId_SponsorId",
                schema: "EventManager",
                table: "EventSponsor",
                columns: new[] { "EventId", "SponsorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Presentation_EventId",
                schema: "EventManager",
                table: "Presentation",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationAttendant_AttendantId",
                schema: "EventManager",
                table: "PresentationAttendant",
                column: "AttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationAttendant_PresentationId_AttendantId",
                schema: "EventManager",
                table: "PresentationAttendant",
                columns: new[] { "PresentationId", "AttendantId" });

            migrationBuilder.CreateIndex(
                name: "IX_PresentationCredential_CredentialId",
                schema: "EventManager",
                table: "PresentationCredential",
                column: "CredentialId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationCredential_PresentationId_CredentialId",
                schema: "EventManager",
                table: "PresentationCredential",
                columns: new[] { "PresentationId", "CredentialId" });

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerPresentation_PresentationId",
                schema: "EventManager",
                table: "SpeakerPresentation",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerPresentation_SpeakerId_PresentationId",
                schema: "EventManager",
                table: "SpeakerPresentation",
                columns: new[] { "SpeakerId", "PresentationId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSponsor",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "PresentationAttendant",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "PresentationCredential",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "SpeakerPresentation",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "Sponsor",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "Attendant",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "Presentation",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "Speaker",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "Credential",
                schema: "EventManager");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "EventManager");
        }
    }
}
