using BusinessLayer.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : BaseApiController
    {
        private readonly IListItemService _listItemService;

        public CommonController(IListItemService listItemService)
        {
            _listItemService = listItemService;
        }
        
        
        // [HttpPost("GetAllListItem")]
        // public async Task<List<SelectListItem>> UpdateVendor(string listId)
        // {
        //     return await _listItemService.GetListItemDropDown(listId);
        // }
    }
}
