﻿// <auto-generated />
using System;
using Aeroporto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aeroporto.Migrations
{
    [DbContext(typeof(AeroportoContext))]
    partial class AeroportoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aeroporto.Models.Aeronave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumeroAssento")
                        .HasColumnType("int")
                        .HasColumnName("numero_Assento");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("tipo");

                    b.HasKey("Id")
                        .HasName("PK__Aeronave__3213E83FB5DCAF21");

                    b.ToTable("Aeronaves");
                });

            modelBuilder.Entity("Aeroporto.Models.ClientesPreferenciais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Gestante")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("gestante");

                    b.Property<string>("Idoso")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("idoso");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telefone");

                    b.HasKey("Id")
                        .HasName("PK__Clientes__3213E83F49355665");

                    b.ToTable("ClientesPreferenciais");
                });

            modelBuilder.Entity("Aeroporto.Models.Escala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AeroportoSaida")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("aeroporto_saida");

                    b.Property<DateTime>("HorarioSaida")
                        .HasColumnType("datetime")
                        .HasColumnName("horario_saida");

                    b.Property<int?>("VooId")
                        .HasColumnType("int")
                        .HasColumnName("voo_id");

                    b.HasKey("Id")
                        .HasName("PK__Escalas__3213E83FCF58F572");

                    b.HasIndex("VooId");

                    b.ToTable("Escalas");
                });

            modelBuilder.Entity("Aeroporto.Models.Poltrona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AeronaveId")
                        .HasColumnType("int")
                        .HasColumnName("aeronave_id");

                    b.Property<string>("Disponibilidade")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("disponibilidade");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("localizacao");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("numero");

                    b.HasKey("Id")
                        .HasName("PK__Poltrona__3213E83F96B6E083");

                    b.HasIndex("AeronaveId");

                    b.ToTable("Assento");
                });

            modelBuilder.Entity("Aeroporto.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cliente_id");

                    b.Property<int?>("PoltronaId")
                        .HasColumnType("int")
                        .HasColumnName("poltrona_id");

                    b.Property<int?>("VooId")
                        .HasColumnType("int")
                        .HasColumnName("voo_id");

                    b.HasKey("Id")
                        .HasName("PK__Reservas__3213E83FF7558A66");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PoltronaId");

                    b.HasIndex("VooId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Aeroporto.Models.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AeronaveId")
                        .HasColumnType("int")
                        .HasColumnName("aeronave_id");

                    b.Property<string>("AeroportoDestino")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("aeroporto_destino");

                    b.Property<string>("AeroportoOrigem")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("aeroporto_origem");

                    b.Property<DateTime>("HorarioPrevistoChegada")
                        .HasColumnType("datetime")
                        .HasColumnName("horario_previsto_chegada");

                    b.Property<DateTime>("HorarioSaida")
                        .HasColumnType("datetime")
                        .HasColumnName("horario_saida");

                    b.HasKey("Id")
                        .HasName("PK__Voos__3213E83F2C326BB0");

                    b.HasIndex("AeronaveId");

                    b.ToTable("Voos");
                });

            modelBuilder.Entity("Aeroporto.Models.Escala", b =>
                {
                    b.HasOne("Aeroporto.Models.Voo", "Voo")
                        .WithMany("Escalas")
                        .HasForeignKey("VooId")
                        .HasConstraintName("FK__Escalas__voo_id__3B75D760");

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("Aeroporto.Models.Poltrona", b =>
                {
                    b.HasOne("Aeroporto.Models.Aeronave", "Aeronave")
                        .WithMany("Assento")
                        .HasForeignKey("AeronaveId")
                        .HasConstraintName("FK__Assento__dispo__3E52440B");

                    b.Navigation("Aeronave");
                });

            modelBuilder.Entity("Aeroporto.Models.Reserva", b =>
                {
                    b.HasOne("Aeroporto.Models.ClientesPreferenciais", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK__Reservas__client__44FF419A");

                    b.HasOne("Aeroporto.Models.Poltrona", "Poltrona")
                        .WithMany("Reservas")
                        .HasForeignKey("PoltronaId")
                        .HasConstraintName("FK__Reservas__poltro__440B1D61");

                    b.HasOne("Aeroporto.Models.Voo", "Voo")
                        .WithMany("Reservas")
                        .HasForeignKey("VooId")
                        .HasConstraintName("FK__Reservas__voo_id__4316F928");

                    b.Navigation("Cliente");

                    b.Navigation("Poltrona");

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("Aeroporto.Models.Voo", b =>
                {
                    b.HasOne("Aeroporto.Models.Aeronave", "Aeronave")
                        .WithMany("Voos")
                        .HasForeignKey("AeronaveId")
                        .HasConstraintName("FK__Voos__aeronave_i__38996AB5");

                    b.Navigation("Aeronave");
                });

            modelBuilder.Entity("Aeroporto.Models.Aeronave", b =>
                {
                    b.Navigation("Assento");

                    b.Navigation("Voos");
                });

            modelBuilder.Entity("Aeroporto.Models.ClientesPreferenciais", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Aeroporto.Models.Poltrona", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Aeroporto.Models.Voo", b =>
                {
                    b.Navigation("Escalas");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
