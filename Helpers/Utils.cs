using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

namespace Phasmophobia_Save_Editor
{
    // Token: 0x02000009 RID: 9
    internal class Utils
    {
        // Token: 0x06000020 RID: 32 RVA: 0x000054E4 File Offset: 0x000036E4
        //public static string[] GetUsers()
        //{
        //    //IEnumerable<ManagementObject> enumerable = from ManagementObject u in new ManagementObjectSearcher("SELECT * FROM Win32_UserAccount").Get()
        //    //                                           where !(bool)u["Disabled"] && !(bool)u["Lockout"] && int.Parse(u["SIDType"].ToString()) == 1 && u["Name"].ToString() != "HomeGroupUser$"
        //    //                                           select u;
        //    //List<string> list = new List<string>();
        //    //foreach (ManagementObject managementObject in enumerable)
        //    //{
        //    //    list.Add(managementObject["Name"].ToString());
        //    //}
        //    //return list.ToArray();
        //}

        // Token: 0x06000021 RID: 33 RVA: 0x00005580 File Offset: 0x00003780
        public static Dictionary<string, string> EnumerateSaves()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string text2 = string.Format("C://Users/icey7/AppData/LocalLow/Kinetic Games/Phasmophobia/SaveFile.txt", "icey7");
                if (File.Exists(text2))
                {
                    dictionary.Add("icey7", text2);
                }
            return dictionary;
        }
    }
}
