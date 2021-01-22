using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProje.Models
{
    public class Kitap
    {
        public virtual int Id { get; set; }
        public virtual string KitapAd { get; set; }
        public virtual string KitapYazar { get; set; }
        public virtual string BaskiSayisi { get; set; }
        public virtual string Yayinevi { get; set; }
        public virtual ICollection<Yazar> Yazarlar { get; set; } = new List<Yazar>();
    }

    public class KitapMap : ClassMapping<Kitap>
    {
        public KitapMap()
        {
            Table("Kitap");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.KitapAd, c => c.Length(30));
            Property<string>(x => x.KitapYazar, c => c.Length(30));
            Property(x => x.BaskiSayisi, c => c.Length(30));
            Property(x => x.Yayinevi, c => c.Length(30));
            Set(e => e.Yazarlar, mapper =>
            {
                mapper.Key(k => k.Column("Kitap"));
                mapper.Inverse(true);
                mapper.Cascade(Cascade.All);
            }, relation => relation.OneToMany(mapping => mapping.Class(typeof(Yazar))));
        }
    }
}