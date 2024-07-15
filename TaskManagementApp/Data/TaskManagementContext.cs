using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Models;

namespace TaskManagementApp.Data
{ 

    public class TaskManagementContext : DbContext
    {
        public TaskManagementContext() : base() { }

        public DbSet<Assignment> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<AdminReport> adminReports { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
           

            modelBuilder.Entity<Assignment>()
                .HasKey(a => a.AssignmentId);

            modelBuilder.Entity<Document>()
                .HasKey(d => d.DocumentId);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Manager>()
                .HasKey(m => m.ManagerId);

            modelBuilder.Entity<TaskNote>()
                .HasKey(tn => tn.TaskNoteId);

            modelBuilder.Entity<AdminReport>()
                .HasKey(ar => ar.AdminReportId);

            modelBuilder.Entity<Team>()
                .HasKey(t => t.TeamId);

            // Define relationships

            // An Employee has many Assignments
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Assignments)
                .HasForeignKey(a => a.EmployeeId);

            // An Assignment has many Documents
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Assignment)
                .WithMany(a => a.Documents)
                .HasForeignKey(d => d.AssignmentId);

            // An Assignment has many TaskNotes
            modelBuilder.Entity<TaskNote>()
                .HasOne(tn => tn.Assignment)
                .WithMany(a => a.TaskNotes)
                .HasForeignKey(tn => tn.AssignmentId);

            // A Manager manages many Teams
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Manager)
                .WithMany(m => m.Teams)
                .HasForeignKey(t => t.ManagerId);

            // A Team has many Employees
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TeamId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("taskdb");
            }
        }
    }

        
    

}


