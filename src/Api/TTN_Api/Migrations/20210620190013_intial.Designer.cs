﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TTN_DDOI.Model;

namespace TTN_DDOI.Migrations
{
    [DbContext(typeof(TTNTrackerDbContext))]
    [Migration("20210620190013_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TTN_DDOI.Model.Application", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("AppDesc")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("app_desc");

                    b.Property<string>("AppId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("app_id");

                    b.Property<string>("AppName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("app_name");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLastUpdated")
                        .HasColumnType("datetime")
                        .HasColumnName("date_last_updated");

                    b.Property<string>("Status")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AppId" }, "UQ__applicat__6F8A0A35169F285C")
                        .IsUnique();

                    b.ToTable("applications");
                });

            modelBuilder.Entity("TTN_DDOI.Model.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppEui")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("app_eui");

                    b.Property<string>("AppId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("app_id");

                    b.Property<string>("AppKey")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("app_key");

                    b.Property<string>("ApplicationServerAddress")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("application_server_address");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLastUpdated")
                        .HasColumnType("datetime")
                        .HasColumnName("date_last_updated");

                    b.Property<string>("DevEui")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("dev_eui");

                    b.Property<string>("DeviceDescription")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("device_description");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("device_id");

                    b.Property<string>("DeviceName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("device_name");

                    b.Property<string>("FrequencyPlanId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("frequency_plan_id");

                    b.Property<string>("JoinServerAddress")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("join_server_address");

                    b.Property<string>("LorawanPhyVersion")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("lorawan_phy_version");

                    b.Property<string>("LorawanVersion")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("lorawan_version");

                    b.Property<string>("NetworkServerAddress")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("network_server_address");

                    b.Property<string>("Status")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("status");

                    b.Property<bool?>("SupportsClassB")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("supports_class_b")
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("SupportsClassC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("supports_class_c")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.HasIndex("FrequencyPlanId");

                    b.HasIndex("LorawanVersion");

                    b.HasIndex(new[] { "DeviceId" }, "UQ__devices__3B085D8AEDB6F151")
                        .IsUnique();

                    b.ToTable("devices");
                });

            modelBuilder.Entity("TTN_DDOI.Model.DeviceUplinkMsg", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Altitude")
                        .HasColumnType("int")
                        .HasColumnName("altitude");

                    b.Property<string>("AppId")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("app_id");

                    b.Property<string>("ConsumedAirtime")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("consumed_airtime");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("date_created");

                    b.Property<string>("DevAddr")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("dev_addr");

                    b.Property<string>("DevEui")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("dev_eui");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("device_id");

                    b.Property<int?>("FCnt")
                        .HasColumnType("int")
                        .HasColumnName("f_cnt");

                    b.Property<int?>("FPort")
                        .HasColumnType("int")
                        .HasColumnName("f_port");

                    b.Property<string>("FrmPayload")
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("frm_payload");

                    b.Property<decimal?>("Hdop")
                        .HasColumnType("decimal(18,6)")
                        .HasColumnName("hdop");

                    b.Property<string>("JoinEui")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("join_eui");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(12,9)")
                        .HasColumnName("latitude");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(12,9)")
                        .HasColumnName("longitude");

                    b.Property<int?>("Port")
                        .HasColumnType("int")
                        .HasColumnName("port");

                    b.Property<DateTime?>("ReceivedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("received_at");

                    b.Property<int?>("Sats")
                        .HasColumnType("int")
                        .HasColumnName("sats");

                    b.Property<string>("SessionKeyId")
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("session_key_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.HasIndex("UserId", "DeviceId");

                    b.ToTable("device_uplink_msgs");
                });

            modelBuilder.Entity("TTN_DDOI.Model.FrequencyPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FrequencyBase")
                        .HasColumnType("int")
                        .HasColumnName("frequency_base");

                    b.Property<string>("FrequencyId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("frequency_id");

                    b.Property<string>("FrequencyName")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("frequency_name");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FrequencyId" }, "UQ__frequenc__F32AB2AAE11C508F")
                        .IsUnique();

                    b.ToTable("frequency_plan");
                });

            modelBuilder.Entity("TTN_DDOI.Model.LorawanVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LorawanVersionCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("lorawan_version_code");

                    b.Property<string>("LorawanVersionName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("lorawan_version_name");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "LorawanVersionCode" }, "UQ__lorawan___CBA5D18344B00607")
                        .IsUnique();

                    b.ToTable("lorawan_version");
                });

            modelBuilder.Entity("TTN_DDOI.Model.UserDevice", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("DeviceId")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("device_id");

                    b.HasKey("UserId", "DeviceId")
                        .HasName("PK__user_dev__1A0EB2D73071FA77");

                    b.HasIndex("DeviceId");

                    b.ToTable("user_devices");
                });

            modelBuilder.Entity("TTN_DDOI.Model.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("date_created");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.ToTable("user_profile");
                });

            modelBuilder.Entity("TTN_DDOI.Model.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser<int>");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TTN_DDOI.Model.Device", b =>
                {
                    b.HasOne("TTN_DDOI.Model.Application", "App")
                        .WithMany("Devices")
                        .HasForeignKey("AppId")
                        .HasConstraintName("FK__devices__app_id__2F10007B")
                        .HasPrincipalKey("AppId")
                        .IsRequired();

                    b.HasOne("TTN_DDOI.Model.FrequencyPlan", "FrequencyPlan")
                        .WithMany("Devices")
                        .HasForeignKey("FrequencyPlanId")
                        .HasConstraintName("FK__devices__frequen__30F848ED")
                        .HasPrincipalKey("FrequencyId");

                    b.HasOne("TTN_DDOI.Model.LorawanVersion", "LorawanVersionNavigation")
                        .WithMany("Devices")
                        .HasForeignKey("LorawanVersion")
                        .HasConstraintName("FK__devices__lorawan__300424B4")
                        .HasPrincipalKey("LorawanVersionCode");

                    b.Navigation("App");

                    b.Navigation("FrequencyPlan");

                    b.Navigation("LorawanVersionNavigation");
                });

            modelBuilder.Entity("TTN_DDOI.Model.DeviceUplinkMsg", b =>
                {
                    b.HasOne("TTN_DDOI.Model.Application", "App")
                        .WithMany("DeviceUplinkMsgs")
                        .HasForeignKey("AppId")
                        .HasConstraintName("FK__device_up__app_i__3B75D760")
                        .HasPrincipalKey("AppId");

                    b.HasOne("TTN_DDOI.Model.UserDevice", "UserDevice")
                        .WithMany("DeviceUplinkMsgs")
                        .HasForeignKey("UserId", "DeviceId")
                        .HasConstraintName("FK__device_uplink_ms__3C69FB99")
                        .IsRequired();

                    b.Navigation("App");

                    b.Navigation("UserDevice");
                });

            modelBuilder.Entity("TTN_DDOI.Model.UserDevice", b =>
                {
                    b.HasOne("TTN_DDOI.Model.Device", "Device")
                        .WithMany("UserDevices")
                        .HasForeignKey("DeviceId")
                        .HasConstraintName("FK__user_devi__devic__38996AB5")
                        .HasPrincipalKey("DeviceId")
                        .IsRequired();

                    b.HasOne("TTN_DDOI.Model.UserProfile", "User")
                        .WithMany("UserDevices")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__user_devi__user___37A5467C")
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TTN_DDOI.Model.UserProfile", b =>
                {
                    b.HasOne("TTN_DDOI.Model.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TTN_DDOI.Model.Application", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("DeviceUplinkMsgs");
                });

            modelBuilder.Entity("TTN_DDOI.Model.Device", b =>
                {
                    b.Navigation("UserDevices");
                });

            modelBuilder.Entity("TTN_DDOI.Model.FrequencyPlan", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("TTN_DDOI.Model.LorawanVersion", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("TTN_DDOI.Model.UserDevice", b =>
                {
                    b.Navigation("DeviceUplinkMsgs");
                });

            modelBuilder.Entity("TTN_DDOI.Model.UserProfile", b =>
                {
                    b.Navigation("UserDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
