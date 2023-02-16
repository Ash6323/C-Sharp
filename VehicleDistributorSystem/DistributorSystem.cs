using System.Collections.Generic;
using System;

internal class VehicleDistributorSystem : DistributorClass
{   
    internal void runDistributorSystem()
    {
        int numberOfDistributors;
        while (true)
        {
            Console.Write("How many Models do you want to input?: ");
            numberOfDistributors = Convert.ToInt32(Console.ReadLine());
            if (numberOfDistributors <= 0)
                Console.WriteLine(ConstantMessagesForOutput.Messages.wrongInput);
            else
                break;
        }
        DistributorClass[] distributor = new DistributorClass[numberOfDistributors];
        for (int i = 0; i < numberOfDistributors; i++)
            distributor[i] = new DistributorClass();

        List<DistributorClass> DistributorList = new List<DistributorClass>();

        for (int i=0; i<numberOfDistributors; i++)
        {
            while(true)
            {
                Console.WriteLine($"\nEnter Details of Model {i + 1} Below... ");
                Console.Write("Enter the Name of Model: ");
                distributor[i].modelName = Console.ReadLine();
                if (ValidationMethods.VehicleNameValidate(distributor[i].modelName))
                    Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
                else
                    break;
            }
            
            while(true)
            {
                Console.Write("Enter the Manufacturer of Model: ");
                distributor[i].manufacturerName = Console.ReadLine();
                if (ValidationMethods.VehicleNameValidate(distributor[i].manufacturerName))
                    Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
                else
                    break;
            }
            
            while (true)
            {
                Console.Write("Enter the Category of Model -\n1: Two-Wheeler, 2: Four-Wheeler:  ");
                int vehicleCategoryChoice = Convert.ToInt32(Console.ReadLine());
                if (vehicleCategoryChoice == 1)
                {
                    distributor[i].vehicleCategory = "Two Wheeler";
                    break;
                }
                else if (vehicleCategoryChoice == 2)
                {
                    distributor[i].vehicleCategory = "Four Wheeler";
                    break;
                }
                else
                    Console.WriteLine(ConstantMessagesForOutput.Messages.wrongInput);
            }

            while(true)
            {
                Console.Write("Enter the Base Price of the Model: ");
                distributor[i].basePrice = Convert.ToDouble(Console.ReadLine());
                if (distributor[i].basePrice <= 0)
                    Console.WriteLine(ConstantMessagesForOutput.Messages.wrongInput);
                else
                    break;
            }

            while(true)
            {
                Console.Write("Enter the name of Distributor: ");
                distributor[i].distributorName = Console.ReadLine();
                if (ValidationMethods.VehicleNameValidate(distributor[i].distributorName))
                    Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
                else
                    break;
            }
            
            while(true)
            {
                Console.Write("Enter the Commission Percentage of the Distributor: ");
                distributor[i].commissionPercentage = Convert.ToDouble(Console.ReadLine());
                if (distributor[i].commissionPercentage <= 0 || distributor[i].commissionPercentage > 100)
                    Console.WriteLine(ConstantMessagesForOutput.Messages.wrongInput);
                else
                    break;
            }           
            distributor[i].priceAfterCommission = CommissionCalculatorClass.CommissionCalculator(distributor[i].basePrice, distributor[i].commissionPercentage);
            DistributorList.Add(distributor[i]);
        }
        List<double> sameVehicelPriceList = new List<double>();

        // PRINTING WHOLE DATABASE
        Console.WriteLine("\nSo Far, the Database for Vehicles in Distribution Centers is as Below-\n");
        foreach (var vehicle in DistributorList)
        {
            Console.WriteLine("Manufacturer Name: {0}, Distributor Name: {1}, Model Name: {2}, Vehicle Category: {3}, Base Price: {4}, Commission: {5}%, Selling Price: {6}", vehicle.manufacturerName, vehicle.distributorName, vehicle.modelName, vehicle.vehicleCategory, vehicle.basePrice, vehicle.commissionPercentage, vehicle.priceAfterCommission);
        }

        string findVehicleModel;
        while (true)
        {
            Console.Write("\nEnter the Name of Model for Which You Want the Best Price: ");
            findVehicleModel = Console.ReadLine();
            if (ValidationMethods.VehicleNameValidate(findVehicleModel))
                Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
            else
                break;
        }
        // MAKING SEPARATE LIST FOR PRICES OF VEHICLES
        foreach(var vehicle in DistributorList)
        {
            if (vehicle.modelName == findVehicleModel)
                sameVehicelPriceList.Add(vehicle.priceAfterCommission);
            else
            {
                Console.WriteLine("No Matching Vehicle found in Distributor Databases. Exiting System...");
                Environment.Exit(0);
            }
        }
        double minSellingPrice = sameVehicelPriceList.Min();    //MIN OF ALL VEHICLE SELLING PRICES

        // PRINTING DETAILS OF DISTRIBUTOR & MINIMUM PRICE FOR THE VEHICLE 
        foreach(var vehicle in DistributorList)
        {
            if(vehicle.priceAfterCommission == minSellingPrice)
                Console.WriteLine("\nDetails Regarding the Best Distributor for this Model are-\nModel Name: {0}, Dist Name: {1}, Selling Price: {2}", vehicle.modelName, vehicle.distributorName, vehicle.priceAfterCommission);
        }
    }
}
