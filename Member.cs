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
        private List<String> Subordinates = new List<String>();
        private List<String> getSubordinates()
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

        public String toString()
        {
            var result = "Name: " + this.Name + ", seniority: " + this.Seniority;

            result += ", boss: ";
            if (Boss != null && Boss != "")
            {
                result += this.Boss;
            } else {
                result += "NOBODY";
            }

            result += ", subordinates: \n";
            if (Subordinates.Count > 0)
            {
                
                foreach (String m in Subordinates)
                {
                    result += "    " + m + "\n";
                }
            } else {
                result +=  "    " + "NOBODY";
            }
            return result;
        }
    }
}