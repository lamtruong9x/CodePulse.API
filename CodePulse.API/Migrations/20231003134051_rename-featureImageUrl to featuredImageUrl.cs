﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePulse.API.Migrations
{
    /// <inheritdoc />
    public partial class renamefeatureImageUrltofeaturedImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BlogPosts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "FeatureImageUrl",
                table: "BlogPosts",
                newName: "FeaturedImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "BlogPosts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FeaturedImageUrl",
                table: "BlogPosts",
                newName: "FeatureImageUrl");
        }
    }
}
