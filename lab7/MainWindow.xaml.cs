using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GpsTracker tracker;
        private Warehouse warehouse;
        private Truck truck;
        private Customer customer;
        public MainWindow()
        {
            InitializeComponent();

            tracker = new GpsTracker();
            warehouse = new Warehouse();
            truck = new Truck();
            customer = new Customer();

            tracker.arrivedDestination += warehouse.Warehouse_ArrivedEvent;
            tracker.arrivedDestination += truck.Truck_ArrivedEvent;
            tracker.arrivedDestination += customer.Customer_ArrivedEvent;

            tracker.deviationFromRoute += () => LogMessage("Трекер: відхилення від маршруту!");

            warehouse.MessageGenerated += LogMessage;
            truck.MessageGenerated += LogMessage;
            customer.MessageGenerated += LogMessage;

            tracker.locationUpdated += (dist) => LogMessage($"Трекер оновлено: залишилось {dist} км.");
        }

        private void LogMessage(string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            lbLog.Items.Add($"[{time}] {message}");

            lbLog.ScrollIntoView(lbLog.Items[lbLog.Items.Count - 1]);
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDistance.Text, out double distance))
            {
                txtDistance.Clear();

                while (distance > 0)
                {
                    tracker.UpdateLocation(distance);
                    distance -= 5;
                    await Task.Delay(1000);
                }

                tracker.UpdateLocation(distance);
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректне число.");
            }
        }
    }
}