// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Custom.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the Custom.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Infrastructure.Database;

using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

public class CustomFieldNameConvention : IModelFinalizingConvention
{
    #region Public Methods and Operators

    public void ProcessModelFinalizing(
        IConventionModelBuilder modelBuilder,
        IConventionContext<IConventionModelBuilder> context)
    {
        foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.Name.Length < 5)
                {
                    continue;
                }

                var backingFieldName = ConvertToBackingFieldName(property.Name);

                var fieldInfo = entityType.ClrType.GetField(
                    backingFieldName,
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                if (fieldInfo != null)
                {
                    Console.WriteLine($"Setting backing field: {backingFieldName} for property: {property.Name}");

                    modelBuilder.Entity(entityType.ClrType)
                                .Property(property.ClrType, property.Name)
                                .HasField(backingFieldName);
                    // property.SetField(backingFieldName);
                }
            }
        }
    }

    #endregion

    #region Methods

    private static string ConvertToBackingFieldName(string propertyName)
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            return propertyName;
        }

        // Split the property name at each underscore
        var parts = propertyName.Split('_');

        // Convert the first part to lowercase
        var firstPartLower = parts[0].ToLower(CultureInfo.InvariantCulture);

        // Convert the remaining parts to camelCase
        var camelCaseParts = parts.Skip(1).Select(p => p).ToArray();

        // Concatenate all parts and return
        return $"_{firstPartLower}{string.Concat(camelCaseParts)}";
    }

    #endregion
}