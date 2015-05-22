namespace BE_SpexPAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClaimsData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityUserClaimsLists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClaimsListType = c.String(),
                        ClaimsListValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IdentityUserClaimsLists");
        }
    }
}
