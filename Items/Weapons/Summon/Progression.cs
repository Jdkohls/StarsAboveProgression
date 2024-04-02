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
                item.damage = 4;
        }}
        

        // Need to get working- aaaaa
        // theres may be a default method for this, so we're suffering.

        
        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {if(item.type == real_id){
            bool slimeKing = NPC.downedSlimeKing;
            bool eye = NPC.downedBoss1;
            bool evilboss = NPC.downedBoss2;
            bool queenBee = NPC.downedQueenBee;
            bool skeletron = NPC.downedBoss3;
            bool hardmode = Main.hardMode;
            bool queenSlime = NPC.downedQueenSlime;
            bool anyMech = NPC.downedMechBossAny;
            bool allMechs = NPC.downedMechBoss3 && NPC.downedMechBoss2 && NPC.downedMechBoss1;
            bool plantera = NPC.downedPlantBoss;
            bool golem = NPC.downedGolemBoss;
            bool cultist = NPC.downedAncientCultist;
            bool moonLord = NPC.downedMoonlord;

            float damageMult = 1f +
                (slimeKing ? 0.15f : 0f) +
                (eye ? 0.2f : 0f) +
                (evilboss ? 0.2f : 0f) +
                (queenBee ? 0.36f : 0f) +
                (skeletron ? .5f : 0f) +
                (hardmode ? 1.75f : 0f) +
                (queenSlime ? 1.2f : 0f) +
                (anyMech ? 1.23f : 0f) +
                (allMechs ? 1.3f : 0f) +
                (plantera ? 2.4f : 0f) +
                (golem ? 2.75f : 0f) +
                (cultist ? 3f : 0f) +
                (moonLord ? 4f : 0f);

            if(ModLoader.TryGetMod("CalamityMod", out Mod calamityMod)){
                bool desertscourge = (bool)calamityMod.Call("GetBossDowned","desert scourge");
                bool crabby = (bool)calamityMod.Call("GetBossDowned","crabulon");
                bool perf_hive = (bool)calamityMod.Call("GetBossDowned","hivemind") || (bool)calamityMod.Call("GetBossDowned","perforator");
                bool slimeGod = (bool)calamityMod.Call("GetBossDowned","slimegod");
                bool cryogen = (bool)calamityMod.Call("GetBossDowned","cryogen");
                bool brimstonie = (bool)calamityMod.Call("GetBossDowned","brimstoneelemental");
                bool clam_clone = (bool)calamityMod.Call("GetBossDowned","clone");
                bool aureus = (bool)calamityMod.Call("GetBossDowned","aureus");
                bool ravager = (bool)calamityMod.Call("GetBossDowned","ravager");
                bool donuts = (bool)calamityMod.Call("GetBossDowned","profanedguardians");
                bool providence = (bool)calamityMod.Call("GetBossDowned","providence");
                bool oldduke = (bool)calamityMod.Call("GetBossDowned","oldduke");
                bool sentinels = (bool)calamityMod.Call("GetBossDowned","sentinelall");
                bool dog = (bool)calamityMod.Call("GetBossDowned","dog");
                bool yharon = (bool)calamityMod.Call("GetBossDowned","yharon");
                bool superbosses = (bool)calamityMod.Call("GetBossDowned","exomechs") && (bool)calamityMod.Call("GetBossDowned","scal");
                bool daddyWorm = (bool)calamityMod.Call("GetBossDowned","adultwyrm");

                damage += (yharon ? 1 : 0) +
                (superbosses ? 4 : 0);

                damageMult += 
                (desertscourge ? .15f : 0f) +
                (crabby ? .1f : 0f) +
                (perf_hive ? .3f : 0f) +
                (slimeGod ? .2f : 0f) +
                (cryogen ? 1f : 0f) +
                (brimstonie ? 1.5f : 0f) +
                (clam_clone ? 2f : 0f) +
                (aureus ? 2.5f : 0f) +
                (ravager ? 3f : 0f) +
                (donuts ? 5f : 0f) +
                (providence ? 5f : 0f) +
                (oldduke ? 5f : 0f) +
                (sentinels ? 6f : 0f) +
                (dog ? 10f : 0f) +
                (yharon ? 2f : 0f) +
                (superbosses ? 5f : 0f) +
                (daddyWorm ? 12f : 0f);
            }

            damage *= damageMult;
        }}
    }
}