using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Netuter.Kalkuliator;

namespace Netuter
{
    public partial class Glavnoe_Okno : Form
    {
        public Glavnoe_Okno()
        {
            InitializeComponent();
            Pole_Vvoda_IP.SelectedItem = "192.168.0.1";
            Pole_Vvoda_Maski.SelectedIndex = 24;
            Pole_KolVo_Podsetei.SelectedItem = "4";
        }
        private void Glavnoe_Okno_Load(object sender, EventArgs e)
        {
        }
        private void Poschitat_Click(object sender, EventArgs e)
        {
            label_Error.Text = "";

            Set set;

            try
            {
                set = Obiect_set(Pole_Vvoda_IP.Text, Pole_Vvoda_Maski.Text.Substring(Pole_Vvoda_Maski.Text.IndexOf('-') + 2));
            }
            catch (Exception)
            {
                return;
            }

            if (Proverka_Maski_I_IP(set) == false)
            {
                return;
            }

            label_Bit_V_Maske.Text = set.biti_v_maske.ToString();
            label_Vivoda_Seti.Text = $"{set.set[0]}.{set.set[1]}.{set.set[2]}.{set.set[3]}";
            label_Vivoda_Broadcast.Text = $"{set.broadcast[0]}.{set.broadcast[1]}.{set.broadcast[2]}.{set.broadcast[3]}";
            label_Vivoda_Wildcard.Text = $"{set.wildcard[0]}.{set.wildcard[1]}.{set.wildcard[2]}.{set.wildcard[3]}";
            label_Vivoda_MinIP.Text = $"{set.minip[0]}.{set.minip[1]}.{set.minip[2]}.{set.minip[3]}";
            label_Vivoda_MaxIP.Text = $"{set.maxip[0]}.{set.maxip[1]}.{set.maxip[2]}.{set.maxip[3]}";

            if (set.maxip[0] == set.set[0])
            {
                if (set.maxip[1] == set.set[1])
                {
                    if (set.maxip[2] == set.set[2])
                    {
                        if (set.maxip[3] == set.set[3])
                        {
                            label_Vivoda_MaxIP.Text = "----------------";
                        }
                    }
                }
            }

            if (set.biti_v_maske == 32)
            {
                label_Vivoda_Broadcast.Text = "----------------";
                label_Vivoda_MinIP.Text = "----------------";
                label_Vivoda_MaxIP.Text = "----------------";
            }

            label_Vivoda_Hostov.Text = set.hosti.ToString();

            uint kolvo_setei = uint.Parse(Pole_KolVo_Podsetei.Text);

            ulong shag = (set.hosti + 2) / (kolvo_setei);

            if (2 > shag)
            {
                label_Error.Text = "Количество хостов исходной сети меньше, чем в желаемых";

                return;
            }

            for (int i = 0; i < Math.Log(kolvo_setei, 2); i++)
            {
                set.maska = Pribavliaem_Bit_K_Maske(set.maska);
            }

            set = Kalkuliator.Obiect_set(set.minip, set.maska);

            list_Vivod_Podsetei.Items.Clear();

            for (int i = 0; i < kolvo_setei; i++)
            {
                ListViewItem lv = new ListViewItem(new string[] {
                    $"{set.minip[0]}.{set.minip[1]}.{set.minip[2]}.{set.minip[3]}",
                    $"{set.maxip[0]}.{set.maxip[1]}.{set.maxip[2]}.{set.maxip[3]}",
                    $"{set.maska[0]}.{set.maska[1]}.{set.maska[2]}.{set.maska[3]}",
                    $"{set.set[0]}.{set.set[1]}.{set.set[2]}.{set.set[3]}",
                    set.hosti.ToString() });

                if (set.maxip[0] == set.set[0])
                {
                    if (set.maxip[1] == set.set[1])
                    {
                        if (set.maxip[2] == set.set[2])
                        {
                            if (set.maxip[3] == set.set[3])
                            {
                                lv = new ListViewItem(new string[] {
                                $"{set.minip[0]}.{set.minip[1]}.{set.minip[2]}.{set.minip[3]}",
                                "----------------",
                                $"{set.maska[0]}.{set.maska[1]}.{set.maska[2]}.{set.maska[3]}",
                                $"{set.set[0]}.{set.set[1]}.{set.set[2]}.{set.set[3]}",
                                set.hosti.ToString() });
                            }
                        }
                    }
                }

                list_Vivod_Podsetei.Items.Add(lv);

                set = Kalkuliator.Obiect_set(Pribavliaem_Biti_K_IP(set.ip, shag), set.maska);
            }
        }
        public byte[] Ocifrovka_IP(string stroka_s_ip)
        {
            Regex shablon_dlia_proverki_vvedennogo_ip = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}?$");

            byte[] massiv_ip;

            if (shablon_dlia_proverki_vvedennogo_ip.IsMatch(stroka_s_ip))
            {
                IPAddress ip_adres;

                IPAddress.TryParse(stroka_s_ip, out ip_adres);

                if (ip_adres != null)
                {
                    massiv_ip = IPAddress.Parse(stroka_s_ip).GetAddressBytes();
                }
                else
                {
                    label_Error.Text = "Введён не верный IP";

                    return null;
                }
            }
            else
            {
                label_Error.Text = "Введён не верный IP";

                return null;
            }

            return massiv_ip;
        }
        Set Obiect_set(string ip, string maska)
        {
            Set set;

            set.ip = Ocifrovka_IP(ip);
            set.maska = Ocifrovka_IP(maska);
            set.wildcard = Wildcard(set.maska);
            set.biti_v_maske = Biti_V_Maske(set.maska);
            set.hosti = Hosti(set.biti_v_maske);
            set.set = Set(set.ip, set.maska);
            set.minip = MinIP(set.set);
            set.broadcast = Broadcast(set.set, set.wildcard);
            set.maxip = MaxIP(set.broadcast);

            return set;
        }
        bool Proverka_Maski_I_IP(Set set)
        {
            if (set.ip[0] == 192)
            {
                if (set.ip[1] != 168)
                {
                    label_Error.Text = "Диапазон частной сети от 192.168.0.0 до 192.168.255.255";
                }
                else
                {
                    if (set.biti_v_maske < 16)
                    {
                        label_Error.Text = "Для сети 192.168.0.0 минимальная маска 255.255.0.0";

                        return false;
                    }
                }
            }

            if (set.ip[0] == 172)
            {
                if (set.ip[1] < 16 || set.ip[1] > 31)
                {
                    label_Error.Text = "Диапазон частной сети от 172.16.0.0 до 172.31.255.255";
                }
                else
                {
                    if (set.biti_v_maske < 12)
                    {
                        label_Error.Text = "Для сети 172.16.0.0 минимальная маска 255.240.0.0";

                        return false;
                    }
                }
            }

            if (set.ip[0] == 10)
            {
                if (set.biti_v_maske < 8)
                {
                    label_Error.Text = "Для сети 10.0.0.0 минимальная маска 255.0.0.0";
                }
            }

            return true;
        }
        private void button_Okno_Dlia_Graficheskogo_Delenia_Na_Podseti_Click(object sender, EventArgs e)
        {
            Set set = Obiect_set(Pole_Vvoda_IP.Text, Pole_Vvoda_Maski.Text.Substring(Pole_Vvoda_Maski.Text.IndexOf('-') + 2));

            Okno_Drevovidnoe_Delenie derevo_setei = new Okno_Drevovidnoe_Delenie(set);

            derevo_setei.ShowDialog();
        }
    }
}