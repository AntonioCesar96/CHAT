﻿// <auto-generated />
using System;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chat.Infra.Data.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    partial class ChatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chat.Domain.Contatos.Entities.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FotoUrl")
                        .HasMaxLength(250);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Chat.Domain.Conversas.Entities.Conversa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContatoCriadorDaConversaId");

                    b.Property<int>("ContatoId");

                    b.Property<DateTime>("DataCriacao");

                    b.HasKey("Id");

                    b.HasIndex("ContatoCriadorDaConversaId");

                    b.HasIndex("ContatoId");

                    b.ToTable("Conversa");
                });

            modelBuilder.Entity("Chat.Domain.Conversas.Entities.Mensagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContatoDestinatarioId");

                    b.Property<int>("ContatoRemetenteId");

                    b.Property<int>("ConversaId");

                    b.Property<DateTime>("DataEnvio");

                    b.Property<string>("MensagemEnviada")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ContatoDestinatarioId");

                    b.HasIndex("ContatoRemetenteId");

                    b.HasIndex("ConversaId");

                    b.ToTable("Mensagem");
                });

            modelBuilder.Entity("Chat.Domain.ListaContatos.Entities.ListaContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContatoAmigoId");

                    b.Property<int>("ContatoPrincipalId");

                    b.HasKey("Id");

                    b.HasIndex("ContatoAmigoId");

                    b.HasIndex("ContatoPrincipalId");

                    b.ToTable("ListaContato");
                });

            modelBuilder.Entity("Chat.Domain.Conversas.Entities.Conversa", b =>
                {
                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoCriadorDaConversa")
                        .WithMany()
                        .HasForeignKey("ContatoCriadorDaConversaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Chat.Domain.Conversas.Entities.Mensagem", b =>
                {
                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoDestinatario")
                        .WithMany()
                        .HasForeignKey("ContatoDestinatarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoRemetente")
                        .WithMany()
                        .HasForeignKey("ContatoRemetenteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Chat.Domain.Conversas.Entities.Conversa", "Conversa")
                        .WithMany("Mensagens")
                        .HasForeignKey("ConversaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Chat.Domain.ListaContatos.Entities.ListaContato", b =>
                {
                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoAmigo")
                        .WithMany()
                        .HasForeignKey("ContatoAmigoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Chat.Domain.Contatos.Entities.Contato", "ContatoPrincipal")
                        .WithMany()
                        .HasForeignKey("ContatoPrincipalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
