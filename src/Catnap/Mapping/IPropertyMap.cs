using System.Reflection;

namespace Catnap.Mapping
{
    public interface IPropertyMap<in TEntity> where TEntity : class, new()
    {
        void SetValue(TEntity instance, object value, ISession session);
        PropertyInfo PropertyInfo { get; }
        string PropertyName { get; }
        void Done(IDomainMap domainMap);
    }
}