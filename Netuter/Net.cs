namespace Netuter
{
    /*
     * Шаблон для создания объекта "сети", включающего
     * в себя все характеристики данной "сети".
     */
    public class Net
    {
        /*
         * Пустой конструктор
         */
        public Net()
        {
        }

        /*
         * Конструктор с автоподсчётом хар-к сети
         */
        public Net(byte[] ip, byte[] maska)
        {
            this.ip = ip;

            this.maska = maska;

            Raschet();
        }

        /*
         * Те самые характеристики "сети", сверху-вниз:
         * исходный ip,
         * исходная маска,
         * кол-во бит в маске,
         * кол-во хостов в "сети",
         * обратная маска,
         * адрес сети,
         * широковещательный адрес,
         * первый ip,
         * последний ip.
         */
        public byte[] ip = new byte[4];
        public byte[] maska = new byte[4];
        public byte biti_v_maske = 0;
        public ulong hosti = 0;
        public byte[] wildcard = new byte[4];
        public byte[] set = new byte[4];
        public byte[] broadcast = new byte[4];
        public byte[] min_ip = new byte[4];
        public byte[] max_ip = new byte[4];

        /*
         * Метод корректирующий хар-ки объекта "сети"
         * для подсчёта второй подсети.
         */
        public static void Obnovlenie_Harakteristik_I_Raschet_Vtoroi_Podseti(Net set)
        {
            if (set.broadcast[3] == 255)
            {
                if (set.broadcast[2] == 255)
                {
                    set.broadcast[3] = set.broadcast[2] = 0;

                    set.broadcast[1]++;
                }

                set.broadcast[3] = 0;

                set.broadcast[2]++;
            }
            else
            {
                set.broadcast[3]++;
            }

            set.ip[0] = set.broadcast[0];
            set.ip[1] = set.broadcast[1];
            set.ip[2] = set.broadcast[2];
            set.ip[3] = set.broadcast[3];

            set.Raschet();
        }

        /*
         * Метод расчёта характеристик "сети".
         */
        public void Raschet()
        {
            biti_v_maske = Biti_V_Maske(maska);
            hosti = Hosti(biti_v_maske);
            wildcard = Wildcard(maska);
            set = Set(ip, maska);
            broadcast = Broadcast(set, wildcard);
            min_ip = MinIP(set);
            max_ip = MaxIP(broadcast);
        }

        /*
         * Метод расчёта кол-ва бит в маске.
         */
        byte Biti_V_Maske(byte[] maska)
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

        /*
         * Метод расчёта кол-ва хостов в "сети".
         */
        ulong Hosti(byte biti_v_maske)
        {
            ulong hosti = 1;

            if (biti_v_maske == 32)
            {
                return 0;
            }

            for (int i = 0; i < 32 - biti_v_maske; i++)
            {
                hosti <<= 1;
            }

            hosti -= 2;

            return hosti;
        }

        /*
         * Метод расчёта обратной маски.
         */
        byte[] Wildcard(byte[] maska)
        {
            byte[] wildcard = new byte[4];

            wildcard[0] = (byte)(~maska[0]);
            wildcard[1] = (byte)(~maska[1]);
            wildcard[2] = (byte)(~maska[2]);
            wildcard[3] = (byte)(~maska[3]);

            return wildcard;
        }

        /*
         * Метод расчёта адреса сети.
         */
        public static byte[] Set(byte[] ip, byte[] maska)
        {
            byte[] set = new byte[4];

            set[0] = (byte)(ip[0] & maska[0]);
            set[1] = (byte)(ip[1] & maska[1]);
            set[2] = (byte)(ip[2] & maska[2]);
            set[3] = (byte)(ip[3] & maska[3]);

            return set;
        }

        /*
         * Метод расчёта широковещательного адреса.
         */
        byte[] Broadcast(byte[] set, byte[] wildcard)
        {
            byte[] broadcast = new byte[4];

            broadcast[0] = (byte)(set[0] + wildcard[0]);
            broadcast[1] = (byte)(set[1] + wildcard[1]);
            broadcast[2] = (byte)(set[2] + wildcard[2]);
            broadcast[3] = (byte)(set[3] + wildcard[3]);

            return broadcast;
        }

        /*
         * Метод расчёта первого ip.
         */
        byte[] MinIP(byte[] set)
        {
            byte[] min_ip = new byte[4];

            min_ip[0] = set[0];
            min_ip[1] = set[1];
            min_ip[2] = set[2];
            min_ip[3] = set[3];

            min_ip[3]++;

            return min_ip;
        }

        /*
         * Метод расчёта последнего ip.
         */
        byte[] MaxIP(byte[] broadcast)
        {
            byte[] max_ip = new byte[4];

            max_ip[0] = broadcast[0];
            max_ip[1] = broadcast[1];
            max_ip[2] = broadcast[2];
            max_ip[3] = broadcast[3];

            max_ip[3]--;

            return max_ip;
        }

        /*
         * Метод, позволяющий добавить к маске 1 бит.
         */
        public static void Pribavliaem_K_Maske_Bit(byte[] maska)
        {
            for (int i = 0; i < 4; i++)
            {
                switch (maska[i])
                {
                    case 0: maska[i] = 128; return;
                    case 128: maska[i] = 192; return;
                    case 192: maska[i] = 224; return;
                    case 224: maska[i] = 240; return;
                    case 240: maska[i] = 248; return;
                    case 248: maska[i] = 252; return;
                    case 252: maska[i] = 254; return;
                    case 254: maska[i] = 255; return;
                    default: break;
                }
            }
        }

        /*
         * Метод, преобразующий массив из 4 байт в строку.
         */
        public static string Massiv_V_Stroku(byte[] massiv)
        {
            string stroka = $"{massiv[0]}.{massiv[1]}.{massiv[2]}.{massiv[3]}";

            return stroka;
        }
    }
}