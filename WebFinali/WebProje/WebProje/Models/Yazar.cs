using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.Models
{
    public class Yazar
    {
        public virtual int Id { get; set; }
        public virtual string YazarAd { get; set; }
        public virtual string YazarYas { get; set; }
        public virtual string YazarUlke { get; set; }
        public virtual Kitap KitapAd { get; set; }
    }

    public class YazarMap : ClassMapping<Yazar>
    {
        public YazarMap()
        {
            Table("Yazar");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.YazarAd, c => c.Length(30));
            Property(x => x.YazarYas, c => c.Length(30));
            Property(x => x.YazarUlke, c => c.Length(30));
            ManyToOne(x => x.KitapAd);
        }
    }
}