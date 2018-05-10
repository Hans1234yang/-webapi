using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace 调用webapi.Models
{
    [DataContract]
    public class MoStudent
    {
        /// <summary>
        /// 如果不加DataMember 属性， 我的字段将会 隐藏起来。
        /// </summary>
        //[DataMember(Order =3)]  ///显示顺序   第4顺序
          [JsonProperty(Order =1)]
         public DateTime Birthday { get; set; }

        [JsonProperty(Order =0)]
        //[DataMember(Order = 0)]   ///第一个顺序
        public int Id { get; set; }

        [JsonProperty(Order =2)]
        //[DataMember(Order =1)]
        public string Name { get; set; }


        [JsonProperty(Order =3)]
        //[DataMember(Order =2)]
        public bool Sex { get; set; }
    }
}