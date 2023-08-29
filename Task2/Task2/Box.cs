class Box<T> where T : Fruit, new()
{
    private List<T> _fruits = new List<T>();

    public void AddFruit(T fruit)
    {
        _fruits.Add(fruit);
    }

    public double GetWeight()
    {
        double weight = 0.0;

        foreach (var fruit in _fruits)
        {
            weight += fruit.Weight;
        }

        return weight;
    }

    public bool Compare<K>(Box<K> otherBox) where K : Fruit, new()
    {
        return Math.Abs(GetWeight() - otherBox.GetWeight()) < 0.0001;
    }

    public void TransferFruits(Box<T> otherBox, int count)
    {
        if (count <= 0 || count > _fruits.Count)
        {
            throw new ArgumentException("Ошибка, неверное количество");
        }

        for (int i = 0; i < count; i++)
        {
            otherBox.AddFruit(_fruits[i]);
        }

        _fruits.RemoveRange(0, count);
    }
}
