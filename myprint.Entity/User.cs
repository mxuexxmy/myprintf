//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace myprint.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public long id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string user_phone { get; set; }
        public Nullable<int> user_type { get; set; }
        public string address { get; set; }
        public Nullable<System.DateTime> create_time { get; set; }
        public Nullable<System.DateTime> update_time { get; set; }
    }
}