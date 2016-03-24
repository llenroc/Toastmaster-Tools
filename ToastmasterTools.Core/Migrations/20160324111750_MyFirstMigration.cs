using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ToastmasterTools.Core.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardTime",
                columns: table => new
                {
                    CardTimeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Minutes = table.Column<int>(nullable: false),
                    Seconds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTime", x => x.CardTimeId);
                });
            migrationBuilder.CreateTable(
                name: "SpeechType",
                columns: table => new
                {
                    SpeechTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GreenCardTimeCardTimeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RedCardTimeCardTimeId = table.Column<int>(nullable: true),
                    YellowCardTimeCardTimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeechType", x => x.SpeechTypeId);
                    table.ForeignKey(
                        name: "FK_SpeechType_CardTime_GreenCardTimeCardTimeId",
                        column: x => x.GreenCardTimeCardTimeId,
                        principalTable: "CardTime",
                        principalColumn: "CardTimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpeechType_CardTime_RedCardTimeCardTimeId",
                        column: x => x.RedCardTimeCardTimeId,
                        principalTable: "CardTime",
                        principalColumn: "CardTimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpeechType_CardTime_YellowCardTimeCardTimeId",
                        column: x => x.YellowCardTimeCardTimeId,
                        principalTable: "CardTime",
                        principalColumn: "CardTimeId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Club = table.Column<string>(nullable: true),
                    CurrentLessonSpeechTypeId = table.Column<int>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Member_SpeechType_CurrentLessonSpeechTypeId",
                        column: x => x.CurrentLessonSpeechTypeId,
                        principalTable: "SpeechType",
                        principalColumn: "SpeechTypeId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Speech",
                columns: table => new
                {
                    SpeechId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    IsCustom = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SpeakerMemberId = table.Column<int>(nullable: true),
                    SpeechTimeInSeconds = table.Column<double>(nullable: false),
                    SpeechTypeSpeechTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speech", x => x.SpeechId);
                    table.ForeignKey(
                        name: "FK_Speech_Member_SpeakerMemberId",
                        column: x => x.SpeakerMemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Speech_SpeechType_SpeechTypeSpeechTypeId",
                        column: x => x.SpeechTypeSpeechTypeId,
                        principalTable: "SpeechType",
                        principalColumn: "SpeechTypeId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Counter",
                columns: table => new
                {
                    CounterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SpeechSpeechId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counter", x => x.CounterId);
                    table.ForeignKey(
                        name: "FK_Counter_Speech_SpeechSpeechId",
                        column: x => x.SpeechSpeechId,
                        principalTable: "Speech",
                        principalColumn: "SpeechId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Counter");
            migrationBuilder.DropTable("Speech");
            migrationBuilder.DropTable("Member");
            migrationBuilder.DropTable("SpeechType");
            migrationBuilder.DropTable("CardTime");
        }
    }
}
