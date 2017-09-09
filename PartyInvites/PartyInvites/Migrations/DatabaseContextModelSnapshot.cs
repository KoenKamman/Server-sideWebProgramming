using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PartyInvites.Models;

namespace PartyInvites.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PartyInvites.Models.Credential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("PartyInvites.Models.GuestResponse", b =>
                {
                    b.Property<int>("GuestResponseId");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<bool?>("WillAttend")
                        .IsRequired();

                    b.HasKey("GuestResponseId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("PartyInvites.Models.GuestResponse", b =>
                {
                    b.HasOne("PartyInvites.Models.Credential", "Credential")
                        .WithOne("GuestResponse")
                        .HasForeignKey("PartyInvites.Models.GuestResponse", "GuestResponseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
