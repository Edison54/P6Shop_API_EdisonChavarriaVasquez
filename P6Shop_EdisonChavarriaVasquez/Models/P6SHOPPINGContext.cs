using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace P6Shop_EdisonChavarriaVasquez.Models
{
    public partial class P6SHOPPINGContext : DbContext
    {
        public P6SHOPPINGContext()
        {
        }

        public P6SHOPPINGContext(DbContextOptions<P6SHOPPINGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceInventory> InvoiceInventories { get; set; } = null!;
        public virtual DbSet<ItemPicture> ItemPictures { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Shipping> Shippings { get; set; } = null!;
        public virtual DbSet<ShippingChannel> ShippingChannels { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserStore> UserStores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=DESKTOP-AIMH9J6;DATABASE=P6SHOPPING; INTEGRATED SECURITY=TRUE; User Id=;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Idcountry)
                    .HasName("PK__Country__D9D5A69404B63237");

                entity.ToTable("Country");

                entity.HasIndex(e => e.CountryCode, "UQ__Country__5D9B0D2C797EE946")
                    .IsUnique();

                entity.HasIndex(e => e.CountryName, "UQ__Country__E056F2014876939C")
                    .IsUnique();

                entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.Idcurrency)
                    .HasName("PK__Currency__50890739B70C9C21");

                entity.ToTable("Currency");

                entity.Property(e => e.Idcurrency).HasColumnName("IDCurrency");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Idinventory)
                    .HasName("PK__Inventor__CD45C7BE0E11CF8D");

                entity.ToTable("Inventory");

                entity.Property(e => e.Idinventory).HasColumnName("IDInventory");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Idcurrency).HasColumnName("IDCurrency");

                entity.Property(e => e.IditemPicture).HasColumnName("IDItemPicture");

                entity.Property(e => e.Idstore).HasColumnName("IDStore");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ItemImageUrl)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ItemImageURL");

                entity.Property(e => e.ItemManufacturerNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ItemSku)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ItemSKU");

                entity.Property(e => e.ItemUpc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ItemUPC");

                entity.HasOne(d => d.IdcurrencyNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.Idcurrency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKInventory334173");

                entity.HasOne(d => d.IdstoreNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.Idstore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKInventory139758");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Idinvoice)
                    .HasName("PK__Invoice__4DA85D70992E6A0D");

                entity.ToTable("Invoice");

                entity.Property(e => e.Idinvoice).HasColumnName("IDInvoice");

                entity.Property(e => e.IdpaymentMethod).HasColumnName("IDPaymentMethod");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceNotes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsShoppingChart)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.IdpaymentMethodNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdpaymentMethod)
                    .HasConstraintName("FKInvoice537771");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKInvoice690119");
            });

            modelBuilder.Entity<InvoiceInventory>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceIdinvoice, e.InventoryIdinventory })
                    .HasName("PK__Invoice___2623EC5CE600C988");

                entity.ToTable("Invoice_Inventory");

                entity.Property(e => e.InvoiceIdinvoice).HasColumnName("InvoiceIDInvoice");

                entity.Property(e => e.InventoryIdinventory).HasColumnName("InventoryIDInventory");

                entity.Property(e => e.ItemPrice).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.InventoryIdinventoryNavigation)
                    .WithMany(p => p.InvoiceInventories)
                    .HasForeignKey(d => d.InventoryIdinventory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKInvoice_In601042");

                entity.HasOne(d => d.InvoiceIdinvoiceNavigation)
                    .WithMany(p => p.InvoiceInventories)
                    .HasForeignKey(d => d.InvoiceIdinvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKInvoice_In759876");
            });

            modelBuilder.Entity<ItemPicture>(entity =>
            {
                entity.HasKey(e => e.IditemPicture)
                    .HasName("PK__ItemPict__2FBB4E092BAC11BE");

                entity.ToTable("ItemPicture");

                entity.Property(e => e.IditemPicture).HasColumnName("IDItemPicture");

                entity.Property(e => e.Idinventory).HasColumnName("IDInventory");

                entity.Property(e => e.ItemPictureUrl)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ItemPictureURL");

                entity.HasOne(d => d.IdinventoryNavigation)
                    .WithMany(p => p.ItemPictures)
                    .HasForeignKey(d => d.Idinventory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKItemPictur611810");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.IdpaymentMethod)
                    .HasName("PK__PaymentM__2994821370268580");

                entity.ToTable("PaymentMethod");

                entity.Property(e => e.IdpaymentMethod).HasColumnName("IDPaymentMethod");

                entity.Property(e => e.PaymentMethodDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.Idshipping)
                    .HasName("PK__Shipping__3ED42B5E92FB8162");

                entity.ToTable("Shipping");

                entity.Property(e => e.Idshipping).HasColumnName("IDShipping");

                entity.Property(e => e.Idinvoice).HasColumnName("IDInvoice");

                entity.Property(e => e.IdshippingChannel).HasColumnName("IDShippingChannel");

                entity.Property(e => e.ShippingAddress)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingCity)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingDelivered)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShippingStreet)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdinvoiceNavigation)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.Idinvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKShipping688863");

                entity.HasOne(d => d.IdshippingChannelNavigation)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.IdshippingChannel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKShipping548666");
            });

            modelBuilder.Entity<ShippingChannel>(entity =>
            {
                entity.HasKey(e => e.IdshippingChannel)
                    .HasName("PK__Shipping__2B5DF8415A332088");

                entity.ToTable("ShippingChannel");

                entity.Property(e => e.IdshippingChannel).HasColumnName("IDShippingChannel");

                entity.Property(e => e.ShippingChannelDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Idstore)
                    .HasName("PK__Store__BD8985FA53D089C8");

                entity.ToTable("Store");

                entity.Property(e => e.Idstore).HasColumnName("IDStore");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.StoreDescription)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StoreWelcomeMessage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcountryNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.Idcountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKStore607261");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PK__User__EAE6D9DFA5CF71E9");

                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__User__A9D105340A8936A6")
                    .IsUnique();

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.BackUpEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idcountry).HasColumnName("IDCountry");

                entity.Property(e => e.IduserRole).HasColumnName("IDUserRole");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcountryNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Idcountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser179649");

                entity.HasOne(d => d.IduserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IduserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser896129");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.IduserRole)
                    .HasName("PK__UserRole__5A7AF781AE8EF669");

                entity.ToTable("UserRole");

                entity.Property(e => e.IduserRole).HasColumnName("IDUserRole");

                entity.Property(e => e.UserRoleDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserStore>(entity =>
            {
                entity.HasKey(e => new { e.Iduser, e.Idstore })
                    .HasName("PK__User_Sto__513E418002EB6E21");

                entity.ToTable("User_Store");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Idstore).HasColumnName("IDStore");

                entity.Property(e => e.IsFollowedByUser)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsStoreAdmin)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.IdstoreNavigation)
                    .WithMany(p => p.UserStores)
                    .HasForeignKey(d => d.Idstore)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser_Store535971");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.UserStores)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser_Store809685");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
