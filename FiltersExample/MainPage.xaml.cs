using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FiltersExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Perosn> _people = new List<Perosn>
        {
            new Perosn("Man1","Nathan",20),
            new Perosn("Man2","Cohen",30),
            new Perosn("Man3","Parker",40),
        };
        FilterManager<Perosn> _filterManager;
        public MainPage()
        {
            this.InitializeComponent();
            _filterManager = new FilterManager<Perosn>(_people, FirstNameFilter, LastNameFilter, AgeFilter);
            View.ItemsSource = _filterManager.FilterdList;
        }
        bool AgeFilter(Perosn perosn) => int.TryParse(FilterAgeBox.Text, out int age) ? perosn.Age.Equals(age) : FilterAgeBox.Text.Equals(string.Empty);
        bool FirstNameFilter(Perosn perosn) => FilterFirstNameBox.Text.Equals(string.Empty) || perosn.FirstName.ToLower().StartsWith(FilterFirstNameBox.Text.ToLower());
        bool LastNameFilter(Perosn perosn) => FilterLastNameBox.Text.Equals(string.Empty) || perosn.LastName.ToLower().StartsWith(FilterLastNameBox.Text.ToLower());
        
        private void FilterAgeBox_TextChanged(object sender, TextChangedEventArgs e) => _filterManager.ApplyFilters();
        private void FilterFirstNameBox_TextChanged(object sender, TextChangedEventArgs e) => _filterManager.ApplyFilters();
        private void FilterLastNameBox_TextChanged(object sender, TextChangedEventArgs e) => _filterManager.ApplyFilters();
    }
}
