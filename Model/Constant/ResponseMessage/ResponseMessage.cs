namespace Models.Constant.ResponseMessage;

public static class ResponseMessage
{
    #region Vendor

    public const string VendorCreatedSuccessfully = "Vendor Created Successfully";
    public const string VendorUpdatedSuccessfully = "Vendor Updated Successfully";
    public const string VendorIdNotValid = "Vendor Id not valid.";

    #endregion
    
    #region Product
    public const string ProductCreatedSucessfully = "Product Created Successfully";
    public const string ProductCodeAlreadyExists = "Product Code Alraedy Exists..!";
    public const string ProductIdNotValid = "Product Id not valid.";
    public const string ProductUpdatedSuccessfully = "Product Updated Successfully";
    public const string ProductCodeMustBeUnique = "Product Code must be Unique";
    #endregion

}