using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABPBlog.Migrations
{
    public partial class updatePhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_PhotoAlbums_PhotoAlbumId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PhotoAlbumId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoAlbumId",
                table: "Photos");

            migrationBuilder.AddColumn<Guid>(
                name: "AlbumId",
                table: "Photos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AlbumId",
                table: "Photos",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_PhotoAlbums_AlbumId",
                table: "Photos",
                column: "AlbumId",
                principalTable: "PhotoAlbums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_PhotoAlbums_AlbumId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AlbumId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Photos");

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoAlbumId",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoAlbumId",
                table: "Photos",
                column: "PhotoAlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_PhotoAlbums_PhotoAlbumId",
                table: "Photos",
                column: "PhotoAlbumId",
                principalTable: "PhotoAlbums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
