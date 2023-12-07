using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.EntityModels;

public partial class SecretSantaContext : DbContext
{
    public SecretSantaContext()
    {
    }

    public SecretSantaContext(DbContextOptions<SecretSantaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Matching> Matchings { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string databaseName = "SecretSanta.db";
            string dir = Environment.CurrentDirectory;
            string path = String.Empty;
            if (dir.EndsWith("net8.0"))
            {
                path = Path.Combine("..", "..", "..", "..", databaseName);
            }
            else
            {
                path = Path.Combine("..", databaseName);
            }
            path = Path.GetFullPath(path);
            SecretSantaContextLogger.WriteLine($"Using database file: {path}");
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    message: $"{path} not found.", fileName: path);
            }
            optionsBuilder.UseSqlite($"Data Source={path}");
            optionsBuilder.LogTo(SecretSantaContextLogger.WriteLine,
                new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting});
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
