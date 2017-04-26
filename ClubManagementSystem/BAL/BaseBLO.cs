using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using App.Gwin.Attributes;
using LinqExtension;
using System.Reflection;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using App.Gwin;
using System.Data.Entity.Validation;
using App.Gwin.Entities;
using App.Gwin.Application.Presentation.Messages;
using App.Gwin.Application.BAL;
using App;
 

namespace ClubManagement.BAL
{
    /// <summary>
    /// Version 0.09
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseBLO<T> : GwinBaseBLO<T> ,IGwinBaseBLO where T : BaseEntity
    {
        private Type typeDbContext;

        #region construcreur
        public BaseBLO(DbContext context, Type typeDbContext) : base(context, typeDbContext)
        {
            // Convertion DBContext to ModelContext
            this.Context = (ModelContext)context;
            if (this.Context == null  && typeDbContext == null)
            {
                this.Context = new ModelContext();
                this.DbSet = this.Context.Set<T>();
            }
        }


        public BaseBLO(DbContext context):this(context,null)
        {
            
        }
        public BaseBLO() : this(null,null) { }

        public BaseBLO(Type typeDbContext):this(null,typeDbContext)
        {
           
        }
        #endregion

        #region Context

        public override void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
        #endregion

        #region CreateInstance
        public override object CreateEntityInstance()
        {
            return this.Context.Set<T>().Create();
        }

        /// <summary>
        /// Creating an instance of the Service object from the entity type
        /// </summary>
        /// <param name="TypeEntity">the entity type</param>
        /// <returns></returns>
        public override IGwinBaseBLO CreateServiceBLOInstanceByTypeEntity(Type TypeEntity)
        {
            Type TypeEntityService = typeof(BaseBLO<>).MakeGenericType(TypeEntity);
            IGwinBaseBLO EntityService = (IGwinBaseBLO)Activator.CreateInstance(TypeEntityService, this.Context);
            return EntityService;
        }
        /// <summary>
        /// Creating an instance of the Service object from the entity type and Context
        /// </summary>
        /// <param name="TypeEntity">the entity type</param>
        /// <param name="context">the context</param>
        /// <returns></returns>
        public virtual IGwinBaseBLO CreateServiceBLOInstanceByTypeEntityAndContext(Type TypeEntity, DbContext context)
        {

            Type TypeEntityService = typeof(BaseBLO<>).MakeGenericType(TypeEntity);
            IGwinBaseBLO EntityService = (IGwinBaseBLO)Activator.CreateInstance(TypeEntityService, context);
            return EntityService;
        }
        #endregion

       

    }
}
