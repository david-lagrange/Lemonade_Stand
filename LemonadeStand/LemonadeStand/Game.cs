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

        public Game()
        {
            player = new Player();
            store = new Store(player);
            day = new Day(player);
        }
        public void StartGame()
        {

        }
    }
}
