using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Business.Abstract;
using ShoppingAPI.Entity.DTO.Category;
using ShoppingAPI.Entity.DTO.Product;
using ShoppingAPI.Entity.Poco;
using ShoppingAPI.Entity.Result;
using System.Net;

namespace ShoppingAPI.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper, IProductService productService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet("/Products")]
        [ProducesResponseType(typeof(Sonuc<List<CategoryDTOResponse>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync(q=>q.IsActive==true && q.IsDeleted==false,"Category");
            //categories = null;
            if (products != null)
            {
                List<ProductDTOResponse> productDTOResponseList = new();

                foreach (var product in products)
                {
                    productDTOResponseList.Add(_mapper.Map<ProductDTOResponse>(product));
                }
                return Ok(Sonuc<List<ProductDTOResponse>>.SuccessWithData(productDTOResponseList));
            }
            else
            {
                return NotFound(Sonuc<List<CategoryDTOResponse>>.SuccessNoDataFound());
            }
        }


        [HttpGet("/Product/{productGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<CategoryDTOResponse>>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetProduct(Guid productGUID)
        {
            var product = await _productService.GetAsync(q => q.Guid==productGUID, "Category");
            //categories = null;
            if (product != null)
            {
                ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(product);
               
                return Ok(Sonuc<ProductDTOResponse>.SuccessWithData(productDTOResponse));
            }
            else
            {
                return NotFound(Sonuc<ProductDTOResponse>.SuccessNoDataFound());
            }
        }

        [HttpPost("/AddProduct")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> AddProduct([FromBody]ProductDTORequest productDTO)
        {
            Category category = await _categoryService.GetAsync(q => q.Guid == productDTO.CategoryGUID);

            Product product = _mapper.Map<Product>(productDTO);

            product.Category = category;

            await _productService.AddAsync(product);

            return Ok(Sonuc<bool>.SuccessWithData(true));
        }


        [HttpPost("/UpdateProduct")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductDTORequest productDTO)
        {
            Product product = await _productService.GetAsync(q => q.Guid == productDTO.Guid);

            Category category = await _categoryService.GetAsync(q => q.Guid == productDTO.CategoryGUID);

            product.Category = category;
            product.Name=productDTO.Name;
            product.Description = productDTO.Description;
            product.FeaturedImage = productDTO.FeaturedImage ?? product.FeaturedImage;

            await _productService.UpdateAsync(product);

            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

        [HttpPost("/RemoveProduct")]
        [ProducesResponseType(typeof(Sonuc<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult>RemoveProduct([FromBody]ProductDTORequest productDTO)
        {
            Product product = await _productService.GetAsync(q => q.Guid == productDTO.Guid);

            product.IsActive = false;
            product.IsDeleted = true;
            await _productService.UpdateAsync(product);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }
    }
}
