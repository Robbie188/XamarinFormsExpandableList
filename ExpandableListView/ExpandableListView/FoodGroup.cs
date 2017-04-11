using Java.Lang;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpandableListView
{
    /// <summary>
    /// A list of lists
    /// </summary>
    
    public class FoodGroup : ObservableCollection<Food>, INotifyPropertyChanged
    {

        private bool _expanded;

        public string Title { get; set; }

        public string TitleWithItemCount{
            get {return string.Format("{0} ({1})", Title,FoodCount);}
        }

        public string ShortName { get; set; }

        public bool Expanded{
            get { return _expanded;}
            set{ if (_expanded != value){
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }
        
        public string StateIcon{
            get{return Expanded ? "expanded_blue.png" : "collapsed_blue.png";}
        }
        
        public int FoodCount { get; set; }

        public FoodGroup(string title, string shortName, bool expanded = true){
            Title = title;
            ShortName = shortName;
            Expanded = expanded;
        }

        public static ObservableCollection<FoodGroup> All { private set; get; }

        static FoodGroup(){
            ObservableCollection<FoodGroup> Groups = new ObservableCollection<FoodGroup>{
                new FoodGroup("Carbohydrates","C"){
                    new Food { Name = "pasta", Description = "Carb Snakes",  Icon="pasta.png" },
                    new Food { Name = "potato", Description = "The King of all Carbs", Icon="potato.png" },
                    new Food { Name = "bread", Description = "Soft & Gentle", Icon="bread.png" },
                    new Food { Name = "rice", Description = "Tiny grains of goodness", Icon="rice.png" },
                },
                new FoodGroup("Fruits","F"){
                    new Food { Name = "apple", Description = "Keep the Doctor away", Icon="apple.png"},
                    new Food { Name = "banana", Description = "This fruit is appeeling", Icon="banana.png"},
                    new Food { Name = "pear", Description = "Pear with me", Icon="pear.png"},
                },
                new FoodGroup("Vegetables","V"){
                    new Food { Name = "carrot", Description = "Sounds like parrot", Icon="carrot.png"},
                    new Food { Name = "green bean", Description = "The less popular cousin of the baked bean", Icon="greenbean.png"},
                    new Food { Name = "broccoli", Description = "Tiny food trees", Icon="broccoli.png"},
                    new Food { Name = "peas", Description = "Peas sir, can I have some more?", Icon="peas.png"},
                },
                new FoodGroup("Dairy","D"){
                    new Food { Name = "Milk", Description = "Molk", Icon="milk.png"},
                    new Food { Name = "Cheese", Description = "Cheese + Potato = <3", Icon="cheese.png"},
                    new Food { Name = "Ice Cream", Description = "Because I couldn't find an icon for yoghurt", Icon="icecream.png"},

                } };
            All = Groups;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    
}
