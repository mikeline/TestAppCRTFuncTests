using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestTaskCRT;

namespace TestAppCRTFuncTests
{
    [TestClass]
    public class MessageBrokerTests
    {
        [TestMethod]
        public void Subscribers_WithMessagePosted_ShouldReceiveMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                MessageBroker mb = new MessageBroker();

                ISubscriber subscriberA = new CustomSubscriber("Subscriber A");
                ISubscriber subscriberB = new CustomSubscriber("Subscriber B");

                IMessage message = new CustomMessage("Test header", "Test message");

                mb.Subscribe(subscriberA);
                mb.Subscribe(subscriberB);

                mb.Post(message);

                StringAssert.Contains(sw.ToString(), "Test header");
                StringAssert.Contains(sw.ToString(), "Test message");
            }
        }


        [TestMethod]
        public void Subscribers_WhenUnsubscribed_ShouldNotReceiveMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                MessageBroker mb = new MessageBroker();

                ISubscriber subscriberA = new CustomSubscriber("Subscriber A");
                ISubscriber subscriberB = new CustomSubscriber("Subscriber B");

                IMessage message = new CustomMessage("Test header", "Test message");

                mb.Subscribe(subscriberA);
                mb.Subscribe(subscriberB);

                mb.Unsubscribe(subscriberA);
                mb.Unsubscribe(subscriberB);

                mb.Post(message);

                Assert.AreEqual("", sw.ToString());
            }
        }
    }
}
