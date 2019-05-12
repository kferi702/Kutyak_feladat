namespace Kutyak
{
    public class KutyaNevek
    {
        public int id { get; set; }
        public string nev { get; set; }

        public KutyaNevek(string id, string nev)
        {
            this.id = int.Parse(id);
            this.nev = nev;
        }
        public override string ToString()
        {
            return id+" "+nev;
        }
    }
}