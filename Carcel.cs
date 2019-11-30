using System;
using System.Collections.Generic;

namespace pruebaCodigo
{
    public class Carcel
    {
        public void enter(Member m){
            // When a member enter in Carcel set old Subordinates
            m.setOldSubordinates(m.getSubordinates());
            m.setOldBoss(m.getBoss());
            m.changeBossInSubordinates(m.getBoss(), m.getSubordinates());
            m.dropSubordinatesInBoss();
            m.setBoss(""); 
            // When a member enter in Carcel clean current subordinates
            m.setSubordinates(new List<string>());
            // When a member enter in Carcel remove his position in MemberList
            StaticLists.removeMemberList(m);
            // When a member enter in Carcel is added to prisoner list
            StaticLists.addPrisonerList(m);
            // Console.WriteLine("OLD SUBORDINATES {0}", m.oldSubordinatesToString());
            
        }

        public void leave(Member m){
            StaticLists.addMemberList(m);
            StaticLists.removePrisonerList(m);
            m.changeBossInSubordinates(m.getName());
            m.setBoss(m.getOldBoss());
            /*m.setOldSubordinates(new List<String>());
            m.setOldBoss("");
            m.setSubordinates(m.getOldSubordinates());
            m.setBoss(m.getOldBoss());*/
        }

        public String toString()
        {
            List<Member> PrisonersList = StaticLists.getPrisonersList();
            var result = "PRISONERS";

            if (PrisonersList.Count > 0)
            {
                result += "\n";
                foreach (Member m in PrisonersList)
                {
                   result += "    " +  m.getName();
                }
            }else {
                result += ": NOBODY";
            }
            return result;
        }
    }
}