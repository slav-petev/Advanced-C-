using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

public class PetrolPump
{
    public int PetrolAmountToGive { get; set; }
    public int DistanceToNextPump { get; set; }

    public override string ToString()
    {
        return $"Gives {PetrolAmountToGive}{Environment.NewLine}Distance To next: {DistanceToNextPump}";
    }

    public static PetrolPump Parse(string petrolPumpInfo)
    {
        var petrolPumInfoParts = petrolPumpInfo.Split(new[] {' '},
            StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        return new PetrolPump
        {
            PetrolAmountToGive = petrolPumInfoParts[0],
            DistanceToNextPump = petrolPumInfoParts[1]
        };
    }
}

public class TruckTourExcercise
{
    public static void Main()
    {
        var petrolPumps = ReadPetrolPumps();
        var petrolPumpsArray = petrolPumps.ToArray();
        var firstPetrolPump = petrolPumps.Peek();
        var journeyComplete = false;

        while (true)
        {
            var currentPetrolPump = petrolPumps.Dequeue();
            petrolPumps.Enqueue(currentPetrolPump);
            firstPetrolPump = currentPetrolPump;
            
            var fuelAmount = currentPetrolPump.PetrolAmountToGive;
            while (fuelAmount >= currentPetrolPump.DistanceToNextPump)
            {
                fuelAmount -= currentPetrolPump.DistanceToNextPump;
                currentPetrolPump = petrolPumps.Dequeue();
                petrolPumps.Enqueue(currentPetrolPump);
                if (currentPetrolPump == firstPetrolPump)
                {
                    journeyComplete = true;
                    break;
                }
                fuelAmount += currentPetrolPump.PetrolAmountToGive;
            }

            if (journeyComplete)
            {
                Console.WriteLine(petrolPumpsArray.ToList().IndexOf(firstPetrolPump));
                break;
            }
        }
    }

    private static Queue<PetrolPump> ReadPetrolPumps()
    {
        var numberOfPumps = int.Parse(Console.ReadLine());
        var petrolPumps = new Queue<PetrolPump>();

        for (var i = 0; i < numberOfPumps; ++i)
        {
            petrolPumps.Enqueue(PetrolPump.Parse(Console.ReadLine()));
        }

        return petrolPumps;
    }
}
