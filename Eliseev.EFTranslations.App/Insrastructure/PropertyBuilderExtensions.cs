using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Eliseev.EFTranslations.App.Insrastructure
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<TProperty> HasValueGenerator<TEntityType, TProperty>(
            this PropertyBuilder<TProperty> propertyBuilder,
            Func<TEntityType, TProperty> func)
        {
            propertyBuilder.HasValueGenerator((x, y)
                => new CustomValueGenerator<TEntityType, TProperty>(func));

            return propertyBuilder;
        }
    }

}