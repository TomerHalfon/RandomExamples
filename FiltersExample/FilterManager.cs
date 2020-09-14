using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersExample
{
    /// <summary>
    /// An object Filter Manager
    /// </summary>
    /// <typeparam name="T">The type of the filterd item</typeparam>
    class FilterManager<T>
    {
        Predicate<T> _filters;
        /// <summary>
        /// The output view
        /// </summary>
        public ObservableCollection<T> FilterdList { get; }

        readonly IEnumerable<T> _baseData;
        /// <summary>
        /// Create an instance of the Filter Manager
        /// </summary>
        /// <param name="baseData">The full data source</param>
        /// <param name="filters">The filters conditions</param>
        public FilterManager(IEnumerable<T> baseData, params Predicate<T>[] filters)
        {
            _baseData = baseData;
            FilterdList = new ObservableCollection<T>(baseData);
            LinkPredicates(filters);
        }
        void LinkPredicates(Predicate<T>[] predicates)
        {
            foreach (Predicate<T> filter in predicates)
            {
                _filters = _filters?.GetInvocationList()[0] is Predicate<T> temp ? x => temp(x) && filter(x) : filter;
            }
        }
        /// <summary>
        /// Apply filters to view
        /// </summary>
        public void ApplyFilters()
        {
            var filtered = _baseData.Where(item => _filters(item));
            Remove_FromFilterd(filtered);
            AddMissinigToFiltered(filtered);
        }
        void Remove_FromFilterd(IEnumerable<T> filteredData)
        {
            for (int i = FilterdList.Count - 1; i >= 0; i--)
            {
                var item = FilterdList[i];
                if (!filteredData.Contains(item))

                {
                    FilterdList.Remove(item);
                }
            }
        }
        void AddMissinigToFiltered(IEnumerable<T> filteredData)
        {
            foreach (var item in filteredData)
            {
                if (!FilterdList.Contains(item))
                {
                    FilterdList.Add(item);
                }
            }
        }
    }
}