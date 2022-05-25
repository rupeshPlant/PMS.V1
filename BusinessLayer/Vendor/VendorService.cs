using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Vendor;
using Microsoft.Extensions.Logging;
using Models.Common;
using Models.Constant.ResponseMessage;
using System.Linq.Dynamic.Core;
namespace BusinessLayer.Vendor;

public class VendorService : IVendorService
{
    private readonly DataContext _context;
    private readonly ILogger<VendorService> _logger;

    public VendorService(DataContext context, ILogger<VendorService> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<VendorDataTableModel> VendorListAsync(DataTableRequestModel model)
    {
        try
        {
            int pageSize = model.Length != null ? Convert.ToInt32(model.Length) : 0;
            int skip = model.Start != null ? Convert.ToInt32(model.Start) : 0;
            
            var vendorList = (from v in _context.Vendor
                    join l in _context.ListItem on v.VendorStatusListItem equals l.ListItemId
                    join li in _context.ListItem on v.VendorTypeListItem equals li.ListItemId
                    select new VendorModel
                    {
                        VendorId = v.VendorId,
                        VendorName = v.VendorName,
                        VendorStatusListItem = l.ListItemName,
                        VendorTypeListItem = li.ListItemName,
                        TaxRegistrationNumber = v.TaxRegistrationNumber
                    });
            if (!string.IsNullOrEmpty(model.SortColumn) && !string.IsNullOrEmpty(model.SortColumnDirection))
            {
                vendorList = vendorList.OrderBy(model.SortColumn + " " + model.SortColumnDirection);
            }
            if (!string.IsNullOrEmpty(model.SearchValue))
            {
                vendorList = vendorList.Where(r => r.VendorName.ToLower().Contains(model.SearchValue.ToLower()));
            }
            int recordsTotal = vendorList.Count();
            var data = await vendorList.Skip(skip).Take(pageSize).ToListAsync();

            return new VendorDataTableModel
            {
                Draw = model.Draw,
                RecordsFiltered = recordsTotal.ToString(),
                RecordsTotal = recordsTotal.ToString(),
                Data = data
            };
        }
        catch (Exception e)
        {
            _logger.LogError("Error while fetching all Product. Exception message: {Message}", e.Message);
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

    public async Task<UpdateVendorModel> GetVendorByIdAsync(string vendorId)
    {
        try
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
            if (vendor != null)
            {
                return vendor;
            }

            return new UpdateVendorModel
            {

            };
        }
        catch (Exception e)
        {
            _logger.LogError("Error while fetching Company Rate. Exception message: {Message}", e.Message);
            throw;
        }
    }

    public async Task<ResponseMessageModel> UpdateVendor(UpdateVendorModel updateVendorModel)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var vendor = await _context.Vendor.Where(v => v.VendorId == updateVendorModel.VendorId).FirstOrDefaultAsync();
            if (vendor == null) return new ResponseMessageModel() { ResponseMessage = ResponseMessage.VendorIdNotValid };

            // var vendor = new Entities.Vendor.Vendor
            // {
            //     VendorId = updateVendor.VendorId,
            //     VendorName = updateVendorModel.VendorName,
            //     VendorStatusListItem = updateVendorModel.VendorStatusListItem,
            //     VendorTypeListItem = updateVendorModel.VendorTypeListItem,
            //     TaxRegistrationNumber = updateVendorModel.TaxRegistrationNumber,
            //     InsertPersonId = updateVendorModel.InsertPersonId,
            //     InsertDate = updateVendorModel.InsertDate,
            //     UpdateDate = updateVendorModel.UpdateDate,
            //     UpdatePersonId = "1"
            // };

            vendor.VendorName = updateVendorModel.VendorName;
            vendor.VendorStatusListItem = updateVendorModel.VendorStatusListItem;
            vendor.VendorTypeListItem = updateVendorModel.VendorTypeListItem;
            vendor.TaxRegistrationNumber = updateVendorModel.TaxRegistrationNumber;
            vendor.UpdateDate = updateVendorModel.UpdateDate;
            vendor.UpdatePersonId = "1";
                
            _context.Vendor.Update(vendor);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return new ResponseMessageModel()
            {
                ResponseMessage = ResponseMessage.VendorUpdatedSuccessfully
            };
        }
        catch (Exception e)
        {
            _logger.LogError("Error while updating Product. Exception message: {Message}", e.Message);
            throw;
        }
    }
}