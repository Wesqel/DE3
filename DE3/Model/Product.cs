//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DE3.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int idProduct { get; set; }
        public string ProductName { get; set; }
        public byte[] Photo { get; set; }
        public string ProductDescription { get; set; }
        public string ProductMaker { get; set; }
        public decimal ProductCost { get; set; }
        public Nullable<double> ProductDiscount { get; set; }
        public int ProductNumber { get; set; }
        public System.DateTime ProductDate { get; set; }
        public string Point_Of_Issue { get; set; }
        public int DeliveryTime { get; set; }
    }
}
