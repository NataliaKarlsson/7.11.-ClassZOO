namespace _7._11._ClassZOO.Models.repos
{
    public class InMemoryRepo : IAnimalRepo
    {
        static int idCounter = 0;
        static List<Animals> animalsList = new List<Animals>();
        public Animals Create(Animals animal)
        {
            animal.Id = ++idCounter;
            animalsList.Add(animal);
            return animal;
        }
        public List<Animals> GetAll()
        {
            return animalsList;
        }


        public Animals GetById(int id)
        {
            Animals animals = null;
            foreach (Animals aAnimal in animalsList)
            {
                if (aAnimal.Id == id)
                {
                    animals = aAnimal;
                    break;
                }
            }
            return animals;

        }    
           

        
        public List<Animals> GetBySpecies(string species)
        {
            List<Animals> animalSpesies = new List<Animals>();
            foreach (Animals aAnimal in animalSpesies)
            {
                if (aAnimal.Spesies == species)
                {
                    animalSpesies.Add(aAnimal);
                }
            }
            return animalSpesies;
        }

        public void Update(Animals animals)
        {
            Animals orgAn = GetById(animals.Id);
            if (orgAn != null)
            {
                orgAn.AnimalName = animals.AnimalName;
                orgAn.Spesies = animals.Spesies;
                orgAn.CalleByName = animals.CalleByName;
                orgAn.Quantity = animals.Quantity;
            }
        }
        public void Delete(Animals animals)
        {
            if (animals != null)
            {
                animalsList.Remove(animals);
            }
        }

    }
}
