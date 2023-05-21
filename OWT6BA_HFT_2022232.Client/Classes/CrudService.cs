using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OWT6BA_HFT_2022232.Client.Interfaces;

namespace OWT6BA_HFT_2022232.Client.Classes
{
    class CrudService
    {
        private IRestService rest;

        public CrudService(IRestService rest)
        {
            this.rest = rest;
        }

        public void Create<T>()
        {
            try
            {
                var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual)).Skip(1);
                T instance = (T)Activator.CreateInstance(typeof(T));
                foreach (var property in properties)
                {
                    Console.Write($"{property.Name} = ");
                    string input = Console.ReadLine();
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(instance, int.Parse(input));
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        property.SetValue(instance, double.Parse(input));
                    }
                    else
                    {
                        property.SetValue(instance, input);
                    }
                }
                rest.Post(instance, typeof(T).Name + "/Create");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        public void ReadAll<T>()
        {
            try
            {
                var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual));

                var items = rest.Get<T>(typeof(T).Name + "/ReadAll");

                foreach (var property in properties)
                {
                    Console.Write($"{property.Name}\t");
                }
                Console.Write("\n");

                foreach (var item in items)
                {
                    foreach (var property in properties)
                    {
                        Console.Write($"{property.GetValue(item)}\t");
                    }
                    Console.Write("\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
        public void Read<T>()
        {
            try
            {
                Console.WriteLine("Enter Entity's id to read:");
                int id = int.Parse(Console.ReadLine());

                var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual));
                var item = rest.Get<T>(id, typeof(T).Name + "/Read");

                foreach (var property in properties)
                {
                    Console.Write($"{property.Name}\t");
                }
                Console.Write("\n");

                if (item == null)
                {
                    Console.ReadLine();
                    return;
                }

                foreach (var property in properties)
                {
                    Console.Write($"{property.GetValue(item)}\t");
                }
                Console.Write("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
        public void Update<T>()
        {
            try
            {
                Console.WriteLine("Enter Entity's Id to update: ");
                int id = int.Parse(Console.ReadLine());

                var instance = rest.Get<T>(id, typeof(T).Name + "/Read");

                var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual)).Skip(1);

                foreach (var property in properties)
                {
                    Console.Write($"New {property.Name} [Old: {property.GetValue(instance)}]= ");
                    string input = Console.ReadLine();
                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(instance, int.Parse(input));
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        property.SetValue(instance, double.Parse(input));
                    }
                    else
                    {
                        property.SetValue(instance, input);
                    }
                }
                rest.Put(instance, typeof(T).Name + "/Update");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        public void Delete<T>()
        {
            try
            {
                Console.WriteLine("Enter Entity's id to delete:");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, typeof(T).Name + "/Delete");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
