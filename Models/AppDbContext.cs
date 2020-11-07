using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuthApi.Model
{
    public class AppDbContext:DbContext
    {
             IConfiguration _configuration;
        
            public DbSet<User> Users { get; set; }
            public DbSet<ProductType> ProductTypes {get;set;}

           

            

        public AppDbContext(DbContextOptions<AppDbContext> options,IConfiguration configuration) {
          _configuration=configuration;

           
           Database.SetCommandTimeout(300);
          Database.EnsureDeleted();  //24.10.20
            Database.EnsureCreated();
            }

            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
              optionsBuilder.UseMySql(_configuration["ConnectStringLocal"]);      //Startup.GetConnetionStringDB());
            }
                 //  при создании бд  создается admin 
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
          
            OnModelAuthCreating(modelBuilder);
            OnModelProductTypeCreating(modelBuilder);
            
        }

        private void OnModelAuthCreating(ModelBuilder modelBuilder){

          var initObject=_configuration.GetSection("Users");
          var admin=initObject.GetSection("Admin");
          var user=initObject.GetSection("User");
          string adminEmail =  admin["Email"];// ";
            string adminPassword =  admin["Password"]; 
            string userEmail=user["Email"]; //  "user@mail.ru";
            string userPassword=user["Password"];// "";
            string userPhone= user["Phone"];// "+79181111111";
            string userName="user";
 
            // добавляем роли
            
            User adminUser = new User {Id=1,  Email = adminEmail, Password = adminPassword,
             Role = Role.Admin,Name=admin["Name"]
            ,Address="" ,Phone=admin["Phone"]};
            User user1= new User{Id=2, Email=userEmail,Password=userPassword,
            Name=userName,
            Role=Role.User,Address="",Phone=userPhone};
          // modelBuilder.Entity<User>().Property(u=>u.Role).HasDefaultValue(Role.User);
          
            modelBuilder.Entity<User>().HasData( new User[] { adminUser,user1});
            base.OnModelCreating(modelBuilder);


        }

        private void OnModelProductTypeCreating(ModelBuilder modelBuilder){
         
          /* angular - staticDataSourse
           private categorys:ProductType[]=[
      new ProductType(1,"Камод",null),
      new ProductType(2,"Кровать",null),
      new ProductType(3,"Шкаф",null),
      new ProductType(4,"Кухня",null),
      new ProductType(5,"Кухонный Уголок",null),
      new ProductType(6,"Стол Обеденный",null),
      new ProductType(7,"Стол Писменный",null),
      new ProductType(8,"Стол Журнальный"),
      new ProductType(9,"Стол Маникюрный"),
      new ProductType(10,"Стол Тумба",null),
      new ProductType(11,"Гномик",null),
      new ProductType(12,"Диван",null),
      new ProductType(13,"Диван Угловой",null),
      new ProductType(14,"Титаник",null)
    ]
  */
       // private ProductType[]
        var _categorys=new ProductType[]{
        new ProductType {Id=1,Name="Камод"},
         new ProductType{Id=2,Name="Кровать"},
          new ProductType{Id=3,Name="Шкаф"},
          new ProductType{Id=4,Name="Кухонный Уголок"},
          new ProductType{Id=5,Name="Стол Обеденный"} ,
          new ProductType{Id=6,Name="Стол Писменный"},
          new ProductType{Id=7,Name="Стол Журнальный"},
          new ProductType{Id=8,Name="Стол Маникюрный"},
          new ProductType{Id=9,Name="Стол Тумба"},
          new ProductType{Id=10,Name="Гномик"},
          new ProductType{Id=11,Name="Комплектующие"}

        };

        Console.WriteLine("Create -----------      ProductType()---------- Start->");

         modelBuilder.Entity<ProductType>().HasData( _categorys);
            base.OnModelCreating(modelBuilder);
  

              
        
     }
}

}
