namespace MusicianBandsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        BandId = c.Int(nullable: false, identity: true),
                        BandName = c.String(),
                        BandDateOfCreation = c.Int(nullable: false),
                        BandCountry = c.String(),
                        BandGenre = c.String(),
                        BandImage = c.String(),
                    })
                .PrimaryKey(t => t.BandId);
            
            CreateTable(
                "dbo.Musicians",
                c => new
                    {
                        MusicianId = c.Int(nullable: false, identity: true),
                        MusicianName = c.String(),
                        MusicianDateOfBirth = c.Int(nullable: false),
                        MusicianRole = c.String(),
                        MusicianImage = c.String(),
                        BandId = c.Int(),
                    })
                .PrimaryKey(t => t.MusicianId)
                .ForeignKey("dbo.Bands", t => t.BandId)
                .Index(t => t.BandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musicians", "BandId", "dbo.Bands");
            DropIndex("dbo.Musicians", new[] { "BandId" });
            DropTable("dbo.Musicians");
            DropTable("dbo.Bands");
        }
    }
}
