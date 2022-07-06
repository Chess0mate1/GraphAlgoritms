using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Core.Extentions
{
    public static class ObservableCollectionExtentions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        //public static ObservableCollection<T> Clone<T>(this ObservableCollection<T> from)
        //{
        //    ObservableCollection<T> to = new();

        //    foreach (T item in from)
        //    {
        //        to.Add(item);
        //    }

        //    return to;
        //}
    }
}
