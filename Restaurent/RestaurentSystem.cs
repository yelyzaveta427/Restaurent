using System.Collections;

namespace Restaurent;

public class RestaurentSystem
{
    
    private Dictionary<int, Order> orderByTable = new Dictionary<int, Order>();

    private Queue<Order> orders = new Queue<Order>();
    private Stack<Order> orderHistory = new Stack<Order>();
    private List<Dish> menu = new List<Dish>();
    
    public void AddDishToMenu(Dish dish)
    {
        menu.Add(dish);
        Console.WriteLine($"Dish '{dish.DishName}' is added menu.");
    }
    
    
    public Order CreateOrder(int orderNumber,int tableNumber, List<string> requestedDishNames)
    {
        if (orderByTable.ContainsKey(tableNumber))
        {
            Console.WriteLine($"Table {tableNumber} has an active order");
        }
        
        Order newOrder = new Order(orderNumber, tableNumber);
        foreach (string requestedName in requestedDishNames)
        {
            foreach (Dish d in menu)
            {
                if (d.DishName == requestedName)
                {
                    newOrder.dishes.Add(d);
                    Console.WriteLine($"Dish {d.DishName} is added and has price {d.DishPrice} USD");
                }
            }
            newOrder.CalculateOrder();
        }

        return newOrder;

    }

    public void RegistrateOrder(int tableNumber, Order o)
    {
        if (orderByTable.ContainsKey(tableNumber))
        {
            Console.WriteLine($"Table {tableNumber} has an active order");
        }
        orderByTable.Add(tableNumber,o);
        Console.WriteLine($"Order for table {tableNumber} is successfully registered");
    }

    public void AddToQueue(Order? order)
    {
        if (order == null)
        {
            Console.WriteLine("Order does not exist");
        }
        orders.Enqueue(order);
    }

    public void ProcessNextOrder()
    {
        while (orders.Count > 0)
        {
            Order order = orders.Dequeue();
            Console.WriteLine($"Order {order.OrderNumber} is in process of cooking");
        }
    }

    public void FinishOrder(int tableNumber)
    {
        if (orderByTable.ContainsKey(tableNumber))
        {
            Order finishedOrder = orderByTable[tableNumber];
            orderHistory.Push(finishedOrder);
            orderByTable.Remove(tableNumber);
            Console.WriteLine($"Order to table {tableNumber} is finished and added to history. Sum was {finishedOrder.TotalSum}");
            
        }
        else
        {
            Console.WriteLine($"Table does not have active orders");
        }
    }

    public void FindByTable(int tableNumber)
    {
        if (orderByTable.TryGetValue(tableNumber, out Order o))
        {
            Console.WriteLine($"Order {o.OrderNumber} is found by table {tableNumber}");
            
        }
        else
        {
            Console.WriteLine("Table is not found");
        }
    }

    public void ShowMenuByCategories()
    {
        List<Dish> starters = new List<Dish>();
        List<Dish> mains = new List<Dish>();
        List<Dish> desserts = new List<Dish>();
        List<Dish> drinks = new List<Dish>();
        foreach (Dish d in menu)
        {
            switch (d.DishCategory)
            {
                case DishCategory.Starter:
                    starters.Add(d); break;
                case (DishCategory.Main):
                    mains.Add(d); break;
                case (DishCategory.Dessert):
                    desserts.Add(d); break;
                case (DishCategory.Drink):
                    drinks.Add(d); break;
            }
        }
        foreach (var d in starters)
        {
            Console.WriteLine($"Starter: {d.DishName}");
        }
        foreach (var d in mains)
        {
            Console.WriteLine($"Main: {d.DishName}");
        }
        foreach (var d in desserts)
        {
            Console.WriteLine($"Dessert: {d.DishName}");
        }
        foreach (var d in drinks)
        {
            Console.WriteLine($"Drink: {d.DishName}");
        }
        
    }

    public void ShowActiveOrders()
    {
        foreach (var order in orders)
        {
            Console.WriteLine($"Order {order.OrderNumber} is active");
        }
    }

    public void ShowProcessQueue()
    {
        while (orders.Count > 0)
        {
            Order order = orders.Dequeue();
            Console.WriteLine($"Order {order.OrderNumber} is in process of cooking");
        }
        Console.WriteLine("Queue is empty. There are no active orders");
    }

    public void ShowHistory()
    {
        foreach (var order in orderHistory)
        {
            Console.WriteLine($"Order {order.OrderNumber} with table {order.TableNumber} is finished");
        }
    }
}