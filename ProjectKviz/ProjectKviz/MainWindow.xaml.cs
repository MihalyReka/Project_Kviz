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
        List<string> tema = new List<string>();
        
        int pontok;
        int i=0 ;
        int sorSzam = 0;


        public MainWindow()
        {
            InitializeComponent();
            FajlBeolvasasa("KvizhezSzoveg.txt");
           
        }

        private void Ellenorzes()
        {
            
            
            if (valaszA.IsChecked==true && valaszA.Content == kviz[i].Helyes)
                pontok = pontok + 1;
            else if (valaszB.IsChecked == true && valaszB.Content == kviz[i].Helyes)
                pontok = pontok + 1;
            else if (valaszC.IsChecked == true && valaszC.Content == kviz[i].Helyes)
                pontok = pontok + 1;
            else if (valaszD.IsChecked == true && valaszD.Content == kviz[i].Helyes)
                pontok = pontok + 1;


        }


        private void FajlBeolvasasa(string fajlNeve)
        {
            kviz = new List<Kviz>();
            foreach (var s in File.ReadAllLines(fajlNeve))
            {
                kviz.Add(new Kviz(s));
            }
            
           
            tantargyCB.ItemsSource = tantargyak;
            valaszA.IsEnabled = false;
            valaszB.IsEnabled = false;
            valaszC.IsEnabled = false;
            valaszD.IsEnabled = false;
            visszaGomb.IsEnabled = false;
            tovabbGomb.IsEnabled = false;
            kiertekeles.IsEnabled = false;
            indit.IsEnabled = false;
        }

        private void tantargyCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string tantargy = tantargyCB.SelectedItem.ToString();
            
            

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
            
            indit.IsEnabled = true;
            string temakor = temakorCB.SelectedItem.ToString();
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
            if (sorSzam<10)
            {
                sorSzam++;
            }
            
            sorszam.Content =sorSzam +".";
            if (i%10+1<=10)
            {
                i++;
            }
            

            kerdes.Content = kviz[i].Kerdes;
            valaszA.Content = kviz[i].ValaszA;
            valaszC.Content = kviz[i].ValaszC;
            valaszB.Content = kviz[i].ValaszB;
            valaszD.Content = kviz[i].ValaszD;




        }

        private void visszaGomb_Click(object sender, RoutedEventArgs e)
        {
            
            if (sorSzam>1)
            {
                sorSzam--;
            }
            
            sorszam.Content = sorSzam + ".";
            if (i>0)
            {
                i = i - 1;
            }
            kerdes.Content = kviz[i].Kerdes;
            valaszA.Content = kviz[i].ValaszA;
            valaszC.Content = kviz[i].ValaszC;
            valaszB.Content = kviz[i].ValaszB;
            valaszD.Content = kviz[i].ValaszD;

        }

        private void kiertekeles_Click(object sender, RoutedEventArgs e)
        {
            Ellenorzes();
            MessageBox.Show($"Elért pontszáma a 10-ből: {pontok} ");
            tantargyCB.IsEnabled = true;
            temakorCB.IsEnabled = true;
        }

        private void indit_Click(object sender, RoutedEventArgs e)
        {
           
            

            valaszA.IsEnabled=true;
            valaszB.IsEnabled = true;
            valaszC.IsEnabled = true;
            valaszD.IsEnabled = true;
            visszaGomb.IsEnabled = true;
            tovabbGomb.IsEnabled = true;
            kiertekeles.IsEnabled = true;
            temakorCB.IsEnabled = false;
            tantargyCB.IsEnabled = false;
            Ellenorzes();

            
        }
    }
}
