namespace Massive
{
    public class Employees : DynamicModel
    {
        public Employees(): base("northwind")
        {
            PrimaryKeyField = "EmployeeID";
        }
        
    }


    public abstract class Repository : DynamicModel
    {
        public Repository(string primary_key) :base("northwind")
        {
            PrimaryKeyField = primary_key;
        }
    }
    public class Products : Repository
    {
        public Products() : base("ProductId"){}
    }

    public class Category : Repository
    {
        public Category() : base("CategoryID")
        {
            TableName = "Categories";
        }
    }

    public class Orders : Repository
    {
        public Orders() : base("OrderID")
        {
        }
    }
    public class Customers : Repository
    {
        public Customers() : base("CustomerID")
        {
        }
    }
}