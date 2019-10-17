using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class AddedNLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE TABLE [dbo].[Exceptionlog]   
                        (   
                         [id]         [INT] IDENTITY(1, 1) NOT NULL,   
                         [timestamp]  [DATETIME] NOT NULL,   
                         [level]      [VARCHAR](100) NOT NULL,   
                         [logger]     [VARCHAR](1000) NOT NULL,   
                         [message]    [VARCHAR](3600) NOT NULL,   
                         [userid]     [INT] NULL,   
                         [exception]  [VARCHAR](3600) NULL,   
                         [stacktrace] [VARCHAR](3600) NULL,   
                         CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED ( [id] ASC )WITH (   
                         pad_index = OFF, statistics_norecompute = OFF, ignore_dup_key = OFF,   
                         allow_row_locks = on, allow_page_locks = on) ON [PRIMARY]   
                        )   
                    ON [PRIMARY] ";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE [dbo].[exceptionlog]";

            migrationBuilder.Sql(sp);
        }
    }
}
