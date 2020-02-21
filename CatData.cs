using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_Client
{
    class CatData
    {

        public static void enroll(deviceJson device)
        {
            
        }

        public static void fetch()
        {

        }

        public static void merge()
        {

        }

        public static bool pull()
        {
            var local_tasks = getlocaltasks();
            var server_tasks = getservertasks();

            var server_tasks_id = server_tasks.Where(x => x.local_id == null).Select(x => x.ID);
            var local_tasks_id = local_tasks.Where(x => x.server_id != null).Select(x => (int)x.server_id);
            Console.WriteLine();
            Console.Write("server_tasks_id :");
            Console.Write("[");
            foreach (var v in server_tasks_id)
            {
                Console.Write($" {v} ");
            }
            Console.Write("]");
            Console.WriteLine();
            Console.Write("local_tasks_id :");
            Console.Write("[");
            foreach (var v in local_tasks_id)
            {
                Console.Write($" {v} ");
            }
            Console.Write("]");
            Console.WriteLine();
            var compare_tasks_id = server_tasks_id.Except(local_tasks_id);
            Console.Write("compare_tasks_id :");
            Console.Write("[");
            foreach (var v in compare_tasks_id)
            {
                Console.Write($" {v} ");
            }
            Console.Write("]");
            var compare_task = from task in server_tasks where compare_tasks_id.Contains(task.ID) select task;
            Console.WriteLine();
            Console.Write("compare_task :");
            Console.Write("[");
            foreach (var v in compare_task)
            {
                Console.Write($" {v.ID} ");
            }
            Console.Write("]");
            Console.WriteLine($"Add task number {compare_task.Count()}");
            if (compare_task.Count()>0)
            {
                int check_sum = 0;
                foreach (var task in compare_task)
                {
                    if (localtaskAdd(task)) check_sum++;
                }
                if (check_sum == compare_task.Count()) return true;
            }
            return false;

        }

        public static void push()
        {

        }
        public static bool sync()
        {
            try
            {
                var local_tasks = getlocaltasks();
                foreach (var task in local_tasks)
                {
                    if (task.is_update == false.ToString())
                    {
                        taskUpdate(task);
                    }
                }
                return true;
            }

            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        class cattask
        {
            public cattask(cat_local.task local, cat_server.taskTable server)
            {

            }
            public int server_id { get; set; }
            public int local_id { get; set; }
            public string SN { get; set; }
            public string task { get; set; }
            public string state { get; set; }
            public string result { get; set; }
            public string result_loc { get; set; }
            public string result_ids { get; set; }
            public Nullable<int> series { get; set; }
            public Nullable<System.DateTime> start { get; set; }
            public Nullable<System.DateTime> finish { get; set; }
        }

        public static bool databaseCheck()
        {
            try
            {
                using (cat_local.lab_local lab_local = new cat_local.lab_local())
                {
                    if (lab_local.Database.CreateIfNotExists())
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        FileInfo file = new FileInfo(config.AppSettings.Settings["catdata"].Value);
                        if (file.Exists)
                        {
                            if (lab_local.Database.ExecuteSqlCommand(file.OpenText().ReadToEnd()) > 0) return true;
                        }
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var getFullMessage = string.Join("; ", entityError);
                var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);
                //NLog
                Console.WriteLine(exceptionMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        public static List<cat_local.task> getlocaltasks()
        {
            var tasks = new List<cat_local.task>();
            using (cat_local.lab_local lab_local = new cat_local.lab_local())
            {
                try
                {
                    if (lab_local.Database.Exists())
                    {
                        tasks = (from task in lab_local.task select task).ToList();
                    }

                }
                catch (DbEntityValidationException ex)
                {
                    var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                    var getFullMessage = string.Join("; ", entityError);
                    var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);
                    //NLog
                    Console.WriteLine(exceptionMessage);
                }
                return tasks;
            }

        }
        public static List<cat_server.taskTable> getservertasks()
        {
            var tasks = new List<cat_server.taskTable>();
            using (cat_server.lab_server lab_server = new cat_server.lab_server())
            {
                try
                {
                    if (lab_server.Database.Exists())
                    {
                        tasks = (from task in lab_server.taskTable where task.SN == CatCore.device.sn select task).ToList();
                    }

                }
                catch (DbEntityValidationException ex)
                {
                    var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                    var getFullMessage = string.Join("; ", entityError);
                    var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);
                    //NLog
                    Console.WriteLine(exceptionMessage);
                }
                return tasks;
            }
        }
        public static cat_local.task getNexttask()
        {
            var task = getlocaltasks();
            if (task.Count()>0)
            {
                return (from _task in task where _task.state.Contains(CatStatus.taskStatus.PENDING.ToString()) select _task).FirstOrDefault();
            }
            return null;
        }
        public static cat_local.task getCurrenttask()
        {
            var task = getlocaltasks();
            if (task.Count() > 0)
            {
                return (from _task in task where _task.state.Contains(CatStatus.taskStatus.RUNNING.ToString()) select _task).FirstOrDefault();
            }
            return null;
        }
        public static cat_server.CAT_info getCatInfo()
        {

            using(cat_server.lab_server lab_server = new cat_server.lab_server())
            {
                if (lab_server.Database.Exists())
                {
                    return (from uut in lab_server.CAT_info where uut.SN == CatCore.device.sn select uut).FirstOrDefault();
                }
            }
            return null;

        }

        public static bool localtaskAdd(cat_local.task task)
        {
            using (cat_local.lab_local lab_local = new cat_local.lab_local())
            {
                if (lab_local.Database.Exists())
                {
                    task = lab_local.task.Add(task);
                    if (lab_local.SaveChanges() > 0)
                    {
                        if (CatNet.ServerConnection)
                        {
                            using (cat_server.lab_server lab_server = new cat_server.lab_server())
                            {
                                if (lab_server.Database.Exists())
                                {
                                    cat_server.taskTable server_task = new cat_server.taskTable();
                                    server_task.local_id = task.local_id;
                                    server_task.SN = CatCore.device.sn;
                                    server_task.state = task.state;
                                    server_task.task = task.task1;
                                    server_task.result_id = task.result_ids;
                                    server_task.startTime = task.start;
                                    server_task.finishTime = task.finish;
                                    server_task.series = task.series;
                                    server_task = lab_server.taskTable.Add(server_task);
                                    if (lab_server.SaveChanges() > 0)
                                    {
                                        task.server_id = server_task.ID;
                                        task.is_update = false.ToString();
                                        try
                                        {
                                            lab_local.SaveChanges();
                                            return true;
                                        }
                                        catch (DbEntityValidationException ex)
                                        {
                                            var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                                            var getFullMessage = string.Join("; ", entityError);
                                            var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);
                                            //NLog
                                            Console.WriteLine(exceptionMessage);
                                        }
                                        catch (Exception e)
                                        {
                                            
                                            Console.WriteLine(e.ToString());
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        return true;
                    }
                }
            }

            return false;
            
        }
        public static bool localtaskAdd(cat_server.taskTable task)
        {
            try
            {
                cat_local.task local_task = new cat_local.task();
                using (cat_local.lab_local lab_local = new cat_local.lab_local())
                {
                    if (lab_local.Database.Exists())
                    {
                        local_task.server_id = task.ID;
                        local_task.task1 = task.task;
                        local_task.state = task.state;
                        local_task.start = task.startTime;
                        local_task.finish = task.finishTime;
                        local_task.series = task.series;
                        local_task.result_ids = task.result_id;
                        local_task.is_update = false.ToString();
                        local_task = lab_local.task.Add(local_task);
                        if (lab_local.SaveChanges() > 0) 
                        {
                            using (cat_server.lab_server lab_server = new cat_server.lab_server())
                            {
                                lab_server.Entry(task).State = System.Data.Entity.EntityState.Modified;
                                task.local_id = local_task.local_id;
                                int ret = lab_server.SaveChanges();
                                var v = (from _v in lab_server.taskTable where _v.ID == task.ID select _v).FirstOrDefault();
                                if (v == task) return true;
                            }

                        }

                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var getFullMessage = string.Join("; ", entityError);
                var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);
                //NLog
                Console.WriteLine(exceptionMessage);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                return false;
            }
            return false;
        }
        public static bool taskUpdate(cat_local.task task)
        {

            try
            {
                using (cat_local.lab_local lab_local = new cat_local.lab_local())
                {
                    if (lab_local.Database.Exists())
                    {
                        using (cat_server.lab_server lab_server = new cat_server.lab_server())
                        {
                            if (CatNet.ServerConnection)
                            {
                                var server_task = (from __task in lab_server.taskTable where task.local_id == __task.local_id select __task).FirstOrDefault();
                                lab_server.Entry(server_task).State = System.Data.Entity.EntityState.Modified;
                                server_task.state = task.state;
                                server_task.startTime = task.start;
                                server_task.finishTime = task.finish;
                                server_task.result_id = task.result_ids;
                                if (task.state == CatStatus.taskStatus.DONE.ToString()) task.is_update = true.ToString();
                                lab_server.SaveChanges();
                            }
                        }
                        lab_local.Entry(task).State = System.Data.Entity.EntityState.Modified;
                        lab_local.SaveChanges();
                        if (task == (from v in lab_local.task where v.local_id == task.local_id select v).FirstOrDefault()) return true;
                    }
                }

            }
            catch (DbEntityValidationException ex)
            {
                var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var getFullMessage = string.Join("; ", entityError);
                var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);
                //NLog
                Console.WriteLine(exceptionMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        public static bool catinfoUpdate(cat_server.CAT_info catinfo)
        {
            try
            {
                using(cat_server.lab_server lab_server = new cat_server.lab_server())
                {
                    if (CatNet.ServerConnection)
                    {
                        var uut = (from _uut in lab_server.CAT_info where _uut.SN == catinfo.SN select _uut).FirstOrDefault();
                        if (uut == null) throw new Exception("UUT NOT FOUND");
                        currentinfoCompare(ref uut, catinfo);
                        lab_server.Entry(uut).State = System.Data.Entity.EntityState.Modified;
                        lab_server.SaveChanges();
                        return true;
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var getFullMessage = string.Join("; ", entityError);
                var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);
                //NLog
                Console.WriteLine(exceptionMessage);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            return false;
        }
        private static void currentinfoCompare(ref cat_server.CAT_info refreshinfo, cat_server.CAT_info currentinfo)
        {
            if (refreshinfo.BIOS != currentinfo.BIOS) refreshinfo.BIOS = currentinfo.BIOS;
            if (refreshinfo.BT_Driver != currentinfo.BT_Driver) refreshinfo.BT_Driver = currentinfo.BT_Driver;
            if (refreshinfo.BT_Module != currentinfo.BT_Module) refreshinfo.BT_Module = currentinfo.BT_Module;
            if (refreshinfo.GNSS_Driver != currentinfo.GNSS_Driver) refreshinfo.GNSS_Driver = currentinfo.GNSS_Driver;
            if (refreshinfo.GNSS_Module != currentinfo.GNSS_Module) refreshinfo.GNSS_Module = currentinfo.GNSS_Module;
            if (refreshinfo.Image != currentinfo.Image) refreshinfo.Image = currentinfo.Image;
            if (refreshinfo.NFC_Driver != currentinfo.NFC_Driver) refreshinfo.NFC_Driver = currentinfo.NFC_Driver;
            if (refreshinfo.NFC_Module != currentinfo.NFC_Module) refreshinfo.NFC_Module = currentinfo.NFC_Module;
            if (refreshinfo.NIC_Driver != currentinfo.NIC_Driver) refreshinfo.NIC_Driver = currentinfo.NIC_Driver;
            if (refreshinfo.NIC_Module != currentinfo.NIC_Module) refreshinfo.NIC_Module = currentinfo.NIC_Module;
            if (refreshinfo.OS != currentinfo.OS) refreshinfo.OS = currentinfo.OS;
            if (refreshinfo.Platform != currentinfo.Platform) refreshinfo.Platform = currentinfo.Platform;
            if (refreshinfo.RFID_Driver != currentinfo.RFID_Driver) refreshinfo.RFID_Driver = currentinfo.RFID_Driver;
            if (refreshinfo.RFID_Module != currentinfo.RFID_Module) refreshinfo.RFID_Module = currentinfo.RFID_Module;
            if (refreshinfo.WLAN_Driver != currentinfo.WLAN_Driver) refreshinfo.WLAN_Driver = currentinfo.WLAN_Driver;
            if (refreshinfo.WLAN_Module != currentinfo.WLAN_Module) refreshinfo.WLAN_Module = currentinfo.WLAN_Module;
            if (refreshinfo.WWAN_Driver != currentinfo.WWAN_Driver) refreshinfo.WWAN_Driver = currentinfo.WWAN_Driver;
            if (refreshinfo.WWAN_Firmware != currentinfo.WWAN_Firmware) refreshinfo.WWAN_Firmware = currentinfo.WWAN_Firmware;
            if (refreshinfo.WWAN_Modem != currentinfo.WWAN_Modem) refreshinfo.WWAN_Modem = currentinfo.WWAN_Modem;
            if (refreshinfo.WWAN_Module != currentinfo.WWAN_Module) refreshinfo.WWAN_Module = currentinfo.WWAN_Module;
            if (refreshinfo.LastUsedTime != currentinfo.LastUsedTime) refreshinfo.LastUsedTime = currentinfo.LastUsedTime;
            if (refreshinfo.CurrentTask != currentinfo.CurrentTask) refreshinfo.CurrentTask = currentinfo.CurrentTask;
            if (refreshinfo.STATUS != currentinfo.STATUS) refreshinfo.STATUS = currentinfo.STATUS;
            if (refreshinfo.Tag != currentinfo.Tag) refreshinfo.Tag = currentinfo.Tag;
        }
        private static void deviceRefresh(ref cat_server.CAT_info currentinfo, deviceJson device)
        {
            currentinfo.SN = device.sn;
            currentinfo.BIOS = device.bios;
            currentinfo.OS = device.os;
            currentinfo.Image = device.image;
            currentinfo.Platform = device.platform;
            currentinfo.WWAN_Driver = device.wwan[0].driver;
            currentinfo.WWAN_Firmware = device.wwan[0].firmware;
            currentinfo.WWAN_Modem = device.wwan[0].modem;
            currentinfo.WWAN_Module = device.wwan[0].hwid;
            currentinfo.WLAN_Driver = device.wlan[0].driver;
            currentinfo.WLAN_Module = device.wlan[0].hwid;
            currentinfo.NIC_Driver = device.lan[0].driver;
            currentinfo.NIC_Module = device.lan[0].hwid;
            currentinfo.BT_Driver = device.bt[0].driver;
            currentinfo.BT_Module = device.bt[0].hwid;
            currentinfo.NFC_Driver = device.nfc[0].driver;
            currentinfo.NFC_Module = device.nfc[0].hwid;
            currentinfo.RFID_Driver = device.rfid[0].driver;
            currentinfo.RFID_Module = device.rfid[0].hwid;
            currentinfo.GNSS_Driver = device.wwan[0].gnss;
        }
        public static bool catinfoEnroll(deviceJson device)
        {
            try
            {
                cat_server.CAT_info currentinfo = new cat_server.CAT_info();
                deviceRefresh(ref currentinfo, device);
                using (cat_server.lab_server lab_server = new cat_server.lab_server())
                {
                    if (CatNet.ServerConnection)
                    {
                        var serverinfo = (from _uut in lab_server.CAT_info where _uut.SN == device.sn select _uut).FirstOrDefault();
                        if(serverinfo == null)
                        {
                            lab_server.Entry(currentinfo).State = System.Data.Entity.EntityState.Added;
                            currentinfo.STATUS = CatStatus.uutStatus.STANDBY.ToString();
                            currentinfo.CurrentTask = CatStatus.taskName.NO_TASK.ToString();
                            currentinfo.LastUsedTime = DateTime.Now;
                            lab_server.CAT_info.Add(currentinfo);
                        }
                        else
                        {
                            lab_server.Entry(serverinfo).State = System.Data.Entity.EntityState.Modified;
                            currentinfo.STATUS = CatReg.status.ToString();
                            currentinfo.CurrentTask = CatReg.task_name;
                            currentinfo.LastUsedTime = DateTime.Now;
                            currentinfoCompare(ref serverinfo, currentinfo);
                        }
                    }
                    lab_server.SaveChanges();
                }
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var getFullMessage = string.Join("; ", entityError);
                var exceptionMessage = string.Concat(ex.Message, "errors are: ", getFullMessage);
                //NLog
                Console.WriteLine(exceptionMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

    }
}
