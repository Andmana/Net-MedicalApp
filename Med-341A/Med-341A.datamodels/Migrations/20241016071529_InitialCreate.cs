using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Med_341A.datamodels.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_admin",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biodata_id = table.Column<long>(type: "bigint", nullable: true),
                    code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_admin__3213E83F59AB3BE3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_bank",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    va_code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_bank__3213E83F04F31EF0", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_biodata",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    mobile_phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    image_path = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_biodat__3213E83FBED4C8E7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_biodata_address",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biodata_id = table.Column<long>(type: "bigint", nullable: true),
                    label = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    recipent = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    recipent_phone_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    location_id = table.Column<long>(type: "bigint", nullable: true),
                    postal_code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_biodat__3213E83F53EC9EA3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_biodata_attachment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biodata_id = table.Column<long>(type: "bigint", nullable: true),
                    file_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    file_path = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    file_size = table.Column<int>(type: "int", nullable: true),
                    file = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_biodat__3213E83FC93AE946", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_blood_group",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_blood___3213E83F90DDE2C3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_courier",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_courie__3213E83FA11418F2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_courier_type",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courier_id = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_courie__3213E83F38AEB480", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_customer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biodata_id = table.Column<long>(type: "bigint", nullable: true),
                    dob = table.Column<DateOnly>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    blood_group_id = table.Column<long>(type: "bigint", nullable: true),
                    rhesus_type = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    height = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    weight = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_custom__3213E83F103512FE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_customer_member",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_biodata_id = table.Column<long>(type: "bigint", nullable: true),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    customer_relation_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_custom__3213E83F9BBA1B5A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_customer_relation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_custom__3213E83F890206BB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_doctor",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biodata_id = table.Column<long>(type: "bigint", nullable: true),
                    str = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_doctor__3213E83F7D718851", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_doctor_education",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor_id = table.Column<long>(type: "bigint", nullable: true),
                    education_level_id = table.Column<long>(type: "bigint", nullable: true),
                    institution_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    major = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    start_year = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    end_year = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    is_last_education = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_doctor__3213E83F44B2B8EE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_education_level",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_educat__3213E83F9C78F7A2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_location",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    parent_id = table.Column<long>(type: "bigint", nullable: true),
                    location_level_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_locati__3213E83F43166E99", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_location_level",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    abbreviation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_locati__3213E83F55B245A7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_medical_facility",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    medical_facility_category_id = table.Column<long>(type: "bigint", nullable: true),
                    location_id = table.Column<long>(type: "bigint", nullable: true),
                    full_address = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phone_code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    fax = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_medica__3213E83FF52229AA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_medical_facility_category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_medica__3213E83FE7E55C0D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_medical_facility_schedule",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medical_facility_id = table.Column<long>(type: "bigint", nullable: true),
                    day = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    time_schedule_start = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    time_schedule_end = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_medica__3213E83FB25869E1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_medical_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    medical_item_category_id = table.Column<long>(type: "bigint", nullable: true),
                    composition = table.Column<string>(type: "text", nullable: true),
                    medical_item_segmentation_id = table.Column<long>(type: "bigint", nullable: true),
                    manufacturer = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    indication = table.Column<string>(type: "text", nullable: true),
                    dosage = table.Column<string>(type: "text", nullable: true),
                    directions = table.Column<string>(type: "text", nullable: true),
                    contraindication = table.Column<string>(type: "text", nullable: true),
                    caution = table.Column<string>(type: "text", nullable: true),
                    packaging = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    price_max = table.Column<long>(type: "bigint", nullable: true),
                    price_min = table.Column<long>(type: "bigint", nullable: true),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    image_path = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_medica__3213E83F2E0416CE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_medical_item_category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_medica__3213E83FA9BB83AE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_medical_item_segmentation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_medica__3213E83FD92E333D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_menu",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    url = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    parent_id = table.Column<long>(type: "bigint", nullable: true),
                    big_icon = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    small_icon = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_menu__3213E83F98ECE147", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_menu_role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menu_id = table.Column<long>(type: "bigint", nullable: true),
                    role_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_menu_r__3213E83F579FEAF8", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_payment_method",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_paymen__3213E83F7DD79E79", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_role__3213E83FDDC73EDB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_specialization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_specia__3213E83F4F1D13CE", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    biodata_id = table.Column<long>(type: "bigint", nullable: true),
                    role_id = table.Column<long>(type: "bigint", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    login_attempt = table.Column<int>(type: "int", nullable: true),
                    is_locked = table.Column<bool>(type: "bit", nullable: true),
                    last_login = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_user__3213E83FC888DCEA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_wallet_default_nominal",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nominal = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__m_wallet__3213E83FF12CA286", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_appointment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    doctor_office_id = table.Column<long>(type: "bigint", nullable: true),
                    doctor_office_schedule_id = table.Column<long>(type: "bigint", nullable: true),
                    doctor_office_treatment_id = table.Column<long>(type: "bigint", nullable: true),
                    appointment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_appoin__3213E83FFEE083D2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_appointment_cancellation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointment_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_appoin__3213E83F8BB5E48D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_appointment_done",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointment_id = table.Column<long>(type: "bigint", nullable: true),
                    diagnosis = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_appoin__3213E83F14FB12AC", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_appointment_reschedule_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    appointment_id = table.Column<long>(type: "bigint", nullable: true),
                    doctor_office_schedule_id = table.Column<long>(type: "bigint", nullable: true),
                    doctor_office_treatment_id = table.Column<long>(type: "bigint", nullable: true),
                    appointment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_appoin__3213E83F9425F9C8", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_courier_discount",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courier_type_id = table.Column<long>(type: "bigint", nullable: true),
                    value = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_courie__3213E83F7F6B720A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_current_doctor_specialization",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor_id = table.Column<long>(type: "bigint", nullable: true),
                    specialization_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_curren__3213E83F98CCE984", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_chat",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    doctor_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83FB7C0F4E8", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_chat_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_chat_id = table.Column<long>(type: "bigint", nullable: true),
                    chat_content = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83F21C9AE47", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_chat_nominal",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    nominal = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83F18150402", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_registered_card",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    card_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    validity_period = table.Column<DateOnly>(type: "date", nullable: true),
                    cvv = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83F214BA7ED", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_va",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    va_number = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    validity_period = table.Column<DateOnly>(type: "date", nullable: true),
                    cvv = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83FAE2F4AC1", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_va_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_va_id = table.Column<long>(type: "bigint", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    expired_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    cvv = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83F1241481E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_wallet",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    pin = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    balance = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    barcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    points = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    pin_attempt = table.Column<int>(type: "int", nullable: true),
                    block_ends = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_blocked = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83F2D7EB22C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_wallet_topup",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_wallet_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83FC0C6374F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_customer_wallet_withdraw",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    wallet_default_nominal_id = table.Column<long>(type: "bigint", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: true),
                    bank_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    account_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    account_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    otp = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_custom__3213E83FE173D058", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_doctor_office",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor_id = table.Column<long>(type: "bigint", nullable: true),
                    medical_facilty_id = table.Column<long>(type: "bigint", nullable: true),
                    specialization = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    service_unit_id = table.Column<long>(type: "bigint", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_doctor__3213E83F5FD8AA25", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_doctor_office_schedule",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor_id = table.Column<long>(type: "bigint", nullable: true),
                    medical_facility_schedule = table.Column<long>(type: "bigint", nullable: true),
                    slot = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_doctor__3213E83F9C961BFB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_doctor_office_treatment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor_treatment_id = table.Column<long>(type: "bigint", nullable: true),
                    doctor_office_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_doctor__3213E83F49844F51", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_doctor_treatment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor_id = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_doctor__3213E83F1A89990E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_medical_item_purchase",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<long>(type: "bigint", nullable: true),
                    payment_method_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_medica__3213E83F04653190", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_medical_item_purchase_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medical_item_purchase_id = table.Column<long>(type: "bigint", nullable: true),
                    medical_item_id = table.Column<long>(type: "bigint", nullable: true),
                    qty = table.Column<int>(type: "int", nullable: true),
                    medical_facility_id = table.Column<long>(type: "bigint", nullable: true),
                    courier_id = table.Column<long>(type: "bigint", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_medica__3213E83F43BFD694", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_reset_password",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    old_password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    new_password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    reset_for = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_reset___3213E83F63BE2EA3", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_token",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    reset_for = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    token = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    expired_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_expired = table.Column<bool>(type: "bit", nullable: true),
                    used_for = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_token__3213E83F21859B9E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_treatment_discount",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctor_office_treatment_price_id = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    value = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: true),
                    modified_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__t_treatm__3213E83F1F10C995", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_admin");

            migrationBuilder.DropTable(
                name: "m_bank");

            migrationBuilder.DropTable(
                name: "m_biodata");

            migrationBuilder.DropTable(
                name: "m_biodata_address");

            migrationBuilder.DropTable(
                name: "m_biodata_attachment");

            migrationBuilder.DropTable(
                name: "m_blood_group");

            migrationBuilder.DropTable(
                name: "m_courier");

            migrationBuilder.DropTable(
                name: "m_courier_type");

            migrationBuilder.DropTable(
                name: "m_customer");

            migrationBuilder.DropTable(
                name: "m_customer_member");

            migrationBuilder.DropTable(
                name: "m_customer_relation");

            migrationBuilder.DropTable(
                name: "m_doctor");

            migrationBuilder.DropTable(
                name: "m_doctor_education");

            migrationBuilder.DropTable(
                name: "m_education_level");

            migrationBuilder.DropTable(
                name: "m_location");

            migrationBuilder.DropTable(
                name: "m_location_level");

            migrationBuilder.DropTable(
                name: "m_medical_facility");

            migrationBuilder.DropTable(
                name: "m_medical_facility_category");

            migrationBuilder.DropTable(
                name: "m_medical_facility_schedule");

            migrationBuilder.DropTable(
                name: "m_medical_item");

            migrationBuilder.DropTable(
                name: "m_medical_item_category");

            migrationBuilder.DropTable(
                name: "m_medical_item_segmentation");

            migrationBuilder.DropTable(
                name: "m_menu");

            migrationBuilder.DropTable(
                name: "m_menu_role");

            migrationBuilder.DropTable(
                name: "m_payment_method");

            migrationBuilder.DropTable(
                name: "m_role");

            migrationBuilder.DropTable(
                name: "m_specialization");

            migrationBuilder.DropTable(
                name: "m_user");

            migrationBuilder.DropTable(
                name: "m_wallet_default_nominal");

            migrationBuilder.DropTable(
                name: "t_appointment");

            migrationBuilder.DropTable(
                name: "t_appointment_cancellation");

            migrationBuilder.DropTable(
                name: "t_appointment_done");

            migrationBuilder.DropTable(
                name: "t_appointment_reschedule_history");

            migrationBuilder.DropTable(
                name: "t_courier_discount");

            migrationBuilder.DropTable(
                name: "t_current_doctor_specialization");

            migrationBuilder.DropTable(
                name: "t_customer_chat");

            migrationBuilder.DropTable(
                name: "t_customer_chat_history");

            migrationBuilder.DropTable(
                name: "t_customer_chat_nominal");

            migrationBuilder.DropTable(
                name: "t_customer_registered_card");

            migrationBuilder.DropTable(
                name: "t_customer_va");

            migrationBuilder.DropTable(
                name: "t_customer_va_history");

            migrationBuilder.DropTable(
                name: "t_customer_wallet");

            migrationBuilder.DropTable(
                name: "t_customer_wallet_topup");

            migrationBuilder.DropTable(
                name: "t_customer_wallet_withdraw");

            migrationBuilder.DropTable(
                name: "t_doctor_office");

            migrationBuilder.DropTable(
                name: "t_doctor_office_schedule");

            migrationBuilder.DropTable(
                name: "t_doctor_office_treatment");

            migrationBuilder.DropTable(
                name: "t_doctor_treatment");

            migrationBuilder.DropTable(
                name: "t_medical_item_purchase");

            migrationBuilder.DropTable(
                name: "t_medical_item_purchase_detail");

            migrationBuilder.DropTable(
                name: "t_reset_password");

            migrationBuilder.DropTable(
                name: "t_token");

            migrationBuilder.DropTable(
                name: "t_treatment_discount");
        }
    }
}
