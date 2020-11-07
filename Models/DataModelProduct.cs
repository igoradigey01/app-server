
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AuthApi.Model
{
    // Интерфейсы
    interface ICategory {
 public int  Id{get;}
  public string Name{get;}
 // public string Description{get;}
 // public IFile[] file {get;}
 
}

 interface IFile{
public string  Name{get;}
public string  Path{get;}
}

/*
 private shopingTypes:ShopingType[]=[
      new ShopingType(0,'All','Любой продукт'),
      new ShopingType(1,'Корпусная Мебель','Например шкаф ,тумбочка,камод,кровать'),
      new ShopingType(2,'Мягкая Мебель','Например диван,')
    ]

*/
// мягкая мебель ,Корпусная мебель , хозТовары,Любая категория
 class ShopingType: ICategory{
     int _id;
     string _name;
   ShopingType(int id,string name   ){

       _id=id;
       _name=name;
   }

   public int Id{
       get{ return _id;}
       set{_id=value;}
   }
   public string Name{
       get{return _name;}
       set{_name=value;}
   }

 } 
    
// категория продукта ---камод стол шкаф двиван--- вывод на начальной странице
 public class ProductType: ICategory{    
     
 
  public int Id{ get;set;}
         
  [Required(ErrorMessage = "Укажите Категорию(тип) Товара")]
  [MaxLength(50)]
  public string Name{
     get;set;
  }
}
}