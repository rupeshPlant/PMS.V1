using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Vendor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Common;
using Models.Vendor;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseApiController
    {
        private readonly IVendorService _iVendorService;

        public VendorController(IVendorService iVendorService)
        {
            _iVendorService = iVendorService;
        }

        [HttpPost("VendorList")]
        public async Task<VendorDataTableModel> VendorList(DataTableRequestModel model)
        {
            return await _iVendorService.VendorListAsync(model);
        }

        [HttpPost("CreateVendor")]
        public async Task<ResponseMessageModel> CreateVendor(CreateVendorModel createVendorModel)
        {
            return await _iVendorService.CreateVendor(createVendorModel);
        }

        [HttpPost("GetVendorId/{vendorId}")]
        public async Task<UpdateVendorModel> GetVendorByIdAsync(string vendorId)
        {
            return await _iVendorService.GetVendorByIdAsync(vendorId);
        }

        [HttpPost("UpdateVendor")]
        public async Task<ResponseMessageModel> UpdateVendor(UpdateVendorModel updateVendorModel)
        {
            return await _iVendorService.UpdateVendor(updateVendorModel);
        }
    }
}