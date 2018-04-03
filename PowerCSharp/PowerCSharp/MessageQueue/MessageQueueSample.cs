using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace PowerCSharp.MessageQueueSample
{
    // MessageQueue Class
    // https://docs.microsoft.com/zh-tw/dotnet/api/system.messaging.messagequeue?view=netframework-4.7.1
    // 建議先不要啟動AD整合(啟動Message Queue功能時不要勾選)，可能會因為AD同步問題，導致測試時，建立或刪除queue後，在Queue Message的MMC管理介面裡面，暫時沒有出現queue，但程式會出現queue已經存在

    // Message Queuing (MSMQ) 學習心得分享
    // https://blog.miniasp.com/post/2010/04/06/MSMQ-Message-Queuing-Learning-Notes.aspx

    // string queuePath = ".\\private$\\myqueue";
    // string queuePath = @"FormatName:DIRECT=TCP:192.168.1.1\private$\myqueue";// 使用遠程IP指定訊息佇列位置

    // 表達 MSMQ 傳送路徑有分兩種方式，表達的名稱稱為 FormatName，大致的格式如下：

    //PUBLIC=QueueGUID
    //DIRECT=Protocol:ComputerAddress\QueueName
    //DIRECT=OS:ComputerName\private$\QueueName
    //PRIVATE=ComputerGUID\QueueNumber
    //對於想要直接傳到訊息到目的地的寫法稱為 Direct Format Names，大致格式如下：

    //DIRECT=AddressSpecification\QueueName  (For public queues.)
    //DIRECT=AddressSpecification\PRIVATE$\QueueName  (For private queues.)
    //DIRECT=AddressSpecification\SYSTEM$;computersystemqueue  (Introduced in MSMQ 2.0)
    //DIRECT=HTTP://URLAddressSpecification/msmq/QueueName  (Introduced in MSMQ 3.0)
    //DIRECT=HTTPS://URLAddressSpecification/msmq/QueueName  (Introduced in MSMQ 3.0)


    // This class represents an object the following example 
    // sends to a queue and receives from a queue.
    public class Order
    {
        public int orderId;
        public DateTime orderTime;
    };

    /// <summary>
    /// Provides a container class for the example.
    /// </summary>
    public class MyNewQueue
    {

        //**************************************************
        // Provides an entry point into the application.
        //		 
        // This example sends and receives a message from
        // a queue.
        //**************************************************

        public static void Main4()
        {
            // Create a new instance of the class.
            MyNewQueue myNewQueue = new MyNewQueue();

            // Send a message to a queue.
            myNewQueue.SendMessage();

            // Receive a message from a queue.
            myNewQueue.ReceiveMessage();

            return;
        }


        //**************************************************
        // Sends an Order to a queue.
        //**************************************************

        public void SendMessage()
        {

            // Create a new order and set values.
            Order sentOrder = new Order();
            sentOrder.orderId = 3;
            sentOrder.orderTime = DateTime.Now;

            string queuePath = ".\\private$\\myqueue";//使用本機方式指定訊息佇列位置

            MessageQueue myQueue;

            if (MessageQueue.Exists(queuePath))//判斷 myqueue訊息佇列是否存在
            {
                //GetQueuesByComputer();
                myQueue = new MessageQueue(queuePath);
            }
            else
            {
                try
                {
                    myQueue = MessageQueue.Create(queuePath);//建立用來接受/發送的訊息佇列
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            //Connect to a queue on the local computer.
            //MessageQueue myQueue = new MessageQueue(queuePath);



            // success
            //MessageQueue myQueue = new MessageQueue(".\\myQueue2");

            // Send the Order to the queue.
            myQueue.Send(sentOrder);

            return;
        }


        //**************************************************
        // Receives a message containing an Order.
        //**************************************************

        public void ReceiveMessage()
        {
            // Connect to the a queue on the local computer.
            MessageQueue myQueue = new MessageQueue(".\\myQueue");

            // Set the formatter to indicate body contains an Order.
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(PowerCSharp.MessageQueueSample.Order) });

            try
            {
                // Receive and format the message. 
                Message myMessage = myQueue.Receive();
                Order myOrder = (Order)myMessage.Body;

                // Display message information.
                Console.WriteLine("Order ID: " +
                    myOrder.orderId.ToString());
                Console.WriteLine("Sent: " +
                    myOrder.orderTime.ToString());
            }

            catch (MessageQueueException)
            {
                // Handle Message Queuing exceptions.
            }

            // Handle invalid serialization format.
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            // Catch other exceptions as necessary.

            return;
        }
    }
}
