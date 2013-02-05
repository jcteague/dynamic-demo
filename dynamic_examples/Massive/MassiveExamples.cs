using System;
using Massive;
using NUnit.Framework;

namespace dynamic_examples.Massive
{
    [TestFixture]
    public class MassiveExamples
    {

        [Test]
        public void get_products_using_all()
        {
            var products = new Products();
            var all_products = products.All(where: "CategoryID = @0",
                                            columns: "ProductID, ProductName",
                                            args: 3);
            foreach (dynamic p in all_products)
            {
                Console.WriteLine("{0} {1}", p.ProductID, p.ProductName);
            }

        }

        [Test]
        public void get_products_using_find_by()
        {


            dynamic products = new Products();
             var beverage_products = products.FindAllBy(CategoryID: 3, UnitPrice: 5);

            //list products


            //scalar
            var product_count = products.Scalar("select count(*) from Products");
            Console.WriteLine("product count ={0}", product_count);
            //join
            
            foreach (dynamic p in beverage_products)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        [Test]
        public void using_query()
        {
            var products = new Products();
            var seafood_products = products.Query("Select p.ProductName,c.CategoryName from Products p " +
                                                  "inner join Categories c on p.categoryid = c.categoryid where c.categoryname=@0",
                                                  "Seafood");
            Console.WriteLine("seafood products");
            foreach (var bp in seafood_products) {
                Console.WriteLine("{0}, {1}", bp.ProductName, bp.CategoryName);
            }

        }



//            Products products = show_all_products();
//            var seafood_products = products.Query("Select p.ProductName from Products p inner join Categories c on p.categoryid = c.categoryid where c.categoryname=@0", "Seafood");
//               foreach (var bp in seafood_products) {
//                Console.WriteLine(bp.ProductName);
//            }





//            customer_and_orders("CONSH");
//            var products = new Products();
//            Console.WriteLine("Total Products: {0}", products.All().Count());
//
//            var product_count = products.Scalar("select count(*) from Products");
//            Console.WriteLine("the real count is => {0}", product_count);
//
//            var categories = new Category();
//            var category_names = categories.All(columns: "CategoryID as id, CategoryName as name");
//            foreach (var categoryName in category_names)
//            {
//                Console.WriteLine("{0} -> {1}",categoryName.id,categoryName.name);
//            }
//            var beverage_products = products.All(columns:"ProductName",where: "CategoryID=@0", args: 1);
//            foreach (var bp in beverage_products)
//            {
//                Console.WriteLine(bp.ProductName);
//            }
//            Console.WriteLine("seafood");
//            var seafood_products = products.Query("Select p.ProductName from Products p inner join Categories c on p.categoryid = c.categoryid where c.categoryname=@0", "Seafood");
//            foreach (var bp in seafood_products) {
//                Console.WriteLine(bp.ProductName);
//            }


//            var customers_in_orders = customers.All(columns: "CustomerID, ContactName", where: "CustomerID in @customers",args:ids);
//            foreach (dynamic customer in customers_in_orders)
//            {
//                Console.WriteLine(customer.ContactName);
//            }



        static Products show_all_products()
        {
            var products = new Products();
            var all_Products = products.All(columns: "ProductID, ProductName", where: "CategoryID = @0", args: 3);

            foreach (dynamic product in all_Products)
            {
                Console.WriteLine("{0} {1}", product.ProductID, product.ProductName);
            }
            var count = products.Scalar("select count(*) from Products");
            Console.WriteLine("count = {0}", count);
            return products;
        }

        static void OnPriceUpdated(ProductPriceUpdate update_event)
        {
            var p = new Products();
            p.Update(new {UnitPrice = update_event.Price}, new {ProductId = update_event.ProductID});
        }
    }

    public class ProductPriceUpdate
        {
            public int ProductID { get; set; }
            public decimal Price { get; set; }

        }



                    
        


        

       
}