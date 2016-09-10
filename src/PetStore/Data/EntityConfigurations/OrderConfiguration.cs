using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;

namespace PetStore.EntityConfigurations
{
    public static class OrderConfiguration
    {
        public static void ConfigureOrder(this EntityTypeBuilder<Order> b)
        {
            
            b.ToTable("Orders","Order");

            b.HasKey(o => o.Id);

            b.HasOne(o => o.ShippingAddress)
                .WithMany(uadd => uadd.Orders)
                .HasForeignKey(o => o.ShippingAddressId)
                .HasPrincipalKey(uadd => uadd.Id)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(o => o.Status)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.StatusId)
                .HasPrincipalKey(os => os.Id)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public static void ConfigureOrderStatus(this EntityTypeBuilder<OrderStatus> b)
        {
            b.ToTable("OrderStatus", "Order");

            b.HasKey(os => os.Id);

        }

        public static void ConfigureOrdersItem(this EntityTypeBuilder<OrderItem> b)
        {
            b.ToTable("OrderItems", "Order");

            b.HasKey(op => new { op.OrderId, op.ProductId });

            //Many to Many
            b.HasOne(op => op.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(oi => oi.OrderId)
                .HasPrincipalKey(o => o.Id);

            b.HasOne(oi => oi.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(oi => oi.ProductId)
                .HasPrincipalKey(p=>p.Id);

        }

    }
}
