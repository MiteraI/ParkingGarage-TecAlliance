﻿using Microsoft.EntityFrameworkCore;
using ParkingGarage.Domain.Entities;
using ParkingGarage.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void UpdateState<TEntity>(TEntity entity, EntityState state)
        {
            _context.Entry(entity).State = state;
        }

        public void SetEntityStateModified<TEntiy, TProperty>(TEntiy entity, Expression<Func<TEntiy, TProperty>> propertyExpression) where TEntiy : class where TProperty : class
        {
            _context.Entry(entity).Reference(propertyExpression).IsModified = true;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            using var saveChangeTask = _context.SaveChangesAsync(cancellationToken);
            return await saveChangeTask;
        }

        public DbSet<T> Set<T>(string name = null) where T : class
        {
            return _context.Set<T>(name);
        }

        public void AddOrUpdateGraph<TEntiy>(TEntiy entity, ICollection<Type> entitiesToBeUpdated = null) where TEntiy : class
        {
            var rootTypeEntity = entity.GetType();

            _context.ChangeTracker.TrackGraph(entity, e =>
            {
                Type navigationPropertyName = e.Entry.Entity.GetType();

                var alreadyTrackedEntity = _context.ChangeTracker.Entries().FirstOrDefault(entry => entry.Entity.Equals(e.Entry.Entity));

                if (alreadyTrackedEntity != null)
                {
                    alreadyTrackedEntity.State = EntityState.Detached;
                }

                if (!navigationPropertyName.Equals(rootTypeEntity) && !(entitiesToBeUpdated != null && entitiesToBeUpdated.Contains(navigationPropertyName)))
                {
                    // Check if the primary key property is set
                    var primaryKeyProperty = e.Entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey());
                    if (primaryKeyProperty != null && primaryKeyProperty.CurrentValue != null)
                    {
                        e.Entry.State = EntityState.Unchanged;
                    }
                    else
                    {
                        // If the primary key is not set, assume it's a new entity
                        e.Entry.State = EntityState.Added;
                    }
                }
                else if (e.Entry.IsKeySet)
                {
                    if (e.Entry.Entity.GetType() == typeof(Vehicle)) //Assuming Vehicle will not be updated
                    {
                        e.Entry.State = EntityState.Added;
                    }
                    else
                    {
                        e.Entry.State = EntityState.Modified;
                    }
                }
                else
                {
                    e.Entry.State = EntityState.Added;
                }
                System.Diagnostics.Debug.WriteLine($"Tracking {e.Entry.Metadata.DisplayName()} as {e.Entry.State}");
            });
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
