namespace _7._11._ClassZOO.Models.repos
{
    public interface IAnimalRepo
    {
        Animals Create(Animals animal);
        Animals GetById(int id);
        List<Animals> GetAll();
        List<Animals> GetBySpecies(string species);
        
        void Update (Animals animals);
        void Delete (Animals animals);
    }
}
