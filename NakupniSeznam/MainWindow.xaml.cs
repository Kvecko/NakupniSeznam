using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NakupniSeznam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            JsonExample example = new JsonExample
            {
                Name = txtName.Text,
            };

            string json = JsonConvert.SerializeObject(example);

            File.WriteAllText($"{Environment.CurrentDirectory}/file.json", json);
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            string filePath = $"{Environment.CurrentDirectory}/file.json";

            if (File.Exists(filePath))
            {
                string js = File.ReadAllText(filePath);
                JsonExample example = JsonConvert.DeserializeObject<JsonExample>(js);

                txtName.Text = example.Name;
            }
            else
            {
                MessageBox.Show("Nebyl vytvořen žádný seznam");
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            string filePath = $"{Environment.CurrentDirectory}/file.json";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                MessageBox.Show("Seznam úspěšne smazán");
            }
            else
            {
                MessageBox.Show("Nebyl nalezen seznam pro smazání");
            }
        }
    }
}