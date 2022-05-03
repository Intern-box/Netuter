using System;
using System.Windows.Forms;

namespace Netuter
{
    public partial class Okno_Drevovidnoe_Delenie : Form
    {
        public Okno_Drevovidnoe_Delenie(Net set)
        {
            InitializeComponent();

            Otrisovka_Dereva(set);
        }
        void Otrisovka_Dereva(Net set)
        {
            TreeNode delimaia_set = new TreeNode()
            {
                Name = "auto",

                Text = $"{Net.Massiv_V_Stroku(set.set)} / {set.biti_v_maske} ({set.hosti})"
            };

            treeView_Derevo.Nodes.Add(delimaia_set);

            uint kolvo_setei = (uint)Math.Pow(2, 30 - set.biti_v_maske);

            set.ip[0] = set.min_ip[0];
            set.ip[1] = set.min_ip[1];
            set.ip[2] = set.min_ip[2];
            set.ip[3] = set.min_ip[3];

            for (uint i = 0; i < Math.Log(kolvo_setei, 2); i++)
            {
                Net.Pribavliaem_K_Maske_Bit(set.maska);
            }

            set.Raschet();

            for (uint i = 0, progressia = 1; i < kolvo_setei; i++)
            {
                for (uint k = 0; k < progressia; k++)
                {
                    TreeNode podset = new TreeNode()
                    {
                        Name = "auto",

                        Text = $"{Net.Massiv_V_Stroku(set.set)} / {set.biti_v_maske} ({set.hosti})"
                    };

                    delimaia_set.Nodes.Add(podset);

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
            }
        }
    }
}
