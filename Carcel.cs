using System;
using System.Collections.Generic;

namespace pruebaCodigo
{
    public class Carcel
    {
        // CREATION DATE: 30/11/2019
        // Function to enter in Carcel. Use Member and StaticLists class
        public void enter(Member m){
            // When a member enter in Carcel set old Subordinates and old boss
            m.setOldSubordinates(m.getSubordinates());
            m.setOldBoss(m.getBoss());

            // When a member enter in Carcel change boss register in subordinates
            m.changeBossInSubordinates(m.getBoss(), m.getSubordinates());
            // Drop member of list of subordinates in his current boss
            
            m.dropSubordinatesInBoss();
            m.setBoss(""); // Currently the member has no boss
            // When a member enter in Carcel clean current subordinates
            m.setSubordinates(new List<string>());

            // When a member enter in Carcel remove his position in MemberList
            StaticLists.removeMemberList(m);
            // When a member enter in Carcel is added to prisoner list
            StaticLists.addPrisonerList(m);            
        }

        // CREATION DATE: 30/11/2019
        // Function to free people. Use Member and StaticLists class
        public void leave(Member m){
            
            // Addition of member to member list
            StaticLists.addMemberList(m);
            StaticLists.removePrisonerList(m);

            // Change boss of their old subordinates
            m.changeBossInSubordinates(m.getName(), m.getOldSubordinates());
            m.setBoss(m.getOldBoss()); // Set the old boss

            // Obtain member boss, as an Object, with the name of the boss
            Member mBoss = StaticLists.getMemberList().Find(x => x.getName() == m.getBoss());
            
            if (mBoss != null){ 

                // Remove subordinates in the boss of the free man, to put them in the free man, out of the loop
                foreach(String strName in m.getOldSubordinates()){
                    mBoss.removeSubordinate(strName);
                }

                // Addition of free man as subordinate in the old bos
                mBoss.addSubordinate(m.getName());
            } else{
                Member seniorMember = StaticLists.getSeniorMember();
                // In case of no boss set free man as senior member
                StaticLists.setSeniorMember(m);

                foreach(String nameSubordinate in m.getSubordinates()){
                    // Delete new senior member in lists of subordinates of other members
                    seniorMember.removeSubordinate(nameSubordinate);
                }
            }
            
            // Clean old subordinates and old boss
            m.setOldSubordinates(new List<String>());
            m.setOldBoss("");
        }

    }
}