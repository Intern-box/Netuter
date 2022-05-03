using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Netuter.Kalkuliator;

namespace Netuter
{
    public partial class Okno_Drevovidnoe_Delenie : Form
    {
        public Set set;
        public Okno_Drevovidnoe_Delenie()
        {
            InitializeComponent();
        }
        public Okno_Drevovidnoe_Delenie(Set set)
        {
            InitializeComponent();

            Otrisovka_Dereva(set);
        }
        void Otrisovka_Dereva(Set set)
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

            set.maska = Pribavliaem_Bit_K_Maske(set.maska);

            set = Obiect_set(set.minip, set.maska);

            TreeNode pervaia_podset = new TreeNode()
            {
                Name = "auto",

                Text = $"{set.set[0]}.{set.set[1]}.{set.set[2]}.{set.set[3]}/{set.biti_v_maske} ({set.hosti})"
            };

            delimaia_set.Nodes.Add(pervaia_podset);

            set = Obiect_set(Pribavliaem_Biti_K_IP(set.ip, shag), set.maska);

            delimaia_set.Nodes.Add(pervaia_podset);
        }
    }
}
