namespace DogsMVC.Models
{
    public class DogsList
    {
        static List<Dog> dogs = new List<Dog> 
        {
            new Dog { ID = 1, Name = "Gibson", Age = 4},
            new Dog { ID = 2, Name = "Taylor", Age = 6},
            new Dog { ID = 3, Name = "Leif", Age = 8}
        };

        public Dog[] GetAllDogs()
        {
            return dogs
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Age)
                .ToArray();
        }
        public void AddDog(Dog dog)
        {
            dog.ID = dogs.Max(d => d.ID) + 1;
            dogs.Add(dog);
        }

        public Dog GetDogByID(int id)
        {
            return dogs
                .FirstOrDefault(p => p.ID == id);
        }
    }
}
