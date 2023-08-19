using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Api.Aspects;
using ShoppingAPI.Api.Validation.FluentValidation;
using ShoppingAPI.Business.Abstract;
using ShoppingAPI.Entity.DTO.Category;
using ShoppingAPI.Entity.DTO.User;
using ShoppingAPI.Entity.Poco;
using ShoppingAPI.Entity.Result;
using ShoppingAPI.Helper.CustomException;
using System.Net;

namespace ShoppingAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CategoryController:Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost("/AddCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult>AddCategory(CategoryDTORequest categoryDTORequest)
        {
           
            
                Category category = _mapper.Map<Category>(categoryDTORequest);

               await _categoryService.AddAsync(category);

                CategoryDTOResponse categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);

                return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
            
            
        }


        [HttpPost("/UpdateCategory")]
        [ValidationFilter(typeof(CategoryValidator))]
        public async Task<IActionResult> UpdateCategory(CategoryDTORequest categoryDTORequest)
        {
            Category category = await _categoryService.GetAsync(q => q.Guid == categoryDTORequest.Guid);
            category.Name = categoryDTORequest.Name;
            await _categoryService.UpdateAsync(category);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }


        [HttpGet("/Categories")]
        [ProducesResponseType(typeof(Sonuc<List<CategoryDTOResponse>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult>GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            //categories = null;
            if (categories!=null)
            {
                List<CategoryDTOResponse> categoryDTOResponseList = new();

                foreach (var category in categories)
                {
                    categoryDTOResponseList.Add(_mapper.Map<CategoryDTOResponse>(category));
                }
                return Ok(Sonuc<List<CategoryDTOResponse>>.SuccessWithData(categoryDTOResponseList));
            }
            else
            {
                return NotFound(Sonuc<List<CategoryDTOResponse>>.SuccessNoDataFound());
            }
        }

        [HttpGet("/ActiveCategories")]
        [ProducesResponseType(typeof(Sonuc<List<CategoryDTOResponse>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetCategories_Active()
        {
            var categories = await _categoryService.GetAllAsync(q=>q.IsActive==true && q.IsDeleted ==false);
            //categories = null;
            if (categories != null)
            {
                List<CategoryDTOResponse> categoryDTOResponseList = new();

                foreach (var category in categories)
                {
                    categoryDTOResponseList.Add(_mapper.Map<CategoryDTOResponse>(category));
                }
                return Ok(Sonuc<List<CategoryDTOResponse>>.SuccessWithData(categoryDTOResponseList));
            }
            else
            {
                return NotFound(Sonuc<List<CategoryDTOResponse>>.SuccessNoDataFound());
            }
        }


        [HttpGet("/Category/{categoryGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<CategoryDTOResponse>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetCategory(Guid categoryGUID)
        {
            var category = await _categoryService.GetAsync(q=>q.Guid== categoryGUID);
            //categories = null;
            if (category != null)
            {
                CategoryDTOResponse categoryDTOResponse = new();


                categoryDTOResponse = _mapper.Map<CategoryDTOResponse>(category);
                
                return Ok(Sonuc<CategoryDTOResponse>.SuccessWithData(categoryDTOResponse));
            }
            else
            {
                return NotFound(Sonuc<List<CategoryDTOResponse>>.SuccessNoDataFound());
            }



        }

        [HttpPost("/RemoveCategory")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult>RemoveCategory(CategoryDTORequest categoryDTORequest)
        {
            Category category = await _categoryService.GetAsync(q => q.Guid == categoryDTORequest.Guid);
            category.IsActive = false;
            category.IsDeleted = true;
            await _categoryService.UpdateAsync(category);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

    }
}
