using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schulverwaltung.Entities;

namespace Schulverwaltung.Models
{
    public class GroupedCategoryItemsByCategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IGrouping<int, CategoryItemDetailsModel> Items { get; set; }
    }
}
