namespace Netuter
{
    public class Kalkuliator
    {
        public static byte[] Wildcard(byte[] maska)
        {
            byte[] wildcard = { 0, 0, 0, 0 };

            wildcard[0] = (byte)(~maska[0]);
            wildcard[1] = (byte)(~maska[1]);
            wildcard[2] = (byte)(~maska[2]);
            wildcard[3] = (byte)(~maska[3]);

            return wildcard;
        }
        public static byte Biti_V_Maske(byte[] maska)
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
        public static ulong Hosti(byte biti_v_maske)
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
        public static byte[] Set(byte[] ip, byte[] maska)
        {
            byte[] set = { 0, 0, 0, 0 };

            set[0] = (byte)(ip[0] & maska[0]);
            set[1] = (byte)(ip[1] & maska[1]);
            set[2] = (byte)(ip[2] & maska[2]);
            set[3] = (byte)(ip[3] & maska[3]);

            return set;
        }
        public static byte[] Broadcast(byte[] set, byte[] wildcard)
        {
            byte[] broadcast = { 0, 0, 0, 0 };

            broadcast[0] = (byte)(set[0] + wildcard[0]);
            broadcast[1] = (byte)(set[1] + wildcard[1]);
            broadcast[2] = (byte)(set[2] + wildcard[2]);
            broadcast[3] = (byte)(set[3] + wildcard[3]);

            return broadcast;
        }
        public static byte[] MinIP(byte[] set)
        {
            byte[] minip = { 0, 0, 0, 0 };

            minip[0] = set[0];
            minip[1] = set[1];
            minip[2] = set[2];
            minip[3] = set[3];

            minip[3]++;

            return minip;
        }
        public static byte[] MaxIP(byte[] broadcast)
        {
            byte[] maxip = { 0, 0, 0, 0 };

            maxip[0] = broadcast[0];
            maxip[1] = broadcast[1];
            maxip[2] = broadcast[2];
            maxip[3] = broadcast[3];

            maxip[3]--;

            return maxip;
        }
        public static byte[] Pribavliaem_Bit_K_Maske(byte[] maska)
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
        public static byte[] Pribavliaem_Biti_K_IP(byte[] ip, ulong kolichestvo_bit)
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
        public static Set Obiect_set(byte[] ip, byte[] maska)
        {
            Set set;

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
    }
}