﻿namespace Kutyak
{
    public class KutyaFajtak
    {
        public int id { get; set; }
        public string magyar { get; set; }
        public string eredeti { get; set; }
        public KutyaFajtak(string id, string magyar, string eredeti)
        {
            this.id = int.Parse(id);
            this.magyar = magyar;
            this.eredeti = eredeti;
        }
        public override string ToString()
        {
            return id+" "+magyar+" "+eredeti;
        }
    }
}