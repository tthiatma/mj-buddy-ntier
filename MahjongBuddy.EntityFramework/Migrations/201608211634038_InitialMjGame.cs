namespace MahjongBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMjGame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MjGames",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatorUserId = c.Long(),
                        IsPrivateGame = c.Boolean(nullable: false),
                        GameRoomPassword = c.String(),
                        MjRuleId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        State = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .ForeignKey("dbo.MjRules", t => t.MjRuleId)
                .Index(t => t.CreatorUserId)
                .Index(t => t.MjRuleId);
            
            CreateTable(
                "dbo.MjSignalRConnections",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ConnectionId = c.String(),
                        UserAgent = c.String(),
                        Connected = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.MjRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MjGameSessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MjGameId = c.Long(),
                        Wind = c.String(),
                        GameNo = c.String(),
                        HasWinner = c.Boolean(nullable: false),
                        LastTileOnBoard_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjTileInGames", t => t.LastTileOnBoard_Id)
                .ForeignKey("dbo.MjGames", t => t.MjGameId)
                .Index(t => t.MjGameId)
                .Index(t => t.LastTileOnBoard_Id);
            
            CreateTable(
                "dbo.MjTileInGames",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TileId = c.Int(),
                        MjGameSessionId = c.Long(nullable: false),
                        State = c.Byte(nullable: false),
                        OwnerId = c.Int(),
                        OrderNum = c.Int(nullable: false),
                        UserOrderNum = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        MjGameSession_Id = c.Long(),
                        MjTileSet_Id = c.Int(),
                        MjWinningTileSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjGameSessions", t => t.MjGameSessionId, cascadeDelete: true)
                .ForeignKey("dbo.MjTiles", t => t.TileId)
                .ForeignKey("dbo.MjGameSessions", t => t.MjGameSession_Id)
                .ForeignKey("dbo.MjTileSets", t => t.MjTileSet_Id)
                .ForeignKey("dbo.MjWinningTileSets", t => t.MjWinningTileSet_Id)
                .Index(t => t.TileId)
                .Index(t => t.MjGameSessionId)
                .Index(t => t.MjGameSession_Id)
                .Index(t => t.MjTileSet_Id)
                .Index(t => t.MjWinningTileSet_Id);
            
            CreateTable(
                "dbo.MjTiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TileType = c.Byte(nullable: false),
                        Value = c.Byte(nullable: false),
                        ImageMedPath = c.String(),
                        ImageSmPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MjHandWorths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MjRuleId = c.Int(),
                        MjWinningType = c.Byte(nullable: false),
                        Point = c.Int(nullable: false),
                        MjWinningTileSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjRules", t => t.MjRuleId)
                .ForeignKey("dbo.MjWinningTileSets", t => t.MjWinningTileSet_Id)
                .Index(t => t.MjRuleId)
                .Index(t => t.MjWinningTileSet_Id);
            
            CreateTable(
                "dbo.MjTileSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TileSetType = c.Byte(nullable: false),
                        TileType = c.Byte(nullable: false),
                        IsRevealed = c.Boolean(nullable: false),
                        MjWinningTileSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjWinningTileSets", t => t.MjWinningTileSet_Id)
                .Index(t => t.MjWinningTileSet_Id);
            
            CreateTable(
                "dbo.MjUserPlayingSessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CanPickTile = c.Boolean(nullable: false),
                        CanThrowTile = c.Boolean(nullable: false),
                        CanDoNoFlower = c.Boolean(nullable: false),
                        Wind = c.String(),
                        MjGameSessionId = c.Long(),
                        UserId = c.Long(),
                        AutoSortTile = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjGameSessions", t => t.MjGameSessionId)
                .ForeignKey("dbo.AbpUsers", t => t.UserId)
                .Index(t => t.MjGameSessionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MjWinningTileSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MjGameSessionId = c.Long(nullable: false),
                        TotalPoints = c.Int(nullable: false),
                        Eye_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjTileSets", t => t.Eye_Id)
                .ForeignKey("dbo.MjGameSessions", t => t.MjGameSessionId, cascadeDelete: true)
                .Index(t => t.MjGameSessionId)
                .Index(t => t.Eye_Id);
            
            AddColumn("dbo.AbpUsers", "IsPlaying", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUsers", "MjGame_Id", c => c.Long());
            AddColumn("dbo.AbpUsers", "MjGameSession_Id", c => c.Long());
            AddColumn("dbo.AbpUsers", "MjGameSession_Id1", c => c.Long());
            CreateIndex("dbo.AbpUsers", "MjGame_Id");
            CreateIndex("dbo.AbpUsers", "MjGameSession_Id");
            CreateIndex("dbo.AbpUsers", "MjGameSession_Id1");
            AddForeignKey("dbo.AbpUsers", "MjGame_Id", "dbo.MjGames", "Id");
            AddForeignKey("dbo.AbpUsers", "MjGameSession_Id", "dbo.MjGameSessions", "Id");
            AddForeignKey("dbo.AbpUsers", "MjGameSession_Id1", "dbo.MjGameSessions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MjTileSets", "MjWinningTileSet_Id", "dbo.MjWinningTileSets");
            DropForeignKey("dbo.MjWinningTileSets", "MjGameSessionId", "dbo.MjGameSessions");
            DropForeignKey("dbo.MjHandWorths", "MjWinningTileSet_Id", "dbo.MjWinningTileSets");
            DropForeignKey("dbo.MjTileInGames", "MjWinningTileSet_Id", "dbo.MjWinningTileSets");
            DropForeignKey("dbo.MjWinningTileSets", "Eye_Id", "dbo.MjTileSets");
            DropForeignKey("dbo.MjUserPlayingSessions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.MjUserPlayingSessions", "MjGameSessionId", "dbo.MjGameSessions");
            DropForeignKey("dbo.MjTileInGames", "MjTileSet_Id", "dbo.MjTileSets");
            DropForeignKey("dbo.MjHandWorths", "MjRuleId", "dbo.MjRules");
            DropForeignKey("dbo.AbpUsers", "MjGameSession_Id1", "dbo.MjGameSessions");
            DropForeignKey("dbo.MjTileInGames", "MjGameSession_Id", "dbo.MjGameSessions");
            DropForeignKey("dbo.MjGameSessions", "MjGameId", "dbo.MjGames");
            DropForeignKey("dbo.AbpUsers", "MjGameSession_Id", "dbo.MjGameSessions");
            DropForeignKey("dbo.MjGameSessions", "LastTileOnBoard_Id", "dbo.MjTileInGames");
            DropForeignKey("dbo.MjTileInGames", "TileId", "dbo.MjTiles");
            DropForeignKey("dbo.MjTileInGames", "MjGameSessionId", "dbo.MjGameSessions");
            DropForeignKey("dbo.AbpUsers", "MjGame_Id", "dbo.MjGames");
            DropForeignKey("dbo.MjGames", "MjRuleId", "dbo.MjRules");
            DropForeignKey("dbo.MjGames", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.MjSignalRConnections", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.MjWinningTileSets", new[] { "Eye_Id" });
            DropIndex("dbo.MjWinningTileSets", new[] { "MjGameSessionId" });
            DropIndex("dbo.MjUserPlayingSessions", new[] { "UserId" });
            DropIndex("dbo.MjUserPlayingSessions", new[] { "MjGameSessionId" });
            DropIndex("dbo.MjTileSets", new[] { "MjWinningTileSet_Id" });
            DropIndex("dbo.MjHandWorths", new[] { "MjWinningTileSet_Id" });
            DropIndex("dbo.MjHandWorths", new[] { "MjRuleId" });
            DropIndex("dbo.MjTileInGames", new[] { "MjWinningTileSet_Id" });
            DropIndex("dbo.MjTileInGames", new[] { "MjTileSet_Id" });
            DropIndex("dbo.MjTileInGames", new[] { "MjGameSession_Id" });
            DropIndex("dbo.MjTileInGames", new[] { "MjGameSessionId" });
            DropIndex("dbo.MjTileInGames", new[] { "TileId" });
            DropIndex("dbo.MjGameSessions", new[] { "LastTileOnBoard_Id" });
            DropIndex("dbo.MjGameSessions", new[] { "MjGameId" });
            DropIndex("dbo.MjSignalRConnections", new[] { "User_Id" });
            DropIndex("dbo.AbpUsers", new[] { "MjGameSession_Id1" });
            DropIndex("dbo.AbpUsers", new[] { "MjGameSession_Id" });
            DropIndex("dbo.AbpUsers", new[] { "MjGame_Id" });
            DropIndex("dbo.MjGames", new[] { "MjRuleId" });
            DropIndex("dbo.MjGames", new[] { "CreatorUserId" });
            DropColumn("dbo.AbpUsers", "MjGameSession_Id1");
            DropColumn("dbo.AbpUsers", "MjGameSession_Id");
            DropColumn("dbo.AbpUsers", "MjGame_Id");
            DropColumn("dbo.AbpUsers", "IsPlaying");
            DropTable("dbo.MjWinningTileSets");
            DropTable("dbo.MjUserPlayingSessions");
            DropTable("dbo.MjTileSets");
            DropTable("dbo.MjHandWorths");
            DropTable("dbo.MjTiles");
            DropTable("dbo.MjTileInGames");
            DropTable("dbo.MjGameSessions");
            DropTable("dbo.MjRules");
            DropTable("dbo.MjSignalRConnections");
            DropTable("dbo.MjGames");
        }
    }
}
