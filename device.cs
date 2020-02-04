using MbnApi;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;


namespace Cat_Client
{
    public class CatReg
    {

    }

    public class CatUut : CatReg
    {
        public static string SN
        {
            get
            {
                string sn="";
                return sn;
            }
        }

        public static string Platform
        {
            get
            {
                string sn = "";
                return sn;
            }
        }

        public static string OS
        {
            get
            {
                string os = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "NA").ToString();
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HpComm\\CAT\\UUT", "OS", os, RegistryValueKind.String);
                return os;
            }
        }
        public static string Image
        {
            get
            {
                string image = "";
                using (ManagementObjectSearcher m = new ManagementObjectSearcher("SELECT OEMStringArray FROM Win32_COMPUTERSYSTEM"))
                {
                    foreach (var v in m.Get())
                    {
                        foreach (var p in v.Properties)
                        {
                            foreach (var str in (string[])p.Value)
                            {
                                if (str.Contains("BUILDID"))
                                {
                                    try
                                    {
                                        image = str.Split('#')[1];

                                    }
                                    catch
                                    {
                                        Console.WriteLine("BUILD ID MISSING");
                                        image = "";
                                    }
                                }
                            }
                        }
                    }

                }
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HpComm\\CAT\\UUT", "IMG", image, RegistryValueKind.String);
                return image;
            }
        }
        public static string BIOS
        {
            get
            {
                string bios = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSVersion", "NA").ToString();
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\HpComm\\CAT\\UUT", "BIOS", bios, RegistryValueKind.String);
                return bios;
            }
        }
        public struct WLAN
        {
            public static string hwid = "NA";
            public static string driver = "NA";
        }
        public struct BT
        {
            public static string hwid = "NA";
            public static string driver = "NA";
        }
        public struct WWAN
        {
            public static string hwid = "NA";
            public static string driver = "NA";
            public static string modem = "NA";
            public static string firmware = "NA";

        }
        public struct GNSS
        {
            public static string hwid = "NA";
            public static string driver = "NA";
        }
        public struct LAN
        {
            public static string hwid = "NA";
            public static string driver = "NA";
        }
        public struct RFID
        {
            public static string hwid = "NA";
            public static string driver = "NA";
        }
        public struct NFC
        {
            public static string hwid = "NA";
            public static string driver = "NA";
        }
        public static int[] GetCommDev()
        {
            int[] ret = new int[] { 0, 0, 0, 0, 0, 0 };
            Task<int> getnet = Task<int>.Run(() => GetNetDev());
            Task<int> getbt = Task<int>.Run(() => GetBTDev());
            Task<int> getmodem = Task<int>.Run(() => GetModemDev());
            Task<int> getnfc = Task<int>.Run(() => GetNFCDev());
            Task<int> getrfid = Task<int>.Run(() => GetRFIDDev());
            Task<int> getgnss = Task<int>.Run(() => GetGNSSDev());
            Task.WaitAll(
                getnet,
                getbt,
                getmodem,
                getnfc,
                getrfid,
                getgnss
            );
            ret[0] = getnet.Result;
            ret[1] = getbt.Result;
            ret[2] = getmodem.Result;
            ret[3] = getnfc.Result;
            ret[4] = getrfid.Result;
            ret[5] = getgnss.Result;
            return ret;
        }

        private static string netquery = "SELECT " +
                                        "Description," +
                                        "DriverDate," +
                                        "DriverProviderName," +
                                        "DriverVersion," +
                                        "FriendlyName," +
                                        "HardWareID " +
                                    "FROM " +
                                        "Win32_PnPSignedDriver " +
                                    "WHERE " +
                                        "deviceclass='net' and not " +
                                        "Description like '%WAN Miniport%' and not " +
                                        "Description like '%Wi-Fi Direct Virtual Adapter%' and not " +
                                        "Description like '%Microsoft Kernel Debug Network Adapter%' and not " +
                                        "Description like '%Bluetooth Device%'";
        private static string modemquery = "SELECT " +
                                        "Description," +
                                        "DriverDate," +
                                        "DriverProviderName," +
                                        "DriverVersion," +
                                        "HardWareID " +
                                    "FROM " +
                                        "Win32_PnPSignedDriver " +
                                    "WHERE " +
                                        "deviceclass='System' and  (Description like '%7360%' or Description like '%7560%' or Description like '%ModemControl%')";
        private static string btquery = "SELECT " +
                                        "Description," +
                                        "DriverDate," +
                                        "DriverProviderName," +
                                        "DriverVersion, " +
                                        "HardWareID " +
                                    "FROM " +
                                        "Win32_PnPSignedDriver " +
                                    "WHERE " +
                                        "deviceclass='Bluetooth' and " +
                                        "(Description like '%Intel%' or " +
                                        "Description like '%Realtek%')";
        private static string proxquery = "SELECT " +
                                        "Description," +
                                        "DriverDate," +
                                        "DriverProviderName," +
                                        "DriverVersion, " +
                                        "HardWareID " +
                                    "FROM " +
                                        "Win32_PnPSignedDriver " +
                                    "WHERE " +
                                        "deviceclass='Proximity'";
        private static string rfidquery = "SELECT " +
                                        "Description," +
                                        "DriverDate," +
                                        "DriverProviderName," +
                                        "DriverVersion, " +
                                        "HardWareID " +
                                    "FROM " +
                                        "Win32_PnPSignedDriver " +
                                    "WHERE " +
                                        "deviceclass='HIDClass' and " +
                                        "HardWareID like '%0C27%'";

        private static string gnssquery = "SELECT " +
                                        "Description," +
                                        "DeviceName," +
                                        "DriverVersion, " +
                                        "HardWareID " +
                                    "FROM " +
                                        "Win32_PnPSignedDriver " +
                                    "WHERE " +
                                        "deviceclass='Sensor' and " +
                                        "DeviceName like '%GNSS%'";


        private static int GetNetDev()
        {
            int ret = 0;
            try
            {
                var devs = new List<Dictionary<string, string>>();
                using (ManagementObjectSearcher m = new ManagementObjectSearcher(netquery))
                {
                    foreach (var v in m.Get())
                    {
                        var dev = new Dictionary<string, string>();

                        foreach (var p in v.Properties)
                        {
                            dev.Add(p.Name, ((string)p.Value).ToLower());
                        }

                        devs.Add(dev);
                    }
                }
                var wlan = (from dev in devs
                            where (dev["FriendlyName"].Contains("intel") && dev["FriendlyName"].Contains("wireless")) || (dev["FriendlyName"].Contains("intel") && dev["FriendlyName"].Contains("wi-fi")) || (dev["FriendlyName"].Contains("realtek") && dev["FriendlyName"].Contains("802.11"))
                            select dev).FirstOrDefault();
                var lan = (from dev in devs
                           where (dev["FriendlyName"].Contains("intel") && dev["FriendlyName"].Contains("ethernet")) || (dev["FriendlyName"].Contains("realtek") && dev["FriendlyName"].Contains("gbe"))
                           select dev).FirstOrDefault();
                var wwan_net = (from dev in devs
                                where (dev["FriendlyName"].Contains("intel") && dev["FriendlyName"].Contains("xmm")) || (dev["FriendlyName"].Contains("hp") && dev["FriendlyName"].Contains("lte"))
                                select dev).FirstOrDefault();
                if (wlan.Count > 0)
                {
                    CatUut.WLAN.hwid = wlan["HardWareID"];
                    CatUut.WLAN.driver = wlan["DriverVersion"];
                }
                if (lan.Count > 0)
                {
                    CatUut.LAN.hwid = lan["HardWareID"];
                    CatUut.LAN.driver = lan["DriverVersion"];
                }
                if (wwan_net.Count > 0)
                {
                    CatUut.WWAN.hwid = lan["HardWareID"];
                    CatUut.WWAN.driver = lan["DriverVersion"];
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                ret = -1;
            }
            return ret;
        }
        private static int GetModemDev()
        {
            MbnInterfaceManager mbn = new MbnInterfaceManager();
            IMbnInterfaceManager imbn = (IMbnInterfaceManager)mbn;

            IMbnInterface[] interfaces = (IMbnInterface[])imbn.GetInterfaces();
            void debug()
            {
                foreach (var _interface in interfaces)
                {
                    MBN_INTERFACE_CAPS caps = _interface.GetInterfaceCapability();
                    MBN_PROVIDER provider = _interface.GetHomeProvider();
                    MBN_READY_STATE readyState = _interface.GetReadyState();
                    IMbnRadio radio = (IMbnRadio)_interface;

                    Console.WriteLine();
                    Console.WriteLine("Manufacturer:        " + caps.manufacturer);
                    Console.WriteLine("Model:               " + caps.model);
                    Console.WriteLine("DeviceID:            " + caps.deviceID);
                    Console.WriteLine("FirmwareInfo:        " + caps.firmwareInfo);
                    Console.WriteLine("Ready State :        " + readyState.ToString());
                    Console.WriteLine("HardwareRadioState:  " + radio.HardwareRadioState.ToString());
                    Console.WriteLine("SoftwareRadioState:  " + radio.SoftwareRadioState.ToString());
                    Console.WriteLine("InterfaceID:         " + _interface.InterfaceID);
                    Console.WriteLine("Provider:            " + provider.providerName);
                    Console.WriteLine("ProviderID:          " + provider.providerID);
                    Console.WriteLine("ProviderState:       " + provider.providerState);

                }
            }
            int ret = 0;
            try
            {
                var devs = new List<Dictionary<string, string>>();
                using (ManagementObjectSearcher m = new ManagementObjectSearcher(modemquery))
                {
                    foreach (var v in m.Get())
                    {
                        var dev = new Dictionary<string, string>();

                        foreach (var p in v.Properties)
                        {
                            dev.Add(p.Name, ((string)p.Value).ToLower());
                        }

                        devs.Add(dev);
                        break;
                    }
                }
                if (devs.Count > 0)
                {
                    string modem_ver = "";
                    if (devs[0].TryGetValue("DriverVersion", out modem_ver))
                    {
                        if (modem_ver != "") CatUut.WWAN.modem = modem_ver;
                    }
                }

                //x64
                //string output = "";
                //if (executeProgram(@"netsh ", "mbn sh inter", out output) && output != "")
                //{//Firmware Version
                //    foreach (string line in output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                //    {
                //        if (line.Contains("Firmware")) { CatUut.WWAN.firmware = line.Substring(line.IndexOf(":") + ":".Length).Trim(); break; }
                //    }
                //}

                //x86
                foreach (var _interface in interfaces)
                {
                    MBN_INTERFACE_CAPS caps = _interface.GetInterfaceCapability();
                    CatUut.WWAN.firmware = caps.firmwareInfo.Trim();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                ret = -1;
            }
            return ret;
        }
        private static int GetBTDev()
        {
            int ret = 0;
            try
            {
                var devs = new List<Dictionary<string, string>>();
                using (ManagementObjectSearcher m = new ManagementObjectSearcher(btquery))
                {
                    foreach (var v in m.Get())
                    {
                        var dev = new Dictionary<string, string>();

                        foreach (var p in v.Properties)
                        {
                            dev.Add(p.Name, ((string)p.Value).ToLower());
                        }

                        devs.Add(dev);
                    }
                }
                if (devs.Count > 0)
                {
                    string bt_ver = "";
                    string bt_hwid = "";
                    if (devs[0].TryGetValue("DriverVersion", out bt_ver))
                    {
                        if (bt_ver != "") CatUut.BT.driver = bt_ver;
                    }
                    if (devs[0].TryGetValue("HardWareID", out bt_hwid))
                    {
                        if (bt_hwid != "") CatUut.BT.hwid = bt_hwid;
                    }
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                ret = -1;
            }
            return ret;
        }
        private static int GetNFCDev()
        {
            int ret = 0;
            try
            {
                var devs = new List<Dictionary<string, string>>();
                using (ManagementObjectSearcher m = new ManagementObjectSearcher(proxquery))
                {
                    foreach (var v in m.Get())
                    {
                        var dev = new Dictionary<string, string>();

                        foreach (var p in v.Properties)
                        {
                            dev.Add(p.Name, ((string)p.Value).ToLower());
                        }

                        devs.Add(dev);
                    }
                }
                if (devs.Count > 0)
                {
                    string prox_ver = "";
                    string prox_hwid = "";
                    if (devs[0].TryGetValue("HardWareID", out prox_hwid))
                    {
                        if (prox_hwid != "") CatUut.NFC.hwid = prox_hwid;
                    }
                    if (devs[0].TryGetValue("DriverVersion", out prox_ver))
                    {
                        if (prox_ver != "") CatUut.NFC.driver = prox_ver;
                    }
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                ret = -1;
            }
            return ret;
        }
        private static int GetGNSSDev()
        {
            int ret = 0;
            try
            {
                var devs = new List<Dictionary<string, string>>();
                using (ManagementObjectSearcher m = new ManagementObjectSearcher(gnssquery))
                {
                    foreach (var v in m.Get())
                    {
                        var dev = new Dictionary<string, string>();

                        foreach (var p in v.Properties)
                        {
                            dev.Add(p.Name, ((string)p.Value).ToLower());
                        }

                        devs.Add(dev);
                    }
                }
                if (devs.Count > 0)
                {
                    string gnssx_ver = "";
                    string gnss_hwid = "";
                    if (devs[0].TryGetValue("HardWareID", out gnss_hwid))
                    {
                        if (gnss_hwid != "") CatUut.GNSS.hwid = gnss_hwid;
                    }
                    if (devs[0].TryGetValue("DriverVersion", out gnssx_ver))
                    {
                        if (gnssx_ver != "") CatUut.GNSS.driver = gnssx_ver;
                    }
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                ret = -1;
            }
            return ret;
        }
        private static int GetRFIDDev()
        {
            int ret = 0;
            try
            {
                var devs = new List<Dictionary<string, string>>();
                using (ManagementObjectSearcher m = new ManagementObjectSearcher(rfidquery))
                {
                    foreach (var v in m.Get())
                    {
                        var dev = new Dictionary<string, string>();

                        foreach (var p in v.Properties)
                        {
                            dev.Add(p.Name, ((string)p.Value).ToLower());
                        }

                        devs.Add(dev);
                    }
                }
                if (devs.Count > 0)
                {
                    string rfid_ver = "";
                    string rfid_hwid = "";
                    if (devs[0].TryGetValue("HardWareID", out rfid_hwid))
                    {
                        if (rfid_hwid != "") CatUut.RFID.hwid = rfid_hwid;
                    }
                    if (devs[0].TryGetValue("DriverVersion", out rfid_ver))
                    {
                        if (rfid_ver != "") CatUut.RFID.driver = rfid_ver;
                    }
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
                ret = -1;
            }

            return ret;
        }
        private static bool executeProgram(string exePath, string exeCommand, out string Output)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = exePath;
                process.StartInfo.Arguments = exeCommand;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                StreamReader reader = process.StandardOutput;
                Output = reader.ReadToEnd();
                process.WaitForExit();
                return true;

            }
            catch
            {
                Output = "";
                return false;
            }

        }

    }


}
