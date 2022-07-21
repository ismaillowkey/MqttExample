namespace MqttExample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GBSubscribeTopic = new System.Windows.Forms.GroupBox();
            this.LBTopicSubscribe = new System.Windows.Forms.ListBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.MBtnSubscribe = new MetroFramework.Controls.MetroButton();
            this.LblMqttStatus = new MetroFramework.Controls.MetroLabel();
            this.TxtTopicNamereceived = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.RTSubscribeJson = new System.Windows.Forms.RichTextBox();
            this.MtxtTopicSubscribe = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.BtnConnect = new MetroFramework.Controls.MetroButton();
            this.TxtMqttBroker = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTPublishJson = new System.Windows.Forms.RichTextBox();
            this.MbtnPublish = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.MtxtTopicPublish = new System.Windows.Forms.TextBox();
            this.GBSubscribeTopic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBSubscribeTopic
            // 
            this.GBSubscribeTopic.Controls.Add(this.LBTopicSubscribe);
            this.GBSubscribeTopic.Controls.Add(this.metroLabel3);
            this.GBSubscribeTopic.Controls.Add(this.MBtnSubscribe);
            this.GBSubscribeTopic.Controls.Add(this.LblMqttStatus);
            this.GBSubscribeTopic.Controls.Add(this.TxtTopicNamereceived);
            this.GBSubscribeTopic.Controls.Add(this.metroLabel1);
            this.GBSubscribeTopic.Controls.Add(this.RTSubscribeJson);
            this.GBSubscribeTopic.Controls.Add(this.MtxtTopicSubscribe);
            this.GBSubscribeTopic.Enabled = false;
            this.GBSubscribeTopic.Location = new System.Drawing.Point(31, 111);
            this.GBSubscribeTopic.Name = "GBSubscribeTopic";
            this.GBSubscribeTopic.Size = new System.Drawing.Size(587, 324);
            this.GBSubscribeTopic.TabIndex = 3;
            this.GBSubscribeTopic.TabStop = false;
            this.GBSubscribeTopic.Text = "Subscribe Topic";
            // 
            // LBTopicSubscribe
            // 
            this.LBTopicSubscribe.FormattingEnabled = true;
            this.LBTopicSubscribe.Location = new System.Drawing.Point(7, 92);
            this.LBTopicSubscribe.Name = "LBTopicSubscribe";
            this.LBTopicSubscribe.Size = new System.Drawing.Size(288, 199);
            this.LBTopicSubscribe.TabIndex = 15;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(7, 50);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(106, 19);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Topic Received : ";
            // 
            // MBtnSubscribe
            // 
            this.MBtnSubscribe.Location = new System.Drawing.Point(216, 20);
            this.MBtnSubscribe.Name = "MBtnSubscribe";
            this.MBtnSubscribe.Size = new System.Drawing.Size(79, 23);
            this.MBtnSubscribe.TabIndex = 7;
            this.MBtnSubscribe.Text = "Subscribe";
            this.MBtnSubscribe.Click += new System.EventHandler(this.BtnSubscribe_Click);
            // 
            // LblMqttStatus
            // 
            this.LblMqttStatus.AutoSize = true;
            this.LblMqttStatus.Location = new System.Drawing.Point(7, 301);
            this.LblMqttStatus.Name = "LblMqttStatus";
            this.LblMqttStatus.Size = new System.Drawing.Size(41, 19);
            this.LblMqttStatus.TabIndex = 13;
            this.LblMqttStatus.Text = "status";
            // 
            // TxtTopicNamereceived
            // 
            this.TxtTopicNamereceived.Location = new System.Drawing.Point(121, 50);
            this.TxtTopicNamereceived.Name = "TxtTopicNamereceived";
            this.TxtTopicNamereceived.ReadOnly = true;
            this.TxtTopicNamereceived.Size = new System.Drawing.Size(174, 23);
            this.TxtTopicNamereceived.TabIndex = 12;
            this.TxtTopicNamereceived.Text = "...";
            this.TxtTopicNamereceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(7, 20);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Topic Name : ";
            // 
            // RTSubscribeJson
            // 
            this.RTSubscribeJson.Location = new System.Drawing.Point(301, 19);
            this.RTSubscribeJson.Name = "RTSubscribeJson";
            this.RTSubscribeJson.ReadOnly = true;
            this.RTSubscribeJson.Size = new System.Drawing.Size(280, 273);
            this.RTSubscribeJson.TabIndex = 2;
            this.RTSubscribeJson.Text = "";
            // 
            // MtxtTopicSubscribe
            // 
            this.MtxtTopicSubscribe.Location = new System.Drawing.Point(100, 20);
            this.MtxtTopicSubscribe.Name = "MtxtTopicSubscribe";
            this.MtxtTopicSubscribe.Size = new System.Drawing.Size(110, 20);
            this.MtxtTopicSubscribe.TabIndex = 1;
            this.MtxtTopicSubscribe.Text = "iot/#";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(34, 63);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(80, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Mqtt Broker";
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(262, 63);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnConnect.TabIndex = 5;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TxtMqttBroker
            // 
            this.TxtMqttBroker.Location = new System.Drawing.Point(120, 63);
            this.TxtMqttBroker.Name = "TxtMqttBroker";
            this.TxtMqttBroker.Size = new System.Drawing.Size(136, 23);
            this.TxtMqttBroker.TabIndex = 6;
            this.TxtMqttBroker.Text = "ismaillowkey.my.id";
            this.TxtMqttBroker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTPublishJson);
            this.groupBox1.Controls.Add(this.MbtnPublish);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.MtxtTopicPublish);
            this.groupBox1.Location = new System.Drawing.Point(656, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 324);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "publish Topic";
            // 
            // RTPublishJson
            // 
            this.RTPublishJson.Location = new System.Drawing.Point(18, 50);
            this.RTPublishJson.Name = "RTPublishJson";
            this.RTPublishJson.ReadOnly = true;
            this.RTPublishJson.Size = new System.Drawing.Size(371, 264);
            this.RTPublishJson.TabIndex = 16;
            this.RTPublishJson.Text = "";
            // 
            // MbtnPublish
            // 
            this.MbtnPublish.Location = new System.Drawing.Point(310, 18);
            this.MbtnPublish.Name = "MbtnPublish";
            this.MbtnPublish.Size = new System.Drawing.Size(79, 23);
            this.MbtnPublish.TabIndex = 12;
            this.MbtnPublish.Text = "Publish";
            this.MbtnPublish.Click += new System.EventHandler(this.MbtnPublish_ClickAsync);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(10, 19);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(90, 19);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "Topic Name : ";
            // 
            // MtxtTopicPublish
            // 
            this.MtxtTopicPublish.Location = new System.Drawing.Point(103, 19);
            this.MtxtTopicPublish.Name = "MtxtTopicPublish";
            this.MtxtTopicPublish.Size = new System.Drawing.Size(201, 20);
            this.MtxtTopicPublish.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtMqttBroker);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.GBSubscribeTopic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GBSubscribeTopic.ResumeLayout(false);
            this.GBSubscribeTopic.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox GBSubscribeTopic;
        private System.Windows.Forms.RichTextBox RTSubscribeJson;
        private System.Windows.Forms.TextBox MtxtTopicSubscribe;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton BtnConnect;
        private MetroFramework.Controls.MetroTextBox TxtMqttBroker;
        private MetroFramework.Controls.MetroTextBox TxtTopicNamereceived;
        private MetroFramework.Controls.MetroLabel LblMqttStatus;
        private MetroFramework.Controls.MetroButton MBtnSubscribe;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ListBox LBTopicSubscribe;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton MbtnPublish;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.TextBox MtxtTopicPublish;
        private System.Windows.Forms.RichTextBox RTPublishJson;
    }
}

