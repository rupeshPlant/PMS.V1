using Models;
using Models.Common;
using Models.Vendor;

namespace BusinessLayer.Vendor;

public interface IVendorService
{
    public Task<VendorDataTableModel> VendorListAsync(DataTableRequestModel model);
    public Task<ResponseMessageModel> CreateVendor(CreateVendorModel createVendorModel);
    public Task<UpdateVendorModel> GetVendorByIdAsync(string vendorId);
    public Task<ResponseMessageModel> UpdateVendor(UpdateVendorModel editVendorModel);
}