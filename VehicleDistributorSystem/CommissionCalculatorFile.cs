using System;

public static class CommissionCalculatorClass
{
	public static double CommissionCalculator(double basePrice, double commission)
	{
		double priceAfterCommission = basePrice + (basePrice * (commission / 100));
		return priceAfterCommission;
	}
}
