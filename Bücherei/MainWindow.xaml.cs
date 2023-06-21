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

namespace Bibliotheksverwaltung
{
    public partial class MainWindow : Window
    {
        private List<Buch> buchListe = new List<Buch>(); // Liste von Büchern

        public MainWindow()
        {
            InitializeComponent();  // Benutzeroberfläche

            // Bücher hinzufügen
            buchListe.Add(new Buch { Titel = "Der kleine Prinz", Autor = "Antoine de Saint-Exupéry", Verlag = "Reclam", Erscheinungsjahr = 1943 });
            buchListe.Add(new Buch { Titel = "Harry Potter und der Stein der Weisen", Autor = "J.K. Rowling", Verlag = "Carlsen", Erscheinungsjahr = 1997 });

            // Bücherliste anzeigen
            buchListView.ItemsSource = buchListe; // Setzen der Bücherliste als Datenquelle für die ListView
        }

        private void neuesBuch_Click(object sender, RoutedEventArgs e) //  "Neues Buch hinzufügen"-Button
        {
            // Neues Buch erstellen und neue Eingaben hinzufügen
            Buch buch = new Buch(); //  neues Buch erstelen
            buch.Titel = titelTextBox.Text; // Titels von Buch
            buch.Autor = autorTextBox.Text; // Autors von Buch
            buch.Verlag = verlagTextBox.Text; // Verlag von Buch
            buch.Erscheinungsjahr = int.Parse(erscheinungsjahrTextBox.Text); // Erscheinungsjahrs des Buches

            // Das neues Buch zur Liste hinzufügen
            buchListe.Add(buch);

            // Die ListAnzeigeaktualisieren
            buchListView.Items.Refresh();
        }

        private void buchBearbeiten_Click(object sender, RoutedEventArgs e) // "Bearbeiten" Button
        {
            // Das ausgewählte Buch aus der Listanzeige zeigen
            Buch buch = (Buch)buchListView.SelectedItem;

            // Überprüfen, ob ein Buch ausgewählt wurde
            if (buch != null)
            {
                // Die Eigenschaften von Buch mit den neuen Werten aktualisieren
                buch.Titel = titelTextBox.Text;
                buch.Autor = autorTextBox.Text;
                buch.Verlag = verlagTextBox.Text;
                buch.Erscheinungsjahr = int.Parse(erscheinungsjahrTextBox.Text);

                // Die ListAnzeige aktualisieren
                buchListView.Items.Refresh();
            }
        }

        private void buchEntfernen_Click(object sender, RoutedEventArgs e) // "Entfernen" Button
        {
            // Das ausgewählte Buch aus der ListView abrufen
            Buch buch = (Buch)buchListView.SelectedItem;

            // Überprüfen, ob ein Buch ausgewählt wurde
            if (buch != null)
            {
                // Das Buch aus der Liste entfernen
                buchListe.Remove(buch);

                // Die ListView aktualisieren
                buchListView.Items.Refresh();
            }
        }

        private void erscheinungsjahrTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class Buch // Klasse für ein Buch
    {
        public string Titel { get; set; } // Titel von Buch
        public string Autor { get; set; } // Autor von Buch
        public string Verlag { get; set; } // Verlag von Buch
        public int Erscheinungsjahr { get; set; } // Erscheinungsjahr von Buch
    }
}

    