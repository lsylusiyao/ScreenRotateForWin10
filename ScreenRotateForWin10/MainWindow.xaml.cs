using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

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
        private int currScreenID = 0;
        private int primaryScreenID = 0;
        private readonly List<Screen> allScreens = Screen.AllScreens.ToList();

        private void Init()
        {
            var result = new List<string>();
            
            screenCount = allScreens.Count;
            result.AddRange(
                Enumerable.Range(0, screenCount)
                .Select(x => $"{x + 1}号屏幕") // $"NO.{x + 1} Screen"
                );
            result.Add("所有"); // All

            primaryScreenID = allScreens.IndexOf(Screen.PrimaryScreen) + 1;
            primaryScreenLabel.Content = $"主屏幕：{primaryScreenID}号屏幕"; // "Primary Screen: NO.? Screen"

            screenList = result;
            choiceComboBox.ItemsSource = screenList;
            choiceComboBox.SelectedIndex = result.Count - 1; // Last

            Window_LocationChanged(null, null); // currScreen label changed
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

        private void DefaultButton_Click(object sender, RoutedEventArgs e) => Display.ResetAllRotations(screenCount);

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

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            var currScreen = Screen.FromHandle(new WindowInteropHelper(this).Handle);
            currScreenID = allScreens.IndexOf(currScreen) + 1;
            currScreenLabel.Content = $"当前：{currScreenID}号屏幕"; // "Curr: NO.? Screen"
        }
    }
}
