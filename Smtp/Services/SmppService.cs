using JamaaTech.Smpp.Net.Client;
using JamaaTech.Smpp.Net.Lib;
using Smtp.Models;

namespace Smtp.Services;

public class SmppService : ISmppService
{
    public Task<BaseResponse> Send(SendSmsDto dto)
    {
        SmppClient client = new SmppClient();
        
        SmppConnectionProperties properties = client.Properties;
        properties.SystemID = "Your smpp Login";
        properties.Password = "Your password";
        properties.Port = 0000; //Port
        properties.Host = "IP";
        properties.SystemType = "";
        properties.DefaultServiceType = "";
        properties.DefaultEncoding = DataCoding.UCS2;
        properties.SourceAddress = "Your Address";
        properties.AddressTon = TypeOfNumber.Alphanumeric;
        properties.AddressNpi = NumberingPlanIndicator.Unknown;

        client.AutoReconnectDelay = 3000;
        client.KeepAliveInterval = 15000;
        client.Start();
        client.ConnectionStateChanged += ClientConnectionStateChanged;

        Console.WriteLine("SMPP client connected.");

        var msg = new TextMessage();

        msg.DestinationAddress = dto.Phone;
        msg.Text = dto.Message;
        msg.RegisterDeliveryNotification = true;

        while (client.ConnectionState != SmppConnectionState.Connected)
        {
            if (client.ConnectionState == SmppConnectionState.Connected)
            {
                try
                {
                    client.SendMessage(msg);
                    Console.WriteLine("SMPP client sent!");
                }
                catch (Exception e)
                {
                    return Task.FromResult(BaseResponse.Error());
                }
               
            }
        }

        Console.ReadLine();


        return Task.FromResult(BaseResponse.Ok());

        static void ClientConnectionStateChanged(object? sender, ConnectionStateChangedEventArgs e)
        {
            Console.WriteLine(e.CurrentState);
            switch (e.CurrentState)
            {
                case SmppConnectionState.Closed:
                    e.ReconnectInteval = 1000;
                    break;
                case SmppConnectionState.Connected:
                    break;
                case SmppConnectionState.Connecting:
                    break;
            }

        }
    }
}