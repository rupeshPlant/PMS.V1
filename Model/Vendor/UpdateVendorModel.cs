namespace Models.Vendor;

public class UpdateVendorModel
{
    public string VendorId { get; set; }
    public string VendorName { get; set; }
    public string VendorTypeListItem { get; set; }
    public string VendorStatusListItem { get; set; }
    public string TaxRegistrationNumber { get; set; }
    public string InsertPersonId { get; set; }
    public DateTimeOffset InsertDate { get; set; }

    public string UpdatePersonId { get; set; }

    public DateTimeOffset UpdateDate { get; set; }
}