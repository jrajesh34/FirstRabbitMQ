using AutoMapper;
using log4net;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Charting;
using RabbitMQ.Client.Events;
using Eom.Messaging;
using Newtonsoft.Json;
using BenchmarkDotNet.Attributes;

namespace FirstRabbitMQ
{
    public partial class Form1 : Form
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "localhost";
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";

            Dictionary<string, object> queueArgs = new Dictionary<string, object>
            {
                //{"x-dead-letter-exchange", MainExchange},
                {"x-message-ttl", 60000}
            };

            // create a connection and open a channel, dispose them when done
            using (var conn = connectionFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var json = @"{ATPId: '1',
                            UPCCode: 'ABC12345',
                            ProductId: 1001,
                             ProductDimension: null,
                            SupplierId: null,
                            EstimatedDeliveryDate: null,
                            ShippingCost: null
                            }";
                var queueName = "ATPQueue";
                var data = Encoding.UTF8.GetBytes(json);
                var exchangeName = "ATPExchange";
                var routingKey = "ATPQueue";

                channel.ExchangeDeclare("ATPExchange", ExchangeType.Direct);
                channel.QueueDeclare(queueName, false, false, false, null);
                channel.QueueBind(queueName, exchangeName, routingKey, null);
                channel.BasicQos(0, 1, false);
                channel.BasicPublish(exchangeName, routingKey, null, data);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = ReadMessage();
        }

        [Benchmark(Baseline = true)]
        private string ReadMessage()
        {
           // string MainExchange = "MainExchange";
            int messageRequeueTTL = 60000;

            Dictionary<string, object> queueArgs = new Dictionary<string, object>
            {
                //{"x-dead-letter-exchange", MainExchange},
                {"x-message-ttl", messageRequeueTTL}
            };

            //var queueName = "AutoCredit";
            var queueName =  "queueFromVisualStudio"; //"AutoCredit";
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "localhost";
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";
            using (var conn = connectionFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(queueName, true, false, false, queueArgs);
                var data = channel.BasicGet(queueName, false);
                if (data == null) return null;
                var message = Encoding.UTF8.GetString(data.Body);
                channel.BasicAck(data.DeliveryTag, true);
                return (message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var message = "";
            Dictionary<string, object> queueArgs = new Dictionary<string, object>
            {
                {"x-message-ttl", 60000}
            };
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";
            factory.VirtualHost = "/";

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            var queueName = "TEST123";
            channel.QueueDeclare(queueName, true, false, false, queueArgs);
            channel.QueueBind(queueName, "Exch1", "", null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine("received [x] {0}", message);
            };
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Eom.Messaging.Class1 obj = new Class1();
            //Logger.InfoFormat("Running as {0}", WindowsIdentity.GetCurrent().Name);

            List<Tracker> trackers = new Tracker().GetTrackers();

            List<Tracker> trackersWithMasterTrack = trackers.FindAll(x => x.MasterTrackingNo != null);

            var result = trackersWithMasterTrack.GroupBy(track => track.MasterTrackingNo)
                                  .OrderBy(group => group.Key)
                                  .Select(n => new
                                  {
                                      MasterTrack = n.Key,
                                      MasterTrackCount = n.Count()
                                  }.MasterTrack);

                                 //.Select(group => Tuple.Create(group.Key, group.Count()));

                                  // int count = from trake
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
                gfx.DrawString("Hello, World!", Font, XBrushes.Black,
                        new XRect(0, 0, page.Width, page.Height),XStringFormats.Center);
                gfx.DrawString("Second Paragraph", Font, XBrushes.Black,
                       new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
                const string filename = "HelloWorld.pdf";
                document.Save(filename);

                //FileStream fs = new FileStream("Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                //Document doc = new Document();
                //PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                //doc.Open();
                //doc.Add(new Paragraph("Hello World"));
                //doc.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Tracker
    {
        public string MasterTrackingNo { get; set; }
        public string ParentTrackingNo { get; set; }

        public List<Tracker> GetTrackers()
        {

            List<Tracker> trackers = new List<Tracker>();
            var tracker = new Tracker();
            tracker.MasterTrackingNo = "1";
            tracker.ParentTrackingNo = "100";
            trackers.Add(tracker);

            tracker = new Tracker();
            tracker.MasterTrackingNo = "1";
            tracker.ParentTrackingNo = "101";
            trackers.Add(tracker);

            tracker = new Tracker();
            tracker.MasterTrackingNo = "1";
            tracker.ParentTrackingNo = "102";
            trackers.Add(tracker);

            tracker = new Tracker();
            tracker.MasterTrackingNo = "2";
            tracker.ParentTrackingNo = "201";
            trackers.Add(tracker);

            tracker = new Tracker();
            tracker.MasterTrackingNo = "2";
            tracker.ParentTrackingNo = "202";
            trackers.Add(tracker);

            tracker = new Tracker();
            tracker.MasterTrackingNo = null;
            tracker.ParentTrackingNo = "104";
            trackers.Add(tracker);

            tracker = new Tracker();
            tracker.MasterTrackingNo = null;
            tracker.ParentTrackingNo = "105";
            trackers.Add(tracker);

            return trackers;
        }
    }

    public class class1
    {
        public string fName { get; set; }
        public string lName { get; set; }
    }

    public class class2
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }

    public class MyMapper
    {

        public class2 MapIgnoreNonExisting1(class1 source, class2 destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<class1, class2>()
                .ForMember(s => s.FName, option => option.Ignore());
            });

            return null;
        }
        public class2 MapIgnoreNonExisting2(class1 source, class2 destination)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<class1, class2>()
                .ForMember(s => s.FName, option => option.Ignore());
            });

            return null;
        }
    }
}
