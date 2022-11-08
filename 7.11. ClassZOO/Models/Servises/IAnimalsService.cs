using _7._11._ClassZOO.Models.Viewmodels;

namespace _7._11._ClassZOO.Models.Servises
{
    public interface IAnimalsService
    {
        Animals Create(CreateAnimalsViewModel createAnimal);
        List<Animals> GetAll();
        List<Animals> FindBySpecies(string species);
        Animals FindById(int id);
        void Edit(int id, CreateAnimalsViewModel editAnimal);
        void Remove(int id);
    }
}
