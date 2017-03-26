using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Articles = new List<Article>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }

        public virtual IList<Article> Articles { get; set; }

    }
}
