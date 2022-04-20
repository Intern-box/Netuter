using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Netuter
{
    public partial class Glavnoe_Okno : Form
    {
        struct Net
        {
            public byte[] ip;
            public byte[] maska;
            public byte[] wildcard;
            public byte biti_v_maske;
            public ulong hosti;
            public byte[] set;
            public byte[] minip;
            public byte[] broadcast;
            public byte[] maxip;
        }
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

            Net set;

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

            set = Obiect_set(set.minip, set.maska);

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

                set = Obiect_set(Pribavliaem_Biti_K_IP(set.ip, shag), set.maska);
            }
        }
        byte[] Ocifrovka_IP(string stroka_s_ip)
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
        static byte[] Wildcard(byte[] maska)
        {
            byte[] wildcard = { 0, 0, 0, 0 };

            wildcard[0] = (byte)(~maska[0]);
            wildcard[1] = (byte)(~maska[1]);
            wildcard[2] = (byte)(~maska[2]);
            wildcard[3] = (byte)(~maska[3]);

            return wildcard;
        }
        static byte Biti_V_Maske(byte[] maska)
        {
            byte biti_v_maske = 0;

            for (int i = 0; i < 4; i++)
            {
                switch (maska[i])
                {
                    case 255: biti_v_maske += 8; break;
                    case 254: biti_v_maske += 7; break;
                    case 252: biti_v_maske += 6; break;
                    case 248: biti_v_maske += 5; break;
                    case 240: biti_v_maske += 4; break;
                    case 224: biti_v_maske += 3; break;
                    case 192: biti_v_maske += 2; break;
                    case 128: biti_v_maske += 1; break;
                    default: break;
                }
            }

            return biti_v_maske;
        }
        static ulong Hosti(byte biti_v_maske)
        {
            ulong hosti = 1;

            if (biti_v_maske == 32)
            {
                return hosti = 0;
            }

            for (int i = 0; i < 32 - biti_v_maske; i++)
            {
                hosti <<= 1;
            }

            hosti -= 2;

            return hosti;
        }
        static byte[] Set(byte[] ip, byte[] maska)
        {
            byte[] set = { 0, 0, 0, 0 };

            set[0] = (byte)(ip[0] & maska[0]);
            set[1] = (byte)(ip[1] & maska[1]);
            set[2] = (byte)(ip[2] & maska[2]);
            set[3] = (byte)(ip[3] & maska[3]);

            return set;
        }
        static byte[] MinIP(byte[] set)
        {
            byte[] minip = { 0, 0, 0, 0 };

            minip[0] = set[0];
            minip[1] = set[1];
            minip[2] = set[2];
            minip[3] = set[3];

            minip[3]++;

            return minip;
        }
        static byte[] Broadcast(byte[] set, byte[] wildcard)
        {
            byte[] broadcast = { 0, 0, 0, 0 };

            broadcast[0] = (byte)(set[0] + wildcard[0]);
            broadcast[1] = (byte)(set[1] + wildcard[1]);
            broadcast[2] = (byte)(set[2] + wildcard[2]);
            broadcast[3] = (byte)(set[3] + wildcard[3]);

            return broadcast;
        }
        static byte[] MaxIP(byte[] broadcast)
        {
            byte[] maxip = { 0, 0, 0, 0 };

            maxip[0] = broadcast[0];
            maxip[1] = broadcast[1];
            maxip[2] = broadcast[2];
            maxip[3] = broadcast[3];

            maxip[3]--;

            return maxip;
        }
        Net Obiect_set(string ip, string maska)
        {
            Net set;

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
        static Net Obiect_set(byte[] ip, byte[] maska)
        {
            Net set;

            set.ip = ip;
            set.maska = maska;
            set.wildcard = Wildcard(set.maska);
            set.biti_v_maske = Biti_V_Maske(set.maska);
            set.hosti = Hosti(set.biti_v_maske);
            set.set = Set(set.ip, set.maska);
            set.minip = MinIP(set.set);
            set.broadcast = Broadcast(set.set, set.wildcard);
            set.maxip = MaxIP(set.broadcast);

            return set;
        }
        bool Proverka_Maski_I_IP(Net set)
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
        static byte[] Pribavliaem_Bit_K_Maske(byte[] maska)
        {
            byte[] novaia_maska = { 0, 0, 0, 0 };

            novaia_maska[0] = maska[0];
            novaia_maska[1] = maska[1];
            novaia_maska[2] = maska[2];
            novaia_maska[3] = maska[3];

            for (int i = 0; i < 4; i++)
            {
                switch (novaia_maska[i])
                {
                    case 0: novaia_maska[i] = 128; return novaia_maska;
                    case 128: novaia_maska[i] = 192; return novaia_maska;
                    case 192: novaia_maska[i] = 224; return novaia_maska;
                    case 224: novaia_maska[i] = 240; return novaia_maska;
                    case 240: novaia_maska[i] = 248; return novaia_maska;
                    case 248: novaia_maska[i] = 252; return novaia_maska;
                    case 252: novaia_maska[i] = 254; return novaia_maska;
                    case 254: novaia_maska[i] = 255; return novaia_maska;
                    default: break;
                }
            }

            return novaia_maska;
        }
        static byte[] Pribavliaem_Biti_K_IP(byte[] ip, ulong kolichestvo_bit)
        {
            byte[] novii_ip = { 0, 0, 0, 0 };

            novii_ip[0] = ip[0];
            novii_ip[1] = ip[1];
            novii_ip[2] = ip[2];
            novii_ip[3] = ip[3];

            for (ulong i = 0; i < kolichestvo_bit; i++)
            {
                if (novii_ip[3] == 255)
                {
                    if (novii_ip[2] == 255)
                    {
                        if (novii_ip[1] == 255)
                        {
                            novii_ip[3] = 0;
                            novii_ip[2] = 0;
                            novii_ip[1] = 0;
                            novii_ip[0]++;
                        }
                        else
                        {
                            novii_ip[3] = 0;
                            novii_ip[2] = 0;
                            novii_ip[1]++;
                        }
                    }
                    else
                    {
                        novii_ip[3] = 0;
                        novii_ip[2]++;
                    }
                }
                else
                {
                    novii_ip[3]++;
                }
            }

            return novii_ip;
        }
    }
}