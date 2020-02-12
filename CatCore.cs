using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using SimpleWifi;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace Cat_Client
{

    class CatStatus
    {
        public enum uutStatus
        {
            RUNNING, STANDBY
        }

        public enum taskStatus
        {
            SKIP,
            RERUN,
            PENDING,

            RUNNING,

            BSOD,
            DONE,
            SCRIPT_ERROR,
        }

        public enum modernStandby
        {
            NONE,MSC,MSD,
        }


    }
    class CatReg
    {

        private static List<List<string>> Init_Key = new List<List<string>>() {
                new List<string>(){ "task_name"             , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    "NO TASK"  },
                new List<string>(){ "task_status"           , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    "NO TASK"  },
                new List<string>(){ "task_id"               , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    "NO TASK"  },
                new List<string>(){ "task_path"             , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    "NO TASK"  },
                new List<string>(){ "task_result_folder"    , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    "NO TASK"  },
                new List<string>(){ "task_start_time"       , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    "NO TASK"  },
                new List<string>(){ "connect"               , @"HKEY_CURRENT_USER\Software\HpComm\CAT",         "NO TASK"  },
                new List<string>(){ "modern_standby"        , @"HKEY_CURRENT_USER\Software\HpComm\CAT",         CatStatus.modernStandby.NONE.ToString()  },
                new List<string>(){ "debug"                 , @"HKEY_CURRENT_USER\Software\HpComm\CAT",         false.ToString()  },
            };
        public static string task_name
        {
            get
            {
                string name = Registry.GetValue(Init_Key[0][1], Init_Key[0][0], Init_Key[0][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[0][1], Init_Key[0][0], value.ToString());
            }
        }
        public static string task_status
        {
            get
            {
                string name = Registry.GetValue(Init_Key[1][1], Init_Key[1][0], Init_Key[1][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[1][1], Init_Key[1][0], value.ToString());
            }
        }
        public static string task_id
        {
            get
            {
                string name = Registry.GetValue(Init_Key[2][1], Init_Key[2][0], Init_Key[2][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[2][1], Init_Key[2][0], value.ToString());
            }
        }
        public static string task_path
        {
            get
            {
                string name = Registry.GetValue(Init_Key[3][1], Init_Key[3][0], Init_Key[3][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[3][1], Init_Key[3][0], value.ToString());
            }
        }
        public static string task_result_folder
        {
            get
            {
                string name = Registry.GetValue(Init_Key[4][1], Init_Key[4][0], Init_Key[4][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[4][1], Init_Key[4][0], value.ToString());
            }
        }
        public static string task_start_time
        {
            get
            {
                string name = Registry.GetValue(Init_Key[5][1], Init_Key[5][0], Init_Key[5][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[5][1], Init_Key[5][0], value.ToString());
            }
        }
        public static string connect
        {
            get
            {
                string name = Registry.GetValue(Init_Key[6][1], Init_Key[6][0], Init_Key[6][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[6][1], Init_Key[6][0], value.ToString());
            }
        }
        public static string modern_standby
        {
            get
            {
                string name = Registry.GetValue(Init_Key[7][1], Init_Key[7][0], Init_Key[7][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[7][1], Init_Key[7][0], value.ToString());
            }
        }
        public static string debug
        {
            get
            {
                string name = Registry.GetValue(Init_Key[8][1], Init_Key[8][0], Init_Key[8][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[8][1], Init_Key[8][0], value.ToString());
            }
        }
        public static string winpvt_version
        {
            get
            {
                try
                {
                    string registry_key = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
                    using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
                    {
                        foreach (string subkey_name in key.GetSubKeyNames())
                        {
                            using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                            {
                                if (subkey.GetValue("DisplayName") != null && subkey.GetValue("DisplayName").ToString().Contains("WinPVT")) return subkey.GetValue("DisplayVersion").ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                return "NA";

            }
        }
        public static void set_and_check()
        {
            foreach (var key_value in Init_Key)
            {
                if (Registry.GetValue(key_value[1].ToString(), key_value[0], null) == null)
                {
                    Registry.SetValue(key_value[1].ToString(), key_value[0], key_value[2], RegistryValueKind.String);
                }
            }
        }
    }
    class CatNet
    {
        public static bool ServerConnection
        {
            get
            {
                bool ping_result = false;
                Ping ping = new Ping();
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    string hostname_or_ip = config.AppSettings.Settings["hostname"].Value;

                    PingReply ping_reply = ping.Send(hostname_or_ip);
                    if (ping_reply.Status == IPStatus.Success)
                    {
                        ping_result = true;

                    }
                }
                catch
                {
                    ping_result = false;
                }

                CatReg.connect = ping_result.ToString();
                return ping_result;
            }
        }

        public static bool ConnectServer()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string ssid = config.AppSettings.Settings["wifissid"].Value;
                string password = config.AppSettings.Settings["wifipassword"].Value;
                return connectwifi(ssid, password);
            }
            catch
            {
                return false;
            }

        }

        enum connectmode { auto, manual };
        static bool connectwifi(string ssid, string password, connectmode mode = connectmode.auto)
        {
            try
            {
                Wifi wifi = new Wifi();
                System.Diagnostics.Process.Start("explorer.exe", "ms-availablenetworks:");
                var point = wifi.GetAccessPoints().Where(x => x.Name == ssid).FirstOrDefault();
                if (!point.IsConnected)
                {
                    var pointset = new AuthRequest(point);
                    if (!point.IsValidPassword(password)) return false;
                    if (point.Connect(pointset)) return true;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static void check()
        {
            if (CatCore.LiveNetScripts.Count > 0)
            {
                if (!CatCore.LiveNetScripts.Contains(CatReg.task_name))
                {
                    if (!ServerConnection) ConnectServer();
                }
            }
        }

    }

    class CatCore
    {
        public static deviceJson device = null;

        public static List<string> LiveNetScripts
        {
            get
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                List<string> scripts = new List<string>();
                FileInfo fi = new FileInfo($@".\{config.AppSettings.Settings["livenet"].Value}");
                if (fi.Exists)
                {
                    scripts.AddRange((fi.OpenText().ReadToEnd()).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList());
                }
                return scripts;
            }
        }
        static bool runexe(string exePath, string exeCommand, out string Output)
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
        static bool runexe(string exePath, string exeCommand)
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
                process.WaitForExit();
                return true;

            }
            catch
            {
                return false;
            }

        }
        private static deviceJson GetDevice()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var devfile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, config.AppSettings.Settings["catdev"].Value,SearchOption.AllDirectories);
            if (devfile.Count() > 0)
            {
                runexe(devfile[0], "export");
                devfile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, config.AppSettings.Settings["devjson"].Value, SearchOption.AllDirectories);
                if(devfile.Count() > 0)
                {
                    return CatConvert.deviceToClass(devfile[0]);
                }
                else
                {
                    Console.WriteLine("Can't find CatDevOut.json");
                }
            }
            else
            {
                Console.WriteLine("Can't find CatDev.exe");
                return null;
            }
            return null;
        }
        private static void Catshortcut()
        {
            WshShell shell = new WshShell();
            string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + $@"\{ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["catlnk"].Value}";
            if (!System.IO.File.Exists(shortcutAddress))
            {
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Description = "Cat Client 3.0";
                shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                shortcut.Save();
            }
        }
        public void CatInit()
        {
            CatReg.set_and_check();
            device = GetDevice();
            Catshortcut();
        }




        public void Execute()
        {
            CatNet.check();
            
            while (device!=null || device.sn!="NA")
            {

            }
        }
    }
}
