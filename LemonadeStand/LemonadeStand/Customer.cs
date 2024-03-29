﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        private Weather weather;
        private Player player;
        public bool choice;
        private List<string> names;
        public string name;
        public Customer(Weather weather, Player player, Random random)
        {
            names = new List<string>() { "David", "John", "Paul", "Mark", "James", "Andrew", "Scott", "Steven", "Robert", "Stephen", "William", "Craig", "Michael", "Stuart", "Christopher", "Alan", "Colin", "Brian", "Kevin", "Gary", "Richard", "Derek", "Martin", "Thomas", "Neil", "Barry", "Ian", "Jason", "Iain", "Gordon", "Alexander", "Graeme", "Peter", "Darren", "Graham", "George", "Kenneth", "Allan", "Simon", "Douglas", "Keith", "Lee", "Anthony", "Grant", "Ross", "Jonathan", "Gavin", "Nicholas", "Joseph", "Stewart", "Daniel", "Edward", "Matthew", "Donald", "Fraser", "Garry", "Malcolm", "Charles", "Duncan", "Alistair", "Raymond", "Philip", "Ronald", "Ewan", "Ryan", "Francis", "Bruce", "Patrick", "Alastair", "Bryan", "Marc", "Jamie", "Hugh", "Euan", "Gerard", "Sean", "Wayne", "Adam", "Calum", "Alasdair", "Robin", "Greig", "Angus", "Russell", "Cameron", "Roderick", "Norman", "Murray", "Gareth", "Dean", "Eric", "Adrian", "Gregor", "Samuel", "Gerald", "Henry", "Justin", "Benjamin", "Shaun" };
            this.weather = weather;
            this.player = player;
            SetName();
        }
        private void SetName()
        {
            System.Threading.Thread.Sleep(125);
            name = names[UI.random.Next(0, names.Count - 1)];
        }

        public void DecisionToBuy(Day day)
        {
            AI ai = new AI(weather, player);
            choice = ai.RunAI();
            if (player.pitcher.Cups < 0)
            {
                choice = false;
            }else if(player.pitcher.PriceOfGlass > 0.80 && weather.Temperature < 95)
            {
                choice = false;
            }
            else
            {
                if (choice == true)
                {
                    day.bought++;
                    player.pitcher.CheckAmountOfCupsLeftPerPitcher();
                    GiveMoney();
                    TakeCup();
                }
                else
                {
                    return;
                }
            }
        }
        private void GiveMoney()
        {
            player.wallet.IncrementMoney(player.pitcher.PriceOfGlass);
        }
        private void TakeCup()
        {
            Console.WriteLine("Cups: " + player.pitcher.Cups);
            player.pitcher.DecrementCups();
        }

    }
}
