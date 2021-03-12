using System;
using System.Collections.Generic;
using System.Linq;

namespace myprint.Entity
{
    /// <summary>
    /// 分页对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageInfo<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data { get; set; }
        public String errer { get; set; }

    }
}