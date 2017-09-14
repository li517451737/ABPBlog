using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ABPBlog.Migrations
{
    public partial class AddArticleClassify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassifyId",
                table: "ArticleInfoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleInfoes_ClassifyId",
                table: "ArticleInfoes",
                column: "ClassifyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleInfoes_ArticleClassifies_ClassifyId",
                table: "ArticleInfoes",
                column: "ClassifyId",
                principalTable: "ArticleClassifies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleInfoes_ArticleClassifies_ClassifyId",
                table: "ArticleInfoes");

            migrationBuilder.DropIndex(
                name: "IX_ArticleInfoes_ClassifyId",
                table: "ArticleInfoes");

            migrationBuilder.DropColumn(
                name: "ClassifyId",
                table: "ArticleInfoes");
        }
    }
}
