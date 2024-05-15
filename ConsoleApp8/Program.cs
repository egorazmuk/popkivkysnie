using System;
using System.Collections.Generic;

abstract class PassengerCar
{
    public int LowerBerths { get; set; }
    public int UpperBerths { get; set; }
    public int LowerSideBerths { get; set; }
    public int UpperSideBerths { get; set; }

    public Dictionary<string, decimal> AdditionalServices { get; set; } = new Dictionary<string, decimal>();

    public abstract decimal GetTotalIncome();

    protected decimal CalculateBaseIncome(decimal ticketPrice)
    {
        int totalSeats = LowerBerths + UpperBerths + LowerSideBerths + UpperSideBerths;
        return totalSeats * ticketPrice;
    }

    protected decimal CalculateServiceIncome()
    {
        decimal serviceIncome = 0;
        foreach (var service in AdditionalServices)
        {
            serviceIncome += service.Value;
        }
        return serviceIncome;
    }
}

class CompartmentCar : PassengerCar
{
    public decimal TicketPrice { get; set; }

    public override decimal GetTotalIncome()
    {
        return CalculateBaseIncome(TicketPrice) + CalculateServiceIncome();
    }
}

class PlatzkartCar : PassengerCar
{
    public decimal TicketPrice { get; set; }

    public override decimal GetTotalIncome()
    {
        return CalculateBaseIncome(TicketPrice) + CalculateServiceIncome();
    }
}

class LuxuryCar : PassengerCar
{
    public decimal TicketPrice { get; set; }

    public override decimal GetTotalIncome()
    {
        return CalculateBaseIncome(TicketPrice) + CalculateServiceIncome();
    }
}

class PassengerTrain
{
    public List<PassengerCar> Cars { get; set; } = new List<PassengerCar>();

    public decimal CalculateTotalIncome()
    {
        decimal totalIncome = 0;
        foreach (var car in Cars)
        {
            totalIncome += car.GetTotalIncome();
        }
        return totalIncome;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример создания вагонов
        CompartmentCar compartmentCar = new CompartmentCar
        {
            LowerBerths = 10,
            UpperBerths = 10,
            LowerSideBerths = 0,
            UpperSideBerths = 0,
            TicketPrice = 1000,
            AdditionalServices = new Dictionary<string, decimal>
            {
                { "WiFi", 200 },
                { "Meal", 150 }
            }
        };

        PlatzkartCar platzkartCar = new PlatzkartCar
        {
            LowerBerths = 20,
            UpperBerths = 20,
            LowerSideBerths = 10,
            UpperSideBerths = 10,
            TicketPrice = 500,
            AdditionalServices = new Dictionary<string, decimal>
            {
                { "Bedding", 50 }
            }
        };

        LuxuryCar luxuryCar = new LuxuryCar
        {
            LowerBerths = 5,
            UpperBerths = 5,
            LowerSideBerths = 0,
            UpperSideBerths = 0,
            TicketPrice = 2000,
            AdditionalServices = new Dictionary<string, decimal>
            {
                { "WiFi", 300 },
                { "Meal", 200 },
                { "Private Bathroom", 500 }
            }
        };

        // Создание поезда и добавление вагонов
        PassengerTrain train = new PassengerTrain();
        train.Cars.Add(compartmentCar);
        train.Cars.Add(platzkartCar);
        train.Cars.Add(luxuryCar);

        // Подсчет дохода от одного рейса
        decimal totalIncome = train.CalculateTotalIncome();
        Console.WriteLine($"Total income from one trip: {totalIncome}");
    }
}