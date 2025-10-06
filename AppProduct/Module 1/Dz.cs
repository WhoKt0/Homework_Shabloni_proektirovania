using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Module_1
{
    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }
        public int Copies { get; set; }

        public Book(string t, string a, string i, int c) { Title = t; Author = a; ISBN = i; Copies = c; }
        public override string ToString() => $"{Title} — {Author} (ISBN:{ISBN}) {Copies} ex";
    }

    class Reader
    {
        public string Name { get; }
        public int Id { get; }
        public Reader(string n, int id) { Name = n; Id = id; }
        public override string ToString() => $"{Name} (id:{Id})";
    }

    interface IBookRepo
    {
        void Add(Book b);
        bool Remove(string isbn);
        Book? Find(string isbn);
        IReadOnlyCollection<Book> GetAll();
    }

    interface IReaderRepo
    {
        void Add(Reader r);
        bool Remove(int id);
        Reader? Find(int id);
        IReadOnlyCollection<Reader> GetAll();
    }

    class InMemoryBookRepo : IBookRepo
    {
        private readonly List<Book> books = new List<Book>();
        public void Add(Book b)
        {
            var e = books.FirstOrDefault(x => x.ISBN == b.ISBN);
            if (e == null) books.Add(b);
            else e.Copies += b.Copies;
        }

        public bool Remove(string isbn)
        {
            var b = Find(isbn);
            if (b == null) return false;
            if (b.Copies != 0) return false;
            books.Remove(b);
            return true;
        }

        public Book? Find(string isbn) => books.FirstOrDefault(x => x.ISBN == isbn);
        public IReadOnlyCollection<Book> GetAll() => books.AsReadOnly();
    }

    class InMemoryReaderRepo : IReaderRepo
    {
        private readonly List<Reader> readers = new List<Reader>();
        public void Add(Reader r) { if (readers.Any(x => x.Id == r.Id)) return; readers.Add(r); }
        public bool Remove(int id)
        {
            var r = Find(id);
            if (r == null) return false;
            readers.Remove(r);
            return true;
        }
        public Reader? Find(int id) => readers.FirstOrDefault(x => x.Id == id);
        public IReadOnlyCollection<Reader> GetAll() => readers.AsReadOnly();
    }

    interface ILibraryService
    {
        void AddBook(Book b);
        bool RemoveBook(string isbn);
        void RegisterReader(Reader r);
        bool Lend(string isbn, int readerId);
        bool Return(string isbn, int readerId);
    }

    class LibraryService : ILibraryService
    {
        private readonly IBookRepo books;
        private readonly IReaderRepo readers;
        private readonly Dictionary<int, List<string>> loans = new Dictionary<int, List<string>>();

        public LibraryService(IBookRepo br, IReaderRepo rr) { books = br; readers = rr; }

        public void AddBook(Book b) => books.Add(b);

        public bool RemoveBook(string isbn)
        {
            var b = books.Find(isbn);
            if (b == null) return false;
            if (loans.Values.Any(list => list.Contains(isbn))) return false;
            return books.Remove(isbn);
        }

        public void RegisterReader(Reader r) => readers.Add(r);

        public bool Lend(string isbn, int readerId)
        {
            var b = books.Find(isbn);
            if (b == null || b.Copies <= 0) return false;
            var r = readers.Find(readerId);
            if (r == null) return false;

            b.Copies--;
            if (!loans.ContainsKey(readerId)) loans[readerId] = new List<string>();
            loans[readerId].Add(isbn);
            return true;
        }

        public bool Return(string isbn, int readerId)
        {
            if (!loans.ContainsKey(readerId) || !loans[readerId].Remove(isbn)) return false;
            var b = books.Find(isbn);
            if (b != null) b.Copies++;
            else books.Add(new Book("Unknown", "Unknown", isbn, 1));
            return true;
        }
    }

    class Program2
    {
        static void Main()
        {
            IBookRepo bookRepo = new InMemoryBookRepo();
            IReaderRepo readerRepo = new InMemoryReaderRepo();
            ILibraryService lib = new LibraryService(bookRepo, readerRepo);

            lib.AddBook(new Book("Преступление и наказание", "Достоевский", "isbn-1", 2));
            lib.AddBook(new Book("Война и мир", "Толстой", "isbn-2", 1));

            lib.RegisterReader(new Reader("Алина", 1));
            lib.RegisterReader(new Reader("Бек", 2));

            Console.WriteLine(lib.Lend("isbn-1", 1) ? "Выдано isbn-1 читателю 1" : "Не выдано isbn-1 читателю 1");
            Console.WriteLine(lib.Lend("isbn-1", 2) ? "Выдано isbn-1 читателю 2" : "Не выдано isbn-1 читателю 2");
            Console.WriteLine(lib.Lend("isbn-1", 2) ? "Выдано (ожидаемо)" : "Не выдано (ожидаемо, нет копий)");

            Console.WriteLine(lib.Return("isbn-1", 1) ? "Возвращено isbn-1 от читателя 1" : "Ошибка возврата isbn-1 от читателя 1");
            Console.WriteLine(lib.RemoveBook("isbn-2") ? "Удалена isbn-2" : "Нельзя удалить isbn-2 (возможно выдана или нет)");

            Console.WriteLine("\nКаталог:");
            foreach (var b in bookRepo.GetAll()) Console.WriteLine($" - {b}");

            Console.WriteLine("\nЧитатели:");
            foreach (var r in readerRepo.GetAll()) Console.WriteLine($" - {r}");

            Console.WriteLine("\nГотово.");
        }
    }
}
