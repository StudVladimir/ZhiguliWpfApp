//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int Car_id { get; set; }
        public int Model_id { get; set; }
        public int Owner_id { get; set; }
        public string Color { get; set; }
    
        public virtual Model Model { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
