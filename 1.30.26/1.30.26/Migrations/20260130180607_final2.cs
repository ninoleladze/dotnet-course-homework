using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1._30._26.Migrations
{
    /// <inheritdoc />
    public partial class final2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_youtubers_YoutuberId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_YoutuberId",
                table: "posts");

            migrationBuilder.CreateTable(
                name: "PostYoutuber",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    YoutubersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostYoutuber", x => new { x.PostsId, x.YoutubersId });
                    table.ForeignKey(
                        name: "FK_PostYoutuber_posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostYoutuber_youtubers_YoutubersId",
                        column: x => x.YoutubersId,
                        principalTable: "youtubers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostYoutuber_YoutubersId",
                table: "PostYoutuber",
                column: "YoutubersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostYoutuber");

            migrationBuilder.CreateIndex(
                name: "IX_posts_YoutuberId",
                table: "posts",
                column: "YoutuberId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_youtubers_YoutuberId",
                table: "posts",
                column: "YoutuberId",
                principalTable: "youtubers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
