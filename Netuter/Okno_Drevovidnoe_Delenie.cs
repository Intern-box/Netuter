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

            Net.Obnovlenie_Harakteristik_I_Raschet_Vtoroi_Podseti(set);

            treeView_Derevo.Nodes[0].Nodes.Add($"{Net.Massiv_V_Stroku(set.set)} / {Net.Massiv_V_Stroku(set.maska)} / {set.hosti}");

            Otrisovka_Dereva(koren_dereva_setei: treeView_Derevo.Nodes[0], set);
        }
        void Otrisovka_Dereva(TreeNode koren_dereva_setei, Net ishodnaia_set)
        {
            Net set = new Net(ishodnaia_set.ip, ishodnaia_set.maska);

            foreach (TreeNode vetka in koren_dereva_setei.Nodes)
            {
                if (vetka.Nodes.Count == 0 && set.hosti > 0)
                {
                    Net.Pribavliaem_K_Maske_Bit(set.maska);

                    set.Raschet();

                    vetka.Nodes.Add(Net.Massiv_V_Stroku(Net.Set(IPAddress.Parse(Chistii_IP(vetka.Text)).GetAddressBytes(),set.maska))
                        + $" / {Net.Massiv_V_Stroku(set.maska)} / {set.hosti}");

                    Net.Obnovlenie_Harakteristik_I_Raschet_Vtoroi_Podseti(set);

                    vetka.Nodes.Add(Net.Massiv_V_Stroku(Net.Set(IPAddress.Parse(Chistii_IP(vetka.Text)).GetAddressBytes(), set.maska))
                        + $" / {Net.Massiv_V_Stroku(set.maska)} / {set.hosti}");
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