namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCreatedOnPropertyTypoInUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DeletedOn", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "DeltedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DeltedOn", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "DeletedOn");
        }
    }
}
