using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisonousPlants
{
    public class Plant
    {
        public int PesticideAmount { get; set; }
        public int Position { get; set; }
        public bool IsAlive { get; set; }

        public override string ToString()
        {
            return $"({PesticideAmount}, {Position})";
        }
    }

    public class PoisonousPlantsExcercise
    {
        public static void Main(string[] args)
        {
            var numberOfPlants = int.Parse(Console.ReadLine());
            var plantsInfo = Console.ReadLine();
            var gardenPlants = CreateGardenPlants(plantsInfo);

            var hasDeadPlants = false;

            do
            {
                hasDeadPlants = false;
                var initialPlant = gardenPlants.Peek();
                var leftPlant = gardenPlants.Dequeue();

                do
                {
                    var rightPlant = gardenPlants.Peek();
                    if (rightPlant.PesticideAmount > leftPlant.PesticideAmount)
                    {
                        rightPlant.IsAlive = false;
                        hasDeadPlants = true;
                        
                    }
                    if (leftPlant.IsAlive)
                    {
                        gardenPlants.Enqueue(leftPlant);
                    }
                    
                    leftPlant = gardenPlants.Dequeue();
                }
                while (leftPlant != initialPlant);

                if (leftPlant.IsAlive)
                {
                    gardenPlants.Enqueue(leftPlant);
                }
                var listOfPlants = gardenPlants.ToList().OrderBy(plant => plant.Position)
                    .ToList();
                gardenPlants = new Queue<Plant>(listOfPlants);
            }
            while (hasDeadPlants);

        }

        private static Queue<Plant> CreateGardenPlants(string plantsInfo)
        {
            var gardenPlants = new Queue<Plant>();
            var plantsInfoParts = plantsInfo.Split(' ');
            for (var i = 0; i < plantsInfoParts.Length; ++i)
            {
                gardenPlants.Enqueue(
                    new Plant
                    {
                        IsAlive = true,
                        Position = i + 1,
                        PesticideAmount = int.Parse(plantsInfoParts[i])
                    });
            }
            return gardenPlants;
        }
    }
}
