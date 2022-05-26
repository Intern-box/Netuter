using System.Windows.Forms;
using System.Net;

namespace Netuter
{
    public partial class Okno_Drevovidnoe_Delenie : Form
    {
        public Okno_Drevovidnoe_Delenie(Net set)
        {
            InitializeComponent();

            treeView_Derevo.Nodes.Add($"{Net.Massiv_V_Stroku(set.set)} / {Net.Massiv_V_Stroku(set.maska)} / {set.hosti}");

            Net.Pribavliaem_K_Maske_Bit(set.maska);

            set.Raschet();

            treeView_Derevo.Nodes[0].Nodes.Add($"{Net.Massiv_V_Stroku(set.set)} / {Net.Massiv_V_Stroku(set.maska)} / {set.hosti}");

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

            treeView_Derevo.Nodes[0].Nodes.Add($"{Net.Massiv_V_Stroku(set.set)} / {Net.Massiv_V_Stroku(set.maska)} / {set.hosti}");

            Otrisovka_Dereva(koren_dereva_setei: treeView_Derevo.Nodes[0], set);
        }
        void Otrisovka_Dereva(TreeNode koren_dereva_setei, Net ishodnaia_set)
        {
            Net set = new Net();

            set.ip[0] = ishodnaia_set.ip[0];
            set.ip[1] = ishodnaia_set.ip[1];
            set.ip[2] = ishodnaia_set.ip[2];
            set.ip[3] = ishodnaia_set.ip[3];

            set.maska[0] = ishodnaia_set.maska[0];
            set.maska[1] = ishodnaia_set.maska[1];
            set.maska[2] = ishodnaia_set.maska[2];
            set.maska[3] = ishodnaia_set.maska[3];

            set.Raschet();

            foreach (TreeNode vetka in koren_dereva_setei.Nodes)
            {
                if (vetka.Nodes.Count == 0 && set.hosti > 0)
                {
                    Net.Pribavliaem_K_Maske_Bit(set.maska);

                    set.Raschet();

                    vetka.Nodes.Add
                    (
                        Net.Massiv_V_Stroku
                        (
                            Net.Set
                            (
                                IPAddress.Parse(Chistii_IP(vetka.Text)).GetAddressBytes(),

                                set.maska
                            )
                        )

                        + $" / {Net.Massiv_V_Stroku(set.maska)} / {set.hosti}"
                    );

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

                    vetka.Nodes.Add
                    (
                        Net.Massiv_V_Stroku
                        (
                            Net.Set
                            (
                                IPAddress.Parse(Chistii_IP(vetka.Text)).GetAddressBytes(),

                                set.maska
                            )
                        )

                        + $" / {Net.Massiv_V_Stroku(set.maska)} / {set.hosti}"
                    );
                }

                Otrisovka_Dereva(vetka, set);
            };
        }
        string Chistii_IP(string ip)
        {
            string chistii_ip = "";

            for (int i = 0; i < ip.Length; i++)
            {
                if (ip[i] == ' ')
                {
                    return chistii_ip;
                }

                chistii_ip += ip[i];
            }

            return chistii_ip;
        }
    }
}