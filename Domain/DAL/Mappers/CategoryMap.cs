using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Mappers
{
    class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            this.Table("Category");

            this.Id(c => c.Id).Column("Id");
            this.Map(c => c.Name).Column("Name");
            this.Map(c => c.Created).Column("Created");
            this.Map(c => c.Modified).Column("Modified");

            this.HasMany(x => x.Articles)
            .Inverse()
            .Cascade.All();
        }
    }
}
