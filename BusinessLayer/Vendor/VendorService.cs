using Data;
using Entities;
using Entities.ListItem;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Account;
using Models.Vendor;
using Entities.Vendor;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Constant.ResponseMessage;

namespace BusinessLayer.Vendor;

public class VendorService : IVendorService
{
    private readonly DataContext _context;

    public VendorService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<VendorModel>> VendorListAsync()
    {
        try
        {
            var vendorList =
                await (from v in _context.Vendor
                    join l in _context.ListItem on v.VendorStatusListItem equals l.ListItemId
                    join li in _context.ListItem on v.VendorTypeListItem equals li.ListItemId
                    select new VendorModel
                    {
                        VendorId = v.VendorId,
                        VendorName = v.VendorName,
                        VendorStatusListItem = l.ListItemName,
                        VendorTypeListItem = li.ListItemName,
                        TaxRegistrationNumber = v.TaxRegistrationNumber
                    }).ToListAsync();
            return vendorList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ResponseMessageModel> CreateVendor(CreateVendorModel createVendorModel)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var checkIfVenderExists = _context.Vendor.Any(v => v.VendorName == createVendorModel.VendorName);
            if (checkIfVenderExists) return new ResponseMessageModel() { ResponseMessage = "Vendor Already Exists" };

            var vendor = new Entities.Vendor.Vendor
            {
                VendorName = createVendorModel.VendorName,
                VendorStatusListItem = createVendorModel.VendorStatusListItem,
                VendorTypeListItem = createVendorModel.VendorTypeListItem,
                TaxRegistrationNumber = createVendorModel.TaxRegistrationNumber,
                InsertDate = DateTimeOffset.UtcNow,
                InsertPersonId = "1",
                UpdateDate = DateTimeOffset.UtcNow,
                UpdatePersonId = "1"
            };
            await _context.Vendor.AddAsync(vendor);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return new ResponseMessageModel()
            {
                ResponseMessage = ResponseMessage.VendorCreatedSuccessfully
            };
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
        
    }

    public async Task<UpdateVendorModel> GetVendorById(string vendorId)
    {
        var vendor = await (from v in _context.Vendor
            where v.VendorId == vendorId
            select new UpdateVendorModel
            {
                VendorId = v.VendorId,
                VendorName = v.VendorName,
                VendorStatusListItem = v.VendorStatusListItem,
                VendorTypeListItem = v.VendorTypeListItem,
                TaxRegistrationNumber = v.TaxRegistrationNumber
            }).FirstOrDefaultAsync();
        return vendor;
    }

    public async Task<ResponseMessageModel> UpdateVendor(string Id, UpdateVendorModel updateVendorModel)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var editVendor = await _context.Vendor.Where(v => v.VendorId == Id).FirstOrDefaultAsync();
            if (editVendor == null) return new ResponseMessageModel() { ResponseMessage = "No Vendor Selected" };

            var vendor = new Entities.Vendor.Vendor
            {
                VendorName = updateVendorModel.VendorName,
                VendorStatusListItem = updateVendorModel.VendorStatusListItem,
                VendorTypeListItem = updateVendorModel.VendorTypeListItem,
                TaxRegistrationNumber = updateVendorModel.TaxRegistrationNumber,
                UpdateDate = DateTimeOffset.UtcNow,
                UpdatePersonId = "1"
            };
            _context.Vendor.Update(vendor);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return new ResponseMessageModel()
            {
                ResponseMessage = ResponseMessage.VendorCreatedSuccessfully
            };
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}