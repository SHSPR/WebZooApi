namespace WebZoo
{
    public class AnimalService : IAnimalService
    {
        public List<Animal> GetAllAnimals()
        {
            return InMemoryDatabase.Animals.ToList();
        }

        public Animal GetAnimalById(int id)
        {
            var exactAnimal = InMemoryDatabase.Animals.FirstOrDefault(a => a.Id == id);

            return exactAnimal;
        }

        public Animal AddAnimal(string animaltype, string name)
        {
            Animal animal = new Animal();
            animal.Id = InMemoryDatabase.GetNextId();
            animal.Name = name;
            animal.AnimalType = animaltype;
            InMemoryDatabase.Animals.Add(animal);

            return animal;
        }

        public void FeedAnimal(int id, int foodQuantity) 
        {            
            var selectedAnimalToFeed = GetAnimalById(id);

            if (selectedAnimalToFeed.Energy + foodQuantity > 100)
                {
                    selectedAnimalToFeed.Energy = 100;
                }
                else
                {
                    selectedAnimalToFeed.Energy += foodQuantity;
                }
        }

        public void RemoveAnimal(int id) 
        {
            var animalToRemove = InMemoryDatabase.Animals.FirstOrDefault(a=>a.Id == id);

            InMemoryDatabase.Animals.Remove(animalToRemove);
        }
    }
}
