
namespace Netuter
{
    partial class Glavnoe_Okno
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.L_IP_Adres = new System.Windows.Forms.Label();
            this.list_Vivod_Podsetei = new System.Windows.Forms.ListView();
            this.column_MinIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_MaxIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Maska = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Hosti = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Set = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBroadcast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_Vhodnie_dannie = new System.Windows.Forms.GroupBox();
            this.label_Vivoda_Hostov = new System.Windows.Forms.Label();
            this.Poschitat = new System.Windows.Forms.Button();
            this.label_Vivoda_Wildcard = new System.Windows.Forms.Label();
            this.Pole_KolVo_Podsetei = new System.Windows.Forms.ComboBox();
            this.label_Vivoda_MaxIP = new System.Windows.Forms.Label();
            this.L_KolVo_Podsetei = new System.Windows.Forms.Label();
            this.L_Wildcard = new System.Windows.Forms.Label();
            this.label_Vivoda_Broadcast = new System.Windows.Forms.Label();
            this.L_Hosti = new System.Windows.Forms.Label();
            this.L_Broadcast = new System.Windows.Forms.Label();
            this.label_Vivoda_Seti = new System.Windows.Forms.Label();
            this.label_Vivoda_MinIP = new System.Windows.Forms.Label();
            this.Pole_Vvoda_IP = new System.Windows.Forms.ComboBox();
            this.L_Set = new System.Windows.Forms.Label();
            this.L_Maska = new System.Windows.Forms.Label();
            this.Pole_Vvoda_Maski = new System.Windows.Forms.ComboBox();
            this.L_MinIP = new System.Windows.Forms.Label();
            this.L_MaxIP = new System.Windows.Forms.Label();
            this.groupBox_Seti = new System.Windows.Forms.GroupBox();
            this.label_Error = new System.Windows.Forms.Label();
            this.Skopirovat = new System.Windows.Forms.Button();
            this.groupBox_Vhodnie_dannie.SuspendLayout();
            this.groupBox_Seti.SuspendLayout();
            this.SuspendLayout();
            // 
            // L_IP_Adres
            // 
            this.L_IP_Adres.AutoSize = true;
            this.L_IP_Adres.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_IP_Adres.Location = new System.Drawing.Point(6, 50);
            this.L_IP_Adres.Name = "L_IP_Adres";
            this.L_IP_Adres.Size = new System.Drawing.Size(87, 18);
            this.L_IP_Adres.TabIndex = 2;
            this.L_IP_Adres.Text = "IP адрес:";
            // 
            // list_Vivod_Podsetei
            // 
            this.list_Vivod_Podsetei.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_MinIP,
            this.column_MaxIP,
            this.column_Maska,
            this.column_Hosti,
            this.column_Set,
            this.columnBroadcast});
            this.list_Vivod_Podsetei.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.list_Vivod_Podsetei.FullRowSelect = true;
            this.list_Vivod_Podsetei.GridLines = true;
            this.list_Vivod_Podsetei.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_Vivod_Podsetei.HideSelection = false;
            this.list_Vivod_Podsetei.Location = new System.Drawing.Point(5, 30);
            this.list_Vivod_Podsetei.Name = "list_Vivod_Podsetei";
            this.list_Vivod_Podsetei.Size = new System.Drawing.Size(722, 225);
            this.list_Vivod_Podsetei.TabIndex = 24;
            this.list_Vivod_Podsetei.UseCompatibleStateImageBehavior = false;
            this.list_Vivod_Podsetei.View = System.Windows.Forms.View.Details;
            // 
            // column_MinIP
            // 
            this.column_MinIP.Text = "Первый IP";
            this.column_MinIP.Width = 125;
            // 
            // column_MaxIP
            // 
            this.column_MaxIP.Text = "Последний IP";
            this.column_MaxIP.Width = 125;
            // 
            // column_Maska
            // 
            this.column_Maska.Text = "Маска/Префикс";
            this.column_Maska.Width = 145;
            // 
            // column_Hosti
            // 
            this.column_Hosti.Text = "Хосты";
            this.column_Hosti.Width = 53;
            // 
            // column_Set
            // 
            this.column_Set.Text = "Сеть";
            this.column_Set.Width = 125;
            // 
            // columnBroadcast
            // 
            this.columnBroadcast.Text = "Широковещание";
            this.columnBroadcast.Width = 125;
            // 
            // groupBox_Vhodnie_dannie
            // 
            this.groupBox_Vhodnie_dannie.Controls.Add(this.label_Vivoda_Hostov);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.Poschitat);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.label_Vivoda_Wildcard);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.Pole_KolVo_Podsetei);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.label_Vivoda_MaxIP);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_KolVo_Podsetei);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_Wildcard);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.label_Vivoda_Broadcast);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_IP_Adres);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_Hosti);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_Broadcast);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.label_Vivoda_Seti);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.label_Vivoda_MinIP);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.Pole_Vvoda_IP);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_Set);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_Maska);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.Pole_Vvoda_Maski);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_MinIP);
            this.groupBox_Vhodnie_dannie.Controls.Add(this.L_MaxIP);
            this.groupBox_Vhodnie_dannie.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Vhodnie_dannie.Location = new System.Drawing.Point(10, 10);
            this.groupBox_Vhodnie_dannie.Name = "groupBox_Vhodnie_dannie";
            this.groupBox_Vhodnie_dannie.Size = new System.Drawing.Size(732, 180);
            this.groupBox_Vhodnie_dannie.TabIndex = 1;
            this.groupBox_Vhodnie_dannie.TabStop = false;
            this.groupBox_Vhodnie_dannie.Text = "Расчёт";
            // 
            // label_Vivoda_Hostov
            // 
            this.label_Vivoda_Hostov.AutoSize = true;
            this.label_Vivoda_Hostov.Font = new System.Drawing.Font("Verdana", 9F);
            this.label_Vivoda_Hostov.Location = new System.Drawing.Point(249, 145);
            this.label_Vivoda_Hostov.Name = "label_Vivoda_Hostov";
            this.label_Vivoda_Hostov.Size = new System.Drawing.Size(42, 14);
            this.label_Vivoda_Hostov.TabIndex = 22;
            this.label_Vivoda_Hostov.Text = "-------";
            this.label_Vivoda_Hostov.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Poschitat
            // 
            this.Poschitat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Poschitat.Location = new System.Drawing.Point(543, 74);
            this.Poschitat.Name = "Poschitat";
            this.Poschitat.Size = new System.Drawing.Size(130, 27);
            this.Poschitat.TabIndex = 5;
            this.Poschitat.Text = "Посчитать";
            this.Poschitat.UseVisualStyleBackColor = true;
            this.Poschitat.Click += new System.EventHandler(this.Poschitat_Click);
            // 
            // label_Vivoda_Wildcard
            // 
            this.label_Vivoda_Wildcard.AutoSize = true;
            this.label_Vivoda_Wildcard.Font = new System.Drawing.Font("Verdana", 9F);
            this.label_Vivoda_Wildcard.Location = new System.Drawing.Point(575, 145);
            this.label_Vivoda_Wildcard.Name = "label_Vivoda_Wildcard";
            this.label_Vivoda_Wildcard.Size = new System.Drawing.Size(87, 14);
            this.label_Vivoda_Wildcard.TabIndex = 16;
            this.label_Vivoda_Wildcard.Text = "----------------";
            this.label_Vivoda_Wildcard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pole_KolVo_Podsetei
            // 
            this.Pole_KolVo_Podsetei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pole_KolVo_Podsetei.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pole_KolVo_Podsetei.Items.AddRange(new object[] {
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096"});
            this.Pole_KolVo_Podsetei.Location = new System.Drawing.Point(431, 75);
            this.Pole_KolVo_Podsetei.Name = "Pole_KolVo_Podsetei";
            this.Pole_KolVo_Podsetei.Size = new System.Drawing.Size(80, 26);
            this.Pole_KolVo_Podsetei.TabIndex = 8;
            // 
            // label_Vivoda_MaxIP
            // 
            this.label_Vivoda_MaxIP.AutoSize = true;
            this.label_Vivoda_MaxIP.Font = new System.Drawing.Font("Verdana", 9F);
            this.label_Vivoda_MaxIP.Location = new System.Drawing.Point(121, 145);
            this.label_Vivoda_MaxIP.Name = "label_Vivoda_MaxIP";
            this.label_Vivoda_MaxIP.Size = new System.Drawing.Size(87, 14);
            this.label_Vivoda_MaxIP.TabIndex = 20;
            this.label_Vivoda_MaxIP.Text = "----------------";
            this.label_Vivoda_MaxIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_KolVo_Podsetei
            // 
            this.L_KolVo_Podsetei.AutoSize = true;
            this.L_KolVo_Podsetei.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_KolVo_Podsetei.Location = new System.Drawing.Point(428, 50);
            this.L_KolVo_Podsetei.Name = "L_KolVo_Podsetei";
            this.L_KolVo_Podsetei.Size = new System.Drawing.Size(83, 18);
            this.L_KolVo_Podsetei.TabIndex = 4;
            this.L_KolVo_Podsetei.Text = "Подсети:";
            // 
            // L_Wildcard
            // 
            this.L_Wildcard.AutoSize = true;
            this.L_Wildcard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.L_Wildcard.Location = new System.Drawing.Point(575, 115);
            this.L_Wildcard.Name = "L_Wildcard";
            this.L_Wildcard.Size = new System.Drawing.Size(117, 14);
            this.L_Wildcard.TabIndex = 15;
            this.L_Wildcard.Text = "Обратная маска";
            // 
            // label_Vivoda_Broadcast
            // 
            this.label_Vivoda_Broadcast.AutoSize = true;
            this.label_Vivoda_Broadcast.Font = new System.Drawing.Font("Verdana", 9F);
            this.label_Vivoda_Broadcast.Location = new System.Drawing.Point(425, 145);
            this.label_Vivoda_Broadcast.Name = "label_Vivoda_Broadcast";
            this.label_Vivoda_Broadcast.Size = new System.Drawing.Size(87, 14);
            this.label_Vivoda_Broadcast.TabIndex = 14;
            this.label_Vivoda_Broadcast.Text = "----------------";
            this.label_Vivoda_Broadcast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Hosti
            // 
            this.L_Hosti.AutoSize = true;
            this.L_Hosti.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.L_Hosti.Location = new System.Drawing.Point(249, 115);
            this.L_Hosti.Name = "L_Hosti";
            this.L_Hosti.Size = new System.Drawing.Size(49, 14);
            this.L_Hosti.TabIndex = 21;
            this.L_Hosti.Text = "Хосты";
            // 
            // L_Broadcast
            // 
            this.L_Broadcast.AutoSize = true;
            this.L_Broadcast.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.L_Broadcast.Location = new System.Drawing.Point(425, 115);
            this.L_Broadcast.Name = "L_Broadcast";
            this.L_Broadcast.Size = new System.Drawing.Size(122, 14);
            this.L_Broadcast.TabIndex = 13;
            this.L_Broadcast.Text = "Широковещание";
            // 
            // label_Vivoda_Seti
            // 
            this.label_Vivoda_Seti.AutoSize = true;
            this.label_Vivoda_Seti.Font = new System.Drawing.Font("Verdana", 9F);
            this.label_Vivoda_Seti.Location = new System.Drawing.Point(320, 145);
            this.label_Vivoda_Seti.Name = "label_Vivoda_Seti";
            this.label_Vivoda_Seti.Size = new System.Drawing.Size(87, 14);
            this.label_Vivoda_Seti.TabIndex = 12;
            this.label_Vivoda_Seti.Text = "----------------";
            this.label_Vivoda_Seti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Vivoda_MinIP
            // 
            this.label_Vivoda_MinIP.AutoSize = true;
            this.label_Vivoda_MinIP.Font = new System.Drawing.Font("Verdana", 9F);
            this.label_Vivoda_MinIP.Location = new System.Drawing.Point(10, 145);
            this.label_Vivoda_MinIP.Name = "label_Vivoda_MinIP";
            this.label_Vivoda_MinIP.Size = new System.Drawing.Size(87, 14);
            this.label_Vivoda_MinIP.TabIndex = 18;
            this.label_Vivoda_MinIP.Text = "----------------";
            this.label_Vivoda_MinIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pole_Vvoda_IP
            // 
            this.Pole_Vvoda_IP.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pole_Vvoda_IP.Items.AddRange(new object[] {
            "10.0.0.1",
            "172.16.0.1",
            "192.168.0.1"});
            this.Pole_Vvoda_IP.Location = new System.Drawing.Point(10, 75);
            this.Pole_Vvoda_IP.Name = "Pole_Vvoda_IP";
            this.Pole_Vvoda_IP.Size = new System.Drawing.Size(170, 26);
            this.Pole_Vvoda_IP.TabIndex = 6;
            // 
            // L_Set
            // 
            this.L_Set.AutoSize = true;
            this.L_Set.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.L_Set.Location = new System.Drawing.Point(320, 115);
            this.L_Set.Name = "L_Set";
            this.L_Set.Size = new System.Drawing.Size(38, 14);
            this.L_Set.TabIndex = 11;
            this.L_Set.Text = "Сеть";
            // 
            // L_Maska
            // 
            this.L_Maska.AutoSize = true;
            this.L_Maska.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Maska.Location = new System.Drawing.Point(191, 50);
            this.L_Maska.Name = "L_Maska";
            this.L_Maska.Size = new System.Drawing.Size(146, 18);
            this.L_Maska.TabIndex = 3;
            this.L_Maska.Text = "Маска/Префикс:";
            // 
            // Pole_Vvoda_Maski
            // 
            this.Pole_Vvoda_Maski.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pole_Vvoda_Maski.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pole_Vvoda_Maski.Items.AddRange(new object[] {
            "0.0.0.0/0",
            "128.0.0.0/1",
            "192.0.0.0/2",
            "224.0.0.0/3",
            "240.0.0.0/4",
            "248.0.0.0/5",
            "252.0.0.0/6",
            "254.0.0.0/7",
            "255.0.0.0/8",
            "255.128.0.0/9",
            "255.192.0.0/10",
            "255.224.0.0/11",
            "255.240.0.0/12",
            "255.248.0.0/13",
            "255.252.0.0/14",
            "255.254.0.0/15",
            "255.255.0.0/16",
            "255.255.128.0/17",
            "255.255.192.0/18",
            "255.255.224.0/19",
            "255.255.240.0/20",
            "255.255.248.0/21",
            "255.255.252.0/22",
            "255.255.254.0/23",
            "255.255.255.0/24",
            "255.255.255.128/25",
            "255.255.255.192/26",
            "255.255.255.224/27",
            "255.255.255.240/28",
            "255.255.255.248/29",
            "255.255.255.252/30",
            "255.255.255.254/31",
            "255.255.255.255/32"});
            this.Pole_Vvoda_Maski.Location = new System.Drawing.Point(195, 75);
            this.Pole_Vvoda_Maski.Name = "Pole_Vvoda_Maski";
            this.Pole_Vvoda_Maski.Size = new System.Drawing.Size(220, 26);
            this.Pole_Vvoda_Maski.TabIndex = 7;
            // 
            // L_MinIP
            // 
            this.L_MinIP.AutoSize = true;
            this.L_MinIP.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.L_MinIP.Location = new System.Drawing.Point(10, 115);
            this.L_MinIP.Name = "L_MinIP";
            this.L_MinIP.Size = new System.Drawing.Size(79, 14);
            this.L_MinIP.TabIndex = 17;
            this.L_MinIP.Text = "Первый IP";
            // 
            // L_MaxIP
            // 
            this.L_MaxIP.AutoSize = true;
            this.L_MaxIP.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.L_MaxIP.Location = new System.Drawing.Point(121, 115);
            this.L_MaxIP.Name = "L_MaxIP";
            this.L_MaxIP.Size = new System.Drawing.Size(102, 14);
            this.L_MaxIP.TabIndex = 19;
            this.L_MaxIP.Text = "Последний IP";
            // 
            // groupBox_Seti
            // 
            this.groupBox_Seti.Controls.Add(this.list_Vivod_Podsetei);
            this.groupBox_Seti.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_Seti.Location = new System.Drawing.Point(10, 218);
            this.groupBox_Seti.Name = "groupBox_Seti";
            this.groupBox_Seti.Size = new System.Drawing.Size(732, 260);
            this.groupBox_Seti.TabIndex = 23;
            this.groupBox_Seti.TabStop = false;
            this.groupBox_Seti.Text = "Подсети";
            // 
            // label_Error
            // 
            this.label_Error.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Error.ForeColor = System.Drawing.Color.Red;
            this.label_Error.Location = new System.Drawing.Point(10, 200);
            this.label_Error.Name = "label_Error";
            this.label_Error.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_Error.Size = new System.Drawing.Size(700, 20);
            this.label_Error.TabIndex = 24;
            this.label_Error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Skopirovat
            // 
            this.Skopirovat.Enabled = false;
            this.Skopirovat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Skopirovat.Location = new System.Drawing.Point(537, 479);
            this.Skopirovat.Name = "Skopirovat";
            this.Skopirovat.Size = new System.Drawing.Size(200, 27);
            this.Skopirovat.TabIndex = 23;
            this.Skopirovat.Text = "Скопировать подсети";
            this.Skopirovat.UseVisualStyleBackColor = true;
            this.Skopirovat.Click += new System.EventHandler(this.Skopirovat_Click);
            // 
            // Glavnoe_Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(752, 517);
            this.Controls.Add(this.Skopirovat);
            this.Controls.Add(this.label_Error);
            this.Controls.Add(this.groupBox_Seti);
            this.Controls.Add(this.groupBox_Vhodnie_dannie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Glavnoe_Okno";
            this.ShowIcon = false;
            this.Text = "Netuter 5.1";
            this.groupBox_Vhodnie_dannie.ResumeLayout(false);
            this.groupBox_Vhodnie_dannie.PerformLayout();
            this.groupBox_Seti.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label L_IP_Adres;
        private System.Windows.Forms.ColumnHeader column_MinIP;
        private System.Windows.Forms.ColumnHeader column_MaxIP;
        private System.Windows.Forms.ColumnHeader column_Maska;
        private System.Windows.Forms.ColumnHeader column_Set;
        private System.Windows.Forms.ColumnHeader column_Hosti;
        private System.Windows.Forms.ListView list_Vivod_Podsetei;
        private System.Windows.Forms.GroupBox groupBox_Vhodnie_dannie;
        private System.Windows.Forms.Button Poschitat;
        private System.Windows.Forms.Label L_Hosti;
        private System.Windows.Forms.ComboBox Pole_KolVo_Podsetei;
        private System.Windows.Forms.Label L_KolVo_Podsetei;
        private System.Windows.Forms.Label L_MaxIP;
        private System.Windows.Forms.Label L_Broadcast;
        private System.Windows.Forms.Label L_MinIP;
        private System.Windows.Forms.Label L_Wildcard;
        private System.Windows.Forms.ComboBox Pole_Vvoda_IP;
        private System.Windows.Forms.Label L_Maska;
        private System.Windows.Forms.Label L_Set;
        private System.Windows.Forms.ComboBox Pole_Vvoda_Maski;
        private System.Windows.Forms.Label label_Vivoda_Seti;
        private System.Windows.Forms.Label label_Vivoda_Broadcast;
        private System.Windows.Forms.Label label_Vivoda_MinIP;
        private System.Windows.Forms.Label label_Vivoda_Wildcard;
        private System.Windows.Forms.Label label_Vivoda_MaxIP;
        private System.Windows.Forms.Label label_Vivoda_Hostov;
        private System.Windows.Forms.GroupBox groupBox_Seti;
        private System.Windows.Forms.Label label_Error;
        private System.Windows.Forms.ColumnHeader columnBroadcast;
        private System.Windows.Forms.Button Skopirovat;
    }
}

