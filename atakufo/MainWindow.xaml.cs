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

using System.IO;
using Windows.Foundation;

using System.Windows.Media.Animation;

namespace atakufo
{
    /// <summary>
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Random random = new Random(); // generator psuedo

        public Page1()
        {
            InitializeComponent();
        }
        private void DodajWroga()
        {
            ContentControl wrog = new ContentControl(); // nowy obiekt typu Content Control. 
            wrog.Template = Resources["EnemyTemplate2"] as ControlTemplate;
            WygenerujUFO(wrog, 0, playArea.ActualWidth - 100, new PropertyPath("(Canvas.Left)"));
            // WygenerujUFO(wrog, random.Next((int)playArea.ActualHeight - 10),
            WygenerujUFO(wrog, random.Next((int)playArea.ActualHeight - 100), random.Next((int)playArea.ActualHeight - 100), new PropertyPath("(Canvas.Top)"));
            //  random.Next((int))playArea.ActualHeight - 10), "(Canvas.Top)");
            //WygenerujUFO(wrog, random.Next((int)playArea.ActualHeight - 25), random.Next((int)playArea.ActualHeight - 25), new PropertyPath("(Canvas.Top)"))); // dodana z drugie źródła
            playArea.Children.Add(wrog);


        }
        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            DodajWroga();

        }

        

        private void WygenerujUFO(ContentControl wrog, double from, double to, PropertyPath propertyToAnimate)
        {
            
            
           //     throw new NotImplementedException(); // tu wyjebuje wyjatek
            
            Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 4)))
            };
            Storyboard.SetTarget(animation, wrog);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);
            storyboard.Children.Add(animation);
            storyboard.Begin();




        }
    }
}
