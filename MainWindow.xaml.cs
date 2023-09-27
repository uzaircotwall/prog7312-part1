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

namespace DeweyDecimalTrainingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> callNumbers;       // List to store randomly generated call numbers.
        private List<string> sortedCallNumbers; // List to store sorted call numbers.
        private int userPoints;                 // Variable to track user points.

        public MainWindow()
        {
            InitializeComponent();
            userPoints = 0; // Initialize user points to zero when the window is created.
        }

        private void StartReplacingBooksTask_Click(object sender, RoutedEventArgs e)
        {
            MinimizeHomeScreen();
            GenerateCallNumbers();
        }



        private List<string> GenerateRandomCallNumbers(int count)
        {
            Random random = new Random();
            List<string> numbers = new List<string>();

            for (int i = 0; i < count; i++)
            {
                // Generate a random call number with format XXX.XX ABC (e.g., 123.45 XYZ).
                string number = $"{random.Next(1000):000}.{random.Next(100):00} {GenerateRandomAuthorInitials()}";
                numbers.Add(number);
            }
            return numbers;
        }

        private string GenerateRandomAuthorInitials()
        {
            Random random = new Random();
            string initials = "";
            for (int i = 0; i < 3; i++)
            {
                // Generate three random uppercase letters as author initials (e.g., ABC).
                initials += (char)('A' + random.Next(26));
            }
            return initials;
        }

        private void DisplayCallNumbers(List<string> numbers)
        {
            CallNumberTextBox.Text = string.Join(Environment.NewLine, numbers);
        }

        private void CheckOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Split user-entered call numbers into a list.
            List<string> userOrderedNumbers = UserOrderTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (userOrderedNumbers.SequenceEqual(sortedCallNumbers))
            {
                // Award points for the correct order.
                userPoints += 10;

                // Update points label with the new points value.
                PointsLabel.Content = $"Points: {userPoints}";

                MessageBox.Show("Congratulations! You got the order right.");
                // Implement gamification feature here (Narrative and Storytelling).
                MessageBox.Show("You have successfully replaced the books!");
            }
            else
            {
                MessageBox.Show("Sorry, the order is incorrect. Try again.");
            }
        }
        private void GenerateCallNumbers()
        {
            UserOrderTextBox.Clear();
            callNumbers = GenerateRandomCallNumbers(10); // Generate 10 random call numbers.
            sortedCallNumbers = callNumbers.OrderBy(cn => cn).ToList(); // Sort the call numbers.

            DisplayCallNumbers(callNumbers); // Display the randomly generated call numbers.
        }

        private void MinimizeHomeScreen()
        {
            RBTStackPanel.Visibility = Visibility.Visible;
            HomeStackPanel.Visibility = Visibility.Collapsed;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            RBTStackPanel.Visibility = Visibility.Collapsed;
            HomeStackPanel.Visibility = Visibility.Visible;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GenerateCallNumbers();
        }
    }
}