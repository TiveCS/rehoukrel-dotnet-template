using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RehoukrelTemplate.Core.Domain.Traits;

namespace RehoukrelTemplate.Core.Infra.Data.EFCore.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyCoreConfiguration(this ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            ApplyAuditableConfiguration(builder, entityType);
        }
    }
    
    private static void ApplyAuditableConfiguration(ModelBuilder builder, IMutableEntityType entityType)
    {
        if (typeof(IAuditable).IsAssignableFrom(entityType.ClrType))
        {
                
        }
    }
    
    public static void ApplySoftDeleteFilter(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                continue;

            var parameter = Expression.Parameter(entityType.ClrType, "e");
            var property = Expression.Property(parameter, nameof(ISoftDeletable.DeletedAt));
            var condition = Expression.Lambda(Expression.Not(property), parameter);

            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(condition);
        }
    }
}