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
        public bool changeBossInSubordinates(String boss)
        {
            List<Member> memberList = StaticLists.getMemberList();
            //Member subordinate = memberList.Find(x => x.getBoss() == this.Name);
            List<Member> subordinates = memberList.FindAll(
            delegate (Member member)
            {
                return member.getBoss() == this.Name;
            }
            );
            

            if (subordinates.Count != 0)
            {
                int seniority= 0;
                Member finalBoss = new Member();
                // Console.WriteLine("\n {0}  is boss ", this.Name);

                // Loop for set boss of prisoner as boss of their subordinates
                // If boss of prisoner is null obtain the new final boss in base of seniority
                foreach (Member m in subordinates)
                {
                    // Console.WriteLine("{0}", m.toString());
                    if (boss != null && boss != ""){
                        m.Boss = boss; // Set boss of the subordinates of prisoner
                        Member mBoss = memberList.Find(x => x.getName() == boss);
                        mBoss.addSubordinate(m.getName()); // Set subordinates of the boss of prisoner
                    } else {
                        if ( m.getSeniority() >= seniority){
                            seniority = m.getSeniority();
                            finalBoss = m;
                        } else{
                            m.Boss = "";
                        }
                    }
                    // Console.WriteLine("{0}", m.toString());
                }
                
                // Clean boss of the final boss
                finalBoss.setBoss("");

                // Loop for add as boss the finalBoss of the subordinates
                // Addition of subordinates in finalBoss
                foreach (Member m in subordinates)
                {
                    if ( !m.Equals(finalBoss) && (boss == null || boss == "")){
                        m.setBoss(finalBoss.getName());
                        finalBoss.addSubordinate(m.getName());
                    }
                }
                
            }
            return true;
        }

        public bool dropSubordinatesInBoss()
        {
            List<Member> memberList = StaticLists.getMemberList();
            //Member subordinate = memberList.Find(x => x.getBoss() == this.Name);
            List<Member> bosses = memberList.FindAll(
            delegate (Member member)
            {
                return member.getSubordinates().Contains(this.Name);
            }
            );

            // Console.WriteLine("BOSS COUNT {0}, name prisoner {1}", bosses.Count, this.Name);

            if (bosses.Count != 0)
            {
                // Console.WriteLine("\n {0}  is boss ", this.Name);
                foreach (Member m in bosses)
                {
                    // Copy of old subordinates
                    // m.OldSubordinates = Subordinates;
                    // Console.WriteLine("\nOLD BOSS {0}", m.toString());
                    m.Subordinates.Remove(this.Name);
                    // Console.WriteLine("{0}\n", m.toString());
                }
            }
            return true;
        }
        public String oldSubordinatesToString(){
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

        // --> ENDING AUXILIAR METHODS
    }
}