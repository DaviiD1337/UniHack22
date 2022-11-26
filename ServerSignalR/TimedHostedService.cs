/*using ServerSignalR.Hubs;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;
using System.IO.Ports;

namespace ServerSignalR
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        HubConnection hubConnection;
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer = null!;
        public MoveViewHub moveViewHub = new MoveViewHub();
        SerialPort myport;
        string FinalMessage;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);

            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.16:7500/movehub").Build();

            Task.Run(async () =>
            {
                await hubConnection.StartAsync();
            });


            hubConnection.On<string>("ReceiveNewPosition", (message) =>
            {
               FinalMessage = message + DateTime.Now.ToLongTimeString();

            });

            Debug.WriteLine(FinalMessage + DateTime.Now.ToLongTimeString());
            try
            {
                myport = new SerialPort();
                myport.BaudRate = 9600;
                myport.PortName = "COM9";
                myport.DataBits = 8;
                myport.StopBits = StopBits.One;
                myport.Handshake = Handshake.None;
                //    myport.Close();
                myport.Open();

                myport.WriteLine(FinalMessage);

                myport.Close();
            }
            catch (Exception)
            {

            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
*/