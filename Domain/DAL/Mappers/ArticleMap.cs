using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Mappers
{
    class ArticleMap : ClassMap<Article>
    {
        public ArticleMap()
        {
            this.Table("Article");

            this.Id(c => c.Id).Column("Id");
            this.Map(c => c.Title).Column("Title");
            this.Map(c => c.Content).Column("Content");
            this.Map(c => c.Created).Column("Created");
            this.Map(c => c.Modified).Column("Modified");

            this.References(x => x.Category);
        }
    }
}
