using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Shared.Dogs.Queries.AllDogsQuery
{
    public class FilteredDogsList
    {
        public List<FilteredDogsForListVm> Dogs { get; set; }
    }
    public class FilteredDogsForListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
