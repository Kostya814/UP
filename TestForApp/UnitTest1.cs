using MySqlConnector;
using pr10.Database;
using pr10.models;

namespace TestForApp;

public class UnitTest1
{
    Database db = new Database();
    [Fact]
    public void Database_ConnectionString_IsCorrect(){
        // Arrange
        var expectedConnectionString = new MySqlConnectionStringBuilder
        {        
            Server = "localhost",
            Database = "pr10",
            UserID = "root",
            Password = "123456"
        };
        
        // Act
        var actualConnectionString = db.getConnectionString();
        // Assert    
        Assert.Equal(expectedConnectionString.ToString(), actualConnectionString.ToString());    
        
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        var expectedCount = 28;
        
        //Act
        var list = db.GetAllProducts();
        var actualCount = list.Count; 
        
        //Assert
        Assert.Equal(expectedCount,actualCount);
    }
    [Fact]
    public void Test3()
    {
        // Arrange
        var expectedName = db.GetAllUsers().First().Name;
        
        //Act
        var actualName = db.GetAllUsers().FirstOrDefault(u => u.Name == "Лавров Богдан Львович").Name;
        
        //Assert
        Assert.Equal(expectedName,actualName);
    }
    [Fact]
    public void Test4()
    {
        //Arrange
        bool expectedBool = true;
        //Act
        var actualCount = db.GetAllUsers().Count;
        bool actualBool = actualCount>0;
        //Assert
        Assert.Equal(expectedBool,actualBool);
    }
    [Fact]
    public void Test5()
    {
        //Arrange
        var expectedCount = 36;
        //Act
        var actualCount = db.GetAllPoints().Where(u=>u.City.Contains("Кропоткин")).ToList().Count;
        //Assert
        Assert.Equal(expectedCount,actualCount);
    }
    [Fact]
    public void Test6()
    {
        //Arrange
        var currectId = 1; 
        var expectedUser = db.GetUserById(currectId);
        //Act
        var actualUser = db.GetAllUsers().FirstOrDefault(u=>u.Id == currectId);
        //Assert
        Assert.Equal(expectedUser,actualUser);
    }
    [Fact]
    public void Test7()
    {
        //Arrange
        var expectedProduct = db.GetProductById(1);
        //Act
        var actualProduct = db.GetAllProducts().FirstOrDefault(u=>u.Id == 1);
        //Assert
        Assert.Equal(expectedProduct,actualProduct);
    }
    [Fact]
    public void Test8()
    {
        //Arrange
        var expectedRole = "Администратор";
        //Act
        var actualRole = db.GetAllUsers().FirstOrDefault().Role;
        //Assert
        Assert.Equal(expectedRole,actualRole.Name);
    }
    [Fact]
    public void Test9()
    {
        //Arrange
        var currectId = 1; 
        var expectedOrder = db.GetOrderById(currectId);
        //Act
        var actualOrder = db.GetAllOrders().FirstOrDefault(u=>u.Id == currectId);
        //Assert
        Assert.Equal(expectedOrder.Date,actualOrder.Date);
    }
    [Fact]
    public void Test10()
    {
        //Arrange
        var currectId = 1; 
        var expectedPointCity = db.GetPointById(currectId).City;
        //Act
        var actualPoint = db.GetAllPoints().FirstOrDefault(u=>u.Id == currectId);
        //Assert
        Assert.Equal(expectedPointCity,actualPoint.City);
    }
}
