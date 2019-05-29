using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain.Entity;
using Aghsat.ServiceLayer.Interface;
using Aghsat.ViewModel.Product;
using AutoMapper;

namespace Aghsat.ServiceLayer.Services
{
    public class ProductServices : EntityService<Product>, IProductServices
    {
        private readonly IUnitService _unitService;
        private readonly ICategoryServices _categoryServices;


        public ProductServices(IUnitOfWork uow, IUnitService unitService, ICategoryServices categoryServices) : base(uow)
        {
            _unitService = unitService;
            _categoryServices = categoryServices;
        }

        public override AddStatus Create(Product entity)
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
                var Product = _dbset.Find(id);
                if (Product == null) return DeleteStatus.NotExist;
                _dbset.Remove(Product);
                return DeleteStatus.Succeeded;
            }
            catch (Exception)
            {
                return DeleteStatus.Error;
            }
        }

        public override IEnumerable<Product> GetAll()
        {
            return _dbset.Include(p => p.Category)
                .Include(p => p.Unit)
                .Where(x => x.IsActive && !x.IsDeleted).ToList();
        }

        public override updateStatus Update(Product entity)
        {
            return updateStatus.Succeeded;

        }

        public Product_Add_vm GetAddVm()
        {
            return new Product_Add_vm()
            { 
                 UnitDropDownList = _unitService.GetAll(),
                 CategoryDropDownList = _categoryServices.GetAllParentCategories()
            };
        }


        public Product_Add_vm GetAddVm(Product_Add_vm ViewModel)
        {
            ViewModel.UnitDropDownList = _unitService.GetAll();
            ViewModel.CategoryDropDownList = _categoryServices.GetAllParentCategories();
            return ViewModel;
        }

        public Product_Add_vm GetAddVm(Product product)
        {

            return new Product_Add_vm()
            {
                Id = product.Id,
                UnitDropDownList = _unitService.GetAll(),
                CategoryDropDownList = _categoryServices.GetAllParentCategories(),
                CategoryId = product.CategoryId,
                UnitId = product.UnitId,
                CreateDate = product.CreateDate,
                ProductDate = product.ProductDate,
                Name = product.Name,
                IsActive = product.IsActive,
                IsDeleted = product.IsDeleted,
                MainImage = product.MainImage,
                ModifeDate = product.ModifeDate,
                                              
            };
            
        }


        public IEnumerable<Product_List_vm> GetListVms()
        {
            var products = GetAll();
            return Mapper.Map<IEnumerable<Product>, IEnumerable<Product_List_vm>>(products);

        }
    }
}
