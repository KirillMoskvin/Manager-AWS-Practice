using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagerData.Helpers
{
    class SortHelper
    {
        /// <summary>
        /// Сортировка ObservableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="coll"></param>
        /// <param name="selector"></param>
        /// <param name="ascending"></param>
        public static void SortCollection<T1, T2>(ObservableCollection<T1> coll, Func<T1, T2> selector, bool ascending = true)
        {
            ObservableCollection<T1> tmp;
            if (ascending)
                tmp = new ObservableCollection<T1>(coll.OrderBy(selector));
            else
                tmp = new ObservableCollection<T1>(coll.OrderByDescending(selector));
            coll.Clear();
            foreach (T1 elem in tmp)
                coll.Add(elem);
        }
    }
}
