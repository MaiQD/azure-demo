//connection string to your service bus namespace
using Azure.Messaging.ServiceBus;
using System.Text;

var connectionString = "Endpoint=sb://datmq-servicebus-namespace.servicebus.windows.net/;SharedAccessKeyName=ReadWrite;SharedAccessKey=tKJXlvwCDGrsK+t9VbGOMarc+ztwNWD5p2QvZVP7UHE=;";

var queueName = "servicebus-test";

ServiceBusClient client = new ServiceBusClient(connectionString);
ServiceBusSender sender = client.CreateSender(queueName);

Console.WriteLine("Enter your message:");
var message = Console.ReadLine();

//for loop 0 - 10
for (int i = 0; i < 10; i++)
{
	var sentMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes($"{message} - {i}"));
	// Send the message to the queue
	await sender.SendMessageAsync(sentMessage);
}