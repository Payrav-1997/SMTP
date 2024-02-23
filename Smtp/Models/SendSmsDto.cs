using System.ComponentModel.DataAnnotations;

namespace Smtp.Models;

public class SendSmsDto
{
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Message { get; set; }
}




// using System.IO;
// using JamaaTech.Smpp.Net.Client;
// using JamaaTech.Smpp.Net.Lib;
//
// class Program
// {
//     static void Main(string[] args)
//     {
//         SmppClient client = new SmppClient();
//
//         SmppConnectionProperties properties = client.Properties;
//         properties.SystemID = "kor.tj_smpp";
//         properties.Password = "Gtf7H54M";
//         properties.Port = 2775;
//         properties.Host = "217.11.189.250";
//         properties.SystemType = "";
//         properties.DefaultServiceType = "";
//         properties.DefaultEncoding = DataCoding.UCS2;
//         properties.SourceAddress = "VozhaOmuz";
//         properties.AddressTon = TypeOfNumber.Alphanumeric;
//         properties.AddressNpi = NumberingPlanIndicator.Unknown;
//
//         client.AutoReconnectDelay = 3000;
//         client.KeepAliveInterval = 15000;
//         client.Start();
//         client.ConnectionStateChanged += client_ConnectionStateChanged;
//
//         Console.WriteLine("SMPP client connected.");
//
//         string filePath = "C:\\Users\\Администратор\\source\\repos\\ConsoleApp1\\ConsoleApp1\\sms.txt"; // Path to your text file
//         string[] lines = File.ReadAllLines(filePath);
//
//         while (client.ConnectionState != SmppConnectionState.Connected)
//         {
//             if (client.ConnectionState == SmppConnectionState.Connected)
//             {
//                 foreach (string line in lines)
//                 {
//                     string[] parts = line.Split(',');
//                     if (parts.Length == 2)
//                     {
//                         string number = parts[0].Trim();
//                         string message = parts[1].Trim();
//
//                         TextMessage msg = new TextMessage
//                         {
//                             DestinationAddress = number,
//                             Text = message,
//                             RegisterDeliveryNotification = true
//                         };
//
//                         client.SendMessage(msg);
//                     }
//                 }
//             }
//         }
//
//         Console.ReadLine();
//     }
//
//     static void client_ConnectionStateChanged(object? sender, ConnectionStateChangedEventArgs e)
//     {
//         Console.WriteLine(e.CurrentState);
//         switch (e.CurrentState)
//         {
//             case SmppConnectionState.Closed:
//                 e.ReconnectInteval = 1000;
//                 break;
//             case SmppConnectionState.Connected:
//                 break;
//             case SmppConnectionState.Connecting:
//                 break;
//         }
//     }
// }
