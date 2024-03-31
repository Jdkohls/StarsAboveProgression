using static Terraria.ModLoader.ModContent;
using StarsAbove;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using StarsAbove.Items.Essences;
using Terraria.GameContent.Creative;
using StarsAbove.Projectiles.Summon.SparkblossomBeacon;

namespace StarsAboveProgression.Items.Weapons.Summon
{
    public class SparkblossomBeacon : GlobalItem
    {
        private int real_id => ModContent.ItemType<StarsAbove.Items.Weapons.Summon.SparkblossomBeacon>();

        public override void SetDefaults(Item item)
        {if(item.type == real_id){
                item.damage = 50;
        }}
        

        // Need to get working- aaaaa
        // theres may be a default method for this, so we're suffering.

        
        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {if(item.type == real_id){
                bool slimeKing = NPC.downedSlimeKing;
                bool anyMech = NPC.downedMechBossAny;
                bool allMechs = NPC.downedMechBoss3 && NPC.downedMechBoss2 && NPC.downedMechBoss1;
                bool plantera = NPC.downedPlantBoss;
                bool golem = NPC.downedGolemBoss;
                bool cultist = NPC.downedAncientCultist;
                bool moonLord = NPC.downedMoonlord;

                float damageMult = 1f + 
                    (slimeKing ? 12f : 0f) +
                    (anyMech ? 0.23f : 0f) +
                    (allMechs ? 0.3f : 0f) +
                    (plantera ? 1.4f : 0f) +
                    (golem ? 2f : 0f) +
                    (cultist ? 2f : 0f) +
                    (moonLord ? 2f : 0f);
                damage *= damageMult;
        }}
    }
}