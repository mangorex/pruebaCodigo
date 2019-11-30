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

        public static void setMemberList( List<Member> memberList)
        {
            MemberList = memberList;
        }

        public static void addMemberList(Member member)
        {
            MemberList.Add(member);
        }

    }

}