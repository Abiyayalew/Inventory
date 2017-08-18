using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BLayer;


namespace DALayer
{
    public class clsDataLayer
    {
        public string conString = ConfigurationManager.ConnectionStrings["DBcon"].ToString();

        public DataSet ExecuteSqlString(string sqlstring)
        {
            try
            {
                SqlConnection objsqlconn = new SqlConnection(conString);
                objsqlconn.Open();

                DataSet Ds = new DataSet();
                SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
                SqlDataAdapter objAdp = new SqlDataAdapter(objcmd);
                objAdp.Fill(Ds);
                return Ds ;
            }
            catch (Exception ex)
            {
                throw ex;
                
            }


        }

        public void InsertUpdateDeleteSQLString(string sqlstring)
        {

            try
            {
                SqlConnection objsqlconn = new SqlConnection(conString);
                objsqlconn.Open();
                SqlCommand objcmd = new SqlCommand(sqlstring, objsqlconn);
                objcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet FillManufacturer()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Manufacturer";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public DataSet FillProduct()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT ProductId,ProductName from tbl_Product";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public DataSet FillSupplier()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT SupplierId,SupplierName from tbl_Supplier";
            obj = ExecuteSqlString(sql);
            return obj;

        }
       
    }
    // User class
    public class clsUser : clsDataLayer
    {

        // Validate Username and Password
        public DataSet ISValid(User user)
        {
            DataSet obj = new DataSet();
            string sql = "SELECT *  from tbl_Login where username='" + user.username + "' and password= '" + user.password + "'";
            obj = ExecuteSqlString(sql);
            return obj;

        }

        // Add new user on tlb_Login
        public void AddNewUser(User obj)
        {

            string sql = "INSERT INTO tbl_Login (Username,Password ,Email,IsAdmin )"
                        + "VALUES('" + obj.username + "', '" + obj.password + "' , '" + obj.email + "', '" + obj.IsAdmin + "' )";

            InsertUpdateDeleteSQLString(sql);


        }
        // Update existing user
        public void UpdateUser(User obj)
        {

            string sql = " UPDATE  tbl_Login" +
                         " SET UserName='" + obj.username + "'," +
                         " Password='" + obj.password + "'," +
                         " Email='" + obj.email + "'," +
                         " IsAdmin='" + obj.IsAdmin + "'" +
                         "Where UserId='" + obj.UserId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing user
        public void DeleteUser(int userId)
        {
            User obj = new User();
            string sql = "Delete from tbl_Login where userId='" + userId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all users to DataGrid
        public DataSet LoadUser()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Login order by userId";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }
    //Product class
    public class clsProduct : clsDataLayer
    {
        // Add new Product 
        public void AddNewProduct(Product obj)
        {

            string sql = "INSERT INTO tbl_Product " +
                         " (ProductId, ProductName ,MinQty,ManufId )" +
                         " VALUES('" + obj.ProductId + "', '" + obj.ProductName + "' , '" + obj.MinQuantity + "','" + obj.ManufId + "')";

            InsertUpdateDeleteSQLString(sql);
        }

        // Update existing Product
        public void UpdateProduct(Product obj)
        {

            string sql = "UPDATE  tbl_Product SET" +
                         " ProductName='" + obj.ProductName + "'" +
                         ",MinQty='" + obj.MinQuantity + "'" +
                         ",ManufId='" + obj.ManufId + "'" +
                         " Where ProductId='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing Product
        public void DeleteProduct(Product obj)
        {
            DataSet ds = new DataSet();
            string sql = "Delete from tbl_Product" +
                         " where ProductId='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);
        }
        // populate  Products in a  DataGrid.
        public DataSet LoadProduct()
        {
            DataSet obj = new DataSet();
            string sql = @"SELECT tbl_Product.ProductId, tbl_Product.ProductName, tbl_Product.MinQty, tbl_Manufacturer.ManufacturerName
                           FROM tbl_Manufacturer INNER JOIN tbl_Product 
                           ON tbl_Manufacturer.ManufacturerID = tbl_Product.ManufId";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }

    // Supplier Class -------------------------
    public class clsSupplier : clsDataLayer
    {
        // Add new user on tlb_Login
        public void AddNewSupplier(Supplier obj)
        {

            string sql = "INSERT INTO tbl_Supplier (SupplierId,SupplierName,Address ,PhoneNumber,Email )"
                        + "VALUES('" + obj.SupplierId + "', '" + obj.SupplierName + "' , '" + obj.Address + "', '" + obj.PhoneNumber + "','" + obj.Email + "' )";

            InsertUpdateDeleteSQLString(sql);


        }
        // Update existing supplier
        public void UpdateSupplier(Supplier obj)
        {

            string sql = " UPDATE  tbl_Supplier" +
                         " SET SupplierName='" + obj.SupplierName + "'," +
                         " Address='" + obj.Address + "'," +
                         " PhoneNumber='" + obj.PhoneNumber + "'," +
                         " Email='" + obj.Email + "'" +
                         " Where SupplierId='" + obj.SupplierId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete existing supplier
        public void DeleteSupplier(string supId)
        {
            Supplier obj = new Supplier();
            string sql = "Delete from tbl_Supplier where SupplierId='" + supId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load all Supplier to DataGrid
        public DataSet LoadSupplier()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT * from tbl_Supplier order by SupplierId";
            obj = ExecuteSqlString(sql);
            return obj;
        }

    }

    //  Receive Class

    public class clsReceive : clsDataLayer
    {


        // Add new receive.
        public void AddNewReceive(Receive obj)
        {

            string sql = "INSERT INTO tbl_Receive" +
                         " (RecId,RecDate,SupplierId ,ManufId,ProductId,Quantity,UnitCost )" +
                         " VALUES('" + obj.ReceiveId + "', '" + obj.ReceiveDate + "' , '"
                                     + obj.SupplierId + "', '" + obj.ManufId + "','"
                                     + obj.ProductId + "', '" + obj.Qty + "','"
                                     + obj.UnitCost + "' )";


            InsertUpdateDeleteSQLString(sql);




        }
        public void AddNewProductDetail(Receive obj)
        {

            string sql = "INSERT INTO tbl_ProductDetail" +
                         " (RecId,RecDate,SupplierId ,ManufId,ProductId,Quantity,UnitCost,CurrentCost,Transactiontype )" +
                         " VALUES('" + obj.ReceiveId + "', '" + obj.ReceiveDate + "' , '"
                                     + obj.SupplierId + "', '" + obj.ManufId + "','"
                                     + obj.ProductId + "', '" + obj.Qty + "','"
                                     + obj.UnitCost + "','" + obj.CurrentCost + "','" 
                                     +  obj.TransactionType +"')";


            InsertUpdateDeleteSQLString(sql);




        }
        public void UpdateProductDetail(Receive obj)
        {

            string sql = " UPDATE  tbl_ProductDetail" +
                         " SET RecDate='" + obj.ReceiveDate + "'," +
                         " SupplierId='" + obj.SupplierId + "'," +
                         " ManufId='" + obj.ManufId + "'," +
                         " ProductId='" + obj.ProductId + "'," +
                         " Quantity='" + obj.Qty + "'," +
                         " UnitCost='" + obj.UnitCost + "'," +
                         " CurrentCost='" + obj.CurrentCost + "'" +
                         " Where RecId='" + obj.ReceiveId + "' and ProductId ='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        // Update Recevied information.
        public void UpdateReceive(Receive obj)
        {

            string sql = " UPDATE  tbl_Receive" +
                         " SET RecDate='" + obj.ReceiveDate + "'," +
                         " SupplierId='" + obj.SupplierId + "'," +
                         " ManufId='" + obj.ManufId + "'," +
                         " ProductId='" + obj.ProductId + "'," +
                         " Quantity='" + obj.Qty + "'," +
                         " UnitCost='" + obj.UnitCost + "'" +
                         "Where RecId='" + obj.ReceiveId + "' and ProductId ='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete Received product
        public void DeleteReceive(string recId)
        {
            
            string sql = "Delete from tbl_Receive where RecId='" + recId + "'";
            InsertUpdateDeleteSQLString(sql);
             
        }
        // Load selected receive  to DataGrid
        public DataSet LoadReceiveFromDB(string recId)
        {
            DataSet obj = new DataSet();

            string sql = "SELECT  RecId,CONVERT(VARCHAR(10),RecDate,10) as RecDate,SupplierName,ManufacturerName,ProductName,Quantity,UnitCost" +
                         " FROM tbl_Receive INNER JOIN" +
                         " tbl_Product ON tbl_Receive.ProductId = tbl_Product.ProductId INNER JOIN" +
                         " tbl_Manufacturer ON tbl_Receive.ManufId = tbl_Manufacturer.ManufacturerID INNER JOIN" +
                         " tbl_Supplier ON tbl_Receive.SupplierId = tbl_Supplier.SupplierId" +
                         " where RecId = '" + recId + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        // load receive record from memeory to Gridview
        public List<Receive> LoadReceiveFromMemory(string recId)
        {
            List<Receive> receives = new List<Receive>();
            try
            {
                SqlConnection objsqlconn = new SqlConnection(conString);
                objsqlconn.Open();
                String sqlstr = "SELECT * from tbl_Receive  where RecId = '" + recId + "'";
                SqlCommand objcmd = new SqlCommand(sqlstr, objsqlconn);
                SqlDataReader reader = objcmd.ExecuteReader();

                while (reader.Read())
                {
                    Receive obj = new Receive();
                    obj.ReceiveId = reader["RecId"].ToString();
                    obj.ReceiveDate = Convert.ToDateTime(reader["RecDate"].ToString());
                    obj.SupplierId = reader["SupplierId"].ToString();
                    obj.ManufId = reader["ManufId"].ToString();
                    obj.ProductId = reader["ProductId"].ToString();
                    obj.Qty = Convert.ToInt16(reader["Qantity"].ToString());
                    obj.UnitCost = Convert.ToDecimal(reader["UnitCost"].ToString());
                    receives.Add(obj);

                }




            }
            catch (Exception ex)
            {
                throw ex;
            }


            return receives;

        }

        public DataSet  GenerateNewReceiveId()
        {
            DataSet ds = new DataSet();
            string str = " Select" +
                         " CASE" +
                         " WHEN Max(RecId)  IS NULL THEN 1" +
                         " WHEN Max(RecId) >= 1 THEN Max(RecId) + 1" +
                         " END" +
                         " FROM tbl_Receive";
            ds = ExecuteSqlString(str);
            return ds;

        }
        public void DeleteReceiveDetail(string recId)
        {

            string sql = "Delete from tbl_ProductDetail where RecId='" + recId + "'" +
                         " and Transactiontype='R' and CurrentCost='0' ";
            InsertUpdateDeleteSQLString(sql);

        }
        public bool IsProductsGotPrice(string recId)
        {
            DataSet ds = new DataSet();
            string sql = "select CurrentCost from tbl_ProductDetail where RecID='" + recId + "'";
            ds = ExecuteSqlString(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

 
        }


    }

    //  Sales Class

    public class clsSales : clsDataLayer
    {


        // Add new sales to sales table.
        public void AddNewSales(Sales obj)
        {

            string sql = "INSERT INTO tbl_Sales" +
                         " (SalesId,SalesDate,SupplierId ,ManufId,ProductId,Quantity,UnitPrice )" +
                         " VALUES('" + obj.SalesId + "', '" + obj.SalesDate + "' , '"
                                     + obj.SupplierId + "', '" + obj.ManufId + "','"
                                     + obj.ProductId + "', '" + obj.Qty + "','"
                                     + obj.UnitPrice + "' )";


            InsertUpdateDeleteSQLString(sql);




        }
         // add new sales information to productDetail tables.
        public void AddNewProductDetail(Sales obj)
        {

            string sql = "INSERT INTO tbl_ProductDetail" +
                         " (SalesId,SalesDate,SupplierId ,ManufId,ProductId,Quantity,UnitPrice,CurrentCost,Transactiontype)" +
                         " VALUES('" + obj.SalesId + "', '" + obj.SalesDate + "' , '"
                                     + obj.SupplierId + "', '" + obj.ManufId + "','"
                                     + obj.ProductId + "', '" + obj.Qty + "','"
                                     + obj.UnitPrice + "','" + obj.UnitPrice + "','"
                                     + obj.TransactionType + "' )";


            InsertUpdateDeleteSQLString(sql);




        }
        // update sales information in product detail table
        public void UpdateProductDetail(Sales obj)
        {

            string sql = " UPDATE  tbl_ProductDetail" +
                         " SET SalesDate='" + obj.SalesDate + "'," +
                          " SupplierId='" + obj.SupplierId + "'," +
                          " ManufId='" + obj.ManufId + "'," +
                          " ProductId='" + obj.ProductId + "'," +
                          " Quantity='" + obj.Qty + "'," +
                          " UnitPrice='" + obj.UnitPrice + "'" +
                          " Where SalesId='" + obj.SalesId + "' and ProductId ='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        // Update Sales information.
        public void UpdateSales(Sales obj)
        {

            string sql = " UPDATE  tbl_Sales" +
                         " SET SalesDate='" + obj.SalesDate + "'," +
                         " SupplierId='" + obj.SupplierId + "'," +
                         " ManufId='" + obj.ManufId + "'," +
                         " ProductId='" + obj.ProductId + "'," +
                         " Quantity='" + obj.Qty + "'," +
                         " UnitPrice='" + obj.UnitPrice + "'" +
                         "Where SalesId='" + obj.SalesId + "' and ProductId ='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }
        //Delete Sales product
        public void DeleteSales(string SalesId)
        {
            Supplier obj = new Supplier();
            string sql = "Delete from tbl_Sales where SalesId='" + SalesId + "'";
            InsertUpdateDeleteSQLString(sql);

        }
        // Load selected receive  to DataGrid
        public DataSet LoadSales(string SalesId)
        {
            DataSet obj = new DataSet();

            string sql = "SELECT  SalesId,CONVERT(VARCHAR(10),SalesDate,10) as SalesDate,SupplierName,ManufacturerName," +
                          "ProductName,Quantity,UnitPrice,(Quantity*UnitPrice) as Amount " +
                         " FROM tbl_Sales INNER JOIN" +
                         " tbl_Product ON tbl_Sales.ProductId = tbl_Product.ProductId INNER JOIN" +
                         " tbl_Manufacturer ON tbl_Sales.ManufId = tbl_Manufacturer.ManufacturerID INNER JOIN" +
                         " tbl_Supplier ON tbl_Sales.SupplierId = tbl_Supplier.SupplierId" +
                         " where SalesId = '" + SalesId + "' and Void = '0'";
                         
            obj = ExecuteSqlString(sql);
            return obj;
        }

        public DataSet GenerateNewSalesId()
        {
            DataSet ds = new DataSet();
            string str = " Select" +
                         " CASE" +
                         " WHEN Max(SalesId)  IS NULL THEN 1" +
                         " WHEN Max(SalesId) >= 1 THEN Max(SalesId) + 1" +
                         " END" +
                         " FROM tbl_Sales";
            ds = ExecuteSqlString(str);
            return ds;

        }
        public void VoidSales(string SalesId)
        {

            //Void sales record from tbl_receive
            string sql = "UPDATE tbl_Sales Set Void='1'" +
                         " where SalesId='" + SalesId + "'";

            InsertUpdateDeleteSQLString(sql);
            //void sales record from tbl_ProductDetail

                  sql = "UPDATE tbl_ProductDetail Set Void='1'" +
                         " where SalesId='" + SalesId + "'";

            InsertUpdateDeleteSQLString(sql);




        }

        



    }

    //  ProductDetail Class

    public class clsProductDetail : clsDataLayer
    {

        // set price newly added product
        public void SaveCurrentCost(Receive obj)
        {

            string sql = " UPDATE  tbl_ProductDetail" +
                         " SET CurrentCost='" + obj.CurrentCost + "'" +
                         " Where ProductId ='" + obj.ProductId + "'";

            InsertUpdateDeleteSQLString(sql);

        }

        // load selected receive  to Grid using ReceiveId
        public DataSet LoadProductDetail(string recId)
        {
            DataSet obj = new DataSet();

            string sql = "SELECT  RecId,ProductName,Quantity,UnitCost,CurrentCost" +
                         " FROM tbl_ProductDetail INNER JOIN" +
                         " tbl_Product ON tbl_ProductDetail.ProductId = tbl_Product.ProductId " +
                         " where RecId = '" + recId + "'";
            obj = ExecuteSqlString(sql);
            return obj;
        }
        public decimal CalculatePrice(Receive obj)
        {
            decimal NewPrice;
            NewPrice = (obj.UnitCost + (obj.UnitCost * 15) / 100);
            return NewPrice;
        }
        public DataSet FillReceiveAvalibleforPricing()
        {
            DataSet obj = new DataSet();
            string sql = "SELECT distinct RecId from tbl_ProductDetail where CurrentCost=0 ";
            obj = ExecuteSqlString(sql);
            return obj;

        }
        public DataSet FindPriceandAvaliableQty(string productId, string supId, string manufId)
        {
            DataSet obj = new DataSet();
            string sql = " SELECT distinct CurrentCost,sum(Quantity)as Qty" +
                         " FROM tbl_ProductDetail" +
                         " WHERE productId='" + productId + "' and  CurrentCost != 0" +
                         " and SupplierId='" + supId + "' and ManufId='" + manufId + "'" +
                         " GROUP BY productId,CurrentCost";
            obj=ExecuteSqlString(sql);
            return obj;


        }
       
        

    }

}
