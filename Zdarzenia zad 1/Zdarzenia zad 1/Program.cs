using System.Xml.Xsl;

namespace Zdarzenia_zad_1
{
    public delegate void MessangeHandler(string message);
    public class Publisher
    {
        public event MessangeHandler MessageEvent;
        public void SendMessage(string message)
        {
            if( MessageEvent != null )
            {
                MessageEvent(message);
            }
        }
    }

    public class Subscriber
    {
        public void OnMessageReceived(string message)
        {
            Console.WriteLine("Otrzymałem wiadomość: {0}", message);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();

            publisher.MessageEvent += subscriber.OnMessageReceived;
            publisher.SendMessage("Pierwsza Wiadomość");
            publisher.SendMessage("Druga Wiadomość");
            publisher.SendMessage("Trzecia Wiadomość");

            publisher.MessageEvent -= subscriber.OnMessageReceived;
            publisher.SendMessage("Czwarta wiadomość");

            publisher.MessageEvent += subscriber.OnMessageReceived;
            publisher.SendMessage("Piąta wiadomość");
        }
    }
}


/*
 * 
 * Część 1: Zdefiniuj delegat o nazwie MessageHandler, który przyjmuje jako parametr
ciąg znaków (string) i nie zwraca żadnej wartości (void). Następnie zdefiniuj klasę o
nazwie Publisher, która ma pole typu MessageHandler o nazwie MessageEvent. Pole
to ma być zadeklarowane jako zdarzenie (event). Klasa Publisher ma mieć również
metodę o nazwie SendMessage, która przyjmuje jako parametr ciąg znaków (string) i
nie zwraca żadnej wartości (void). Metoda ta ma sprawdzać, czy pole MessageEvent
ma jakichś subskrybentów (nie jest nullem) i jeśli tak, to ma wywoływać zdarzenie
MessageEvent, przekazując mu parametr message.


 Część 2: Zdefiniuj klasę o nazwie Subscriber, która ma metodę o nazwie
OnMessageReceived, która przyjmuje jako parametr ciąg znaków (string) i nie zwraca
żadnej wartości (void). Metoda ta ma wypisywać na konsolę wiadomość o treści
“Otrzymałem wiadomość: {0}”, gdzie {0} to parametr message. Następnie zdefiniuj
klasę o nazwie Program, która ma metodę o nazwie Main, która jest punktem wejścia
programu. W metodzie Main utwórz obiekty klasy Publisher i klasy Subscriber.
Następnie zasubskrybuj zdarzenie MessageEvent za pomocą metody
OnMessageReceived. Wywołaj metodę SendMessage kilka razy z różnymi
parametrami i sprawdź, czy subskrybent otrzymuje wiadomości. Na końcu anuluj
subskrypcję zdarzenia i wywołaj metodę SendMessage ponownie. Sprawdź, czy
subskrybent nadal otrzymuje wiadomości

*/