namespace Restaurent;

public abstract class Program
{
    private static void Main()
    {
        RestaurentSystem restaurent = new RestaurentSystem();
        Dish d1 = new Dish("Bruschetta", 5.50m, DishCategory.Starter);
        Dish d2 = new Dish("Borshch", 10m, DishCategory.Main);
        Dish d3 = new Dish("CHai", 5m, DishCategory.Drink);

        restaurent.AddDishToMenu(d1);
        restaurent.AddDishToMenu(d2);
        restaurent.AddDishToMenu(d3);
        
        Order order1 = restaurent.CreateOrder(123, 5, ["Bruschetta","Borshch","CHai"]);
        
        Dish d4 = new Dish("Sushi", 15m, DishCategory.Main);
        Dish d5 = new Dish("Brauni", 7m, DishCategory.Dessert);
        Dish d6 = new Dish("Espresso", 4m, DishCategory.Drink);

        restaurent.AddDishToMenu(d4);
        restaurent.AddDishToMenu(d5);
        restaurent.AddDishToMenu(d6);
        
        Order order2 = restaurent.CreateOrder(321, 1, ["Sushi","Brauni","Espresso"]);
        
        
        
        restaurent.RegistrateOrder(5, order1);
        restaurent.RegistrateOrder(1, order2);
        
        restaurent.AddToQueue(order1);
        order1.UpdateNestStatus();
        
        restaurent.AddToQueue(order2);
        order2.UpdateNestStatus();
        
        restaurent.ProcessNextOrder();
        
        restaurent.FinishOrder(5);
        order1.UpdateNestStatus();
        
        restaurent.FindByTable(5);
        
        restaurent.ShowMenuByCategories();
        restaurent.ShowProcessQueue();
        restaurent.ShowActiveOrders();
        
        
        
        




    }
}