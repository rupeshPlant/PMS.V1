using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Common;
using Models.Constant.ResponseMessage;
using Models.Product;
using UI.Services.Refit;


namespace UI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _iProductService;

        public ProductController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            await InitializedViewBagAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductModel model)
        {

            if (ModelState.IsValid)
            {
                var response = await _iProductService.CreateProduct(model);
                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    if(responseMessage == ResponseMessage.ProductCreatedSucessfully)
                    {
                        TempData["Success"] = $"Successfully created Company Rate of {model.ProductName}";
                        return RedirectToAction("Index", "Product");
                    }
                    if(responseMessage == ResponseMessage.ProductCodeAlreadyExists)
                    {
                        TempData["Error"] = $"{model.ProductCode} already exists";
                        await InitializedViewBagAsync();
                        return View(model);
                    }
                }
                TempData["Error"] = $"Bad Request ";
                return RedirectToAction("Index", "Product");
            }
            await InitializedViewBagAsync();
            return View(model);
        }

        #region Helpers
        private async Task InitializedViewBagAsync()
        {
            var productRequest = await _iProductService.GetAllProductForDropdown();
            if (productRequest.IsSuccessStatusCode)
            {
                var product = await productRequest.Content.ReadAsAsync<List<ProductModel>>();
                ViewBag.product = new SelectList(product, "ProductId", "ProductName");
            }
        }
        #endregion

        #region DataTable

        [HttpPost]
        public async Task<IActionResult> GetProductDTResult([FromForm] DataTableRequestModel model)
        {
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = model.SortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() +
                                         "][name]"].FirstOrDefault();
            var sortColumnDirection = model.SortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            model.SearchValue = searchValue;
            model.SortColumn = sortColumn;
            model.SortColumnDirection = sortColumnDirection;

            var response = await _iProductService.GetAllProduct(model);
            if (response.IsSuccessStatusCode)
            {
                var roles = await response.Content.ReadAsAsync<ProductDataTableModel>();
                return Json(new
                {
                    draw = roles.Draw,
                    recordsFiltered = roles.RecordsFiltered,
                    recordsTotal = roles.RecordsTotal,
                    data = roles.Data
                });
            }
            return BadRequest();
        }

        #endregion DataTable
    }
}
