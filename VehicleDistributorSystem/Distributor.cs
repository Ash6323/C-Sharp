using System;

internal class ManufacturerClass
{
	internal string manufacturerName;
}
internal class ModelClass : ManufacturerClass
{
	internal string vehicleCategory="";
    internal string modelName="";
	internal double basePrice;
	internal double priceAfterCommission;
}
internal class DistributorClass : ModelClass
{

    internal string distributorName;
    internal double commissionPercentage;
}