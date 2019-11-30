using System;
using System.Collections.Generic;

namespace pruebaCodigo
{
    public class Member
    {
        // --> STARTING ATTRIBUTES. GETTERS AND SETTERS
        private String Name;
        public String getName()
        {
            return this.Name;
        }
        public void setName(String name)
        {
            this.Name = name;
        }
        private int Seniority;
        public int getSeniority()
        {
            return this.Seniority;
        }

        public void setSeniority(int seniority)
        {
            this.Seniority = seniority;
        }
        private List<String> Subordinates = new List<String>();
        public List<String> getSubordinates()
        {
            return this.Subordinates;
        }
        public void setSubordinates(List<String> subordinates)
        {
            this.Subordinates = subordinates;
        }

        public void addSubordinate(String subordinate)
        {
            this.Subordinates.Add(subordinate);
        }

        public void removeSubordinate(String subordinate)
        {
            this.Subordinates.Remove(subordinate);
        }

        private String Boss;
        public String getBoss()
        {
            return this.Boss;
        }
        public void setBoss(String boss)
        {
            this.Boss = boss;
        }

        private String OldBoss;
        public String getOldBoss()
        {
            return this.OldBoss;
        }
        public void setOldBoss(String oldBoss)
        {
            this.OldBoss = oldBoss;
        }

        private List<String> OldSubordinates = new List<String>();
        public List<String> getOldSubordinates()
        {
            return this.OldSubordinates;
        }
        public void setOldSubordinates(List<String> oldSubordinates)
        {
            this.OldSubordinates = oldSubordinates;
        }
        // <-- ENDING ATTRIBUTES. GETTERS AND SETTERS


        // --> STARTING AUXILIAR METHODS

        public String oldSubordinatesToString()
        {
            String result = "Old subordinates: \n";
            if (OldSubordinates.Count > 0)
            {
                foreach (String m in OldSubordinates)
                {
                    result += "    " + m + "\n";
                }
            }
            else
            {
                result += "    " + "NOBODY";
            }
            return result;
        }

        public String toString()
        {
            var result = "Name: " + this.Name + ", seniority: " + this.Seniority;

            result += ", boss: ";
            if (Boss != null && Boss != "")
            {
                result += this.Boss;
            }
            else
            {
                result += "NOBODY";
            }

            result += ", subordinates: \n";
            if (Subordinates.Count > 0)
            {
                foreach (String m in Subordinates)
                {
                    result += "    " + m + "\n";
                }
            }
            else
            {
                result += "    " + "NOBODY";
            }
            return result;
        }

        /* CREATION DATE: 30/11/2019
        * AUTHOR: Manuel Antonio Gomez Angulo
        * Function for change the boss information of subordinates
        * It receives the following:
        *   boss (String): The boss name
        *   nameSubordinates (List<String>): List of subordinates to check and to change the boss
        */
        public bool changeBossInSubordinates(String boss, List<String> nameSubordinates)
        {
            List<Member> memberList = StaticLists.getMemberList(); // List of all members
            List<Member> subordinates = new List<Member>(); // List of members subordinates

            int n;
            bool findMember;

            // Loop of each member of memberList. It is to obtain subordinates with nameSubordinates, but as List<Member> type
            foreach (Member m in memberList)
            {
                n = 0;
                findMember = false; // Flag to find the subordinate by name

                while (n < nameSubordinates.Count && findMember == false)
                {
                    if (nameSubordinates[n] == m.getName())
                    {
                        findMember = true;
                        subordinates.Add(m); // Add member in List<Member> subordinates
                    }
                    n++; // Increments contator
                }
            }

            if (subordinates.Count != 0)
            {
                int seniority = 0;
                Member seniorMember = new Member();

                // Loop for set boss of prisoner as boss of their subordinates
                // If boss of prisoner is null obtain the new senior Member in base of seniority
                foreach (Member m in subordinates)
                {
                    // If boss is passed with not null value
                    if (boss != null && boss != "")
                    {
                        m.Boss = boss; // Set boss of the subordinates of prisoner
                        Member mBoss = memberList.Find(x => x.getName() == boss);
                        mBoss.addSubordinate(m.getName()); // Set subordinates of the boss of prisoner
                    }
                    else
                    {
                        // If not exists boss, set as senior boss the member with more seniority
                        if (m.getSeniority() >= seniority)
                        {
                            seniority = m.getSeniority();
                            seniorMember = m;
                        }
                        else
                        {
                            m.Boss = "";
                        }
                    }
                }

                // Clean boss of the senior Member
                seniorMember.setBoss("");

                // Loop for add as boss the seniorMember of the subordinates
                // Addition of subordinates in seniorMember
                foreach (Member m in subordinates)
                {
                    if (!m.Equals(seniorMember) && (boss == null || boss == ""))
                    {
                        m.setBoss(seniorMember.getName());
                        seniorMember.addSubordinate(m.getName());
                    }
                }

            }

            return true;
        }

        /* CREATION DATE: 30/11/2019
        * AUTHOR: Manuel Antonio Gomez Angulo
        * Function to drop subordinates in boss
        * It receives nothing
        */
        public bool dropSubordinatesInBoss()
        {
            // Get all member list
            List<Member> memberList = StaticLists.getMemberList();

            // Get all bosses with List subordinates, with contains the name of this Member 
            List<Member> bosses = memberList.FindAll(
            delegate (Member member)
            {
                return member.getSubordinates().Contains(this.Name);
            }
            );

            // If exists, remove of the subordinates list this member
            if (bosses.Count != 0)
            {
                foreach (Member m in bosses)
                {
                    m.Subordinates.Remove(this.Name);
                }
            }
            return true;
        }

        // --> ENDING AUXILIAR METHODS
    }
}