using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GridViewExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //The gridview itemsource takes object, that means that grid view can display anything! (doesn't have to be something specific)
        //an excaption for this statement is that if you want to display an object containing multiple objects(a collection for example)
        //that object must implement the IEnumrable interface
        IEnumerable<Modules.Person> _people = new Modules.Person[] 
        {
                new Modules.Person("Person 1", 30, "ms-appx:///Assets/PersonImages/1.jpg", Color.FromArgb(255, 96 ,175 ,209)),
                new Modules.Person("Person 2", 5, "ms-appx:///Assets/PersonImages/2.png", Color.FromArgb(255, 59 ,213 ,121)),
                new Modules.Person("Person 3", 5, "ms-appx:///Assets/PersonImages/3.png", Color.FromArgb(255, 212 ,81 ,55)),
                new Modules.Person("Person 4", 5, "ms-appx:///Assets/PersonImages/4.png", Color.FromArgb(255, 212 ,55 ,186))
        };
        public MainPage()
        {
            this.InitializeComponent();
        }
        //The ItemClick event will invoke this method when an item has been clicked
        //it has a sender (the grid view object upcasted to object) and an event args of type ItemClickEventArgs
        // The ItemClickEventArgs has a propery named ClickedItem wich holds the item wich has been clicked upcasted to object
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //pull the clicked item and down cast it to person
            Modules.Person selectecPerson = e.ClickedItem as Modules.Person;
            //set the relevent uielements properies
            InfoImageView.Source = new BitmapImage(new Uri(selectecPerson.ImagePath));
            NameViewBlock.Text = selectecPerson.Name;
            AgeViewBlock.Text = selectecPerson.Age.ToString();
            InfoSP.Background = new SolidColorBrush(selectecPerson.FavoriteColor);
        }
    }
}
