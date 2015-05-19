namespace BE_SpexPAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renames1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.UserClaim", newName: "UserClaims");
            RenameTable(name: "dbo.UserLogin", newName: "UserLogins");
            RenameTable(name: "dbo.UserRole", newName: "UserRoles");
            RenameTable(name: "dbo.Role", newName: "Roles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Roles", newName: "Role");
            RenameTable(name: "dbo.UserRoles", newName: "UserRole");
            RenameTable(name: "dbo.UserLogins", newName: "UserLogin");
            RenameTable(name: "dbo.UserClaims", newName: "UserClaim");
            RenameTable(name: "dbo.Users", newName: "User");
        }
    }
}
