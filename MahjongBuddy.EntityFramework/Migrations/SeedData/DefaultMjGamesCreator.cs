using System.Collections.Generic;
using System.Linq;
using MahjongBuddy.EntityFramework;
using MahjongBuddy.Tiles;
using MahjongBuddy.Game.Rule;

namespace MahjongBuddy.Migrations.SeedData
{
    public class DefaultMjGamesCreator
    {
        public static List<MjTile> InitialMjTiles { get; private set; }
        public static List<MjRule> InitialMjRules { get; private set; }

        private readonly MahjongBuddyDbContext _context;

        static DefaultMjGamesCreator()
        {
            InitialMjTiles = new List<MjTile>();
            InitialMjRules = new List<MjRule>();

            for (int i = 1; i < 5; i++)
            {
                InitialMjTiles.Add(new MjTile()
                {
                    Name = i + "MoneyOne",
                    ImageMedPath = "",
                    ImageSmPath = "",
                    TileType = MjTileType.Money,
                    Value = MjTileValue.One
                });
            }

            InitialMjRules.Add(new MjRule()
            {
                Description = "Hongkong Rule",
                Name = "Hongkong"
            });
        }


        public DefaultMjGamesCreator(MahjongBuddyDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //CreateTiles();
            CreateRules();

        }

        private void CreateTiles()
        {
            foreach (var tile in InitialMjTiles)
            {
                AddTileIfNotExists(tile);
            }
        }

        public void CreateRules()
        {
            foreach (var rule in InitialMjRules)
            {
                AddRuleIfNotExists(rule);
            }
        }

        private void AddRuleIfNotExists(MjRule rule)
        {
            if (_context.MjRules.Any(r => r.Name == rule.Name))
            {
                return;
            }

            _context.MjRules.Add(rule);
            _context.SaveChanges();

        }
        private void AddTileIfNotExists(MjTile tile)
        {
            if (_context.MjTiles.Any(t => t.Value == tile.Value))
            {
                return;
            }

            _context.MjTiles.Add(tile);
            _context.SaveChanges();
        }
    }
}
