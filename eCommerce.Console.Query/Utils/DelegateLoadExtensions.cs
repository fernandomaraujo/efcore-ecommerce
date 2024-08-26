using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Query.Utils
{
    public static class DelegateLoadExtensions
    {
        /*
         Referência: https://learn.microsoft.com/pt-br/ef/core/querying/related-data/lazy
        */

        public static TRelated Load<TRelated>(
            this Action<object, string> loader,
            object entity,
            ref TRelated navigationField,
            [CallerMemberName] string navigationName = null)
            where TRelated : class
        {
            loader?.Invoke(entity, navigationName);

            return navigationField;
        }
    }


}
