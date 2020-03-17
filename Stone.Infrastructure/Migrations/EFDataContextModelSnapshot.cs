﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stone.Infrastructure.DataContextLayer;

namespace Stone.Infrastructure.Migrations
{
    [DbContext(typeof(EFDataContext))]
    partial class EFDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stone.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Admissao");

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<bool>("PlanoDental");

                    b.Property<bool>("PlanoSaude");

                    b.Property<decimal>("SalarioBruto");

                    b.Property<string>("Setor")
                        .IsRequired();

                    b.Property<string>("SobreNome")
                        .IsRequired();

                    b.Property<bool>("ValeTransporte");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Stone.Domain.Entities.Inss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Aliquota");

                    b.Property<decimal>("Maximo");

                    b.Property<decimal>("Minimo");

                    b.HasKey("Id");

                    b.ToTable("Inss");
                });

            modelBuilder.Entity("Stone.Domain.Entities.Irpf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Aliquota");

                    b.Property<decimal>("Deduzir");

                    b.Property<decimal>("Maximo");

                    b.Property<decimal>("Minimo");

                    b.HasKey("Id");

                    b.ToTable("Irpf");
                });
#pragma warning restore 612, 618
        }
    }
}
