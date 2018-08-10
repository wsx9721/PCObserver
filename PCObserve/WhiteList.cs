using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PCObserve
{
    class WhiteList
    {
        private Hashtable whitelist;

        public WhiteList()
        {
            whitelist = new Hashtable();
        }

        public string check(ArrayList pros)
        {
            string s = "有如下白名单中未配置的进程:\r\n";
            foreach (string pro in pros)
            {
                if (!whitelist.ContainsKey(pro))
                {
                    s = s + pro + "\r\n";
                }
            }
            return s;
        }

    }
}
