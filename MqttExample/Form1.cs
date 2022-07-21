using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
// including the Mqttnet Library
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;

namespace MqttExample
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private IMqttClient client;
        private MqttClientOptions clientOptions;

        public delegate void _ShowMessage(MetroLabel lbl, string msg);
        public delegate void _ShowMessageTextBox(MetroTextBox txt, string msg);
        public delegate void _ShowMessageRT(string msg);
        public delegate void _ShowMessageStatus(string msg);
        public delegate void _ShowPictureBox(PictureBox pct, bool status);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void BtnConnect_Click(object sender, EventArgs e)
        {
            var BrokerAddress = TxtMqttBroker.Text;
            // use a unique id as client id, each time we start the application
            var clientId = Guid.NewGuid().ToString();

            var factory = new MqttFactory();
            client = factory.CreateMqttClient();
            clientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(BrokerAddress, 1883) // Port is optional
                .WithClientId(clientId)
                .Build();

            client.ConnectedAsync += Client_ConnectedAsync;
            client.ConnectingAsync += Client_ConnectingAsync;
            client.DisconnectedAsync += Client_DisconnectedAsync;
            client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;

            await client.ConnectAsync(clientOptions, CancellationToken.None);
        }

        private Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            // get payload
            string ReceivedMessage = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);

            // get topic name
            string TopicReceived = arg.ApplicationMessage.Topic;

            //Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
            //Console.WriteLine($"+ Topic = {TopicReceived}");
            //Console.WriteLine($"+ Payload = {ReceivedMessage}");
            //Console.WriteLine($"+ QoS = {arg.ApplicationMessage.QualityOfServiceLevel}");
            //Console.WriteLine($"+ Retain = {arg.ApplicationMessage.Retain}");
            //Console.WriteLine();

            ShowMessageTextbox(TxtTopicNamereceived, TopicReceived);

            // Show message
            ShowMessageRT(ReceivedMessage);

            return Task.CompletedTask;
        }

        private async Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            ShowMessage(LblMqttStatus, "Disconnected");

            await Task.Delay(TimeSpan.FromSeconds(3));
            await client.ConnectAsync(clientOptions, CancellationToken.None); // Since 3.0.5 with CancellationToken
            ShowMessage(LblMqttStatus, "Reconnecting");

            await Task.CompletedTask;
        }


        private async Task Client_ConnectingAsync(MqttClientConnectingEventArgs arg)
        {
            ShowMessage(LblMqttStatus, "Reconnecting");
            await Task.CompletedTask;
        }

        private async Task Client_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            ShowMessage(LblMqttStatus, "Connected");
            //client.SubscribeAsync(topic_sub);
            this.Invoke((MethodInvoker)delegate
            {
                BtnConnect.Enabled = false;
                TxtMqttBroker.Enabled = false;
                GBSubscribeTopic.Enabled = true;
                RTPublishJson.Enabled = true;
                RTPublishJson.ReadOnly = false;
            });
            await Task.CompletedTask;
        }


        private async void BtnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                var topic_sub = new MqttTopicFilterBuilder()
                    .WithTopic(MtxtTopicSubscribe.Text)
                    .WithAtMostOnceQoS()
                    .Build();

                await client.SubscribeAsync(topic_sub);

                LBTopicSubscribe.Items.Add(MtxtTopicSubscribe.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private async void MbtnPublish_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(MtxtTopicPublish.Text.Trim())
                    .WithPayload(RTPublishJson.Text)
                    .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                    .WithRetainFlag()
                    .Build();


                await client.PublishAsync(message, CancellationToken.None); // Since 3.0.5 with CancellationToken        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region "Delegate"
        public void ShowMessage(MetroLabel lbl, String msg)
        {
            if (InvokeRequired)
            {
                Invoke(new _ShowMessage(ShowMessage), new Object[] { lbl, msg });
                return;
            }
            lbl.Text = msg;
        }

        public void ShowMessageTextbox(MetroTextBox txt, String msg)
        {
            if (InvokeRequired)
            {
                Invoke(new _ShowMessageTextBox(ShowMessageTextbox), new Object[] { txt, msg });
                return;
            }
            txt.Text = msg;
        }

        public void ShowMessageRT(String msg)
        {
            if (InvokeRequired)
            {
                Invoke(new _ShowMessageRT(ShowMessageRT), new Object[] { msg });
                return;
            }
            RTSubscribeJson.Text = msg;
        }

        #endregion

        
    }


}
