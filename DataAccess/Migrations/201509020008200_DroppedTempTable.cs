namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DroppedTempTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OkToDelete");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OkToDelete",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SomeColumn = c.String(),
                        Auri = c.String(),
                        CarPolish = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
