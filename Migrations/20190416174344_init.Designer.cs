﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoEscola_API.Data;

namespace ProjetoEscola_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190416174344_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("ProjetoEscola_API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataNasc");

                    b.Property<string>("Nome");

                    b.Property<int>("ProfessorId");

                    b.Property<string>("Sobrenome");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ProjetoEscola_API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataNasc");

                    b.Property<string>("Nome");

                    b.Property<string>("Sobrenome");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("ProjetoEscola_API.Models.Aluno", b =>
                {
                    b.HasOne("ProjetoEscola_API.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
