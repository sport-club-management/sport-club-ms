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

namespace App
{
    public class BaseBLO<T> : BaseEntityBLO<T> ,IBaseBLO where T : BaseEntity
    {
     
        #region construcreur
        public BaseBLO(DbContext context):base(context)
        {
            this.Context = (ModelContext) context;
            if (this.Context == null) this.Context = new ModelContext();

            this.DbSet = this.Context.Set<T>();
            this.TypeEntity = typeof(T);
        }
        public BaseBLO() : this(null) { }
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
        public override IBaseBLO CreateServiceBLOInstanceByTypeEntity(Type TypeEntity)
        {
            Type TypeEntityService = typeof(BaseBLO<>).MakeGenericType(TypeEntity);
            IBaseBLO EntityService = (IBaseBLO)Activator.CreateInstance(TypeEntityService, this.Context);
            return EntityService;
        }
        /// <summary>
        /// Creating an instance of the Service object from the entity type and Context
        /// </summary>
        /// <param name="TypeEntity">the entity type</param>
        /// <param name="context">the context</param>
        /// <returns></returns>
        public virtual IBaseBLO CreateEntityInstanceByTypeAndContext(Type TypeEntity, DbContext context)
        {

            Type TypeEntityService = typeof(BaseBLO<>).MakeGenericType(TypeEntity);
            IBaseBLO EntityService = (IBaseBLO)Activator.CreateInstance(TypeEntityService, context);
            return EntityService;
        }
        #endregion

       

    }
}
