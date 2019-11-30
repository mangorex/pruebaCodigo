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

        public static void prisonerListToString()
        {
            for (int i = 0; i < PrisonersList.Count; i++)
            {
                Console.WriteLine(PrisonersList[i].toString());
            }
        }

        // My interpretation is that the senior band is the member who has not a Boss
        public static void printSeniorBand(){
            Member senior = MemberList.Find(x => x.getBoss() == "");
            Console.WriteLine("\nSENIOR BAND IS:");
            Console.WriteLine("{0}", senior.toString());
        }

    }
}