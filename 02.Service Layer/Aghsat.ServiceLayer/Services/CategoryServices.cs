using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer.Interface;
using Aghsat.ViewModel.Category;
using AutoMapper;

namespace Aghsat.ServiceLayer.Services
{
    public class CategoryServices : EntityService<Category>, ICategoryServices
    {
        public CategoryServices(IUnitOfWork uow) : base(uow) { }

        public override AddStatus Create(Category entity)
        {
            try
            {
                if (_dbset.Any(x => x.Name == entity.Name && !x.IsDeleted && x.IsActive)) return AddStatus.Exist;
                _dbset.Add(entity);
                return AddStatus.Succeeded;
            }
            catch (Exception ex)
            {
                return AddStatus.Error;
            }


        }

        public override DeleteStatus delete(int? id)
        {
            try
            {
                var category = _dbset.Find(id);
                if (category == null) return DeleteStatus.NotExist;
                _dbset.Remove(category);
                return DeleteStatus.Succeeded;
            }
            catch (Exception)
            {
                return DeleteStatus.Error;
            }
        }

        public override IEnumerable<Category> GetAll()
        {
            return _dbset.Where(x => x.IsActive && !x.IsDeleted).ToList();
        }

        public IEnumerable<Category> GetAllSubCategoriesByParentId(int? id)
        {
            return id <= 0 ? null : _dbset.Where(x => x.ParentCategoryId == id && x.IsActive && !x.IsDeleted).ToList();
        }

        public IEnumerable<Category> GetAllParentCategories()
        {
            return _dbset.Where(x => x.ParentCategoryId == null && x.IsActive && !x.IsDeleted).OrderByDescending(x => x.CreateDate).ToList();
        }

        public Category_Add_vm GetCategory_Add()
        {
            var categories = GetAllParentCategories();

            var categoryViewModel = new Category_Add_vm()
            {
                SubCategories = categories
            };
            return categoryViewModel;
        }

        public override updateStatus Update(Category entity)
        {
            return updateStatus.Succeeded;

        }
    }
}
