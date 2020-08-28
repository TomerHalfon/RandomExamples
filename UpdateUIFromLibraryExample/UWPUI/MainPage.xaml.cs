using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Manager _manager;
        public MainPage()
        {
            this.InitializeComponent();
            _manager = new Manager();
            //Register a way of updating the UI the the "suite"
            _manager.updatedAmount += UpdateUI;
        }
        //Here is how we update the UI
        private void UpdateUI() => MoneyViewBlock.Text = _manager.Amount.ToString("C");
        //This is when we update the property
        private void UpdateMoney_Click(object sender, RoutedEventArgs e) => _manager.UpdateAmount();
    }
}