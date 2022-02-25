using System;
using System.Collections.Generic;
using System.IO;
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

namespace ProjectKviz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Kviz> kviz;
        List<string> tantargyak = new List<string>() { "töri", "matek" };

        public MainWindow()
        {
            InitializeComponent();
            FajlBeolvasasa("KvizhezSzoveg.txt");
        }

        private void FajlBeolvasasa(string fajlNeve)
        {
            kviz = new List<Kviz>();
            foreach (var s in File.ReadAllLines(fajlNeve).Skip(1))
            {
                kviz.Add(new Kviz(s));
            }
            
           
            tantargyCB.ItemsSource = tantargyak;

        }

        private void tantargyCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string tantargy = tantargyCB.SelectedItem.ToString();
            
            List<string> tema = new List<string>();

            foreach (var v in kviz)
            {
                tema.Add(v.Tema);
            }
            List<string> toriTemak = new List<string>() { "vegyes","dátum" };
            List<string> matekTemak = new List<string>() { "számelmélet", "fogalmak" };
         
            

            if (tantargy=="töri")
            {
                temakorCB.ItemsSource = toriTemak;
            }
            else if (tantargy=="matek")
            {
                temakorCB.ItemsSource = matekTemak;    
            }

        }

        private void TemakorCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string temakor = temakorCB.SelectedItem.ToString();
            int i = 0;
            while (i < kviz.Count && kviz[i].Tema != temakor)
                i++;
            kerdes.Content = kviz[i].Kerdes;
            valaszA.Content = kviz[i].ValaszA;
            valaszC.Content = kviz[i].ValaszC;
            valaszB.Content = kviz[i].ValaszB;
            valaszD.Content = kviz[i].ValaszD;

        }

        private void tovabbGomb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void visszaGomb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kiertekeles_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
