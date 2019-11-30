using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace pruebaCodigo
{
    
    // --> STARTING CLASS PROGRAM
    class Program
    {
        //static List<Member> readFromFile(string path){
        static void readFromFile(string path){
            string json = System.IO.File.ReadAllText(path);

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", json);

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
                        // Console.WriteLine("Property name");
                        switch (reader.Value)
                        {
                            case "name":
                                m = new Member();
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
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                m.setSubordinates(new List<String>());
                                m.setName(reader.Value.ToString());
                                break;
                            case 1:
                                m.setSeniority(Convert.ToInt32(reader.Value));
                                break;
                            case 2:
                                m.addSubordinate(reader.Value.ToString());
                                break;
                            case 3:
                                m.setBoss(reader.Value.ToString());
                                // Console.WriteLine("");
                                // Console.WriteLine($"* Print member {m.toString()}");
                                //memberList.Add(m);
                                StaticLists.addMemberList(m);
                                break;
                        }
                    }

                    // Console.WriteLine("Not null Token: {0}, Value: {1}, i: {2}", reader.TokenType, reader.Value, i);
                }
                /*else
                {
                  Console.WriteLine("null Token: {0}", reader.TokenType);
                }*/
            }

        }

        /*
            AUTHOR: Manuel Antonio Gómez Angulo
            CREATION DATE: 29/11/2019. First example of program with C# in 2019. Remembering to work with C#. Hours: 2
            UPDATE DATE: 30/11/2019. Trying to resolve the problem. HOURS: X+
            DESCRITION: This code has to read json and create members instance, carcel instances to resolve the problem
        */
        static void Main(string[] args)
        {

            /*var m1 = new Member();
            m1.setName("John");
            m1.setSeniority(4);
            Console.WriteLine($"Print member 1. name: {m1.getName()}, seniority: {m1.getSeniority()}");

           
            m1.setSubordinates(new List<String>() { m2.getName(), m3.getName() });
            Console.WriteLine($"* Print member 1 {m1.toString()}");

            var c1 = new Carcel();
            c1.enter(m1);
            c1.enter(m2);
            Console.WriteLine($"* Print carcel 1 {c1.toString()}");
            c1.leave(m1);
            Console.WriteLine($"* Print carcel 2 {c1.toString()}");
            */
           
            // Please, if you want test, modify yourself the path
            
            readFromFile(@"D:\pruebaCodigo\datos-json");
            List<Member> memberList = StaticLists.getMemberList();
            var c1 = new Carcel();

            Console.Write("Do you want to see first member list and current prisoners? [y/n] ");
            ConsoleKey  response = Console.ReadKey(false).Key;   // if you pulse y show json member list
            Console.WriteLine("\n");
            if (response == ConsoleKey.Y)
            {
                Console.WriteLine("Printing initial state");
                for (int j = 0; j < memberList.Count; j++)
                {
                    Console.WriteLine(memberList[j].toString());
                }

                Console.WriteLine("\n{0}", c1.toString());
                Console.WriteLine("Thanks you to check my work. It will continue");
            }
            
            Console.WriteLine("\nTEST");
            Member mPrisoner = memberList.Find(x => x.getName() == "Jhon");
            Console.WriteLine("{0}", mPrisoner.toString() );
            c1.enter(mPrisoner);
            Console.WriteLine("\n{0}", c1.toString());
            mPrisoner = memberList.Find(x => x.getName() == "Andy");
            c1.enter(mPrisoner);
            Console.WriteLine("\n{0}", c1.toString());

        }
        //--> ENDING MAIN

    }
    //--> ENDING CLASS PROGRAM
}
