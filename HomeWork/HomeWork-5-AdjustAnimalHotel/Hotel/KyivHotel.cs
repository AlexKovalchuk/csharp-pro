using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class KyivHotel : IEnumerable<IAnimal>
{
    private int _count = 0;
    private int _capacity = 4;
    private IAnimal[] _animals = new IAnimal[4];
    
    public void FeedAnimals()
    {
        foreach (var animal in _animals)
        {
            animal.Eat();
        }
    }
    
    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals)
        {
            animal.Sleep();
        }
    }
    
    public void AddAnimal(IAnimal animal)
    {
        if (_count == _capacity)
        {
            _capacity *= 2;
            Array.Resize(ref _animals, _capacity);
        }
        
        _animals[_count++] = animal;
    }
    
    public void PrintAnimals()
    {
        foreach (var animal in _animals)
        {
            animal?.ShowAnimalInfo();
        }
    }
    
    public void Sort()
    {
        var sortedAnimals = _animals.Where(a => a != null).OrderBy(a => a.Age).ToArray();
        _animals = sortedAnimals;
    }
    
    public IAnimal[] GetAnimalsWithOwner()
    {
        return _animals.Where(a => a.Owner?.Name?.Length > 0).ToArray();
    }
    
    public IAnimal this[int index]
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
    
    public IEnumerator<IAnimal> GetEnumerator()
    {
        for(var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}