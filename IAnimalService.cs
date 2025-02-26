namespace WebZoo
{
    public interface IAnimalService
    {
        List<Animal> GetAllAnimals();
        Animal GetAnimalById(int id);
        Animal AddAnimal(string animaltype, string name);
        void FeedAnimal(int id, int foodQuantity);
        void RemoveAnimal(int id);
    }
}
