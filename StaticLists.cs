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
    }

}