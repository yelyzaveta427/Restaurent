namespace Restaurent;

public class Dish
{
    public string DishName { get; private set;}
    public decimal DishPrice { get; private set; }
    public DishCategory DishCategory { get; private set; }
    
    public Dish(string dishName, decimal dishPrice, DishCategory dishCategory)
    {
        DishName = dishName;
        DishPrice = dishPrice;
        DishCategory = dishCategory;
    }
    
    
    
    

    
}