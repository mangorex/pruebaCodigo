using System;
using System.Collections.Generic;

namespace pruebaCodigo
{
    public class Carcel
    {
        public void enter(Member m){
            StaticLists.addPrisonerList(m);
        }

        public void leave(Member m){
            StaticLists.removePrisonerList(m);
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