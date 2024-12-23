using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class RomashkaHotel : IEnumerable
{
    private object[] _animals = new object[4];
    private int _count = 0;
    private int _capacity = 4;
    
    public void FeedAnimals()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.Eat();
            }
        }
    }
    
    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.Sleep();
            }
        }
    }
    
    public void AddAnimal(object animal)
    {
        if (_count == _capacity)
        {
            _capacity *= 2;
            Array.Resize(ref _animals, _capacity);
        }
        
        _animals[_count++] = animal;
    }
    
    public void Sort()
    {
        var animalsOfTypeIAnimal = _animals.OfType<IAnimal>().ToArray();
        var sortedAnimals = animalsOfTypeIAnimal.OrderBy(a => a.Age).ToArray();
        // Reassign sorted animals back to _animals
        _animals = sortedAnimals.Cast<object>().ToArray();
    }
    
    public void PrintAnimals()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.ShowAnimalInfo();
            }
        }
    }
    
    public Object[] GetAnimalsWithOwner()
    {
        var animalsOfTypeIAnimal = _animals.OfType<IAnimal>().ToArray();
        var animalsWithOwnerName = animalsOfTypeIAnimal.Where(a => a.Owner?.Name?.Length > 0).ToArray();
        return animalsWithOwnerName.Cast<object>().ToArray();
    }
    
    public object this[int index]
    {
        get
        {
            if (index >= 0 && index < _count)
            {
                return _animals[index];
            }
            throw new IndexOutOfRangeException("Index is out of range.");
        }
        set
        {
            if (index >= 0 && index < _count)
            {
                _animals[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        for(var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }
}