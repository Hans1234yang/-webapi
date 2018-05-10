using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using 调用webapi.Models;

namespace 调用webapi
{
    public class DbData
    {
        public static DbData Current
        {
            get
            {
                var key = "dbKey";
                var db = CallContext.GetData(key) as DbData;
                if (db == null)
                {
                    db = new DbData();
                    CallContext.SetData(key, db);
                }
                return db;

            }
        }

        private static List<MoStudent> students = new List<MoStudent>()
        {
            new MoStudent{ Id =1 , Name ="小1", Sex = true, Birthday= Convert.ToDateTime("1991-05-31")},
            new MoStudent{ Id =2 , Name ="小2", Sex = false, Birthday= Convert.ToDateTime("1991-05-31")},
            new MoStudent{ Id =3 , Name ="小3", Sex = false, Birthday= Convert.ToDateTime("1991-05-31")},
            new MoStudent{ Id =4 , Name ="小4", Sex = true, Birthday= Convert.ToDateTime("1991-05-31")}

        };

        public List<MoStudent> GetAll()
        {
            return students;
        }

        public bool Save(MoStudent moStudent)
        {
            moStudent.Id = students.Max(b=>b.Id) + 1;
            students.Add(moStudent);
            return true;
        }
    }
}