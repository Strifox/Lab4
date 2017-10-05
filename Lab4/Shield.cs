﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Shield : Board, IDurability
    {
        private int durability = 3;
        private string icon = "¤";
        private ConsoleColor color = ConsoleColor.DarkCyan;
        private bool tileExplored;
        public override bool TileExplored { get { return tileExplored; } set { tileExplored = value; } }
        public override ConsoleColor Color { get { return color; } set { color = value; } }
        public override string Icon { get { return icon; } set { value = icon; } }
        // Interface
        public int Durability { get { return durability; } set { durability = value; } }

        public void CheckDurability()
        {
            if (Durability <= 0)
                Player.playerHealthPoints -= 20;
        }

        public void HealthBoost()
        {
            Player.playerHealthPoints += 20;
        }

        public Shield() : base()
        { }

    }
}

