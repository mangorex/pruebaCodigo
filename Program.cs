using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

// IMPORTANT. For this project to work, you need .NET Core 3.0 SDK and Newtonsoft.Json. It is all in README.md
namespace pruebaCodigo
{
    
    // --> STARTING CLASS PROGRAM
    class Program
    {
         /*
            AUTHOR: Manuel Antonio Gómez Angulo
            CREATION DATE: 30/11/2019
            DESCRITION: Function to read from file, set members and set member list.
            It must be executed at first of the main. Requires a path as a parameter
        */
        static void readFromFile(string path){
            // Read file and save the the text as a string. The string is named json
            string json = System.IO.File.ReadAllText(path);

            // Prepare the reader
            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            int i = 0;

            Member m = new Member(); // Instance the class member

            while (reader.Read()) // Loop for read
            {
                if (reader.Value != null) // If the value is distinct to null
                {
                    // If token type is json type PropertyName
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        // Distinguish the value of the property name and set a value as integer in the variable i
                        /* It is required to do so, because the name of the property and its value are not 
                        *  taken at the same time (Example: "name", "Jhon")
                        */
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
                        // If token type is not Property name, We set attributes according to variable i
                        switch (i)
                        {
                            case 0: // Initialize empty subordinate list and set Name
                                m.setSubordinates(new List<String>());
                                m.setName(reader.Value.ToString());
                                break;
                            case 1: // Set seniority as Int32. The convert is to solve an issue
                                m.setSeniority(Convert.ToInt32(reader.Value));
                                break;
                            case 2: 
                                /*  Adding one-to-one subordinates.
                                *    If a member has more than one subordinate the i will not change (2) until they all are added
                                */
                                m.addSubordinate(reader.Value.ToString());
                                break;
                            case 3:
                                m.setBoss(reader.Value.ToString());
                                StaticLists.addMemberList(m);
                                break;
                        }
                    }

                }
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

            string path = Environment.CurrentDirectory;
            path += "\\datos-json";
            Console.WriteLine("COMPLETE PATH: {0}", path);
            
            Console.Write("\nSTARTING DREAM. Thanks you for give me motivation to improve myself\n");

            // PLEASE, if you want to PUT COMPLETE ROUTE, feel free to do so, but COMMENT on the other line of readFromFile
            // readFromFile(@"D:\pruebaCodigo\datos-json");
            readFromFile(path);


            // This code is if you want to see intial state and to test the first impression in the console
            Console.Write("\nDo you want to see initial state of JSON? [y/n] ");
            ConsoleKey  response = Console.ReadKey(false).Key;
            Console.WriteLine("\n");
            if (response == ConsoleKey.Y)  // if you pulse y show json member list
            {
                Console.WriteLine("STARTING INITIAL STATE");
                StaticLists.memberListToString();
                Console.WriteLine("Thanks you to check my work. It will continue");
                Console.WriteLine("ENDING INITIAL STATE");
            }
            
            Console.WriteLine("\nSTARTING CHANGES IN THE DREAM\n");
            Console.WriteLine("Press any key to make Jhon a prisoner"); 
            Console.ReadKey(false); 
            
            // First Get member list
            List<Member> memberList = StaticLists.getMemberList();
            // Find member with name Jhon with predicate
            Member mPrisoner = memberList.Find(x => x.getName() == "Jhon");
            
            var c1 = new Carcel(); // Instance of Carcel
            c1.enter(mPrisoner); // First enter to make Jhon a prisoner
            StaticLists.memberListToString();
            
            Console.WriteLine("Press any key to make Jhon a free man"); 
            Console.ReadKey(false);

            c1.leave(mPrisoner);
            StaticLists.memberListToString();

            Console.WriteLine("Press any key to see senior band"); 
            Console.ReadKey(false);
            Member oldSeniorMember = StaticLists.getSeniorMember();
            Console.WriteLine("\nSENIOR BAND IS:");
            Console.WriteLine("{0}", oldSeniorMember.toString());

            Console.WriteLine("Press any key to make senior member a prisoner"); 
            Console.ReadKey(false);
            c1.enter(oldSeniorMember);
            StaticLists.memberListToString();
            

            Console.WriteLine("Press any key to see new senior band"); 
            Console.ReadKey(false);
            Member seniorMember = StaticLists.getSeniorMember();
            Console.WriteLine("\nSENIOR BAND IS:");
            Console.WriteLine("{0}", seniorMember.toString());

            Console.WriteLine("Press any key to set new senior band. It will be Francis"); 
            Member newSenior = memberList.Find(x => x.getName() == "Francis");
            StaticLists.setSeniorMember(newSenior);
            StaticLists.memberListToString();

            Console.WriteLine("Press any key to make old senior member a free man"); 
            Console.ReadKey(false);
            c1.leave(oldSeniorMember);
            StaticLists.memberListToString();
            
            //StaticLists.prisonerListToString(); // If you want to see prisoner list as a string
        }
        //--> ENDING MAIN

    }
    //--> ENDING CLASS PROGRAM
}
