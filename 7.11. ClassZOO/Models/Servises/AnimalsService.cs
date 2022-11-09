using _7._11._ClassZOO.Models.repos;
using _7._11._ClassZOO.Models.Viewmodels;

namespace _7._11._ClassZOO.Models.Servises
{
    public class AnimalsService : IAnimalsService
    {
        IAnimalRepo _animalRepo;
        public AnimalsService(IAnimalRepo animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public Animals Create(CreateAnimalsViewModel createAnimal)
        {
            if (string.IsNullOrWhiteSpace(createAnimal.AnimalName) || string.IsNullOrWhiteSpace(createAnimal.Spesies) || string.IsNullOrWhiteSpace(createAnimal.CalleByName))
            { throw new ArgumentException("AnimalName, Species, CalledByName is not allowed whitespace"); }
            Animals animals = new Animals()
            {
                AnimalName = createAnimal.AnimalName,
                Spesies = createAnimal.Spesies,
                CalleByName = createAnimal.CalleByName,
                Quantity = createAnimal.Quantity

            };
            animals =_animalRepo.Create(animals);
            return animals;
        }
               

        public void Edit(int id, CreateAnimalsViewModel editAnimal)
        {
            Animals animal = _animalRepo.GetById(id);
            _animalRepo.Update(animal);
            if (animal != null)
            {
                animal.AnimalName = editAnimal.AnimalName;
                animal.Spesies = editAnimal.Spesies;
                animal.CalleByName = editAnimal.CalleByName;
                animal.Quantity = editAnimal.Quantity;
            }
            return;
        }

        public Animals FindById(int id)
        {
           return _animalRepo.GetById(id);
        }

        public List<Animals> FindBySpecies(string species)
        {
            return _animalRepo.GetBySpecies(species);
        }

        public List<Animals> GetAll()
        {
            return _animalRepo.GetAll();
        }

        public void Remove(int id)
        {
            Animals animal = _animalRepo.GetById(id);
            if (animal != null)
            {
                _animalRepo.Delete(animal);
            }
            return;
        }
        public Animals? LastAdded()
        {
            List<Animals> animals = _animalRepo.GetAll();
            if(animals.Count < 1)
            {
                return null;
            }
            return animals.Last();
        }
    }
}
