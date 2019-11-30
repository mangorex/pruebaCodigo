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
            Console.Write("STARTING DREAM. Thanks you for give me motivation to improve my self\n");

            // Please, if you want test, modify yourself the path
            readFromFile(@"D:\pruebaCodigo\datos-json");
            List<Member> memberList = StaticLists.getMemberList();
            var c1 = new Carcel();

            Console.Write("\nDo you want to see first member list and current prisoners? [y/n] ");
            ConsoleKey  response = Console.ReadKey(false).Key;   // if you pulse y show json member list
            Console.WriteLine("\n");
            if (response == ConsoleKey.Y)
            {
                Console.WriteLine("STARTING INITIAL STATE");
                StaticLists.memberListToString();
                Console.WriteLine("\n{0}", c1.toString());
                Console.WriteLine("Thanks you to check my work. It will continue");
                Console.WriteLine("ENDING INITIAL STATE");
            }

            Console.WriteLine("\nSTARTING CHANGES IN THE DREAM\n");
            Console.WriteLine("Press any key to make Jhon a prisoner"); 
            Console.ReadKey(false); 
            
            Member mPrisoner = memberList.Find(x => x.getName() == "Jhon");
            // Console.WriteLine("{0}", mPrisoner.toString() );
            c1.enter(mPrisoner);
            StaticLists.memberListToString();
            
            Console.WriteLine("Click to make Jhon a free man"); 
            Console.ReadKey(false);

            c1.leave(mPrisoner);
            StaticLists.memberListToString();

            Console.WriteLine("Click to see senior band"); 
            Console.ReadKey(false);
            StaticLists.printSeniorBand();
            //StaticLists.prisonerListToString();
        }
        //--> ENDING MAIN

    }
    //--> ENDING CLASS PROGRAM
}
