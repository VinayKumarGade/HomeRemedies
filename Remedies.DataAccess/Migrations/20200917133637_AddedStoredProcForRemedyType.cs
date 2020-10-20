using Microsoft.EntityFrameworkCore.Migrations;

namespace Remedies.DataAccess.Migrations
{
    public partial class AddedStoredProcForRemedyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetRemedyTypes 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.RemedyTypes 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetRemedyType 
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.RemedyTypes  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateRemedyType
	                                @Id int,
	                                @Name varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.RemedyTypes
                                     SET  Name = @Name
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteRemedyType
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.RemedyTypes
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateRemedyType
                                   @Name varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.RemedyTypes(Name)
                                    VALUES (@Name)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetRemedyTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetRemedyType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateRemedyType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteRemedyType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateRemedyType");
        }
    }
}
