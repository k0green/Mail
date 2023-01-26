using Mail.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mail.Context.IContext
{
    public interface ITask6Context
    {
        DbSet<MessagesInfo> MessagesInfos { get; set; }

        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
