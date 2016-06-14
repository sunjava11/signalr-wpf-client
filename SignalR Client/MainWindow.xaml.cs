using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SignalR_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IHubProxy _myHub;
            string connectionUrl = @"http://localhost:59393/signalr";
            var hubConnection = new HubConnection(connectionUrl);
            _myHub = hubConnection.CreateHubProxy("myServerHub");
            hubConnection.Start().Wait();

            _myHub.On("DownloadContent", new Action(() =>
            {
                MessageBox.Show("server has executed the client");
            }));
        }
    }
}
