using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
// including the Mqttnet Library
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;

namespace MqttExample
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private IMqttClient client;
        private IMqttClientOptions clientOptions;

        public delegate void _ShowMessage(MetroLabel lbl, string msg);
        public delegate void _ShowMessageTextBox(MetroTextBox txt, string msg);
        public delegate void _ShowMessageRT(string msg);
        public delegate void _ShowMessageStatus(string msg);
        public delegate void _ShowPictureBox(PictureBox pct, bool status);


        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConnect_ClickAsync(object sender, EventArgs e)
        {
            var BrokerAddress = TxtMqttBroker.Text;
            // use a unique id as client id, each time we start the application
            var clientId = Guid.NewGuid().ToString();

            var factory = new MqttFactory();
            client = factory.CreateMqttClient();
            clientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(BrokerAddress, 1883) // Port is optional
                .WithClientId(clientId)
                .WithCommunicationTimeout(TimeSpan.FromSeconds(3))
                .Build();

            client.UseApplicationMessageReceivedHandler(OnMessageReceived);
            client.UseConnectedHandler(OnConnected);
            //client.UseDisconnectedHandler(OnDisconnected);

            client.UseDisconnectedHandler(async err =>
            {
                Console.WriteLine("### DISCONNECTED FROM SERVER ###");
                ShowMessage(LblMqttStatus, "Reconnecting");
                await Task.Delay(TimeSpan.FromSeconds(5));

                try
                {
                    await client.ConnectAsync(clientOptions, CancellationToken.None); // Since 3.0.5 with CancellationToken
                    var topic_sub = new MqttTopicFilterBuilder()
                        .WithTopic(MtxtTopicSubscribe.Text)
                        .WithAtMostOnceQoS()
                        .Build();

                    await client.SubscribeAsync(topic_sub);
                }
                catch
                {
                    Console.WriteLine("### RECONNECTING FAILED ###");
                    ShowMessage(LblMqttStatus, "Reconnecting");
                }
            });

            Task.Run(async () =>
            {
                await client.ConnectAsync(clientOptions, CancellationToken.None); // Since 3.0.5 with CancellationToken
                ShowMessage(LblMqttStatus, "Reconnecting");
            });
            
        }

        private Task OnDisconnected(MqttClientDisconnectedEventArgs arg)
        {
            ShowMessage(LblMqttStatus, "Reconnecting");

            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
                await client.ConnectAsync(clientOptions, CancellationToken.None); // Since 3.0.5 with CancellationToken
                ShowMessage(LblMqttStatus, "Reconnecting");
            });

            return Task.CompletedTask;
        }

        private Task OnConnected(MqttClientConnectedEventArgs arg)
        {
            ShowMessage(LblMqttStatus, "Connected");
            var topic_sub = new MqttTopicFilterBuilder()
                        .WithTopic(MtxtTopicSubscribe.Text)
                        .WithAtMostOnceQoS()
                        .Build();

            client.SubscribeAsync(topic_sub);
            this.Invoke((MethodInvoker)delegate
            {
                BtnConnect.Enabled = false;
                TxtMqttBroker.Enabled = false;
                GBSubscribeTopic.Enabled = true;
                RTPublishJson.Enabled = true;
                RTPublishJson.ReadOnly = false;
            });

            return Task.CompletedTask;
        }

        private Task OnMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            // get payload
            string ReceivedMessage = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);

            //get topic name
            string TopicReceived = arg.ApplicationMessage.Topic;

            Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
            Console.WriteLine($"+ Topic = {TopicReceived}");
            Console.WriteLine($"+ Payload = {ReceivedMessage}");
            Console.WriteLine($"+ QoS = {arg.ApplicationMessage.QualityOfServiceLevel}");
            Console.WriteLine($"+ Retain = {arg.ApplicationMessage.Retain}");
            Console.WriteLine();

            ShowMessageTextbox(TxtTopicNamereceived, TopicReceived);

            // Show message
            ShowMessageRT(ReceivedMessage);

            return Task.CompletedTask;
        }

        private async void BtnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                //await client.SubscribeAsync("/iot/#", MqttQualityOfServiceLevel.AtMostOnce);

                // or

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
                     .WithTopic(MtxtTopicPublish.Text)
                     .WithPayload(RTPublishJson.Text)
                     .WithAtMostOnceQoS()
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
