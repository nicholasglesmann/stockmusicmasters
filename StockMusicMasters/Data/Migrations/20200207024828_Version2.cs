using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMusicMasters.Data.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GenreTags",
                columns: table => new
                {
                    GenreTagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTags", x => x.GenreTagID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    MessageTitle = table.Column<string>(nullable: true),
                    MessageBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "MusicTracks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GenreTagID = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicTracks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MusicTracks_GenreTags_GenreTagID",
                        column: x => x.GenreTagID,
                        principalTable: "GenreTags",
                        principalColumn: "GenreTagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_MusicTrackID = table.Column<int>(nullable: false),
                    CommentText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_MusicTracks_FK_MusicTrackID",
                        column: x => x.FK_MusicTrackID,
                        principalTable: "MusicTracks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentTags",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: true),
                    MusicTrackID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentTags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InstrumentTags_MusicTracks_MusicTrackID",
                        column: x => x.MusicTrackID,
                        principalTable: "MusicTracks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoodTags",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: true),
                    MusicTrackID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoodTags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MoodTags_MusicTracks_MusicTrackID",
                        column: x => x.MusicTrackID,
                        principalTable: "MusicTracks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherTags",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: true),
                    MusicTrackID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherTags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OtherTags_MusicTracks_MusicTrackID",
                        column: x => x.MusicTrackID,
                        principalTable: "MusicTracks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    MusicTrackID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    RatingValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.UserID, x.MusicTrackID });
                    table.ForeignKey(
                        name: "FK_Ratings_MusicTracks_MusicTrackID",
                        column: x => x.MusicTrackID,
                        principalTable: "MusicTracks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicTrackInstrumentTags",
                columns: table => new
                {
                    MusicTrackID = table.Column<int>(nullable: false),
                    InstrumentTagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicTrackInstrumentTags", x => new { x.MusicTrackID, x.InstrumentTagID });
                    table.ForeignKey(
                        name: "FK_MusicTrackInstrumentTags_InstrumentTags_InstrumentTagID",
                        column: x => x.InstrumentTagID,
                        principalTable: "InstrumentTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicTrackInstrumentTags_MusicTracks_MusicTrackID",
                        column: x => x.MusicTrackID,
                        principalTable: "MusicTracks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicTrackMoodTags",
                columns: table => new
                {
                    MusicTrackID = table.Column<int>(nullable: false),
                    MoodTagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicTrackMoodTags", x => new { x.MusicTrackID, x.MoodTagID });
                    table.ForeignKey(
                        name: "FK_MusicTrackMoodTags_MoodTags_MoodTagID",
                        column: x => x.MoodTagID,
                        principalTable: "MoodTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicTrackMoodTags_MusicTracks_MusicTrackID",
                        column: x => x.MusicTrackID,
                        principalTable: "MusicTracks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicTrackOtherTag",
                columns: table => new
                {
                    MusicTrackID = table.Column<int>(nullable: false),
                    OtherTagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicTrackOtherTag", x => new { x.MusicTrackID, x.OtherTagID });
                    table.ForeignKey(
                        name: "FK_MusicTrackOtherTag_MusicTracks_MusicTrackID",
                        column: x => x.MusicTrackID,
                        principalTable: "MusicTracks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicTrackOtherTag_OtherTags_OtherTagID",
                        column: x => x.OtherTagID,
                        principalTable: "OtherTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FK_MusicTrackID",
                table: "Comments",
                column: "FK_MusicTrackID");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTags_MusicTrackID",
                table: "InstrumentTags",
                column: "MusicTrackID");

            migrationBuilder.CreateIndex(
                name: "IX_MoodTags_MusicTrackID",
                table: "MoodTags",
                column: "MusicTrackID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicTrackInstrumentTags_InstrumentTagID",
                table: "MusicTrackInstrumentTags",
                column: "InstrumentTagID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicTrackMoodTags_MoodTagID",
                table: "MusicTrackMoodTags",
                column: "MoodTagID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicTrackOtherTag_OtherTagID",
                table: "MusicTrackOtherTag",
                column: "OtherTagID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicTracks_GenreTagID",
                table: "MusicTracks",
                column: "GenreTagID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherTags_MusicTrackID",
                table: "OtherTags",
                column: "MusicTrackID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MusicTrackID",
                table: "Ratings",
                column: "MusicTrackID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MusicTrackInstrumentTags");

            migrationBuilder.DropTable(
                name: "MusicTrackMoodTags");

            migrationBuilder.DropTable(
                name: "MusicTrackOtherTag");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "InstrumentTags");

            migrationBuilder.DropTable(
                name: "MoodTags");

            migrationBuilder.DropTable(
                name: "OtherTags");

            migrationBuilder.DropTable(
                name: "MusicTracks");

            migrationBuilder.DropTable(
                name: "GenreTags");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
