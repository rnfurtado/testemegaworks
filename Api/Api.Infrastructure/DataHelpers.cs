using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Api.Infrastructure
{
    public static class DataHelpers
    {
        public static T CheckUpdateObject<T>(T originalObj, T updateObj) where T : class
        {
            foreach (var property in updateObj.GetType().GetProperties())
            {
                var updateValue = property.GetValue(updateObj, null);
                var originalValue = originalObj.GetType().GetProperty(property.Name)?.GetValue(originalObj, null);

                if (updateValue == null || updateValue?.ToString() == DateTime.MinValue.ToString(CultureInfo.CurrentCulture))
                {
                    property.SetValue(updateObj, originalValue);
                }
            }
            return updateObj;
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> q, string sortField, bool ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            string method = ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }

        public static bool CheckExistingProperty<T>(string property) where T : class
        {
            if (!string.IsNullOrEmpty(property))
                return typeof(T).GetProperties().Any(w => w.Name.ToLower() == property.ToLower());

            return false;
        }
    }
}
