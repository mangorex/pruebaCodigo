using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace pruebaCodigo
{
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
    class Program
    {
        private const string V = "PropertyName";

        static void Main(string[] args)
        {
            var m1 = new Member();
            m1.setName("John");
            m1.setSeniority(4);
            Console.WriteLine($"Print member 1. name: {m1.getName()}, seniority: {m1.getSeniority()}");

            var m2 = new Member();
            m2.setName("Francis");
            m2.setSeniority(1);
            Console.WriteLine($"Print member 2. name: {m2.getName()}, seniority: {m2.getSeniority()}");

            var m3 = new Member();
            m3.setName("Pascual");
            m3.setSeniority(3);
            Console.WriteLine($"Print member 3. name: {m3.getName()}, seniority: {m3.getSeniority()}");

            m1.setSubordinates(new List<Member>() { m2, m3 });
            Console.WriteLine($"* Print member 1 {m1.toString()}");

            var c1 = new Carcel();
            c1.enter(m1);
            c1.enter(m2);
            Console.WriteLine($"* Print carcel 1 {c1.toString()}");
            c1.leave(m1);
            Console.WriteLine($"* Print carcel 2 {c1.toString()}");

            string json = @"['Starcraft','Halo','Legend of Zelda']";

            List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);

            Console.WriteLine(string.Join(", ", videogames.ToArray()));

            json = @"{
            'Email': 'james@example.com',
            'Active': true,
            'CreatedDate': '2013-01-20T00:00:00Z',
            'Roles': [
                'User',
                'Admin'
            ]
            }";

            Account account = JsonConvert.DeserializeObject<Account>(json);

            Console.WriteLine(account.Email);

            json = @"{
            'name': 'Jhon',
            'seniority': 4,
            'subordinates': ['Francis','Pascual'],
            'boss': 'Andy'
        }";

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            int i = 0;
            Member m = new Member();
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    //Console.WriteLine("{0}",  reader.TokenType);
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        Console.WriteLine("Property name");
                        switch (reader.Value)
                        {
                            case "name":
                                i = 0;
                                break;
                            case "seniority":
                                i = 1;
                                break;
                            case "subordinates":
                                i = 2;
                                break;
                            case "boss":
                                i = 3;
                                break;
                        }
                    } else{
                         switch (i)
                        {
                            case 0:
                                m.setName(reader.Value.ToString());
                                break;
                            case 1:
                                m.setSeniority(Convert.ToInt32(reader.Value));
                                break;
                        }
                    }

                    Console.WriteLine("Not null Token: {0}, Value: {1}, i: {2}", reader.TokenType, reader.Value, i);
                    Console.WriteLine($"* Print member {m.toString()}");

                }
                /*else
                {
                  Console.WriteLine("null Token: {0}", reader.TokenType);
                }*/
            }

        }
    }
}
