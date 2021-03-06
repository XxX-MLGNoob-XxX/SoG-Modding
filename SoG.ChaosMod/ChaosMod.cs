﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoG.GrindScript;

namespace SoG.ChaosMod
{
    public class ChaosMod : BaseScript
    {
        private bool dead = false;

        public ChaosMod()
        {
            Console.WriteLine("Hello World from Chaosmod!");

            NPC.AddNPCTo(LocalGame, NPCTypes.Desert_Farmer_Boy, new Vector2(1000, 500));
        }

        public override void OnDraw()
        {
            if(!dead)
                return;

            var font = GetFont(FontType.Verdana20);

            
            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            SpriteBatch.DrawString(font, "Oii, dead mate!", new Vector2(200,100), Color.Red);
            SpriteBatch.End();

        }

        public override void OnPlayerDamaged(ref int damage, ref byte type)
        {
            Console.WriteLine("Orignal damage taken: " + damage + " of type: " + type);
            damage = 10 * 1000;
            Console.WriteLine("New damage taken: " + damage + " of type: " + type);
        }

        public override void OnPlayerKilled()
        {
            dead = true;
        }

        public override void OnEnemyDamaged(Enemy enemy, ref int damage, ref byte type)
        {
            Console.WriteLine(enemy.Type + "::" + damage + "::" + type.ToString());
        }

        public override void OnNPCDamaged(NPC npc, ref int damage, ref byte type)
        {
            Console.WriteLine("NPC damaged...");
            Console.WriteLine(damage + "::" + type.ToString());
        }
    }
}
