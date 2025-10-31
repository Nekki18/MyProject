using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class BookLoversContext : DbContext
{
    public BookLoversContext()
    {
    }

    public BookLoversContext(DbContextOptions<BookLoversContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookClub> BookClubs { get; set; }

    public virtual DbSet<BookRecommendation> BookRecommendations { get; set; }

    public virtual DbSet<ClubMember> ClubMembers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersBook> UsersBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .HasColumnName("author");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("genre");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<BookClub>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("book_clubs_pkey");

            entity.ToTable("book_clubs");

            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Creator).WithMany(p => p.BookClubs)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("book_clubs_creator_id_fkey");
        });

        modelBuilder.Entity<BookRecommendation>(entity =>
        {
            entity.HasKey(e => e.RecommendationId).HasName("book_recommendations_pkey");

            entity.ToTable("book_recommendations");

            entity.Property(e => e.RecommendationId).HasColumnName("recommendation_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.BookRecommendations)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("book_recommendations_book_id_fkey");

            entity.HasOne(d => d.Receiver).WithMany(p => p.BookRecommendationReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("book_recommendations_receiver_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.BookRecommendationUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("book_recommendations_user_id_fkey");
        });

        modelBuilder.Entity<ClubMember>(entity =>
        {
            entity.HasKey(e => new { e.ClubId, e.UserId }).HasName("club_members_pkey");

            entity.ToTable("club_members");

            entity.Property(e => e.ClubId).HasColumnName("club_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasColumnName("is_approved");
            entity.Property(e => e.JoinedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("joined_at");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValueSql("'member'::character varying")
                .HasColumnName("role");

            entity.HasOne(d => d.Club).WithMany(p => p.ClubMembers)
                .HasForeignKey(d => d.ClubId)
                .HasConstraintName("club_members_club_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.ClubMembers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("club_members_user_id_fkey");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("comments_pkey");

            entity.ToTable("comments");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Review).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("comments_review_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("comments_user_id_fkey");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.TargetType, e.TargetId }).HasName("likes_pkey");

            entity.ToTable("likes");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.TargetType)
                .HasMaxLength(20)
                .HasColumnName("target_type");
            entity.Property(e => e.TargetId).HasColumnName("target_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("likes_user_id_fkey");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("notes_pkey");

            entity.ToTable("notes");

            entity.Property(e => e.NoteId).HasColumnName("note_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnName("is_public");
            entity.Property(e => e.Page).HasColumnName("page");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.Notes)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("notes_book_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Notes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("notes_user_id_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("reviews_pkey");

            entity.ToTable("reviews");

            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("reviews_book_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("reviews_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UsersBook>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.BookId }).HasName("users_books_pkey");

            entity.ToTable("users_books");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CurrentPage).HasColumnName("current_page");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.Book).WithMany(p => p.UsersBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("users_books_book_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UsersBooks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("users_books_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
