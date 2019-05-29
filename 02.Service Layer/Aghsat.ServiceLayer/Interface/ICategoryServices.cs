using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.Domain.Entity;
using Aghsat.ViewModel.Category;

namespace Aghsat.ServiceLayer.Interface
{
    public interface ICategoryServices : IEntityService<Category>
    {
        IEnumerable<Category> GetAllSubCategoriesByParentId(int? id);
        IEnumerable<Category> GetAllParentCategories();
        Category_Add_vm GetCategory_Add();
    }
}
