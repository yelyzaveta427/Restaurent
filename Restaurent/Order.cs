namespace Restaurent;

public class Order
{
    public int OrderNumber{get; private set; }
    public int TableNumber { get; private set; }
    public DishStatus Status { get; private set; }
    public decimal TotalSum { get; private set; }
    
    public List<Dish> dishes = new List<Dish>();

    public Order(int orderNumber, int tableNumber)
    {
        OrderNumber = orderNumber;
        TableNumber = tableNumber;
        Status = DishStatus.New;
    }

    public void UpdateNestStatus()
    {
        switch (Status)
        {
            case DishStatus.New:
                Status = DishStatus.InProcess; break;
            case DishStatus.InProcess:
                Status = DishStatus.Finished; break;
            case DishStatus.Finished:
                Console.WriteLine("Order is finished"); break;
                
                
        }
    }

    public void CalculateOrder()
    {
        decimal sum = 0;
        foreach (var dish in dishes )
        {
            sum += dish.DishPrice;
        }

        TotalSum = sum;
    }
    
    
    
    
    
}