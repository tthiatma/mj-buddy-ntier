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
                        CreatorId = c.Long(),
                        IsPrivateGame = c.Boolean(nullable: false),
                        GameRoomPassword = c.String(),
                        MjRuleId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        ActiveSessionId = c.Long(),
                        State = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorId)
                .ForeignKey("dbo.MjRules", t => t.MjRuleId)
                .Index(t => t.CreatorId)
                .Index(t => t.MjRuleId);
            
            CreateTable(
                "dbo.MjGameSessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MjGameId = c.Long(),
                        Wind = c.Byte(nullable: false),
                        GameNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjGames", t => t.MjGameId)
                .Index(t => t.MjGameId);
            
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
                "dbo.MjGameSessionResults",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Point = c.Int(nullable: false),
                        MjGameSessionId = c.Long(),
                        PlayerResultState = c.Byte(nullable: false),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjGameSessions", t => t.MjGameSessionId)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id)
                .Index(t => t.MjGameSessionId)
                .Index(t => t.User_Id);
            
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
                        MjTileSet_Id = c.Int(),
                        MjWinningTileSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjGameSessions", t => t.MjGameSessionId, cascadeDelete: true)
                .ForeignKey("dbo.MjTiles", t => t.TileId)
                .ForeignKey("dbo.MjTileSets", t => t.MjTileSet_Id)
                .ForeignKey("dbo.MjWinningTileSets", t => t.MjWinningTileSet_Id)
                .Index(t => t.TileId)
                .Index(t => t.MjGameSessionId)
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
            
            CreateTable(
                "dbo.UserMjGames",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        MjGame_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.MjGame_Id })
                .ForeignKey("dbo.AbpUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.MjGames", t => t.MjGame_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.MjGame_Id);
            
            CreateTable(
                "dbo.MjGameSessionUsers",
                c => new
                    {
                        MjGameSession_Id = c.Long(nullable: false),
                        User_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.MjGameSession_Id, t.User_Id })
                .ForeignKey("dbo.MjGameSessions", t => t.MjGameSession_Id, cascadeDelete: true)
                .ForeignKey("dbo.AbpUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.MjGameSession_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AbpUsers", "IsPlaying", c => c.Boolean(nullable: false));
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
            DropForeignKey("dbo.MjTileInGames", "TileId", "dbo.MjTiles");
            DropForeignKey("dbo.MjTileInGames", "MjGameSessionId", "dbo.MjGameSessions");
            DropForeignKey("dbo.MjHandWorths", "MjRuleId", "dbo.MjRules");
            DropForeignKey("dbo.MjGameSessionResults", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.MjGameSessionResults", "MjGameSessionId", "dbo.MjGameSessions");
            DropForeignKey("dbo.MjGames", "MjRuleId", "dbo.MjRules");
            DropForeignKey("dbo.MjGames", "CreatorId", "dbo.AbpUsers");
            DropForeignKey("dbo.MjSignalRConnections", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.MjGameSessionUsers", "User_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.MjGameSessionUsers", "MjGameSession_Id", "dbo.MjGameSessions");
            DropForeignKey("dbo.MjGameSessions", "MjGameId", "dbo.MjGames");
            DropForeignKey("dbo.UserMjGames", "MjGame_Id", "dbo.MjGames");
            DropForeignKey("dbo.UserMjGames", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.MjGameSessionUsers", new[] { "User_Id" });
            DropIndex("dbo.MjGameSessionUsers", new[] { "MjGameSession_Id" });
            DropIndex("dbo.UserMjGames", new[] { "MjGame_Id" });
            DropIndex("dbo.UserMjGames", new[] { "User_Id" });
            DropIndex("dbo.MjWinningTileSets", new[] { "Eye_Id" });
            DropIndex("dbo.MjWinningTileSets", new[] { "MjGameSessionId" });
            DropIndex("dbo.MjUserPlayingSessions", new[] { "UserId" });
            DropIndex("dbo.MjUserPlayingSessions", new[] { "MjGameSessionId" });
            DropIndex("dbo.MjTileSets", new[] { "MjWinningTileSet_Id" });
            DropIndex("dbo.MjTileInGames", new[] { "MjWinningTileSet_Id" });
            DropIndex("dbo.MjTileInGames", new[] { "MjTileSet_Id" });
            DropIndex("dbo.MjTileInGames", new[] { "MjGameSessionId" });
            DropIndex("dbo.MjTileInGames", new[] { "TileId" });
            DropIndex("dbo.MjHandWorths", new[] { "MjWinningTileSet_Id" });
            DropIndex("dbo.MjHandWorths", new[] { "MjRuleId" });
            DropIndex("dbo.MjGameSessionResults", new[] { "User_Id" });
            DropIndex("dbo.MjGameSessionResults", new[] { "MjGameSessionId" });
            DropIndex("dbo.MjSignalRConnections", new[] { "User_Id" });
            DropIndex("dbo.MjGameSessions", new[] { "MjGameId" });
            DropIndex("dbo.MjGames", new[] { "MjRuleId" });
            DropIndex("dbo.MjGames", new[] { "CreatorId" });
            DropColumn("dbo.AbpUsers", "IsPlaying");
            DropTable("dbo.MjGameSessionUsers");
            DropTable("dbo.UserMjGames");
            DropTable("dbo.MjWinningTileSets");
            DropTable("dbo.MjUserPlayingSessions");
            DropTable("dbo.MjTileSets");
            DropTable("dbo.MjTiles");
            DropTable("dbo.MjTileInGames");
            DropTable("dbo.MjHandWorths");
            DropTable("dbo.MjGameSessionResults");
            DropTable("dbo.MjRules");
            DropTable("dbo.MjSignalRConnections");
            DropTable("dbo.MjGameSessions");
            DropTable("dbo.MjGames");
        }
    }
}
