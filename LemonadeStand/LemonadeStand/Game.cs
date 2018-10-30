﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        private Day day;
        private Player player;
        private Store store;
        private int amountOfDays;
        private int currentDay;

        public Game()
        {
            player = new Player();
            store = new Store(player);
            day = new Day(player);
            currentDay = 0;
        }
        public void StartGame()
        {
            DisplayGameInfo("welcome");
            player.SetName();
            SetDaysToPlay();
        }
        private void PlayerMenu()
        {
            Console.WriteLine("--Player Menu--");
            DisplayInventory();
            PlayerActions();
            Console.ReadLine();
        }
        private void PlayerActions()
        {
            Console.WriteLine("\nType: \n(1) to visit store\n(2) to set recipe");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    store.EnterStore();
                    break;
                case 2:
                    player.SetRecipe();
                    break;
                default:
                    Console.WriteLine("You have entered an invalid input. Please try again.");
                    PlayerActions();
                    return;
            }
        }
        private void SetDaysToPlay()
        {
            Console.WriteLine("\nHow many days would you like to play for?");
            amountOfDays = Convert.ToInt32(Console.ReadLine());
            PlayerMenu();
        }
        private void DisplayGameInfo(string thisCase)
        {
            switch (thisCase)
            {
                case "welcome":
                    Console.WriteLine("Welcome to Lemonade Stand!");
                    break;
                default:
                    break;
            }
        }
        private void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine("--Inventory--\nMoney: $" + player.wallet.Money + "\nLemons: " + player.lemons.amount + "\nCups of sugar: " + player.sugar.amount + "\nPieces of ice: " + player.ice.amount + "\nCups: " + player.cups.amount + "\n\nDay: " + currentDay + " / " + amountOfDays );
          
        }
    }
}
