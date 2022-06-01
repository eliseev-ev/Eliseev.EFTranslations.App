using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;



namespace Eliseev.EFTranslations.App.Insrastructure
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity>
            PropertyValueGenerator<TEntity, TProperty>(
                this EntityTypeBuilder<TEntity> entityTypeBuilder,
                Expression<Func<TEntity, TProperty>> propertyExpression,
                Func<TEntity, TProperty> generatorFucntion)
             where TEntity : class
        {
            entityTypeBuilder
                .Property(propertyExpression)
                .HasValueGenerator(generatorFucntion);

            return entityTypeBuilder;
        }
    }

}