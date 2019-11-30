using System;
using System.Collections.Generic;

namespace pruebaCodigo
{
    public class Carcel
    {
        private List<Member> Prisoners = new List<Member>();
        public void enter(Member m){
            this.Prisoners.Add(m);
        }

        public void leave(Member m){
            this.Prisoners.Remove(m);
        }

        public String toString()
        {
            var result = "PRISONERS";

            if (Prisoners.Count > 0)
            {
                result += "\n";
                foreach (Member m in Prisoners)
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