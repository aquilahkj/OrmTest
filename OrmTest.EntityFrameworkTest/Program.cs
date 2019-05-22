using OrmTest.EntityFrameworkTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrmTest.EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Test(args);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        static void Test(string[] args)
        {
            var times = 10;
            if (args.Length > 0) {
                times = Convert.ToInt32(args[0]);
            }
            var round = 5;
            Console.WriteLine($"Run {times} times, {round} rounds.");
            //var db = new DataContext();


            List<TeBaseField> datalist = new List<TeBaseField>();
            {
                Console.WriteLine("Run Insert");
                DateTime d1 = DateTime.Now;
                int count = 0;
                var list = CreateBaseFieldTableList(times);
                for (int i = 0; i < list.Count; i++) {
                    var item = list[i];
                    var db = new DataContext();
                    //DateTime d2 = DateTime.Now;
                    db.TeBaseFields.Add(item);
                    count += db.SaveChanges();
                    //Console.WriteLine($"times {i + 1}, {count} records insert to database, spend time {(DateTime.Now - d2).TotalSeconds} seconds");
                    datalist.Add(item);
                }

                Console.WriteLine($"insert times {times}, total item {count}, spend time {(DateTime.Now - d1).TotalSeconds} seconds");
            }

            {
                Console.WriteLine("Run Read");
                DateTime d1 = DateTime.Now;
                int count = 0;
                for (int i = 0; i < times; i++) {
                    var item = datalist[i];
                    var db = new DataContext();
                    //DateTime d2 = DateTime.Now;
                    item.BoolField = !item.BoolField;
                    item.DateTimeField = DateTime.Now;
                    var rs = db.TeBaseFields.Where(x => x.Id == item.Id).FirstOrDefault();
                    if (rs != null)
                        count += 1;
                    //Console.WriteLine($"times {i + 1}, {count} records update to database, spend time {(DateTime.Now - d2).TotalSeconds} seconds");
                }

                Console.WriteLine($"raad times {times}, total item {count}, spend time {(DateTime.Now - d1).TotalSeconds} seconds");
            }

            {
                Console.WriteLine("Run Update");
                DateTime d1 = DateTime.Now;
                int count = 0;
                for (int i = 0; i < times; i++) {
                    var item = datalist[i];
                    var db = new DataContext();
                    //DateTime d2 = DateTime.Now;
                    item.BoolField = !item.BoolField;
                    item.DateTimeField = DateTime.Now;
                    db.TeBaseFields.Update(item);
                    count += db.SaveChanges();
                    //Console.WriteLine($"times {i + 1}, {count} records update to database, spend time {(DateTime.Now - d2).TotalSeconds} seconds");
                }

                Console.WriteLine($"update times {times}, total item {count}, spend time {(DateTime.Now - d1).TotalSeconds} seconds");
            }

            {
                Console.WriteLine("Run Delete");
                DateTime d1 = DateTime.Now;
                int count = 0;
                for (int i = 0; i < times; i++) {
                    var item = datalist[i];
                    var db = new DataContext();
                    //DateTime d2 = DateTime.Now;
                    db.TeBaseFields.Remove(item);
                    count += db.SaveChanges();
                    //Console.WriteLine($"times {i + 1}, {count} records update to database, spend time {(DateTime.Now - d2).TotalSeconds} seconds");
                }

                Console.WriteLine($"delete times {times}, total item {count}, spend time {(DateTime.Now - d1).TotalSeconds} seconds");
            }

            List<TeBaseField> totalList = new List<TeBaseField>();
            {
                List<TeBaseField> temp = new List<TeBaseField>();
                Console.WriteLine("Run Batch Insert");
                DateTime d1 = DateTime.Now;
                int count = 0;
                for (int i = 0; i < round; i++) {
                    var list = CreateBaseFieldTableList(times);
                    DateTime d2 = DateTime.Now;
                    var db = new DataContext();
                    db.TeBaseFields.AddRange(list);
                    var res = db.SaveChanges();
                    count += res;
                    Console.WriteLine($"round {i + 1}, item {res}, spend time {(DateTime.Now - d2).TotalSeconds} seconds");
                    temp.AddRange(list);
                }

                Console.WriteLine($"batch insert round {round}, total item {count}, spend time {(DateTime.Now - d1).TotalSeconds} seconds");
                totalList = Random(temp);
            }

            {
                var minid = totalList.Min(x => x.Id);
                Console.WriteLine("Run Range Read");
                DateTime d1 = DateTime.Now;
                int count = 0;
                for (int i = 0; i < round; i++) {
                    DateTime t1 = DateTime.Now;
                    var db = new DataContext();
                    int start = minid + i * times;
                    var list = db.TeBaseFields.Where(x => x.Id >= start && x.Id < start + times).ToList();
                    Console.WriteLine($"read round {i + 1}, item {list.Count}, spend time {(DateTime.Now - t1).TotalSeconds} seconds");
                    count += list.Count;
                }
                Console.WriteLine($"range read round {round}, total item {count}, spend time {(DateTime.Now - d1).TotalSeconds} seconds");
            }

            {
                Console.WriteLine("Run Batch Update");
                totalList.ForEach(x => {
                    x.BoolField = !x.BoolField;
                    x.DateTimeField = DateTime.Now;
                });
                DateTime d1 = DateTime.Now;
                int count = 0;
                for (int i = 0; i < round; i++) {
                    var list = Range(totalList, i * times, times);
                    DateTime t1 = DateTime.Now;
                    var db = new DataContext();
                    db.TeBaseFields.UpdateRange(list);
                    int ret = db.SaveChanges();
                    count += ret;
                    Console.WriteLine($"update round {i + 1}, item {ret}, spend time {(DateTime.Now - t1).TotalSeconds} seconds");
                }
                Console.WriteLine($"batch update round {round}, total item {count}, spend time {(DateTime.Now - d1).TotalSeconds} seconds");
            }

            {
                Console.WriteLine("Run Batch Delete");
                DateTime d1 = DateTime.Now;
                int count = 0;
                for (int i = 0; i < round; i++) {
                    var list = Range(totalList, i * times, times);
                    DateTime t1 = DateTime.Now;
                    var db = new DataContext();
                    db.TeBaseFields.RemoveRange(list);
                    int ret = db.SaveChanges();
                    count += ret;
                    Console.WriteLine($"delete round {i + 1}, item {ret}, spend time {(DateTime.Now - t1).TotalSeconds} seconds");
                }
                Console.WriteLine($"batch delete round {round}, total item {count}, spend time {(DateTime.Now - d1).TotalSeconds} seconds");
            }
        }

        static List<TeBaseField> Range(List<TeBaseField> list, int index, int size)
        {
            List<TeBaseField> target = new List<TeBaseField>();
            int end = index + size;
            int len = end > list.Count ? list.Count : end;
            for (int i = 0; i < len; i++) {
                if (i >= index && i < end) {
                    target.Add(list[i]);
                }
            }
            return target;
        }

        static List<TeBaseField> Random(List<TeBaseField> list)
        {
            List<TeBaseField> temp = new List<TeBaseField>(list);
            Random rand = new Random();
            List<TeBaseField> target = new List<TeBaseField>(list);
            while (temp.Count > 0) {
                int index = rand.Next(0, temp.Count - 1);
                var item = temp[index];
                temp.RemoveAt(index);
                target.Add(item);
            }
            return target;
        }

        static List<TeBaseField> CreateBaseFieldTableList(int count)
        {
            List<TeBaseField> list = new List<TeBaseField>();
            DateTime now = DateTime.Now;
            DateTime d = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            for (int i = 1; i <= count; i++) {
                int x = i % 5 == 0 ? -1 : 1;
                TeBaseField item = new TeBaseField();
                item.BoolField = i % 3 == 0;
                item.BoolFieldNull = i % 2 == 0 ? null : (bool?)(item.BoolField);
                item.ByteField = (byte)(i % 256);
                item.ByteFieldNull = i % 2 == 0 ? null : (byte?)(item.ByteField);
                item.SbyteField = (sbyte)((i % 128) * x);
                item.SbyteFieldNull = i % 2 == 0 ? null : (sbyte?)(item.SbyteField);
                item.Int16Field = (short)((i % 20) * x);
                item.Int16FieldNull = i % 2 == 0 ? null : (short?)(item.Int16Field);
                item.Int32Field = (int)((i % 23) * x);
                item.Int32FieldNull = i % 2 == 0 ? null : (int?)(item.Int32Field);
                item.Int64Field = (long)((i % 25) * x);
                item.Int64FieldNull = i % 2 == 0 ? null : (long?)(item.Int64Field);
                item.Uint16Field = (ushort)(i % 27);
                item.Uint16FieldNull = i % 2 == 0 ? null : (ushort?)(item.Uint16Field);
                item.Uint32Field = (uint)(i % 28);
                item.Uint32FieldNull = i % 2 == 0 ? null : (uint?)(item.Uint32Field);
                item.Uint64Field = (ulong)(i % 31);
                item.Uint64FieldNull = i % 2 == 0 ? null : (ulong?)(item.Uint64Field);
                item.FloatField = (float)((i % 19) * 0.1 * x);
                item.FloatFieldNull = i % 2 == 0 ? null : (float?)(item.FloatField);
                item.DoubleField = (double)((i % 22) * 0.1 * x);
                item.DoubleFieldNull = i % 2 == 0 ? null : (double?)(item.DoubleField);
                item.DecimalField = (decimal)((i % 26) * 0.1 * x);
                item.DecimalFieldNull = i % 2 == 0 ? null : (decimal?)(item.DecimalField);
                item.DateTimeField = d.AddMinutes(i * 2);
                item.DateTimeFieldNull = i % 2 == 0 ? null : (DateTime?)(item.DateTimeField);
                item.VarcharField = "testtest" + item.Int32Field;
                item.VarcharFieldNull = i % 2 == 0 ? null : item.VarcharField;
                item.TextField = "texttext" + item.Int32Field;
                item.TextFieldNull = i % 2 == 0 ? null : item.TextField;
                item.BigDataField = Encoding.UTF8.GetBytes(item.VarcharField);
                item.BigDataFieldNull = i % 2 == 0 ? null : item.BigDataField;
                list.Add(item);
            }
            return list;
        }
    }
}
