using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace GridViewExample.Modules
{
    class Person
    {
        public string Name { get; }
        public int Age { get; }
        public string ImagePath { get; }
        public Color FavoriteColor  { get; }

        public Person(string name, int age, string imagePath, Color favoriteColor)
        {
            Name = name;
            Age = age;
            ImagePath = imagePath;
            FavoriteColor = favoriteColor;
        }
    }
}
