namespace QL_CuaHangBanThuocTruSau.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Products", "ImagePath");
        }
    }
}
