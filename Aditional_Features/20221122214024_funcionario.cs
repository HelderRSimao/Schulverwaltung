using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace Schulverwaltung.Data.Migrations
{
    public partial class funcionario : Migration
    {
        const string FUNCIONARIO_USER_GUID = "c2119f59-76a4-4bed-8f7b-06d345ae41b6";
        const string FUNCIONARIO_ROLE_GUID = "a579fcd3-1932-4a7c-9cc7-1a5342fa9028";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var passwordHash = hasher.HashPassword(null, "Password100!");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,NormalizedEmail,PasswordHash,SecurityStamp,FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{FUNCIONARIO_USER_GUID}'");
            sb.AppendLine(",'funcionario@schule.com'");
            sb.AppendLine(",'FUNCIONARIO@SCHULE.COM'");
            sb.AppendLine(",'funcionario@schule.com'");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'FUNCIONARIO@SCHULE.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(",'Funcionario'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{FUNCIONARIO_ROLE_GUID}','Funcionario','FUNCIONARIO')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{FUNCIONARIO_USER_GUID}','{FUNCIONARIO_ROLE_GUID}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{FUNCIONARIO_USER_GUID}' AND RoleId = '{FUNCIONARIO_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{FUNCIONARIO_USER_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{FUNCIONARIO_ROLE_GUID}'");
        }
    }
}
