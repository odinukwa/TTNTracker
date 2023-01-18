using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTN_DDOI.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "applications",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false),
            //        app_id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        app_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        app_desc = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
            //        status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
            //        date_created = table.Column<DateTime>(type: "datetime", nullable: true),
            //        date_last_updated = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_applications", x => x.id);
            //        table.UniqueConstraint("AK_applications_app_id", x => x.app_id);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "frequency_plan",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        frequency_id = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        frequency_name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        frequency_base = table.Column<int>(type: "int", nullable: true),
            //        status = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_frequency_plan", x => x.id);
            //        table.UniqueConstraint("AK_frequency_plan_frequency_id", x => x.frequency_id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "lorawan_version",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        lorawan_version_code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        lorawan_version_name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
            //        status = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_lorawan_version", x => x.id);
            //        table.UniqueConstraint("AK_lorawan_version_lorawan_version_code", x => x.lorawan_version_code);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    last_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    first_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_profile", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_profile_AspNetUsers_id",
                        column: x => x.id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "devices",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        app_id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        device_id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        app_eui = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
            //        dev_eui = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
            //        device_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        device_description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
            //        lorawan_version = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
            //        lorawan_phy_version = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
            //        network_server_address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        application_server_address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        join_server_address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        frequency_plan_id = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
            //        supports_class_b = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        supports_class_c = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
            //        app_key = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
            //        status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
            //        date_created = table.Column<DateTime>(type: "datetime", nullable: true),
            //        date_last_updated = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_devices", x => x.id);
            //        table.UniqueConstraint("AK_devices_device_id", x => x.device_id);
            //        table.ForeignKey(
            //            name: "FK__devices__app_id__2F10007B",
            //            column: x => x.app_id,
            //            principalTable: "applications",
            //            principalColumn: "app_id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__devices__frequen__30F848ED",
            //            column: x => x.frequency_plan_id,
            //            principalTable: "frequency_plan",
            //            principalColumn: "frequency_id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__devices__lorawan__300424B4",
            //            column: x => x.lorawan_version,
            //            principalTable: "lorawan_version",
            //            principalColumn: "lorawan_version_code",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "user_devices",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    device_id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_dev__1A0EB2D73071FA77", x => new { x.user_id, x.device_id });
                    table.ForeignKey(
                        name: "FK__user_devi__devic__38996AB5",
                        column: x => x.device_id,
                        principalTable: "devices",
                        principalColumn: "device_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__user_devi__user___37A5467C",
                        column: x => x.user_id,
                        principalTable: "user_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "device_uplink_msgs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    app_id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    device_id = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    dev_eui = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    join_eui = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    dev_addr = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    session_key_id = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    f_port = table.Column<int>(type: "int", nullable: true),
                    f_cnt = table.Column<int>(type: "int", nullable: true),
                    frm_payload = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
                    altitude = table.Column<int>(type: "int", nullable: true),
                    latitude = table.Column<decimal>(type: "decimal(12,9)", nullable: true),
                    longitude = table.Column<decimal>(type: "decimal(12,9)", nullable: true),
                    hdop = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    port = table.Column<int>(type: "int", nullable: true),
                    sats = table.Column<int>(type: "int", nullable: true),
                    received_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    consumed_airtime = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    date_created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_uplink_msgs", x => x.id);
                    table.ForeignKey(
                        name: "FK__device_up__app_i__3B75D760",
                        column: x => x.app_id,
                        principalTable: "applications",
                        principalColumn: "app_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__device_uplink_ms__3C69FB99",
                        columns: x => new { x.user_id, x.device_id },
                        principalTable: "user_devices",
                        principalColumns: new[] { "user_id", "device_id" },
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "UQ__applicat__6F8A0A35169F285C",
            //    table: "applications",
            //    column: "app_id",
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_device_uplink_msgs_app_id",
                table: "device_uplink_msgs",
                column: "app_id");

            migrationBuilder.CreateIndex(
                name: "IX_device_uplink_msgs_user_id_device_id",
                table: "device_uplink_msgs",
                columns: new[] { "user_id", "device_id" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_devices_app_id",
            //    table: "devices",
            //    column: "app_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_devices_frequency_plan_id",
            //    table: "devices",
            //    column: "frequency_plan_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_devices_lorawan_version",
            //    table: "devices",
            //    column: "lorawan_version");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__devices__3B085D8AEDB6F151",
            //    table: "devices",
            //    column: "device_id",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "UQ__frequenc__F32AB2AAE11C508F",
            //    table: "frequency_plan",
            //    column: "frequency_id",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "UQ__lorawan___CBA5D18344B00607",
            //    table: "lorawan_version",
            //    column: "lorawan_version_code",
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_devices_device_id",
                table: "user_devices",
                column: "device_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "device_uplink_msgs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "user_devices");

            //migrationBuilder.DropTable(
            //    name: "devices");

            migrationBuilder.DropTable(
                name: "user_profile");

            //migrationBuilder.DropTable(
            //    name: "applications");

            //migrationBuilder.DropTable(
            //    name: "frequency_plan");

            //migrationBuilder.DropTable(
            //    name: "lorawan_version");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
