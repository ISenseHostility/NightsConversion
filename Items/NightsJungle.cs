using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NightsConversion.Items
{
    public class NightsJungle : ModItem
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Night's Jungle");
            Tooltip.SetDefault("Night's Edge but grassy.");
        }

        public override void SetDefaults() 
        {
            item.width = 44;
            item.height = 48;
            item.rare = ItemRarityID.LightRed;
            item.value = 104000;
            item.scale = 1.1F;
			
            item.melee = true;
            item.damage = 42;
            item.knockBack = 4.5F;
			
            item.autoReuse = false;
			
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.UseSound = SoundID.Item1;
			
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                // emit particles on swing
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Grass_Small);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.DemonTorch);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // 60 frames = 1 second
            // time = frames
            target.AddBuff(BuffID.Poisoned, 180);
        }

        public override void AddRecipes() 
        {
            ModRecipe item_recipe = new ModRecipe(mod);
            item_recipe.AddIngredient(ItemID.NightsEdge);
            item_recipe.AddIngredient(ItemID.Emerald, 5);
            item_recipe.AddTile(TileID.Anvils);
            item_recipe.SetResult(this);
            item_recipe.AddRecipe();
            
            ModRecipe default_recipe = new ModRecipe(mod);
            default_recipe.AddIngredient(this);
            default_recipe.AddTile(TileID.Anvils);
            default_recipe.SetResult(ItemID.NightsEdge);
            default_recipe.AddRecipe();
        }
    }
}