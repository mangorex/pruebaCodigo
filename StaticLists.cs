using System;
using System.Collections.Generic;

namespace pruebaCodigo
{
    /* CREATION DATE: 30/11/2019
    * AUTHOR: Manuel Antonio Gomez Angulo
    * Static class to use static lists of members      
    */
    public static class StaticLists
    {
        // --> STARTING ATTRIBUTES. GETTERS AND SETTERS
        private static List<Member> MemberList = new List<Member>();

        public static List<Member> getMemberList()
        {
            return MemberList;
        }

        public static void setMemberList(List<Member> memberList)
        {
            MemberList = memberList;
        }

        public static void addMemberList(Member member)
        {
            MemberList.Add(member);
        }

        public static void removeMemberList(Member member)
        {
            MemberList.Remove(member);
        }

        public static void memberListToString()
        {
            Console.WriteLine("\n PRINTING LIST OF MEMBERS");

            for (int i = 0; i < MemberList.Count; i++)
            {
                Console.WriteLine(MemberList[i].toString());
            }
        }

        private static List<Member> PrisonersList = new List<Member>();

        public static List<Member> getPrisonersList()
        {
            return PrisonersList;
        }

        public static void setPrisonersList(List<Member> prisonersList)
        {
            PrisonersList = prisonersList;
        }

        public static void addPrisonerList(Member member)
        {
            PrisonersList.Add(member);
        }

        public static void removePrisonerList(Member member)
        {
            PrisonersList.Remove(member);
        }
        // <--  ENDING ATTRIBUTES. GETTERS AND SETTERS

        // --> STARTING AUXILIAR METHODS
        public static void prisonerListToString()
        {
            for (int i = 0; i < PrisonersList.Count; i++)
            {
                Console.WriteLine(PrisonersList[i].toString());
            }
        }

        /*
        *   AUTHOR: Manuel Antonio Gómez Angulo
        *   CREATION DATE: 30/11/2019
        *   DESCRITION: This function is to get senior member
        *   My interpretation is that the senior band is the member who has not a Boss.
        *   Maybe other interpretation would be the member who have more seniority, but it is not mine
        */
        public static Member getSeniorMember(){
            Member senior = MemberList.Find(x => x.getBoss() == "");
            return senior;
        }

        /*
        *   AUTHOR: Manuel Antonio Gómez Angulo
        *   CREATION DATE: 30/11/2019
        *   DESCRITION: This function is to set senior member
        *   Function reveive new senior member, get old senior, set boss of the new senior member as empty and take
        *   subordinates of the old senior member.
        *   Also set boss of the old senior member as the new senior and remove the senior of his list of subordinates
        *   My interpretation of the problem of SECOND POINT OF THE PLUS PART was that a member can be senior
        *   passing him as a parameter, regardless of the seniority 
        */
        public static void setSeniorMember(Member newSenior){
            Member oldSenior = getSeniorMember();
            newSenior.setBoss("");
            oldSenior.setBoss(newSenior.getName());
            newSenior.addSubordinate(oldSenior.getName());
            oldSenior.removeSubordinate(newSenior.getName());
        }

        // --> ENDING AUXILIAR METHODS
    }
}