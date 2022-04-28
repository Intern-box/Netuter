using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Okno_Drevovidnoe_Delenie(Set set)
        {
            InitializeComponent();

            TreeNode koren_seti = new TreeNode()
            {
                Name = "auto",

                Text = $"{set.set[0]}.{set.set[1]}.{set.set[2]}.{set.set[3]}"
            };

            treeView_Roscha.Nodes.Add(koren_seti);

            ///////////////////

            TreeNode proverka = new TreeNode()
            {
                Name = "auto",

                Text = $"{set.set[0]}.{set.set[1]}.{set.set[2]}.{set.set[3]}"
            };

            koren_seti.Nodes.Add(proverka);
        }
    }
}
