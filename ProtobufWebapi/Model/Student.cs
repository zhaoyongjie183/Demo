using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtobufWebapi.Model
{
    [ProtoContract]
    public class Student
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        [ProtoMember(1,IsRequired =true,Name ="学生ID")]
        public int ID { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [ProtoMember(2)]
        public string StuName { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        [ProtoMember(3)]
        public string StuAge { get; set; }
    }
}
