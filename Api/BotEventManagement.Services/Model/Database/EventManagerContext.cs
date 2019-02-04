using EventManager.Services.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Services.Model.Database
{
    public class EventManagerContext : DbContext
    {
        public EventManagerContext(DbContextOptions<EventManagerContext> options) : base(options)
        {
        }

        public virtual DbSet<Attendant> Attendant { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Presentation> Presentation { get; set; }
        public virtual DbSet<PresentationAttendant> PresentationAttendant { get; set; }
        public virtual DbSet<PresentationCredential> PresentationCredential { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<SpeakerPresentation> SpeakerPresentation { get; set; }
        public virtual DbSet<Sponsor> Sponsor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsOne(x => x.Address,
                sa =>
                {
                    sa.Property(p => p.Street).HasColumnName("Street");
                    sa.Property(p => p.Latitude).HasColumnName("Latitude");
                    sa.Property(p => p.Longitude).HasColumnName("Longitude");
                    sa.Property(p => p.City).HasColumnName("City");
                    sa.Property(p => p.Neighborhood).HasColumnName("Neighborhood");
                    sa.Property(p => p.State).HasColumnName("State");

                });

            modelBuilder.Entity<PresentationAttendant>().HasKey(x => new { x.PresentationId, x.AttendantId });
            modelBuilder.Entity<PresentationAttendant>().HasIndex(x => new { x.PresentationId, x.AttendantId });

            modelBuilder.Entity<PresentationCredential>().HasKey(x => new { x.PresentationId, x.CredentialId });
            modelBuilder.Entity<PresentationCredential>().HasIndex(x => new { x.PresentationId, x.CredentialId });

            modelBuilder.Entity<SpeakerPresentation>().HasKey(x => new { x.SpeakerId, x.PresentationId });
            modelBuilder.Entity<SpeakerPresentation>().HasIndex(x => new { x.SpeakerId, x.PresentationId });
            
            modelBuilder.HasDefaultSchema("EventManager");

            base.OnModelCreating(modelBuilder);
        }

        private void SetModelBuilderRelationships(ModelBuilder modelBuilder)
        {
            #region Presentation

            modelBuilder.Entity<PresentationAttendant>()
                        .HasOne(p => p.Presentation)
                        .WithMany(p => p.PresentationAttendants)
                        .HasForeignKey(p => p.PresentationId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PresentationAttendant>()
                        .HasOne(a => a.Attendant)
                        .WithMany(p => p.PresentationAttendants)
                        .HasForeignKey(a => a.AttendantId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PresentationCredential>()
                        .HasOne(p => p.Presentation)
                        .WithMany(p => p.PresentationCredentials)
                        .HasForeignKey(p => p.PresentationId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PresentationCredential>()
                        .HasOne(c => c.Credential)
                        .WithMany(p => p.PresentationCredentials)
                        .HasForeignKey(c => c.CredentialId)
                        .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Speaker

            modelBuilder.Entity<SpeakerPresentation>()
                        .HasOne(s => s.Speaker)
                        .WithMany(s => s.SpeakerPresentations)
                        .HasForeignKey(s => s.SpeakerId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SpeakerPresentation>()
                        .HasOne(p => p.Presentation)
                        .WithMany(s => s.SpeakerPresentations)
                        .HasForeignKey(p => p.PresentationId)
                        .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
