using Microsoft.EntityFrameworkCore;
using Mongo.Services.CouponAPI.Data;

namespace Mongo.Services.CouponAPI.Helpers
{
    public static class AppHelper
    {
       public static void ApplyMigration(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MongoServiceDBContext>();
                if (db.Database.GetPendingMigrations().Count() > 0)
                {
                    db.Database.Migrate();
                }
            }
        }
    }
}
