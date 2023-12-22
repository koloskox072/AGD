using System.Xml;

namespace AGD
{
    abstract class AGD
    {
        public string Nazwa { get; protected set; }
        public string Kolor { get; protected set; }
        public int Moc { get; protected set; }
        public bool CzyWlaczone { get; protected set; }
    }
    class Kuchenka : AGD
    {
        public int temp { get; protected set; }
        public Kuchenka(string nazwa, string kolor, int moc, bool czywlaczone) 
        {
            Nazwa = nazwa;
            Kolor = kolor;
            Moc = moc;
            CzyWlaczone = czywlaczone;
        }
        public override string ToString()
        {
            if(CzyWlaczone)
            return $"{Nazwa}: {Kolor}, {Moc}W, {temp}*C, On";
            else return $"{Nazwa}: {Kolor}, {Moc}W, Off";
        }
    }
    class Zelazko : AGD
    {
        public int temp { get; protected set; }
        public void grzanie()
        {
            Console.WriteLine($"Temperatura: {temp}");
            temp = 200;
            Console.WriteLine($"Temperatura: {temp}");
        }
        public Zelazko(string nazwa, string kolor, int moc, bool czywlaczone)
        {
            Nazwa = nazwa;
            Kolor = kolor;
            Moc = moc;
            CzyWlaczone = czywlaczone;
        }
        public override string ToString()
        {
            if (CzyWlaczone)
                return $"{Nazwa}: {Kolor}, {Moc}W, {temp}*C, On";
            else return $"{Nazwa}: {Kolor}, {Moc}W, Off";
        }
    }
    class Ekspres : AGD
    {
        public bool czyKawa { get; protected set; } //Czy ekspres jest zaladowany ziarnami kawy
        public void zrobKawe()
        {
            if (czyKawa)
            {
                Console.WriteLine("Robie kawe....");
                Console.WriteLine("Kawa gotowa");
            }
            else
                Console.WriteLine("Brak ziaren kawy!");
        }
        public void zaladujKawe()
        {
            czyKawa = true;
            Console.WriteLine("Laduje kawe");
            Console.WriteLine("Kawa zaladowana");
        }
        public void on()
        {
            CzyWlaczone = true;
            Console.WriteLine("Urzadzenie wlaczone");
        }
        public void off()
        {
            CzyWlaczone = false;
            Console.WriteLine("Urzadzenie wylaczone");
        }
        public Ekspres(string nazwa, string kolor, int moc, bool czywlaczone, bool czyKawa=false)
        {
            Nazwa = nazwa;
            Kolor = kolor;
            Moc = moc;
            CzyWlaczone = czywlaczone;
            this.czyKawa = czyKawa;
        }
        public override string ToString()
        {
            if (CzyWlaczone) {
                if(czyKawa)
                    return $"{Nazwa}: {Kolor}, {Moc}W, Zaladowany, On";
                else
                    return $"{Nazwa}: {Kolor}, {Moc}W, Brak Kawy, On";
            }
            else return $"{Nazwa}: {Kolor}, {Moc}W, Off";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Zelazko zelazko = new Zelazko("Zelazko", "bialy", 500, false);
            Ekspres ekspres = new Ekspres("Ekspres", "bialy", 200, false);
            Console.WriteLine(ekspres);
            ekspres.on();
            ekspres.zrobKawe();
            ekspres.zaladujKawe();
            ekspres.zrobKawe();
            ekspres.off();
        }
    }
}