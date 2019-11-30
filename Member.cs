using System;
using System.Collections.Generic;

namespace pruebaCodigo
{
    public class Member
    {
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
        private List<Member> Subordinates = new List<Member>();
        private List<Member> getSubordinates()
        {
            return this.Subordinates;
        }
        public void setSubordinates(List<Member> subordinates)
        {
            this.Subordinates = subordinates;
        }
        private Member Boss;
        public Member getBoss()
        {
            return this.Boss;
        }
        public void setBoss(Member boss)
        {
            this.Boss = boss;
        }

        public String toString()
        {
            var result = "Name: " + this.Name + ", seniority: " + this.Seniority;

            if (Boss != null)
            {
                result += ", boss: " + this.Boss;
            }

            if (Subordinates.Count > 0)
            {
                result += ", subordinates: \n";
                foreach (Member m in Subordinates)
                {
                    result += "    " + m.Name + "\n";
                }
            }
            return result;
        }

        /*public Member(String name, int seniority, List<Member> subordinates, Member boss)
        {
            this.Name = name;
            this.Seniority = seniority;
            this.Subordinates = subordinates;
            this.Boss = boss;
        }*/
    }
}