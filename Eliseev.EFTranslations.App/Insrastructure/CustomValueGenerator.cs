using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Eliseev.EFTranslations.App.Insrastructure
{
    public class CustomValueGenerator<TEntityType, TProperty> : ValueGenerator<TProperty>
    {
        private readonly Func<TEntityType, TProperty> factoryGenerateValue;

        public CustomValueGenerator(Func<TEntityType, TProperty> factoryGenerateValue)
        {
            this.factoryGenerateValue = factoryGenerateValue;
        }

        public override TProperty Next(EntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }

            return factoryGenerateValue.Invoke((TEntityType)entry.Entity);
        }

        public override bool GeneratesTemporaryValues { get; }
    }
}