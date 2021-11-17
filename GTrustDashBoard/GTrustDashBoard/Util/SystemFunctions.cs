using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using GTrustDashBoard.Util;
using GTrustDashBoard.Repository;

namespace GTrustDashBoard.Util
{
    public class SystemFunctions
    {
        public static string GetMACAddress()
        {
            return
            (
           from nic in NetworkInterface.GetAllNetworkInterfaces()
           select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();

        }

        public static IEnumerable<string> GetMACAddressList()
        {
            return
            (
           from nic in NetworkInterface.GetAllNetworkInterfaces()
           select nic.GetPhysicalAddress().ToString()
            );

        }
        public static bool IsRegisteredSystem()
        {

            string Current = GetMACAddress();
            List<string> CurrentList = SystemFunctions.GetMACAddressList().ToList();
            int count = SystemFunctionRepo.GetAllRegisteredMacAddresses().Intersect(CurrentList).Count();
            return count > 0 ? true : false;
            //return GetAllRegisteredMacAddresses().Contains(Current);
        }
    }
}
