﻿using System;
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
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using Ch13CardLib;


namespace KarliCards.Gui
{
    /// <summary>
    /// Interaction logic for StartGameWindow.xaml
    /// </summary>
    public partial class StartGameWindow : Window
    {
        private GameOptions gameOptions;
        public StartGameWindow()
        {
            /*
            if (gameOptions == null)
            {

                if (File.Exists("GameOptions.xml"))
                {
                    using (var stream = File.OpenRead("GameOptions.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(GameOptions));
                        gameOptions = serializer.Deserialize(stream) as GameOptions;
                    }
                }


                else
                    gameOptions = new GameOptions();
            }
            

            DataContext = gameOptions;
            */
            InitializeComponent();

            DataContextChanged += StartGame_DataContextChanged;
            
           
        }
        private void ChangeListBoxOptions()
        {
            if (gameOptions.PlayAgainstComputer)
                playerNamesListBox.SelectionMode = SelectionMode.Single;
            else
                playerNamesListBox.SelectionMode = SelectionMode.Extended;

        }

        private void PlayerNamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (gameOptions.PlayAgainstComputer)
                okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == 1);
            else
                okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == gameOptions.NumberOfplayers);
        }

        private void AddNewPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newPlayerTextBox.Text))
                gameOptions.AddPlayer(newPlayerTextBox.Text);
            newPlayerTextBox.Text = string.Empty;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var gameOptions = DataContext as GameOptions;
            gameOptions.SelectedPlayers = new List<string>();
            foreach (string item in playerNamesListBox.SelectedItems)
            { gameOptions.SelectedPlayers.Add(item); }
            /*
            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, gameOptions);
            }
            */
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            gameOptions = null;
            Close();
        }
        void StartGame_DataContextChanged(object sender,DependencyPropertyChangedEventArgs e)
        {
            gameOptions = DataContext as GameOptions;
            ChangeListBoxOptions();
            
        }

    }
}
