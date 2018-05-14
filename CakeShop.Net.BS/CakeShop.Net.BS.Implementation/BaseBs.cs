using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using CakeShop.Net.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace CakeShop.Net.BS.Implementation
{
    /// <summary>
    /// This is the generic base class for every custom repository class. 
    /// Every repository class should be inherited from BaseBs;
    /// It consists several methods as:Add, GetById,GetAll,FindBy,Edit,Delete,Save.
    /// When data is deleted , only the status of record changed from true to false.
    /// <typeparam name="T">This is the appropriate Data Transfer Object</typeparam>
    /// <typeparam name="E">This is the appropriate Domain Model Object</typeparam>
    ///</summary>
    public class BaseBs<T, E> : IBaseBs<T>
        where T : BaseDto, new()
        where E : class, new()
    {
        protected readonly AppDbContext AppDbContext;

        public BaseBs(AppDbContext iDbConnection)
        {
            AppDbContext = iDbConnection;
        }
        /// <summary>
        /// Adding given data to the context.
        /// During adding some fields are changed as
        /// The status is changed to true.
        /// CreationDate and ModifiedDate are assigned as DateTime.Now.
        /// </summary>
        /// <param name="baseDt"> The object which is added into the context</param>
        public virtual void Add(T baseDt)
        {
            if (AppDbContext == null)
                return;

            baseDt.Status = true;
            baseDt.CreatedDate = DateTime.Now;
            baseDt.ModifiedDate = DateTime.Now;
            var entityE = Transformation.Convert<T, E>(baseDt);
            if (AppDbContext.Set<E>() != null)
            {
                AppDbContext.Set<E>().Add(entityE);
            }
        }
        /// <summary>
        /// Adding given Data Transfer objects to the contex
        /// </summary>
        /// <param name="lstBaseDt">Given list of objects that should be added into the context.  </param>
        public virtual void Add(IEnumerable<T> lstBaseDt)
        {
            foreach (var baseDt in lstBaseDt)
            {
                this.Add(baseDt);
            }
        }
        /// <summary>
        /// Gets the Data Transfer Object by given Id
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>Returns the Data Transfer object.</returns>
        public virtual T GetById(Guid id)
        {
            var entityT = FindBy(x => x.Id == id && x.Status == true).FirstOrDefault();
            return entityT;
        }

        /// <summary>
        /// Predicate is for defining conditions.FindBy function converts predicate from Data Tranfer Object to Domain Model Object.
        /// </summary>
        /// <param name="predicateDt">The searching condition.</param>
        /// <returns>Returns the list of Data Transfer Objects that fits to the condition.</returns>
        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicateDt)
        {
            //Converting predicate expression from T type to E type
            var param = Expression.Parameter(typeof(E));
            var visitor = new Visitor<T, E>(param);
            var body = visitor.Visit(predicateDt.Body);
            var predicate = Expression.Lambda<Func<E, bool>>(body, param);
            //
            var query = AppDbContext.Set<E>().Where(predicate);
            IEnumerable<T> lstT = (List<T>)Transformation.Convert<E, T>(query);

            return lstT;
        }

        /// <summary>
        /// Modifing given data to the context.
        /// During modifing some fields are changed as
        /// The status is changed to true.
        /// ModifiedDate are assigned as DateTime.Now.
        /// </summary>
        /// <param name="baseDt"> The object which is added into the context</param>
        public virtual void Edit(T baseDt)
        {
            T currentBaseDt = GetById(baseDt.Id);
            if (currentBaseDt == null)
            {
                throw new Exception("There is no item!");
            }
            baseDt.Status = true;
            baseDt.ModifiedDate = DateTime.Now;
            baseDt.CreatedDate = currentBaseDt.CreatedDate;
            var entityE = Transformation.Convert<T, E>((T)baseDt);
            var entityFromDB = AppDbContext.Set<E>().Find(new object[] { baseDt.Id });
            AppDbContext.Entry(entityFromDB).CurrentValues.SetValues(entityE);
        }

        /// <summary>
        /// Deletion means changing status field value from true to false.
        /// </summary>
        /// <param name="id">The id of deleting item</param>
        /// <returns>Returns the deleted object.</returns>
        public virtual T Delete(Guid id)
        {
            T t = new T()
            {
                Id = id
            };
            return Delete(t);
        }
        /// <summary>
        /// Deletion means changing status field value from true to false.
        /// </summary>
        /// <param name="baseDt">The data transfer object that should be deleted.</param>
        /// <returns>Returns the deleted object.</returns>
        public virtual T Delete(T baseDt)
        {
            if ((baseDt = GetById(baseDt.Id)) == null)
            {
                throw new Exception("There is no item!");
            }
            baseDt.ModifiedDate = DateTime.Now;
            baseDt.Status = false;
            var entityE = Transformation.Convert<T, E>((T)baseDt);
            var entityFromDB = AppDbContext.Set<E>().Find(new object[] { baseDt.Id });
            AppDbContext.Entry(entityFromDB).CurrentValues.SetValues(entityE);
            return baseDt;
        }

        /// <summary>
        /// Deletion list of items.Deletion means changing status field value from true to false.
        /// </summary>
        /// <param name="lstBaseDt">The list of data transfer objects that should be deleted</param>
        public virtual void Delete(IEnumerable<T> lstBaseDt)
        {
            foreach (var baseDt in lstBaseDt)
            {
                Delete(baseDt);
            }
        }

        /// <summary>
        /// Deletion list of items.Deletion means changing status field value from true to false.
        /// </summary>
        /// <param name="lstId">The list of Ids that should be deleted</param>
        public virtual void Delete(IEnumerable<Guid> lstId)
        {
            var lstBaseDt = lstId.Select(x => new T() { Id = x }).ToList<T>();
            Delete(lstBaseDt);
        }
        /// <summary>
        /// Gets all undeleted items.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            var lstT = FindBy(x => x.Status == true);
            return lstT;
        }

        /// <summary>
        /// Saves the context into the database and returns the modified data.
        /// </summary>
        /// <returns>Returns the modified data in Data Transfer Objects.</returns>
        public IEnumerable<T> Save()
        {
            var modifiedEntities = AppDbContext.ChangeTracker.Entries<E>().Where(x => x.State == EntityState.Modified);
            AppDbContext.SaveChanges();
            var savedEntities = AppDbContext.ChangeTracker.Entries<E>();
            List<T> lstT = (List<T>)Transformation.Convert<E, T>(modifiedEntities.Select(x => x.Entity).ToList());
            return lstT;
        }
    }
}