using System;

namespace Saugumas_4
{
    public class PasswordEntry
    {
        private string title;
        private string password;
        private string url;
        private string comment;

        public PasswordEntry(string title, string password, string url, string comment)
        {
            if (String.IsNullOrWhiteSpace(title))
                throw new Exception("Pavadinimas negali būti tuščias");
            if (String.IsNullOrWhiteSpace(password))
                throw new Exception("Slaptažodis negali būti tuščias");

            this.Title = title;
            this.Password = password;
            this.Url = url;
            this.Comment = comment;
        }

        public string Title { get => title; set => title = value; }
        public string Password { get => password; set => password = value; }
        public string Url { get => url; set => url = value; }
        public string Comment { get => comment; set => comment = value; }

        public override string ToString()
        {
            return $"{title}, {password}, {url}, {comment}\n";
        }
    }
}
