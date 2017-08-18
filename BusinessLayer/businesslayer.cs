using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLayer
{
    public class User
    {
        public int UserId { get; set; }
        public String username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool IsAdmin { get; set; }

      
        
    }
    public class Product
    {

        public string  ProductId { get; set; }
        public string ProductName { get; set; } 
        public int MinQuantity { get; set; }
        public string ManufId { get; set; }

    }
    public class Supplier
    {
        public string  SupplierId { get; set; }
        public string  SupplierName { get; set; }
        public string  Address { get; set; }
        public string  PhoneNumber { get; set; }
        public string  Email { get; set; }
   
    }

    public class Receive
    {
         public Receive()
        {
            CurrentCost=0;
            TransactionType = "R";
        }
        
        public string   ReceiveId { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string  SupplierId { get; set; }
        public string  SupplierName { get; set; }
        public string  ManufId { get; set; }
        public string  ManufacturerName { get; set; }
        public string  ProductId { get; set; }
        public string  ProductName { get; set; }
        public int    Qty { get; set; }
        public Decimal UnitCost { get; set; }
        public Decimal  CurrentCost { get; set; }
        public string  TransactionType { get; set; }
       
       

    }
    public class Sales
    {
        public Sales()
        {
            TransactionType = "S";
        }
        
        public string SalesId { get; set; }
        public DateTime SalesDate { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ManufId { get; set; }
        public string ManufacturerName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal CurrentCost { get; set; }
        public string TransactionType { get; set; }




    }


    
}
