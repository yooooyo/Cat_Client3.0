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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using File = System.IO.File;

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

            DONE,
            BSOD,
            SCRIPT_ERROR,
            MSC_NOT_SUPPORT
        }
        public enum taskName
        {
            NO_TASK
        }

        public enum modernStandby
        {
            NONE,MSC,MSD,
        }


    }
    class CatReg
    {

        public static event EventHandler RegValueChanged;

        private static List<List<string>> Init_Key = new List<List<string>>() {
                new List<string>(){ "task_name"             , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    CatStatus.taskName.NO_TASK.ToString()  },
                new List<string>(){ "task_status"           , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    ""  },
                new List<string>(){ "task_id"               , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    ""  },
                new List<string>(){ "task_path"             , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    ""  },
                new List<string>(){ "task_result_folder"    , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    ""  },
                new List<string>(){ "task_start_time"       , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    ""  },
                new List<string>(){ "connect"               , @"HKEY_CURRENT_USER\Software\HpComm\CAT",         false.ToString()  },
                new List<string>(){ "modern_standby"        , @"HKEY_CURRENT_USER\Software\HpComm\CAT",         CatStatus.modernStandby.NONE.ToString()},
                new List<string>(){ "debug"                 , @"HKEY_CURRENT_USER\Software\HpComm\CAT",         false.ToString()  },
                new List<string>(){ "test_image"            , @"HKEY_CURRENT_USER\Software\HpComm\CAT\Task",    ""  },
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
        public static bool connect
        {
            get
            {
                string name = Registry.GetValue(Init_Key[6][1], Init_Key[6][0], Init_Key[6][2]).ToString();
                if (name == false.ToString()) return false;
                if (name == true.ToString()) return true;
                return false;
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
        public static string test_image
        {
            get
            {
                string name = Registry.GetValue(Init_Key[9][1], Init_Key[9][0], Init_Key[9][2]).ToString();
                return name;
            }
            set
            {
                Registry.SetValue(Init_Key[9][1], Init_Key[9][0], value.ToString());
            }
        }
        public static CatStatus.uutStatus status
        {
            get
            {
                if (task_name == CatStatus.taskName.NO_TASK.ToString()) return CatStatus.uutStatus.STANDBY;
                else return CatStatus.uutStatus.RUNNING;
            }
        }
        public static string winpvt_version
        {
            get
            {
                string version = "NA";
                var _d = new DirectoryInfo(@"C:\Program Files\Hewlett-Packard").GetFiles("WinPVT.exe", SearchOption.AllDirectories).FirstOrDefault();
                if (_d != null) version = _d.Directory.Name;
                return version;

            }
        }
        public static string pws_version
        {
            get
            {
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    
                    var pws = (new DirectoryInfo(config.AppSettings.Settings["pws"].Value)).GetFiles(config.AppSettings.Settings["logstrip"].Value.Split(new char[] { ':', ',' })[2]).FirstOrDefault();
                    if(pws != null)
                    {
                        return FileVersionInfo.GetVersionInfo(pws.FullName).FileVersion;
                    }
                }
                catch
                {
                    
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

        public static string checkMSC()
        {
            string status = CatStatus.modernStandby.NONE.ToString();
            var pwrtest = Directory.EnumerateFiles(@"C\Release", "pwrtest.exe", SearchOption.AllDirectories).FirstOrDefault();
            return status;
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
                catch (Exception e)
                {
                    ping_result = CatData.databaseConnection;
                    Console.WriteLine($"ServerConnection FAIL");
                    //Console.WriteLine(e.ToString());
                }
                CatReg.connect = ping_result;
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        enum connectmode { auto, manual };
        static Wifi wifi;
        static bool connectwifi(string ssid, string password, connectmode mode = connectmode.auto)
        {
            
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string wifitool = config.AppSettings.Settings["wifitool"].Value;
                string command = $"connect /ssid:{ssid} /password:{password} /username: /domain:";
                string wifi_tool_path = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, wifitool, SearchOption.AllDirectories).FirstOrDefault();
                if(wifi_tool_path != null)
                {
                    var p = CatCore.runexe2(wifi_tool_path, command);
                    p.Start();
                    p.WaitForExit();
                    
                    if (wifi.GetAccessPoints().Where(x => x.IsConnected).Select(x => x.Name).FirstOrDefault() == ssid) return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"connectwifi FAIL");
                //Console.WriteLine(e.ToString());
            }
            return false;
        }


        public static void check()
        {
            if (!CatCore.LiveNetScripts.Contains(CatReg.task_name))
            {
                if (!ServerConnection) {ConnectServer(); }
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
        public static bool runexe(string exePath, string exeCommand, out string Output)
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
        public static bool runexe(string exePath, string exeCommand)
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
        public static Process runexe2(string exePath, string exeCommand)
        {
            Process process = new Process();
            try
            {

                process.StartInfo.FileName = exePath;
                process.StartInfo.Arguments = exeCommand;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                return process;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return process;
            }

        }
        private static deviceJson GetDevice()
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var catdevfile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, config.AppSettings.Settings["catdev"].Value,SearchOption.AllDirectories);
            if (catdevfile.Count() > 0)
            {
                var devfile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, config.AppSettings.Settings["devjson"].Value, SearchOption.AllDirectories);
                if (devfile.Count() > 0)
                {
                    if (System.IO.File.Exists(devfile[0])) System.IO.File.Delete(devfile[0]);
                }

                var p = runexe2(catdevfile[0], "export");
                p.Start();
                p.WaitForExit();
                devfile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, config.AppSettings.Settings["devjson"].Value, SearchOption.AllDirectories);
                if (devfile.Count() > 0)
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
        private static void CatShortCut()
        {
            
            string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + $@"\{ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["catlnk"].Value}";
            if (!System.IO.File.Exists(shortcutAddress))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Description = "Cat Client 3.0";
                shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                shortcut.Save();
            }
        }
        private static void CatStartUp()
        {
            
            string startupfolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string startupfile = Path.Combine(startupfolder, "catclient.bat");
            string batchcontent = $@"call ""{Application.ExecutablePath}""";
            if (!File.Exists(startupfile))
            {
                CreateText(startupfile, batchcontent);
            }
        }
        public void CatInit()
        {
            CatReg.set_and_check();
            device = GetDevice();
            CatShortCut();
            CatStartUp();
        }


        private static bool executeTest(string taskname)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            DirectoryInfo di = new DirectoryInfo(config.AppSettings.Settings["catscripts"].Value);
            var fi = di.GetFiles(taskname, SearchOption.AllDirectories).FirstOrDefault();
            Process execute = new Process();
            try
            {
                if(fi != null)
                {
                    if (CatReg.task_path != fi.FullName) CatReg.task_path = fi.FullName;
                    if (taskname.Contains(".pvt"))
                    {
                        DirectoryInfo info = new DirectoryInfo(@"C:\Program Files\Hewlett-Packard");
                        var winpvtexeS = info.GetFiles("WinPVT.exe", SearchOption.AllDirectories);
                        if (winpvtexeS.Count() > 0)
                        {
                            ProcessStartInfo executefile = new ProcessStartInfo(winpvtexeS[0].FullName, $@"/ACCEPT /AUTORUN ""{fi.FullName}""");
                            executefile.UseShellExecute = false;
                            execute = Process.Start(executefile);
                        }
                    }
                    else if (taskname.Contains(".bat"))
                    {
                        ProcessStartInfo executefile = new ProcessStartInfo(fi.FullName);
                        executefile.UseShellExecute = false;
                        execute = Process.Start(executefile);
                    }

                    if (!execute.HasExited)
                    {
                        CatReg.test_image = execute.ProcessName;
                        return true;
                    }
                }

            }
            catch (Exception e)
            { 
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        private static void oldlogCheck(string task_name)
        {
            string folder_name = "";
            folder_name = task_name.Remove(task_name.IndexOf('.'));
            if (task_name.Contains(".pvt") || (task_name.Contains(".WinPVT") && task_name.Contains(".bat")))
            {
                if (task_name.Contains(".WinPVT") && task_name.Contains(".bat"))
                {
                    folder_name = folder_name.Substring(folder_name.IndexOf("_") + "_".Length);
                }

                foreach (var dir in new DirectoryInfo(@"C:\ProgramData\Hewlett-Packard").EnumerateDirectories(folder_name, SearchOption.AllDirectories))
                {
                    if (dir.FullName.Contains("Logs") && dir.FullName.Contains(folder_name))
                    {
                        foreach (var _dir in dir.EnumerateDirectories())
                        {
                            if (!_dir.FullName.Contains("_old_")) _dir.MoveTo(_dir.FullName.Replace(_dir.Name, "_old_" + _dir.Name));
                        }
                    }
                }
            }
            else
            {
                foreach (var dir in new DirectoryInfo(@"C:\Release\Log").GetDirectories())
                {
                    if (dir.FullName.Contains("Log") && !dir.FullName.Contains("_old_"))
                    {
                        dir.MoveTo(dir.FullName.Replace(dir.Name, "_old_" + dir.Name));
                    }
                }
            }

        }
        private static void coredumpCheck()
        {
            var coredump_folder = $@"C:\Users\{Environment.UserName}\Documents\Intel\TelephonyTool\trace_folder";
            if (Directory.Exists(coredump_folder))
            {
                Console.WriteLine("Trace Folder Exists");
                var di_res = new List<string>();
                di_res.AddRange(Directory.GetDirectories(coredump_folder, "*COREDUMP*", SearchOption.AllDirectories).ToList());
                di_res.AddRange(Directory.GetFiles(coredump_folder, "*COREDUMP*", SearchOption.AllDirectories).ToList());
                //foreach (var v in Directory.GetFiles(coredump_folder, "*COREDUMP*", SearchOption.AllDirectories).ToList())
                //{
                //    Console.WriteLine("get file :" + v);
                //}
                //foreach (var v in di_res)
                //{
                //    Console.WriteLine("Exists Core Dump " + v);
                //}

                //if (!coreDmp_show || (di_res.Count() > 0 && di_res.Count() > coreDmp_num_temp))
                //{
                //    coreDmp_show = true;
                //    Console.WriteLine("Core Dump Folder Exists");
                //    coreDmp_num_temp = di_res.Count();
                //    List<object> objs = new List<object>();
                //    foreach (var v in di_res)
                //    {
                //        objs.Add(v.ToString());
                //    }
                //    update_lb_coredump_path(objs.ToArray());
                //}
            }

        }
        private static FileInfo resultFind(string task_name)
        {
            FileInfo summary = null;
            try
            {
                if ((task_name.Contains("WinPVT") && task_name.Contains(".bat")) || task_name.Contains(".pvt"))
                {
                    if (CatReg.task_result_folder == "")
                    {
                        DirectoryInfo find_summary = new DirectoryInfo(@"C:\ProgramData\Hewlett-Packard" + "\\" + CatReg.winpvt_version);
                        string folder_name = "";
                        if (task_name.Contains("WinPVT") && task_name.Contains(".bat"))
                        {
                            folder_name = task_name.Remove(task_name.IndexOf('.'));
                            folder_name = folder_name.Substring(folder_name.IndexOf("_") + "_".Length);
                        }
                        else if (task_name.Contains(".pvt"))
                        {
                            folder_name = task_name.Remove(task_name.IndexOf('.'));
                        }
                        var task_folder = (from f in find_summary.EnumerateDirectories(folder_name, SearchOption.AllDirectories)
                                           select f).FirstOrDefault();
                        if (task_folder != null)
                        {
                            var task_summary_folder = (from f in task_folder.EnumerateDirectories()
                                                       where f.FullName.Contains("Logs") && !f.FullName.Contains("_old_")
                                                       select f).FirstOrDefault();
                            if (task_summary_folder != null)
                            {
                                CatReg.task_result_folder = task_summary_folder.FullName;
                                summary = (from f in task_folder.EnumerateFiles("Summary.log", SearchOption.AllDirectories)
                                                where f.FullName.Contains("Logs") && f.FullName.Contains("Summary.log")
                                                select f).FirstOrDefault();
                            }

                        }
                    }
                    else
                    {
                        summary = new DirectoryInfo(CatReg.task_result_folder).EnumerateFiles("Summary.log").FirstOrDefault();
                    }

                }
                else if (task_name.Contains("Interface") || task_name.Contains("Idle-Test") || task_name.Contains("Youtube-Test"))
                {
                    summary = new DirectoryInfo(@"C:\Release\Log").EnumerateFiles("Summary.log", SearchOption.AllDirectories).Where(files => !files.FullName.Contains("_old_")).FirstOrDefault();
                }
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            return summary;
        }
        private static bool processKill()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var Exes = config.AppSettings.Settings["logstrip"].Value.Split(new char[] {',',':' }).ToList();
            var temp_Exes = config.AppSettings.Settings["logstrip"].Value.Split(new char[] { ',', ':' }).ToList();
            foreach (var v in temp_Exes)
            {
                if(int.TryParse(v,out int _))
                {
                    Exes.Remove(v);
                }
            }

            var p = Process.GetProcesses().Where(x => (string.Join("", Exes)).IndexOf(x.ProcessName) >= 0);
            int cnt = 0;
            if (p != null && p.Count() > 0)
            {
                foreach (var _p in p)
                {
                    Console.WriteLine($"Kill {_p.ProcessName}");
                    CatReg.test_image = _p.ProcessName + ".exe";
                    _p.Kill();
                    if (_p.HasExited) cnt++;
                }
                if (cnt == p.Count()) return true;
            }
            else
                Console.WriteLine("Can't finde PowerStressTest.exe or WinPVT.exe");
            return false;
        }
        private static bool logSummarize(FileInfo path,ref cat_local.task task)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var file = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, config.AppSettings.Settings["jimmylog"].Value, SearchOption.AllDirectories).FirstOrDefault();
                if(file != null)
                {
                    var pc = runexe2(file, $"Date:{DateTime.Parse(task.finish.ToString()).ToString("O")} /Logpath:{path.FullName} /LID={task.local_id} /TID={task.server_id}");
                    pc.Start();
                    pc.WaitForExit();
                    if (pc.HasExited)
                    {
                        Console.WriteLine($"LogPharse Exit Code {pc.ExitCode}");
                        Console.WriteLine($"LogPharse Output    {pc.StandardOutput.ReadToEnd()}");
                        string logpathParse(string logpath)
                        {
                            var cat_result = @"C:\Program Files (x86)\Cat\ResultCollection";
                            var s = logpath.Substring(logpath.IndexOf("Log")).Split('\\').ToList();
                            s.Remove(s.Where(x => x.Contains("Log")).First());
                            s.Remove(s.Where(x => x.Contains("Summary")).First());
                            logpath = cat_result + "\\" + string.Join("\\", s);
                            var d = new DirectoryInfo(logpath);
                            if (!d.Exists) d.Create();
                            return logpath;
                        }
                        var resultdest = logpathParse(path.FullName);
                        Console.WriteLine($"Parse Moving Path {resultdest}");
                        if (resultdest != null)
                        {
                            task.result_loc = resultdest + "\\" + path.Name;
                            Console.WriteLine($"Copy {path.FullName} to {resultdest + "\\" + path.Name}");
                            path.CopyTo(resultdest + "\\" + path.Name,true);
                            return true;
                        }
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            return false;
        }
        public static void Log(string context)
        {
            DateTimeOffset timeNow = DateTimeOffset.Now;
            string timeNow_type = "G";
            string TimeNow = timeNow.ToString(timeNow_type);

            string path = @".\log.txt";
            TextWriter writer = new StreamWriter(path, true);
            writer.WriteLine("-->" + TimeNow + " " + context);
            writer.Dispose();
            writer.Close();
        }
        public static void CreateText(string fullPathName,string context)
        {
            using(TextWriter writer = new StreamWriter(fullPathName, true))
            {
                writer.WriteLine(context);
            }

        }
        public async void Execute()
        {

            try
            {
                CatData.databaseCheck();

                while (device != null && device.sn != "NA")
                {

                    await Task.Delay(new TimeSpan(0, 0, new Random().Next(5, 11)));
                    CatNet.check();

                    if (!CatData.catinfoEnroll(device)) continue;
                    CatData.sync();
                    CatData.pull();

                    if (CatReg.status == CatStatus.uutStatus.STANDBY)
                    {
                        var next_task = CatData.getNexttask();
                        if (next_task != null)
                        {
                            oldlogCheck(next_task.task1);
                            if (executeTest(next_task.task1))
                            {
                                next_task.state = CatStatus.taskStatus.RUNNING.ToString();
                                next_task.start = DateTime.Now;
                                if (CatData.taskUpdate(next_task))
                                {
                                    CatReg.task_name = next_task.task1;
                                    CatReg.task_status = CatStatus.taskStatus.RUNNING.ToString();
                                    CatReg.task_id = next_task.server_id.ToString();
                                    CatReg.task_start_time = DateTime.Now.ToString();
                                    var catinfo = CatData.getCatInfo();
                                    if (catinfo != null)
                                    {
                                        catinfo.STATUS = CatStatus.taskStatus.RUNNING.ToString();
                                        catinfo.LastUsedTime = DateTime.Now;
                                        CatData.catinfoUpdate(catinfo);
                                    }

                                }
                            }
                            else
                            {
                                next_task.state = CatStatus.taskStatus.SCRIPT_ERROR.ToString();
                                next_task.start = DateTime.Now;
                                CatData.taskUpdate(next_task);
                            }
                        }
                        else { Console.WriteLine("task null"); continue; }
                    }
                    else if (CatReg.status == CatStatus.uutStatus.RUNNING)
                    {
                        var current_task = CatData.getCurrenttask();
                        if (current_task != null)
                        {
                            var summary = resultFind(current_task.task1);
                            if (summary != null)
                            {
                                current_task.finish = DateTime.Now;
                                processKill();
                                if (logSummarize(summary, ref current_task))
                                {
                                    current_task.state = CatStatus.taskStatus.DONE.ToString();
                                    CatReg.task_status = CatStatus.taskStatus.DONE.ToString();
                                    CatReg.task_name = CatStatus.taskName.NO_TASK.ToString();
                                    CatReg.task_id = "";
                                    CatReg.task_start_time = "";
                                    CatReg.task_result_folder = "";
                                    CatReg.task_path = "";
                                    CatData.taskUpdate(current_task);
                                }
                            }
                        }



                    }
                }
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }

        }
    }
}
