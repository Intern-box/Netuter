using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Netuter
{
    public partial class Glavnoe_Okno : Form
    {
        /*
         * Инициализация компонентов.
         * Выбор входных параметров по-умолчанию.
         */
        public Glavnoe_Okno()
        {
            InitializeComponent();
            Pole_Vvoda_IP.SelectedItem = "192.168.0.1";
            Pole_Vvoda_Maski.SelectedIndex = 24;
            Pole_KolVo_Podsetei.SelectedItem = "4";
        }

        /*
         * Действия после нажатия кнопки "Посчитать".
         */
        private void Poschitat_Click(object sender, EventArgs e)
        {
            // Очищаем строку с сообщениями об ошибках.

            label_Error.Text = "";

            // Пробуем создать объект "сети" по, введённым
            // пользователем, входным данным.

            Net set = new Net();

            try
            {
                set.ip = Ocifrovka_IP(Pole_Vvoda_IP.Text);

                set.maska = Ocifrovka_IP(Pole_Vvoda_Maski.Text.Substring(Pole_Vvoda_Maski.Text.IndexOf('-') + 2));

                set.Raschet();
            }
            catch (Exception)
            {
                return;
            }

            if (Proverka_Maski_I_IP(set) == false)
            {
                return;
            }

            // Вывод рассчитанных характеристик "сети" из объекта.

            label_Bit_V_Maske.Text = set.biti_v_maske.ToString();
            label_Vivoda_Seti.Text = Net.Massiv_V_Stroku(set.set);
            label_Vivoda_Broadcast.Text = Net.Massiv_V_Stroku(set.broadcast);
            label_Vivoda_Wildcard.Text = Net.Massiv_V_Stroku(set.wildcard);
            label_Vivoda_MinIP.Text = Net.Massiv_V_Stroku(set.min_ip);
            label_Vivoda_MaxIP.Text = Net.Massiv_V_Stroku(set.max_ip);
            label_Vivoda_Hostov.Text = set.hosti.ToString();

            // Если последний ip в "сети" равен адресу "сети",
            // то поле "последний ip" ретушируется.

            if (set.max_ip[0] == set.set[0])
            {
                if (set.max_ip[1] == set.set[1])
                {
                    if (set.max_ip[2] == set.set[2])
                    {
                        if (set.max_ip[3] == set.set[3])
                        {
                            label_Vivoda_MaxIP.Text = "----------------";
                        }
                    }
                }
            }

            // Если в маске 32 бита,
            // то поля "широковещательный адрес",
            // "первый ip", "последний ip" ретушируются.

            if (set.biti_v_maske == 32)
            {
                label_Vivoda_Broadcast.Text = "----------------";
                label_Vivoda_MinIP.Text = "----------------";
                label_Vivoda_MaxIP.Text = "----------------";
            }

            // Принимаем входные данные из поля "Подсети".

            uint kolvo_setei = uint.Parse(Pole_KolVo_Podsetei.Text);

            // Если кол-во хостов исходной сети меньше, чем в желаемых
            // выводим сообщение об ошибке.

            if (2 > (set.hosti + 2) / kolvo_setei)
            {
                label_Error.Text = "Количество хостов исходной сети меньше, чем в желаемых";

                return;
            }

            // Подготавливаем входные параметры для расчёта подсетей.

            set.ip[0] = set.min_ip[0];
            set.ip[1] = set.min_ip[1];
            set.ip[2] = set.min_ip[2];
            set.ip[3] = set.min_ip[3];

            for (uint i = 0; i < Math.Log(kolvo_setei, 2); i++)
            {
                Net.Pribavliaem_K_Maske_Bit(set.maska);
            }

            set.Raschet();

            // Очищаем поле для вывода подсетей.

            list_Vivod_Podsetei.Items.Clear();

            // Цикличный вывод подсетей

            for (uint i = 0, progressia = 1; i < kolvo_setei; i++)
            {
                for (uint k = 0; k < progressia; k++)
                {
                    ListViewItem lv = new ListViewItem(new string[]
                    {
                        Net.Massiv_V_Stroku(set.min_ip),
                        Net.Massiv_V_Stroku(set.max_ip),
                        Net.Massiv_V_Stroku(set.maska) + "/" + set.biti_v_maske.ToString(),
                        set.hosti.ToString(),
                        Net.Massiv_V_Stroku(set.set),
                        Net.Massiv_V_Stroku(set.broadcast)

                    });

                    // Если "последний ip" равен "адресу сети",
                    // то ретушируем поле "последний ip".

                    if (set.max_ip[0] == set.set[0])
                    {
                        if (set.max_ip[1] == set.set[1])
                        {
                            if (set.max_ip[2] == set.set[2])
                            {
                                if (set.max_ip[3] == set.set[3])
                                {
                                    lv = new ListViewItem(new string[]
                                    {
                                    Net.Massiv_V_Stroku(set.min_ip),
                                    "----------------",
                                    Net.Massiv_V_Stroku(set.maska),
                                    Net.Massiv_V_Stroku(set.set),
                                    set.hosti.ToString()
                                    });
                                }
                            }
                        }
                    }

                    // Вывод проверенных данных.

                    list_Vivod_Podsetei.Items.Add(lv);

                    // Расчёт следующих выходных параметров.

                    Net.Obnovlenie_Harakteristik_I_Raschet_Vtoroi_Podseti(set);
                }
            }

            Skopirovat.Enabled = true;
        }

        /*
         * Преобразование строки, с введённым пользователем, ip
         * в массив данных из 4 байт.
         */
        byte[] Ocifrovka_IP(string stroka_s_ip)
        {
            //Шаблон проверки введённой строки

            Regex shablon_dlia_proverki_vvedennogo_ip = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}?$");

            byte[] massiv_ip;

            // Процесс проверки

            if (shablon_dlia_proverki_vvedennogo_ip.IsMatch(stroka_s_ip))
            {
                IPAddress ip_adres;

                IPAddress.TryParse(stroka_s_ip, out ip_adres);

                if (ip_adres != null)
                {
                    // Если проверка прошла успешно,
                    // на выходе получим массив из 4 байт.

                    massiv_ip = IPAddress.Parse(stroka_s_ip).GetAddressBytes();
                }
                else
                {
                    // Если проверка прошла неудачно,
                    // на выходе увидим сообщения об ошибках...

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

        /*
         * Проверяем соответствие пары ip/маска принятым стандартам.
         * Если находим несоответствие, выводим сообщения об ошибках.
         */
        bool Proverka_Maski_I_IP(Net set)
        {
            if (set.ip[0] == 192)
            {
                if (set.ip[1] != 168)
                {
                    // Если вышли за диапазон

                    label_Error.Text = "Диапазон частной сети от 192.168.0.0 до 192.168.255.255";
                }
                else
                {
                    if (set.biti_v_maske < 16)
                    {
                        //Если не соответствует стандартам

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

        private void Skopirovat_Click(object sender, EventArgs e)
        {
            string bufer = null;

            for (int i = 0; i < list_Vivod_Podsetei.Items.Count; i++)
            {
                for (int j = 0; j < list_Vivod_Podsetei.Items[i].SubItems.Count; j++)
                {
                    bufer += list_Vivod_Podsetei.Items[i].SubItems[j].Text + "\t";
                }

                bufer += "\r\n";
            }

            Clipboard.SetText(bufer);
        }
    }
}