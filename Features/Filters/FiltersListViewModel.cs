using System.Collections.Generic;

namespace AspVue.Features.Filters
{
    public class FiltersListViewModel
    {
        public IEnumerable<string> Brands { get; set; }
        public IEnumerable<int> Storage { get; set; }
        public IEnumerable<string> Colors { get; set; }
        public IEnumerable<string> OS { get; set; }
        public IEnumerable<string> Features { get; set; }
    }
}