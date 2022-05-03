using System;
using System.Windows.Forms;

namespace Netuter
{
    public partial class Okno_Drevovidnoe_Delenie : Form
    {
        public Set set;
        public Okno_Drevovidnoe_Delenie()
        {
            InitializeComponent();
        }
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

                Text = $"{set.set[0]}.{set.set[1]}.{set.set[2]}.{set.set[3]}/{set.biti_v_maske} ({set.hosti})"
            };

            treeView_Derevo.Nodes.Add(delimaia_set);

            ///////////////////

            uint kolvo_setei = (uint)Math.Pow(2, 30 - set.biti_v_maske);

            ulong shag = (set.hosti + 2) / (kolvo_setei);

            Net.Pribavliaem_K_Maske_Bit(set.maska);

            set.ip[0] = set.min_ip[0];
            set.ip[1] = set.min_ip[1];
            set.ip[2] = set.min_ip[2];
            set.ip[3] = set.min_ip[3];

            set.Raschet();

            TreeNode pervaia_podset = new TreeNode()
            {
                Name = "auto",

                Text = $"{set.set[0]}.{set.set[1]}.{set.set[2]}.{set.set[3]}/{set.biti_v_maske} ({set.hosti})"
            };

            delimaia_set.Nodes.Add(pervaia_podset);

            set.broadcast[3] += 2;

            set.ip[0] = set.broadcast[0];
            set.ip[1] = set.broadcast[1];
            set.ip[2] = set.broadcast[2];
            set.ip[3] = set.broadcast[3];

            set.Raschet();

            delimaia_set.Nodes.Add(pervaia_podset);
        }
    }
}
