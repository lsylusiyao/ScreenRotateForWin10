using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ScreenRotateForWin10
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Init();
        }

        private List<string> screenList = new List<string>();
        private int screenCount = 0;

        private void Init()
        {
            var result = new List<string>();
            result.AddRange(
                Enumerable.Range(1, (int)(Display.GetScreenCount()))
                .Select(x => $"{x}号屏幕") // $"NO.{x} Screen"
                );
            result.Add("所有"); // All
            screenList = result;
            choiceComboBox.ItemsSource = screenList;
            screenCount = (int)Display.GetScreenCount();
        }

        private void RotateChoice(int choice, Display.Orientations degree)
        {
            if (choice == screenCount) // choose "All"
            {
                for (int i = 1; i <= screenCount; ++i) 
                    Display.Rotate((uint)i, degree);
            }
            else
            {
                Display.Rotate((uint)choice + 1, degree);
            }
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e) => Display.ResetAllRotations();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RotateChoice(choiceComboBox.SelectedIndex, Display.Orientations.DEGREES_CW_0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RotateChoice(choiceComboBox.SelectedIndex, Display.Orientations.DEGREES_CW_270);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RotateChoice(choiceComboBox.SelectedIndex, Display.Orientations.DEGREES_CW_180);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RotateChoice(choiceComboBox.SelectedIndex, Display.Orientations.DEGREES_CW_90);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RotateChoice(choiceComboBox.SelectedIndex, Display.Orientations.DEGREES_CW_0);
        }
    }
}
