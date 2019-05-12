namespace Kutyak
{
    public class Kutya
    {
        public int id { get; set; }
        public int f_id { get; set; }
        public int n_id { get; set; }
        public int kor { get; set; }
        public string orvos { get; set; }

        public Kutya(string id, string f_id, string n_id, string kor, string orvos)
        {
            this.id = int.Parse(id);
            this.f_id = int.Parse(f_id);
            this.n_id = int.Parse(n_id);
            this.kor = int.Parse(kor);
            this.orvos = orvos;
        }
        public override string ToString()
        {
            return id+" "+f_id+" "+n_id+" "+kor+" "+orvos;
        }
    }
}