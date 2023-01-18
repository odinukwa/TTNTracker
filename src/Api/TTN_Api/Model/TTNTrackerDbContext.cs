using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TTN_DDOI.Model
{
    public partial class TTNTrackerDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public TTNTrackerDbContext()
        {
        }

        public TTNTrackerDbContext(DbContextOptions<TTNTrackerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceUplinkMsg> DeviceUplinkMsgs { get; set; }
        public virtual DbSet<FrequencyPlan> FrequencyPlans { get; set; }
        public virtual DbSet<LorawanVersion> LorawanVersions { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<DeviceQrcode> DevicesQrcode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("applications");

                entity.HasIndex(e => e.AppId, "UQ__applicat__6F8A0A35169F285C")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AppDesc)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("app_desc");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("app_id");

                entity.Property(e => e.AppName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("app_name");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DateLastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_last_updated");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("devices");

                entity.HasIndex(e => e.DeviceId, "UQ__devices__3B085D8AEDB6F151")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppEui)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("app_eui");

                entity.Property(e => e.AppId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("app_id");

                entity.Property(e => e.AppKey)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("app_key");

                entity.Property(e => e.ApplicationServerAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("application_server_address");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DateLastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_last_updated");

                entity.Property(e => e.DevEui)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("dev_eui");

                entity.Property(e => e.DeviceDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("device_description");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("device_id");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("device_name");

                entity.Property(e => e.FrequencyPlanId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("frequency_plan_id");

                entity.Property(e => e.JoinServerAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("join_server_address");

                entity.Property(e => e.LorawanPhyVersion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("lorawan_phy_version");

                entity.Property(e => e.LorawanVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("lorawan_version");

                entity.Property(e => e.NetworkServerAddress)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("network_server_address");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.SupportsClassB)
                    .HasColumnName("supports_class_b")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SupportsClassC)
                    .HasColumnName("supports_class_c")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.Devices)
                    .HasPrincipalKey(p => p.AppId)
                    .HasForeignKey(d => d.AppId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__devices__app_id__2F10007B");

                entity.HasOne(d => d.FrequencyPlan)
                    .WithMany(p => p.Devices)
                    .HasPrincipalKey(p => p.FrequencyId)
                    .HasForeignKey(d => d.FrequencyPlanId)
                    .HasConstraintName("FK__devices__frequen__30F848ED");

                entity.HasOne(d => d.LorawanVersionNavigation)
                    .WithMany(p => p.Devices)
                    .HasPrincipalKey(p => p.LorawanVersionCode)
                    .HasForeignKey(d => d.LorawanVersion)
                    .HasConstraintName("FK__devices__lorawan__300424B4");
            });

            modelBuilder.Entity<DeviceUplinkMsg>(entity =>
            {
                entity.ToTable("device_uplink_msgs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Altitude).HasColumnName("altitude");

                entity.Property(e => e.AppId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("app_id");

                entity.Property(e => e.ConsumedAirtime)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("consumed_airtime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DevAddr)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("dev_addr");

                entity.Property(e => e.DevEui)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("dev_eui");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("device_id");

                entity.Property(e => e.FCnt).HasColumnName("f_cnt");

                entity.Property(e => e.FPort).HasColumnName("f_port");

                entity.Property(e => e.FrmPayload)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("frm_payload");

                entity.Property(e => e.Hdop)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("hdop");

                entity.Property(e => e.JoinEui)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("join_eui");

                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(12, 9)")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(12, 9)")
                    .HasColumnName("longitude");

                entity.Property(e => e.Port).HasColumnName("port");

                entity.Property(e => e.ReceivedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("received_at");

                entity.Property(e => e.Sats).HasColumnName("sats");

                entity.Property(e => e.SessionKeyId)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("session_key_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.App)
                    .WithMany(p => p.DeviceUplinkMsgs)
                    .HasPrincipalKey(p => p.AppId)
                    .HasForeignKey(d => d.AppId)
                    .HasConstraintName("FK__device_up__app_i__3B75D760");

                entity.HasOne(d => d.UserDevice)
                    .WithMany(p => p.DeviceUplinkMsgs)
                    .HasForeignKey(d => new { d.UserId, d.DeviceId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__device_uplink_ms__3C69FB99");
            });

            modelBuilder.Entity<FrequencyPlan>(entity =>
            {
                entity.ToTable("frequency_plan");

                entity.HasIndex(e => e.FrequencyId, "UQ__frequenc__F32AB2AAE11C508F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FrequencyBase).HasColumnName("frequency_base");

                entity.Property(e => e.FrequencyId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("frequency_id");

                entity.Property(e => e.FrequencyName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("frequency_name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<LorawanVersion>(entity =>
            {
                entity.ToTable("lorawan_version");

                entity.HasIndex(e => e.LorawanVersionCode, "UQ__lorawan___CBA5D18344B00607")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LorawanVersionCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("lorawan_version_code");

                entity.Property(e => e.LorawanVersionName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("lorawan_version_name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("user_profile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<UserDevice>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DeviceId })
                    .HasName("PK__user_dev__1A0EB2D73071FA77");

                entity.ToTable("user_devices");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("device_id");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.UserDevices)
                    .HasPrincipalKey(p => p.DeviceId)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_devi__devic__38996AB5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDevices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__user_devi__user___37A5467C");
            });

            modelBuilder.Entity<DeviceQrcode>(entity =>
                     {
                         entity.ToTable("device_qrcode");
                         entity.Property(e => e.Id).HasColumnName("id");

                         entity.Property(e => e.DevEui)
                             .IsRequired()
                             .HasMaxLength(16)
                             .IsUnicode(false)
                             .HasColumnName("dev_eui");

                         entity.Property(e => e.AppKey)
                             .HasMaxLength(32)
                             .IsUnicode(false)
                             .HasColumnName("app_key");

                         entity.Property(e => e.DateCreated)
                             .HasColumnType("datetime")
                             .HasColumnName("date_created");

                         entity.Property(e => e.AppEui)
                             .IsRequired()
                             .HasMaxLength(16)
                             .IsUnicode(false)
                             .HasColumnName("app_eui");

                         entity.Property(e => e.QrcodePath)
                                                     .HasColumnName("qrcode_path");
                         entity.Property(e => e.LorawanVersion)
                             .HasMaxLength(10)
                             .IsUnicode(false)
                             .HasColumnName("lorawan_version");

                         entity.Property(e => e.SupportsClassB)
                             .HasColumnName("supports_class_b")
                             .HasDefaultValueSql("((0))");

                         entity.Property(e => e.SupportsClassC)
                             .HasColumnName("supports_class_c")
                             .HasDefaultValueSql("((0))");

                         entity.Property(e => e.UserId).HasColumnName("user_id");


                     });


            //OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
