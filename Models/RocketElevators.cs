using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rocket_Elevators_Rest_Api.Models
{
    public partial class RocketElevators : DbContext
    {
        public RocketElevators()
        {
        }

        public RocketElevators(DbContextOptions<RocketElevators> options)
            : base(options)
        {
        }
        public virtual DbSet<Interventions> Interventions { get; set; } 
        public virtual DbSet<ActiveStorageAttachments> ActiveStorageAttachments { get; set; }
        public virtual DbSet<ActiveStorageBlobs> ActiveStorageBlobs { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
        public virtual DbSet<Batteries> Batteries { get; set; }
        public virtual DbSet<BlazerAudits> BlazerAudits { get; set; }
        public virtual DbSet<BlazerChecks> BlazerChecks { get; set; }
        public virtual DbSet<BlazerDashboardQueries> BlazerDashboardQueries { get; set; }
        public virtual DbSet<BlazerDashboards> BlazerDashboards { get; set; }
        public virtual DbSet<BlazerQueries> BlazerQueries { get; set; }
        public virtual DbSet<BuildingDetails> BuildingDetails { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Elevators> Elevators { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<SchemaMigrations> SchemaMigrations { get; set; }
        public virtual DbSet<TextToSpeeches> TextToSpeeches { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=*****;password=*****;database=*****;treattinyasboolean=true", x => x.ServerVersion("5.7.29-mysql"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveStorageAttachments>(entity =>
            {
                entity.ToTable("active_storage_attachments");

                entity.HasIndex(e => e.BlobId)
                    .HasName("index_active_storage_attachments_on_blob_id");

                entity.HasIndex(e => new { e.RecordType, e.RecordId, e.Name, e.BlobId })
                    .HasName("index_active_storage_attachments_uniqueness")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BlobId)
                    .HasColumnName("blob_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RecordId)
                    .HasColumnName("record_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.RecordType)
                    .IsRequired()
                    .HasColumnName("record_type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Blob)
                    .WithMany(p => p.ActiveStorageAttachments)
                    .HasForeignKey(d => d.BlobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_c3b3935057");
            });

            modelBuilder.Entity<ActiveStorageBlobs>(entity =>
            {
                entity.ToTable("active_storage_blobs");

                entity.HasIndex(e => e.Key)
                    .HasName("index_active_storage_blobs_on_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ByteSize)
                    .HasColumnName("byte_size")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Checksum)
                    .IsRequired()
                    .HasColumnName("checksum")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContentType)
                    .HasColumnName("content_type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Metadata)
                    .HasColumnName("metadata")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("addresses");

                entity.HasIndex(e => new { e.EntityType, e.EntityId })
                    .HasName("index_addresses_on_entity_type_and_entity_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AddressNotes)
                    .HasColumnName("address_notes")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.AddressStatus)
                    .HasColumnName("address_status")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.AddressType)
                    .HasColumnName("address_type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntityId)
                    .HasColumnName("entity_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EntityType)
                    .HasColumnName("entity_type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StreetName)
                    .HasColumnName("street_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StreetNumber)
                    .HasColumnName("street_number")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SuiteOrApartment)
                    .HasColumnName("suite_or_apartment")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ArInternalMetadata>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Batteries>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("index_batteries_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BatteryCommissioningDate)
                    .HasColumnName("battery_commissioning_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BatteryInformation)
                    .HasColumnName("battery_information")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BatteryLastInspectionDate)
                    .HasColumnName("battery_last_inspection_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BatteryNotes)
                    .HasColumnName("battery_notes")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BatteryOperationCertificate)
                    .HasColumnName("battery_operation_certificate")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BatteryStatus)
                    .HasColumnName("battery_status")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<BlazerAudits>(entity =>
            {
                entity.ToTable("blazer_audits");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_audits_on_query_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_blazer_audits_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DataSource)
                    .HasColumnName("data_source")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.QueryId)
                    .HasColumnName("query_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Statement)
                    .HasColumnName("statement")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<BlazerChecks>(entity =>
            {
                entity.ToTable("blazer_checks");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_checks_on_creator_id");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_checks_on_query_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CheckType)
                    .HasColumnName("check_type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatorId)
                    .HasColumnName("creator_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Emails)
                    .HasColumnName("emails")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastRunAt)
                    .HasColumnName("last_run_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.QueryId)
                    .HasColumnName("query_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Schedule)
                    .HasColumnName("schedule")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SlackChannels)
                    .HasColumnName("slack_channels")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<BlazerDashboardQueries>(entity =>
            {
                entity.ToTable("blazer_dashboard_queries");

                entity.HasIndex(e => e.DashboardId)
                    .HasName("index_blazer_dashboard_queries_on_dashboard_id");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_dashboard_queries_on_query_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DashboardId)
                    .HasColumnName("dashboard_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QueryId)
                    .HasColumnName("query_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<BlazerDashboards>(entity =>
            {
                entity.ToTable("blazer_dashboards");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_dashboards_on_creator_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatorId)
                    .HasColumnName("creator_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<BlazerQueries>(entity =>
            {
                entity.ToTable("blazer_queries");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_queries_on_creator_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatorId)
                    .HasColumnName("creator_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.DataSource)
                    .HasColumnName("data_source")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Statement)
                    .HasColumnName("statement")
                    .HasColumnType("text")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<BuildingDetails>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_building_details_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.InformationKey)
                    .HasColumnName("information_key")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingAdministratorEmail)
                    .HasColumnName("building_administrator_email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BuildingAdministratorFullName)
                    .HasColumnName("building_administrator_full_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BuildingAdministratorPhone)
                    .HasColumnName("building_administrator_phone")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BuildingTechnicalContactEmail)
                    .HasColumnName("building_technical_contact_email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BuildingTechnicalContactFullName)
                    .HasColumnName("building_technical_contact_full_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BuildingTechnicalContactPhone)
                    .HasColumnName("building_technical_contact_phone")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<Columns>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId)
                    .HasName("index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BatteryId)
                    .HasColumnName("battery_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ColumnInformation)
                    .HasColumnName("column_information")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ColumnNotes)
                    .HasColumnName("column_notes")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ColumnStatus)
                    .HasColumnName("column_status")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServedFloorNumber)
                    .HasColumnName("served_floor_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.QuoteId)
                    .HasName("index_customers_on_quote_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_customers_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CompanyContactEmail)
                    .HasColumnName("company_contact_email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CompanyContactFullName)
                    .HasColumnName("company_contact_full_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CompanyContactPhone)
                    .HasColumnName("company_contact_phone")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CompanyDescription)
                    .HasColumnName("company_description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.QuoteId)
                    .HasColumnName("quote_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ServiceTechnicalAuthorityEmail)
                    .HasColumnName("service_technical_authority_email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ServiceTechnicalAuthorityFullName)
                    .HasColumnName("service_technical_authority_full_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ServiceTechnicalAuthorityPhone)
                    .HasColumnName("service_technical_authority_phone")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.QuoteId)
                    .HasConstraintName("fk_rails_a2e3dd7e5d");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevators>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId)
                    .HasName("index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ColumnId)
                    .HasColumnName("column_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ElevatorCommissioningDate)
                    .HasColumnName("elevator_commissioning_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ElevatorInformation)
                    .HasColumnName("elevator_information")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ElevatorInspectionCertificate)
                    .HasColumnName("elevator_inspection_certificate")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ElevatorLastInspectionDate)
                    .HasColumnName("elevator_last_inspection_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ElevatorModel)
                    .HasColumnName("elevator_model")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ElevatorNotes)
                    .HasColumnName("elevator_notes")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ElevatorSerialNumber)
                    .HasColumnName("elevator_serial_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ElevatorStatus)
                    .HasColumnName("elevator_status")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.Email)
                    .HasName("index_employees_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken)
                    .HasName("index_employees_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ConfirmationSentAt)
                    .HasColumnName("confirmation_sent_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConfirmationToken)
                    .HasColumnName("confirmation_token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ConfirmedAt)
                    .HasColumnName("confirmed_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CurrentSignInAt)
                    .HasColumnName("current_sign_in_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CurrentSignInIp)
                    .HasColumnName("current_sign_in_ip")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasColumnName("encrypted_password")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FailedAttempts)
                    .HasColumnName("failed_attempts")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Function)
                    .IsRequired()
                    .HasColumnName("function")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastSignInAt)
                    .HasColumnName("last_sign_in_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastSignInIp)
                    .HasColumnName("last_sign_in_ip")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LockedAt)
                    .HasColumnName("locked_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnName("remember_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnName("reset_password_sent_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnName("reset_password_token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SignInCount)
                    .HasColumnName("sign_in_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnconfirmedEmail)
                    .HasColumnName("unconfirmed_email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UnlockToken)
                    .HasColumnName("unlock_token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("blob");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentOfService)
                    .HasColumnName("department_of_service")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LeadCompanyName)
                    .HasColumnName("lead_company_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LeadEmail)
                    .HasColumnName("lead_email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LeadFullName)
                    .HasColumnName("lead_full_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LeadMessage)
                    .HasColumnName("lead_message")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LeadPhone)
                    .HasColumnName("lead_phone")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnName("project_description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProjectName)
                    .HasColumnName("project_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.ToTable("quotes");

                entity.HasIndex(e => e.LeadId)
                    .HasName("index_quotes_on_lead_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_quotes_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingType)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ElevatorQuality)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LeadId)
                    .HasColumnName("lead_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.NbrAppt).HasColumnType("int(11)");

                entity.Property(e => e.NbrBassements).HasColumnType("int(11)");

                entity.Property(e => e.NbrBusinesses).HasColumnType("int(11)");

                entity.Property(e => e.NbrElevators).HasColumnType("int(11)");

                entity.Property(e => e.NbrFloors)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NbrOccupanrtPerFloor).HasColumnType("int(11)");

                entity.Property(e => e.NbrParking).HasColumnType("int(11)");

                entity.Property(e => e.NbrRentalCompagnies).HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.WorkingHours).HasColumnType("datetime");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("fk_rails_5a752de9bf");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_02b555fb4d");
            });

            modelBuilder.Entity<SchemaMigrations>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TextToSpeeches>(entity =>
            {
                entity.ToTable("text_to_speeches");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken)
                    .HasName("index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ConfirmationSentAt)
                    .HasColumnName("confirmation_sent_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConfirmationToken)
                    .HasColumnName("confirmation_token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ConfirmedAt)
                    .HasColumnName("confirmed_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CurrentSignInAt)
                    .HasColumnName("current_sign_in_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CurrentSignInIp)
                    .HasColumnName("current_sign_in_ip")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasColumnName("encrypted_password")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FailedAttempts)
                    .HasColumnName("failed_attempts")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastSignInAt)
                    .HasColumnName("last_sign_in_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastSignInIp)
                    .HasColumnName("last_sign_in_ip")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LockedAt)
                    .HasColumnName("locked_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnName("remember_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnName("reset_password_sent_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnName("reset_password_token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.SignInCount)
                    .HasColumnName("sign_in_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnconfirmedEmail)
                    .HasColumnName("unconfirmed_email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UnlockToken)
                    .HasColumnName("unlock_token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });


            modelBuilder.Entity<Interventions>(entity =>
            {
                entity.ToTable("interventions");

                entity.HasIndex(e => e.report)
                    .HasName("report");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.result)
                    .HasColumnName("result");

                entity.Property(e => e.status)
                    .HasColumnName("status");
                
                entity.Property(e => e.author)
                    .HasColumnName("author");

                entity.Property(e => e.employee_id)
                    .HasColumnName("employee_id")
                    .HasColumnType("bigint(20)");
                
                entity.Property(e => e.elevator_id)
                    .HasColumnName("elevator_id")
                    .HasColumnType("bigint(20)");
                
                
                entity.Property(e => e.battery_id)
                    .HasColumnName("battery_id")
                    .HasColumnType("bigint(20)");

                
                entity.Property(e => e.building_id)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");
                
                
                entity.Property(e => e.customer_id)
                    .HasColumnName("customer_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.intervention_starting_date_time)
                    .HasColumnName("intervention_start_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.intervention_ending_date_time)
                    .HasColumnName("intervention_end_date_time")
                    .HasColumnType("datetime");    

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
