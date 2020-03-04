using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cat_Client
{
    public partial class infoControl : UserControl
    {

        public infoControl()
        {
            InitializeComponent();
        }

        private void infoFillin()
        {
            deviceJson device = CatCore.device;
            if (device != null)
            {
                lb_bios.Text = device.bios;
                lb_image.Text = device.image;
                lb_platform.Text = device.platform;
                lb_os.Text = device.os;
                if (device.wwan.Count() > 0)
                {
                    cb_wwan.Items.Clear();
                    cb_wwan.Items.AddRange(device.wwan.Select(x => x.name).ToArray());
                    cb_wwan.SelectedIndex = 0;
                    wwanfill(cb_wwan.SelectedIndex, device);
                }
                if (device.lan.Count() > 0)
                {
                    cb_lan.Items.Clear();
                    cb_lan.Items.AddRange(device.lan.Select(x => x.name).ToArray());
                    cb_lan.SelectedIndex = 0;
                    lanfill(cb_lan.SelectedIndex, device);
                }
                if (device.wlan.Count() > 0)
                {
                    cb_wlan.Items.Clear();
                    cb_wlan.Items.AddRange(device.wlan.Select(x => x.name).ToArray());
                    cb_wlan.SelectedIndex = 0;
                    wlanfill(cb_wlan.SelectedIndex, device);
                }
                if (device.bt.Count() > 0)
                {
                    cb_bt.Items.Clear();
                    cb_bt.Items.AddRange(device.bt.Select(x => x.name).ToArray());
                    cb_bt.SelectedIndex = 0;
                    btfill(cb_bt.SelectedIndex, device);
                }
                if (device.nfc.Count() > 0 && device.nfc.Select(x => x.name != "NA").FirstOrDefault())
                {
                    cb_proxi.Items.Clear();
                    cb_proxi.Items.AddRange(device.nfc.Select(x => x.name).ToArray());
                    cb_proxi.SelectedIndex = 0;
                    nfcfill(cb_proxi.SelectedIndex, device);
                }
                if (device.rfid.Count() > 0 && device.rfid.Select(x => x.name != "NA").FirstOrDefault())
                {
                    cb_proxi.Items.Clear();
                    cb_proxi.Items.AddRange(device.rfid.Select(x => x.name).ToArray());
                    cb_proxi.SelectedIndex = 0;
                    rfidfill(cb_proxi.SelectedIndex, device);
                }
            }
        }

        private void wwanfill(int index,deviceJson device)
        {
            lb_wwan_hwid.Text = device.wwan[index].hwid;
            lb_wwan_driver.Text = device.wwan[index].driver;
            lb_wwan_modem.Text = device.wwan[index].modem;
            lb_wwan_firmware.Text = device.wwan[index].firmware;
            lb_wwan_gnss.Text = device.wwan[index].gnss;
            lb_wwan_ude.Text = device.wwan[index].ude;
        }

        private void wlanfill(int index, deviceJson device)
        {
            lb_wlan_hwid.Text = device.wlan[index].hwid;
            lb_wlan_driver.Text = device.wlan[index].driver;
        }
        private void lanfill(int index, deviceJson device)
        {
            lb_lan_hwid.Text = device.lan[index].hwid;
            lb_lan_driver.Text = device.lan[index].driver;
        }
        private void btfill(int index, deviceJson device)
        {
            lb_bt_hwid.Text = device.bt[index].hwid;
            lb_bt_driver.Text = device.bt[index].driver;
        }
        private void nfcfill(int index, deviceJson device)
        {
            lb_proxi_hwid.Text = device.nfc[index].hwid;
            lb_proxi_driver.Text = device.nfc[index].driver;
        }
        private void rfidfill(int index, deviceJson device)
        {
            lb_proxi_hwid.Text = device.rfid[index].hwid;
            lb_proxi_driver.Text = device.rfid[index].driver;
        }

        private void cb_wwan_SelectedIndexChanged(object sender, EventArgs e)
        {
            wwanfill(cb_wwan.SelectedIndex, CatCore.device);
        }

        private void cb_wlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            wlanfill(cb_wlan.SelectedIndex, CatCore.device);
        }

        private void cb_lan_SelectedIndexChanged(object sender, EventArgs e)
        {
            lanfill(cb_lan.SelectedIndex, CatCore.device);
        }

        private void cb_bt_SelectedIndexChanged(object sender, EventArgs e)
        {
            btfill(cb_bt.SelectedIndex, CatCore.device);
        }

        private void cb_proxi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CatCore.device.nfc.Count()>0 && CatCore.device.nfc.Select(x=>x.name!="NA").FirstOrDefault()) nfcfill(cb_proxi.SelectedIndex, CatCore.device);
            if (CatCore.device.rfid.Count()>0 && CatCore.device.rfid.Select(x => x.name != "NA").FirstOrDefault()) rfidfill(cb_proxi.SelectedIndex, CatCore.device);
        }

        public void infoControlInit()
        {
            infoFillin();
        }
    }
}
