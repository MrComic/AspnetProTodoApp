using Framework.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Domain.Todos.Entities;

namespace TodoApp.Infra.Data.SqlServer
{
    public class TodoDbContext:BaseCommandDbContext
    {
        public TodoDbContext([NotNull] DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            beforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false;
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        private void beforeSaveTriggers()
        {
            var modifiedEntries = ChangeTracker.Entries<IAuditable>()
                                               .Where(x => x.State == EntityState.Modified);
            foreach (var modifiedEntry in modifiedEntries)
            {
                modifiedEntry.Property("ModifiedDateTime").CurrentValue = DateTime.Now;
            }

            var addedEntries = ChangeTracker.Entries<IAuditable>()
                                            .Where(x => x.State == EntityState.Added);
            foreach (var addedEntry in addedEntries)
            {
                addedEntry.Property("CreatedDateTime").CurrentValue = DateTime.Now;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            foreach (var entityType in modelBuilder.Model
                                      .GetEntityTypes()
                                      .Where(e => typeof(IAuditable).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                   .Property<DateTime?>("CreatedDateTime");
                modelBuilder.Entity(entityType.ClrType)
                            .Property<DateTime?>("ModifiedDateTime");
            }


        }


        public IEnumerable<string> GetIncludePaths(Type clrEntityType)
        {
            var entityType = Model.FindEntityType(clrEntityType);
            var includedNavigations = new HashSet<INavigation>();
            var stack = new Stack<IEnumerator<INavigation>>();
            while (true)
            {
                var entityNavigations = new List<INavigation>();
                foreach (var navigation in entityType.GetNavigations())
                {
                    if (includedNavigations.Add(navigation))
                        entityNavigations.Add(navigation);
                }
                if (entityNavigations.Count == 0)
                {
                    if (stack.Count > 0)
                        yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
                }
                else
                {
                    foreach (var navigation in entityNavigations)
                    {
                        var inverseNavigation = navigation.Inverse;
                        if (inverseNavigation != null)
                            includedNavigations.Add(inverseNavigation);
                    }
                    stack.Push(entityNavigations.GetEnumerator());
                }
                while (stack.Count > 0 && !stack.Peek().MoveNext())
                    stack.Pop();
                if (stack.Count == 0) break;
                entityType = stack.Peek().Current.TargetEntityType;
            }
        }

        public DbSet<Todo> Todos { get; set; }

    }
}
